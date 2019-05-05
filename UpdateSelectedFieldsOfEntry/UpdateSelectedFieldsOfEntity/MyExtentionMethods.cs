using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace UpdateSelectedFieldsOfEntity
{
    public static class MyExtentionMethods
    {
        public static void UpdateSelectedFields<K, T>(this K dbContex, T Entity, List<string> list)
            where K : DbContext
        {
            dbContex.Attach(Entity);
            foreach (string item in list)
            {
                dbContex.Entry(Entity).Property(item).IsModified = true;
            }
        }


        public static void UpdateSelectedFields< T>(this DbContext  dbContex, T Entity, List<string> list)
        {
            dbContex.Attach(Entity);
            foreach (string item in list)
            {
                dbContex.Entry(Entity).Property(item).IsModified = true;
            }
        }





    }
}
