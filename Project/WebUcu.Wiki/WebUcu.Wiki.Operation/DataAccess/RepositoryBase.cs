using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Dapper;

namespace WebUcu.Wiki.Operation.DataAccess
{
    public abstract class RepositoryBase
    {
        public IConfiguration Configuration { get; set; }

        public RepositoryBase(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected SqlConnection GetNewConnection()
        {
            return new SqlConnection(Configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
