using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using paymentAPI.Data;
using paymentAPI.Model;
using paymentAPI.Data;

namespace paymentAPI.Controllers
{
    [Route("service/payment")]
    [ApiController]
    public class paymentsController : ControllerBase
    {

        private readonly Ipayment _payment;
        public paymentsController(Ipayment payment)
        {
            this._payment = payment;
        }

        [HttpGet]
        [Route("payments")]
        public ActionResult<IEnumerable<payment>> GetAllPayments()
        {
            var data = _payment.GetPayments();

            return Ok(data);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<payment> getPayment(int id)
        {
            payment pay = _payment.GetPayment(id);

            return Ok(pay);
        }

        [HttpPost]
        [Route("insert")]
        public ActionResult insertPayment([FromBody]payment pay)
        {
           var result = _payment.insertpPayment(pay);
           return Ok(result);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public ActionResult deletePayment(int id)
        {
           var result = _payment.deletePayment(id);
           return Ok(result);
        }

        [HttpPut]
        [Route("update")]
        public ActionResult updatePayment([FromBody]payment pay)
        {
            var result = _payment.updatePayment(pay);
            return Ok(result);
        }

    }
}
