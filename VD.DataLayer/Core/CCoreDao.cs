using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Datalayer.DataObject.Base;
using Datalayer.DataObject.SQL;

namespace VD.Datalayer.DataObject
{
    public class CCoreDao:CDaoBase
    {
        public CCoreDao() : base()
        {
          
        }
        public CCoreDao(string server, string database, string user, string pass) : base(server, database, user, pass)
        {

        }
        public DataSet GetContextData( string inputValue)
        {
            return CallFunction(CStoreProcedure.GetContextData,  inputValue);
        }

        public DataSet ExecuteAction(string inputValue)
        {
            return CallFunction(CStoreProcedure.ExecuteAction, inputValue);
        }
        public DataSet GetContextData(string clientKey, string inputValue)
        {
            return CallFunction(CStoreProcedure.GetContextData,  inputValue);
        }

        public DataSet ExecuteAction(string clientKey, string inputValue)
        {
            return CallFunction(CStoreProcedure.ExecuteAction, inputValue);
        }


        //public DataSet Login(string clientKey, string inputValue)
        //{
        //    return CallFunction(CStoreProcedure.Login, clientKey, inputValue);
        //}
    }
}
