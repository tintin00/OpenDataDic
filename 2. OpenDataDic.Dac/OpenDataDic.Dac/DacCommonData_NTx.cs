using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Data;

using System.EnterpriseServices;




namespace OpenDataDic.Dac
{
    [Transaction(TransactionOption.Supported)]
    [JustInTimeActivation(true)]
    public class DacCommonData_NTx : DacBase
    {
        public DacCommonData_NTx()
        {
        }

        public DataSet CommonData_Select(Hashtable ht)
        {

            DataSet ds = new DataSet();


            return ds;
        }

    }
}
