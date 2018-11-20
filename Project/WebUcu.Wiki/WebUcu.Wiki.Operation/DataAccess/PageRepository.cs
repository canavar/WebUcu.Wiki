using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Dapper;
using Microsoft.Extensions.Configuration;
using WebUcu.Wiki.Operation.Entities;

namespace WebUcu.Wiki.Operation.DataAccess
{
    public class PageRepository : RepositoryBase, IRepository<Page>
    {
        #region Sqls

        private readonly string insertScript = @"INSERT INTO WIKI.PAGE 
                                                    (TITLE, CREATED_BY, CREATE_DATE, IS_LOCKED, MODIFIED_BY, MODIFY_DATE, CONTENT, VERSION_NUMBER, TAGS) 
                                                VALUES (@Title, @CreatedBy, @CreateDate, @IsLocked, @ModifiedBy, @ModifyDate, @Content, @VersionNumber, @Tags);";

        private readonly string updateScript = @"UPDATE WIKI.PAGE 
                                                    SET 
                                                        TITLE = @Title, 
                                                        IS_LOCKED = @IsLocked, 
                                                        MODIFIED_BY = @ModifiedBy, 
                                                        MODIFY_DATE = @ModifyDate, 
                                                        CONTENT = @Content, 
                                                        VERSION_NUMBER = @VersionNumber,
                                                        TAGS = @Tags
                                                WHERE ID = @Id";

        private readonly string deleteScript = @"DELETE FROM WIKI.PAGE WHERE ID = @Id";

        private readonly string selectLastTopRecordsScript = @"SELECT TOP 10 * FROM WIKI.PAGE WITH (NOLOCK) ORDER BY MODIFY_DATE DESC;";
        private readonly string selectByIdScript = @"SELECT * FROM WIKI.PAGE WITH (NOLOCK) WHERE ID = @Id;";
        private readonly string selectByTagScript = @"SELECT * FROM WIKI.PAGE WITH (NOLOCK) WHERE TAGS LIKE @TagExpression ORDER BY MODIFY_DATE DESC;";
        private readonly string selectByContentScript = @"SELECT TOP 10 * FROM WIKI.PAGE WITH (NOLOCK) WHERE CONTENT LIKE @SearchExpression ORDER BY MODIFY_DATE DESC;";

        #endregion

        public PageRepository(IConfiguration configuration) : base(configuration)
        {
            Configuration = configuration;
        }

        public void Add(Page entity)
        {
            using (var connection = GetNewConnection())
            {
                var affectedRows = connection.Execute(insertScript, entity);
            }
        }

        public void Delete(Page entity)
        {
            using (var connection = GetNewConnection())
            {
                var affectedRows = connection.Execute(deleteScript, entity);
            }
        }

        public void Edit(Page entity)
        {
            using (var connection = GetNewConnection())
            {
                var affectedRows = connection.Execute(updateScript, entity);
            }
        }

        public IEnumerable<Page> SelectAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Page> SelectLastWikies()
        {
            IEnumerable<Page> pages = new List<Page>();
            using (var connection = GetNewConnection())
            {
                pages = connection.Query<Page>(selectLastTopRecordsScript);
            }
            return pages;
        }

        public Page SelectById(long id)
        {
            Page page = new Page();
            using (var connection = GetNewConnection())
            {
                page = connection.QuerySingle<Page>(selectByIdScript, new { Id = id });
            }
            return page;
        }

        public IEnumerable<Page> SelectByTag(string tag)
        {
            string tagExpression = string.Format("%{0}%", tag);
            IEnumerable<Page> pages = new List<Page>();
            using (var connection = GetNewConnection())
            {
                pages = connection.Query<Page>(selectByTagScript, new { TagExpression = tagExpression });
            }
            return pages;
        }

        public IEnumerable<Page> SelectBySearchPhrase(string searchPhrase)
        {
            string searchExpression = string.Format("%{0}%", searchPhrase);
            IEnumerable<Page> pages = new List<Page>();
            using (var connection = GetNewConnection())
            {
                pages = connection.Query<Page>(selectByContentScript, new { SearchExpression = searchExpression });
            }
            return pages;
        }
    }
}
