using BusinessLogic.Common.Views.Request;
using BusinessLogic.Common.Views.Response;
using BusinessLogic.Helpers;
using BusinessLogic.Services.Interfaces;
using DataAccess.Entities;
using Nest;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class MainScreenService : IMainScreenService
    {
        private readonly IElasticClient _elasticClient;

        public MainScreenService(IElasticClient elasticClient)
        {
            _elasticClient = elasticClient;
        }

        public async Task<ResponseGetFiltersMainScreenView> GetFiltersAsync(RequestGetFiltersMainScreenView request)
        {
            var str = request.CurrentFilter.ToString().FirstLetterToUpper();

            request.GetType().GetProperty(nameof(request.Filters)).PropertyType.GetProperty(str).SetValue(request.Filters, null);

            var searchResponse = await _elasticClient.SearchAsync<WebAppData>(s => s
                .Query(q => q
                    .SearchQuery(request.Filters))
                .Aggregations(a => a
                    .Terms(request.CurrentFilter.ToString(), c => c
                        .Field(request.CurrentFilter.ToString().GetFilterName())
                        .Size(request.Size)
                        .Order(o => o.KeyAscending())
                    )
                )
            );

            var response = new ResponseGetFiltersMainScreenView();

            response.Items = searchResponse.Aggregations.Terms(request.CurrentFilter.ToString()).Buckets.Select(s => s.Key).ToList();

            return response;
        }

        public async Task<ResponseSearchMainScreenView> SearchAsync(RequestSearchMainScreenView request)
        {
            var searchResponse = await _elasticClient.SearchAsync<WebAppData>(s => s
                .From(request.From)
                .Size(request.Count)
                .Query(q => q
                    .SearchQuery(request.Filters))
                .Aggregations(a => a.ValueCount("valueCount", v => v.Field(f => f.RecId)))
                );

            var webAppDatas = searchResponse.Documents.ToList();
            var count = searchResponse.Aggregations.ValueCount("valueCount").Value;

            var response = new ResponseSearchMainScreenView();
            response.Items = webAppDatas;
            response.ItemsCount = (int)count;

            return response;
        }
    }
}
