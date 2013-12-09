using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using System.Runtime.Serialization.Json;
//using System.Web.Script.Serialization;

namespace EntLib.Core.Util
{
    public class JsonHelper : IDisposable
    {
        public JsonHelper()
        {
        }

        public void Dispose()
        {
        }

        #region 프로토타입 DataTable to Json
        /// <summary>
        /// 프로토타입 DataTable to Json
        /// 관련 링크 : http://stackoverflow.com/questions/355833/converting-a-dataset-to-json-using-net-3-5-in-c-sharp
        /// </summary>
        /// <param name="Dt"></param>
        /// <returns></returns>
        public static string GetJSONString_prototype(DataTable Dt)
        {

            string[] StrDc = new string[Dt.Columns.Count];
            string HeadStr = string.Empty;

            for (int i = 0; i < Dt.Columns.Count; i++)
            {

                StrDc[i] = Dt.Columns[i].Caption;

                HeadStr += "\"" + StrDc[i] + "\" : \"" + StrDc[i] + i.ToString() + "¾" + "\",";
            }

            HeadStr = HeadStr.Substring(0, HeadStr.Length - 1);

            StringBuilder Sb = new StringBuilder();
            Sb.Append("{\"" + Dt.TableName + "\" : [");

            for (int i = 0; i < Dt.Rows.Count; i++)
            {

                string TempStr = HeadStr;
                Sb.Append("{");

                for (int j = 0; j < Dt.Columns.Count; j++)
                {

                    TempStr = TempStr.Replace(Dt.Columns[j] + j.ToString() + "¾", Dt.Rows[i][j].ToString());
                }

                Sb.Append(TempStr + "},");
            }

            Sb = new StringBuilder(Sb.ToString().Substring(0, Sb.ToString().Length - 1));
            Sb.Append("]}");

            return Sb.ToString();
        } 
        #endregion

        #region GetJSONString(DataSet ds, string strIndexType)
        /// <summary>
        /// DataSet to Json Convert
        /// strIndexType : "nm" :: 테이블명으로, "idx" :: 인덱스 번호로

        /// Index 타입
        ///  {
        ///  "0" : [{"USERID" : "mkkim","USERNM" : "김민국"},{"USERID" : "mkkim2","USERNM" : "김민국2"}]
        ///  ,"1" : [{"USERID" : "test","USERNM" : "testName"},{"USERID" : "test2","USERNM" : "testName2"}]
        ///  }

        /// Name 타입
        ///  {
        ///  "Table" : [{"USERID" : "mkkim","USERNM" : "김민국"},{"USERID" : "mkkim2","USERNM" : "김민국2"}]
        ///  ,"Table1" : [{"USERID" : "test","USERNM" : "testName"},{"USERID" : "test2","USERNM" : "testName2"}]
        ///  }
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="strIndexType"></param>
        /// <returns></returns>
        public static string GetJSONString(DataSet ds, string strIndexType)
        {
            if (ds == null || ds.Tables.Count <= 0)
                return "[{}]";

            StringBuilder Sb = new StringBuilder();
            int idx = (int)0;

            Sb.Append("{");
            foreach (DataTable Dt in ds.Tables)
            {

                string[] StrDc = new string[Dt.Columns.Count];
                string HeadStr = string.Empty;

                for (int i = 0; i < Dt.Columns.Count; i++)
                {

                    StrDc[i] = Dt.Columns[i].Caption;

                    HeadStr += "\"" + StrDc[i].Trim() + "\" : \"" + StrDc[i].Trim() + i.ToString() + "¾" + "\",";
                }

                HeadStr = HeadStr.Substring(0, HeadStr.Length - 1);


                switch (strIndexType)
                {
                    case "nm":
                        Sb.Append("\"" + Dt.TableName + "\" : [");
                        break;
                    case "idx":
                    default:
                        Sb.Append("\"" + idx.ToString() + "\" : [");
                        break;
                }

                for (int i = 0; i < Dt.Rows.Count; i++)
                {

                    string TempStr = HeadStr;
                    Sb.Append("{");

                    for (int j = 0; j < Dt.Columns.Count; j++)
                    {

                        TempStr = TempStr.Replace(Dt.Columns[j] + j.ToString().Trim() + "¾", Dt.Rows[i][j].ToString().Trim());
                    }

                    Sb.Append(TempStr + "},");
                }

                Sb = new StringBuilder(Sb.ToString().Substring(0, Sb.ToString().Length - 1));
                Sb.Append("],");

                idx++;
            }
            Sb = new StringBuilder(Sb.ToString().Substring(0, Sb.ToString().Length - 1));
            Sb.Append("}");

            return Sb.ToString();

        } 
        #endregion

        #region GetJSONString(DataTable Dt)
        /// <summary>
        /// DataTable to Json Convert
        ///  [
        ///   {"USERID" : "mkkim","USERNM" : "김민국"}
        ///  ,{"USERID" : "mkkim2","USERNM" : "김민국2"}
        ///  ,{"USERID" : "test","USERNM" : "test"}
        ///  ]
        /// </summary>
        /// <param name="Dt"></param>
        /// <returns></returns>
        public static string GetJSONString(DataTable Dt)
        {
            if (Dt == null)
                return "[ {\"result\":\"ok\", \"cnt\":\"0\", \"msg\":\"조회된 데이터가 없습니다.\" }]";

            string[] StrDc = new string[Dt.Columns.Count];
            string HeadStr = string.Empty;

            for (int i = 0; i < Dt.Columns.Count; i++)
            {

                StrDc[i] = Dt.Columns[i].Caption;

                HeadStr += "\"" + StrDc[i].Trim() + "\" : \"" + StrDc[i].Trim() + i.ToString() + "¾" + "\",";
                //HeadStr += "" + StrDc[i].Trim() + " : \"" + StrDc[i].Trim() + i.ToString() + "¾" + "\",";
            }

            HeadStr = HeadStr.Substring(0, HeadStr.Length - 1);

            StringBuilder Sb = new StringBuilder();
            //Sb.Append("{\"" + Dt.TableName + "\" : [");
            Sb.Append("{");
            Sb.AppendFormat(" \"result\":\"ok\", \"cnt\":\"{0}\", \"msg\":\"조회된 데이터가 없습니다.\", ", Dt.Rows.Count.ToString());
            Sb.Append("\"list\" : [");
            

            for (int i = 0; i < Dt.Rows.Count; i++)
            {

                string TempStr = HeadStr;
                Sb.Append("{");

                for (int j = 0; j < Dt.Columns.Count; j++)
                {

                    TempStr = TempStr.Replace(Dt.Columns[j] + j.ToString().Trim() + "¾", Dt.Rows[i][j].ToString().Trim());
                }

                Sb.Append(TempStr + "},");
            }

            Sb = new StringBuilder(Sb.ToString().Substring(0, Sb.ToString().Length - 1));
            //Sb.Append("]}");
            Sb.Append("]");
            Sb.Append("}");

            return Sb.ToString();

        } 
        #endregion


        //public static string ToJSON(this object obj)
        //{
        //    JavaScriptSerializer serializer = new JavaScriptSerializer();
        //    return serializer.Serialize(obj);
        //}

        //public static string ToJSON(this object obj, int recursionDepth)
        //{
        //    JavaScriptSerializer serializer = new JavaScriptSerializer();
        //    serializer.RecursionLimit = recursionDepth;
        //    return serializer.Serialize(obj);
        //}
    }
}
