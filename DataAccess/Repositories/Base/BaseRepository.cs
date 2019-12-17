using Dapper.Contrib.Extensions;
using DataAccess.Repositories.Interfaces.Base;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly IConfiguration _configuration;
        public BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected SqlConnection SqlConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            using (var connection = SqlConnection())
            {
                var items = await connection.GetAllAsync<T>();

                return items;
            }
        }

        public async Task<T> GetByIdAsync(long id)
        {
            using (var connection = SqlConnection())
            {
                var item = await connection.GetAsync<T>(id);

                return item;
            }
        }

        public async Task<T> CreateAsync(T item)
        {
            using (var connection = SqlConnection())
            {
                var items = 0;
                try
                {                   
                    items = await connection.InsertAsync<T>(item);
                }
                catch(Exception ex)
                {

                }
                return items != 0 ? item : null;
            }
        }

        public async Task<bool> UpdateAsync(T item)
        {
            using (var connection = SqlConnection())
            {
                var result = await connection.UpdateAsync<T>(item);

                return result;
            }
        }

        public async Task<bool> DeleteAsync(T item)
        {
            using (var connection = SqlConnection())
            {
                var result = await connection.DeleteAsync<T>(item);

                return result;
            }
        }
    }
}
