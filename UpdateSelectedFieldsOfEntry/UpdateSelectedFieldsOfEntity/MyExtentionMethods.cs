using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace UpdateSelectedFieldsOfEntity
{
    public static class MyExtentionMethods
    {
 


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
