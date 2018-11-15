using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebUcu.Wiki.Operation.DataAccess
{
    public sealed class DataContext
    {
        private IConfiguration configuration;
        public PageRepository PageRepository { get; }
        private static DataContext current;
        public static DataContext Current
        {
            get
            {
                if (current == null)
                    throw new InvalidOperationException("DataContext is not configured properly.");
                return current;
            }
        }

        public static void Initialize(IConfiguration configuration)
        {
            if (current == null)
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                current = new DataContext(configuration);
            }
        }

        private DataContext(IConfiguration configuration)
        {
            this.configuration = configuration;
            PageRepository = new PageRepository(configuration);
        }
    }
}
