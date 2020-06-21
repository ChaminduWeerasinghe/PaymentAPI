using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using paymentAPI.Model;

namespace paymentAPI.Data
{
    public interface Ipayment
    {
        IEnumerable<payment> GetPayments();
        payment GetPayment(int id);

        string insertpPayment(payment pay);

        string deletePayment(int id);

        string updatePayment(payment pay);

    }
}
