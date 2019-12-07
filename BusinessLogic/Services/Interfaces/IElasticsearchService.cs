﻿using BusinessLogic.Common.Models;
using DataAccess.Entities;
using Nest;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.Interfaces
{
    public interface IElasticsearchService
    {
        Task<SearchResponseView> TermSearchAsync(TermSearchFilter filter);
        Task<List<BulkResponseItemBase>> IndexData();
        Task<SearchResponseView> RangeSearchAsync(RangeSearchFilter filter);
    }
}
