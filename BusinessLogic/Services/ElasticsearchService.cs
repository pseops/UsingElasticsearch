using BusinessLogic.Options;
using BusinessLogic.Services.Interfaces;
using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;
using Microsoft.Extensions.Options;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
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

            var count = 1000;

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
    }
}
