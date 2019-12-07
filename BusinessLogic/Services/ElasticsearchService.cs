using BusinessLogic.Common.Models;
using BusinessLogic.Services.Interfaces;
using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;
using Microsoft.Extensions.Options;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class ElasticsearchService : IElasticsearchService
    {
        private readonly IWebAppDataRepository _dataRepository;
        private readonly IElasticClient _elasticClient;
        private readonly ElasticOptions _elasticOptions;

        public ElasticsearchService(IWebAppDataRepository dataRepository, IElasticClient elasticClient, IOptions<ElasticOptions> elasticOptions)
        {
            _dataRepository = dataRepository;
            _elasticClient = elasticClient;
            _elasticOptions = elasticOptions.Value;
        }

        public async Task<List<BulkResponseItemBase>> IndexData()
        {
            var deleteResponse = await DeleteIndexAsync();

            var count = 5000;

            var result = new List<BulkResponseItemBase>();

            for (int i = 0; ; i+=count)
            {
                var data = await _dataRepository.GetPartsRecords(i, count);

                var response = await ElasticIndexDataAsync(data);

                if (!response.IsValid)
                {
                    throw new Exception();
                }

                result.AddRange(response.ItemsWithErrors);

                response = new BulkResponse();

                GC.Collect();

                if (data.Count() < count)
                {
                    break;
                }
            }

            return result;
        }

        private async Task<DeleteIndexResponse> DeleteIndexAsync()
        {
            var response = await _elasticClient.Indices.DeleteAsync(_elasticOptions.Index);
            //var response = await _elasticClient.DeleteByQueryAsync<WebAppData>(x => x.Query(q => q.QueryString(s => s.Query("*"))));
            return response;
        }


        private async Task<BulkResponse> ElasticIndexDataAsync(IEnumerable<WebAppData> data)
        {
            if (!data.Any())
            {
                return null;
            }

            var client = _elasticClient;

            var response = await client.BulkAsync(x => x.IndexMany(data, (z, doc) => z.Document(doc).Index(_elasticOptions.Index)));

            return response;
        }

        public async Task<SearchResponseView> RangeSearchAsync(RangeSearchFilter filter)
        {
            var client = _elasticClient;

            var count = await client.CountAsync<WebAppData>(s => s
                .Query(q => q
                    .Range(x => x
                        .Field(filter.ColumnName)
                            .GreaterThanOrEquals(filter.MinValue)
                            .LessThanOrEquals(filter.MaxValue)
                    )
                ));

            var searchResponse = await client.SearchAsync<WebAppData>(s => s
                .From(filter.From)
                .Size(filter.Count)
                .Query(q => q
                    .Range(x => x
                        .Field(filter.ColumnName)
                            .GreaterThanOrEquals(filter.MinValue)
                            .LessThanOrEquals(filter.MaxValue)
                    )
                ).
            );

            var webAppDatas = searchResponse.Documents.ToList();

            var response = new SearchResponseView();
            response.Items = webAppDatas;
            response.ItemsCount = count.Count;

            return response;
        }

        public async Task<SearchResponseView> TermSearchAsync(TermSearchFilter filter)
        {
            var client = _elasticClient;

            var count = await client.CountAsync<WebAppData>(s => s
               .Query(q => q.Terms(t => t.Field(filter.ColumnName).Terms(filter.Values))));

            var searchResponse = await client.SearchAsync<WebAppData>(s => s
                .From(filter.From)
                .Size(filter.Count)
                .Query(q => q.Terms(t=>t.Field(filter.ColumnName).Terms(filter.Values))
                )
            );

            var webAppDatas = searchResponse.Documents.ToList();

            var response = new SearchResponseView();
            response.Items = webAppDatas;
            response.ItemsCount = count.Count;

            return response;
        }
    }
}
