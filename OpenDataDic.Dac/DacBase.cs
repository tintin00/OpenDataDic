using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using IBatisNet.DataAccess.Interfaces;
using IBatisNet.DataMapper;
using IBatisNet.DataMapper.MappedStatements;
using IBatisNet.DataMapper.Scope;

namespace OpenDataDic.Dac
{
    public class DacBase : IDisposable, IDao
    {
        //public Database _db = null;
        
        public DacBase()
        {
            //_db = EnterpriseLibraryContainer.Current.GetInstance<Database>("testDB");
        }

        //public DacBase(string strConnectionDbName)
        //{
        //    _db = EnterpriseLibraryContainer.Current.GetInstance<Database>(strConnectionDbName);
        //}

        public void Dispose()
        {
            ;
        }

        public int ExecuteDelete(string statementName, object parameterObject)
        {
            int i = (int)0;


            return i;
        }
        public object ExecuteInsert(string statementName, object parameterObject)
        {
            object obj = null;

            return obj;
        }
        public int ExecuteNonQuery(string statementName, object parameterObject)
        {
            int i = (int)0;


            return i;
        }
        public DataSet ExecuteQueryForDataSet(string statementName, object parameterObject)
        {
            DataSet ds = null;
            ds = GetDataSet(statementName, parameterObject);
            return ds;
        }

        public DataTable ExecuteQueryForDataTable(string statementName, object parameterObject)
        {
            DataTable dt = null;
            dt = GetDataTable(statementName, parameterObject);
            return dt;
        }
        public int ExecuteUpdate(string statementName, object parameterObject)
        {
            int i = (int)0;


            return i;
        }

        // IList<> --> DataTable 형식으로 리턴함.
        protected DataTable GetDataTable(string statementName, object param)
        {

            ISqlMapper mapper = Mapper.Instance();
            if (!mapper.IsSessionStarted) mapper.OpenConnection();

            DataTable dataTable = new DataTable(statementName);

            ISqlMapSession session = mapper.LocalSession;

            IMappedStatement statement = mapper.GetMappedStatement(statementName);
            RequestScope request = statement.Statement.Sql.GetRequestScope(statement, param, session);
            statement.PreparedCommand.Create(request, session, statement.Statement, param);

            using (request.IDbCommand)
            {
                dataTable.Load(request.IDbCommand.ExecuteReader());
            }

            return dataTable;
        }

        // IList<> --> DataSet 형식으로 리턴함.
        protected DataSet GetDataSet(string statementName, object param)
        {
            ISqlMapper mapper = Mapper.Instance();
            if (!mapper.IsSessionStarted) mapper.OpenConnection();

            DataTable dataTable = new DataTable(statementName);

            ISqlMapSession session = mapper.LocalSession;

            IMappedStatement statement = mapper.GetMappedStatement(statementName);
            RequestScope request = statement.Statement.Sql.GetRequestScope(statement, param, session);
            statement.PreparedCommand.Create(request, session, statement.Statement, param);

            using (request.IDbCommand)
            {
                dataTable.Load(request.IDbCommand.ExecuteReader());
            }

            DataSet ds = new DataSet();
            ds.Tables.Add(dataTable);
            return ds;
        }

    }
}
