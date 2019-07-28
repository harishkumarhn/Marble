using Marbale.BusinessObject;
using Marbale.BusinessObject.POSTransaction;
using Marbale.BusinessObject.Tax;
using Marbale.DataAccess;
using Marbale.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marbale.BusinessObject.Customer;

namespace Marble.Business
{
    public class TransactionBL
    {
        private TransactionData trxData;

        public TransactionBL()
        {
            trxData = new TransactionData();
        }

        public int SaveTransaction(Transaction trx)
        {
            return trxData.SaveTransaction(trx);
        }

        public Customers GetCustomer(int customerId, string phoneNumber)
        {
            DataTable dt = trxData.GetCustomer(customerId, phoneNumber);

            Customers customer = new Customers();

            if (dt != null && dt.Rows.Count > 0)
            {
                customer.customer_id = dt.Rows[0]["CustomerId"] == DBNull.Value ? 0 : Convert.ToInt32(dt.Rows[0]["CustomerId"]);
                customer.first_name = dt.Rows[0]["CustomerName"] == DBNull.Value ? string.Empty: dt.Rows[0]["CustomerName"].ToString();
                customer.last_name = dt.Rows[0]["LastName"] == DBNull.Value ? string.Empty : dt.Rows[0]["LastName"].ToString();
                customer.contact_phone1 = dt.Rows[0]["ContactPhone1"] == DBNull.Value ? string.Empty : dt.Rows[0]["ContactPhone1"].ToString();
                customer.address1 = dt.Rows[0]["Address1"] == DBNull.Value ? string.Empty : dt.Rows[0]["Address1"].ToString();
                customer.city = dt.Rows[0]["City"] == DBNull.Value ? string.Empty : dt.Rows[0]["City"].ToString();
                customer.state = dt.Rows[0]["State"] == DBNull.Value ? string.Empty : dt.Rows[0]["State"].ToString();
                customer.country = dt.Rows[0]["Country"] == DBNull.Value ? string.Empty : dt.Rows[0]["Country"].ToString();

                customer.gender = dt.Rows[0]["Gender"] == DBNull.Value ? 'N' : Convert.ToChar(dt.Rows[0]["Gender"]);

                customer.birth_date = dt.Rows[0]["DateOfBirth"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dt.Rows[0]["DateOfBirth"]);
            }

            return customer;
        }
    }
}
