using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mkFx.Core
{
    public class UserInfo
    {
        private string _id = "";
        private string _name = "";

        public UserInfo(string id)
        {
            _id = id;

            // id를 통해서 이름을 DB에서 조회해온다.  
            _name = "달봉이";
        }

        public virtual string ID
        {
            get
            {
                return _id;
            }
        }
        public virtual string Name
        {
            get
            {
                return _name;
            }
        }
    } 
}
