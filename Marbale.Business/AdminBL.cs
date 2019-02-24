using Marbale.BusinessObject;
using Marbale.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;

namespace Marble.Business
{
    public class AdminBL
    {
        private AdminData adminData;

        public AdminBL()
        {
            adminData = new AdminData();
        }

         public List<NameValue> GetAppModules(string module)
         {
             try
             {
                 var dataTable = adminData.GetAppModules(module);
                 List<NameValue> listAppModules = new List<NameValue>();
                 foreach (DataRow dr in dataTable.Rows)
                 {
                     NameValue nameValue = new NameValue();
                     nameValue.Name = dr.IsNull("Root") ? "" : dr["Root"].ToString();
                     nameValue.Value = dr.IsNull("Page") ? "" : dr["Page"].ToString();// current values

                     listAppModules.Add(nameValue);
                 }
                 return listAppModules;
             }
             catch (Exception e)
             {
                 throw e;
             }
         }
    }
}
