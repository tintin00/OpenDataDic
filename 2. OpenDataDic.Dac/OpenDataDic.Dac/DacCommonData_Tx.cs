using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.EnterpriseServices;

namespace OpenDataDic.Dac
{

    [Transaction(TransactionOption.Supported)]
    [JustInTimeActivation(true)]
    public class DacCommonData_Tx : DacBase
    {
        public DacCommonData_Tx()
        {
        }

    }
}
