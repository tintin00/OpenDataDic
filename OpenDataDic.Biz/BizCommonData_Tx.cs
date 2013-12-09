using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.EnterpriseServices;

namespace OpenDataDic.Biz
{
    [Transaction(TransactionOption.Required)]
    [JustInTimeActivation(true)]
    public class BizCommonData_Tx : BizBase
    {
        public BizCommonData_Tx()
        {
        }

    }
}
