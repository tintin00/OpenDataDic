using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;

using OpenDataDic.Dac;
using System.EnterpriseServices;


namespace OpenDataDic.Biz
{
    [Transaction(TransactionOption.NotSupported)]
    [JustInTimeActivation(true)]
    public class BizCommonData_NTx : BizBase
    {
        public BizCommonData_NTx()
        {
        }

        public DataSet CommonData_Select(Hashtable ht)
        {
            
            DataSet ds = new DataSet();

            using (Dac.DacCommonData_NTx NTx = new Dac.DacCommonData_NTx())
            {
                ds = NTx.CommonData_Select(ht);
            }

            return ds;
        }
    }
}
