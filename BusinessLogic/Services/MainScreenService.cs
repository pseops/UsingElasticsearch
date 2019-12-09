using BusinessLogic.Common.Models;
using BusinessLogic.Common.Models.Request;
using BusinessLogic.Common.Models.Response;
using BusinessLogic.Helpers;
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

        public async Task<ResponseDropDownValues> GetDropDownValues(RequestDropDownValues request)
        {
            var client = _elasticClient;

            var searchResponse = await client.SearchAsync<WebAppData>(s => s
                .Query(q => q
                    .Bool(b => b
                        .Must(m => m
                            .Terms(t => t.Field(nameof(request.HolidayYear).GetFilterName()).Terms(request.HolidayYear)
                            ), m => m
                            .Terms(t => t.Field(nameof(request.RegionName).GetFilterName()).Terms(request.RegionName)
                            ), m => m
                            .Term(t => t.Field(nameof(request.ResponsibleRevenueManager).GetFilterName()).Value(request.ResponsibleRevenueManager)
                            ), m => m
                            .Terms(t => t.Field(nameof(request.WeekNumber).GetFilterName()).Terms(request.WeekNumber)
                            ), m => m
                            .Terms(t => t.Field(nameof(request.ParkName).GetFilterName()).Terms(request.ParkName)
                            ), m => m
                            .Terms(t => t.Field(nameof(request.AccommTypeName).GetFilterName()).Terms(request.AccommTypeName)
                            ), m => m
                            .Terms(t => t.Field(nameof(request.AccommBeds).GetFilterName()).Terms(request.AccommBeds)
                            ), m => m
                            .Terms(t => t.Field(nameof(request.AccommName).GetFilterName()).Terms(request.AccommName)
                            ), m => m
                            .Terms(t => t.Field(nameof(request.UnitGradeName).GetFilterName()).Terms(request.UnitGradeName)
                            ), m => m
                            .Terms(t => t.Field(nameof(request.KeyPeriodName).GetFilterName()).Terms(request.KeyPeriodName)
                            )
                        )
                    )
                )
                .Aggregations(a => a
                    .Terms(request.CurrentFilter, c => c
                        .Field(request.CurrentFilter.GetFilterName())
                        .Size(request.Size)
                        .Order(o => o.KeyAscending())
                    )
                )
            );

            var result = searchResponse.Aggregations.Terms(request.CurrentFilter).Buckets.Select(s => s.Key).ToList();

            var response = new ResponseDropDownValues();

            response.Items.AddRange(result);

            return response;
        }
    }
}
