using BusinessLogic.Common.Views.Request;
using BusinessLogic.Common.Views.Response;
using BusinessLogic.Helpers;
using BusinessLogic.Options;
using BusinessLogic.Services.Interfaces;
using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;
using Microsoft.Extensions.Options;
using Nest;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class MainScreenService : IMainScreenService
    {
        private readonly IWebAppDataRepository _dataRepository;
        private readonly IElasticClient _elasticClient;
        private readonly ElasticOptions _elasticOptions;

        public MainScreenService(IWebAppDataRepository dataRepository, IElasticClient elasticClient, IOptions<ElasticOptions> elasticOptions)
        {
            _dataRepository = dataRepository;
            _elasticClient = elasticClient;
            _elasticOptions = elasticOptions.Value;
        }

        public async Task<ResponseFiltersMainScreenView> GetDropDownValues(RequestFiltersMainScreenView request)
        {
            var client = _elasticClient;

            var str = request.CurrentFilter.ToString().FirstLetterToUpper();

            request.GetType().GetProperty(nameof(request.Filters)).PropertyType.GetProperty(str).SetValue(request.Filters, null);

            var searchResponse = await client.SearchAsync<WebAppData>(s => s
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

            var result = searchResponse.Aggregations.Terms(request.CurrentFilter.ToString()).Buckets.Select(s => s.Key).ToList();

            var response = new ResponseFiltersMainScreenView();

            response.Items.AddRange(result);

            return response;
        }
        public async Task<ResponseSearchMainScreenView> SearchAsync(RequestSearchMainScreenView request)
        {
            var client = _elasticClient;         

            var searchResponse = await client.SearchAsync<WebAppData>(s => s
                .From(request.From)
                .Size(request.Count)
                .Query(q => q
                    .SearchQuery(request.Filters))
                .Aggregations(a=>a.ValueCount("valueCount", v=>v.Field(f=>f.RecId)))
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
