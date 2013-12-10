using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using mkFx.Logging;
using OnSiteFx.Logging;

namespace OpenDataDic.Biz
{
    public class Biz01 : BizBase
    {
        private ILogger logger;

        public Biz01(ILogger logger)
        {
            this.logger = logger;

            // 비즈니스 객체가 생성될때 로그를 남긴다. 
            logger.Write("Biz01 생성자 호출");
        }
        public void Save()
        {
            logger.Write("Save() 호출");
        }
    } 
}
