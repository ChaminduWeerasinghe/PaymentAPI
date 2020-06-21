using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace paymentAPI.Connector
{
    public interface IDBConnector
    {
        IDbConnection connection { get; }
    }
}
