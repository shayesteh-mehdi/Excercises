using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RemoveAll
{
    public static class MyExtensionMethods
    {
        static public void RemoveAll<T>(this DbContext dbContex)
        {
            var mapping = dbContex.Model.FindEntityType(typeof(T)).Relational();
            var schema = mapping.Schema ?? "dbo";
            var tableName = mapping.TableName;

            int count_ReferencingForeignKeys = dbContex.Model.FindEntityType(typeof(T)).GetReferencingForeignKeys().ToList().Count;
            string query = count_ReferencingForeignKeys==0 ? $"  TRUNCATE TABLE  [{schema}].[{tableName}]" : $"Delete from [{schema}].[{tableName}]";
            dbContex.Database.ExecuteSqlCommand(query);
        }



    }
}
