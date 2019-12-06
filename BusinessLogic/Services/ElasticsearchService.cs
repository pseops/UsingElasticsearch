﻿using BusinessLogic.Common.Models;
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

            var count = 10000;

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

        public async Task<IEnumerable<WebAppData>> GetPartsRecords()
        {
            return await _dataRepository.GetPartsRecords(50000, 10000);
        }

        private async Task<BulkResponse> ElasticIndexDataAsync(IEnumerable<WebAppData> data)
        {
            var client = _elasticClient;

            var response = await client.BulkAsync(x => x.IndexMany(data, (z, doc) => z.Document(doc).Index(_elasticOptions.Index)));
            return response;
        }

        public async Task<List<WebAppData>> ElasticSearch()
        {
            var client = _elasticClient;

            var searchResponse = await client.SearchAsync<WebAppData>(s => s
                .From(0)
                .Size(10)
                .Query(q => q
                    .Range(x => x
                        .Field(c => c.RecId)
                            .GreaterThanOrEquals(1)
                            .LessThanOrEquals(3)
                    )
                )
            );

            var webAppDatas = searchResponse.Documents.ToList();

            return webAppDatas;
        }

        public async Task<List<WebAppData>> ElasticSearchTerm()
        {
            var client = _elasticClient;

            var searchResponse = await client.SearchAsync<WebAppData>(s => s
                .From(0)
                .Size(10)
                .Query(q => q
                    .Term(t => t.RecId, 1) || q
                    .Term(r => r.RecId, 3)
                )
            );

            var webAppDatas = searchResponse.Documents.ToList();

            return webAppDatas;
        }
    }
}
