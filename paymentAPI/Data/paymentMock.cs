using paymentAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using paymentAPI.Connector;

namespace paymentAPI.Data
{
    public class paymentMock : Ipayment
    {
        private readonly IDBConnector _connector;

        public paymentMock(IDBConnector dBConnector)
        {
            _connector = dBConnector;
        }

       

        public payment GetPayment(int id)
        {
           using(_connector.connection)
            {
                string sql = @"select * from payment where paymentID = @id";
                return _connector.connection.Query<payment>(sql, new { id }).SingleOrDefault();
            }
        }

        public IEnumerable<payment> GetPayments()
        {
            var data = new List<payment>();
            using(_connector.connection)
            {
                string sql = @"select * from payment";
                data = _connector.connection.Query<payment>(sql).ToList();
            }
            return data;
        }

        public string insertpPayment(payment pay)
        {
            using (_connector.connection)
            {
                int rows = 0;
                string sql = "insert into payment values(@paymentID,@patientName,@ammount)";
                rows = _connector.connection.Execute(sql, pay);

                if (rows > 0)
                {
                    return "success";
                }
                else
                {
                    return "false";
                }

            }
        }


        public string deletePayment(int id)
        {
            int row = 0;
            using (_connector.connection)
            {
                string sql = @"delete from payment where paymentID = @id";
                row = _connector.connection.Execute(sql,new {id});

                if (row > 0)
                {
                    return "success";
                }
                else
                {
                    return "error";
                }
            }

        }

        public string updatePayment(payment pay)
        {
            int row = 0;
            using (_connector.connection)
            {
                string sql = "update payment set patientID = @patientID, ammount = @ammount where paymentID = @paymentID";
                row = _connector.connection.Execute(sql, pay);
            }

            if(row > 0)
            {
                return "success";
            }
            else
            {
                return "error";
            }

        }
    }
}
