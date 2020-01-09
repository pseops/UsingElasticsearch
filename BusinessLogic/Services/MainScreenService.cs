using AutoMapper;
using BusinessLogic.Helpers;
using BusinessLogic.Services.Interfaces;
using Common.Views.MainScreen.Request;
using Common.Views.MainScreen.Response;
using DataAccess.Entities;
using Nest;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class MainScreenService : IMainScreenService
    {
        private readonly IElasticClient _elasticClient;
        private readonly IMapper _mapper;

        public MainScreenService(IElasticClient elasticClient, IMapper mapper)
        {
            _elasticClient = elasticClient;
            _mapper = mapper;
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
            response.Items = _mapper.Map<List<WebAppData>, List<ResponseSearchMainScreenViewItem>>(webAppDatas);
            response.ItemsCount = (int)count;

            return response;
        }
    }
}
