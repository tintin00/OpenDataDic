using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using mkFx.Core;

namespace OnSiteFx.Core
{
    public class SiteUserInfo : UserInfo
    {
        // 부서코드 
        string _deptCode = "";

        public SiteUserInfo(string id)
            : base(id)
        {
            // id를 통해서 부서코드를 DB에서 조회홰온다. 
            _deptCode = "HR";
        }
        public string DeptCode
        {
            get
            {
                return _deptCode;
            }
            set
            {
                _deptCode = value;
            }
        }
    } 
}
