using ChangeManagementSystem.EntityClasses;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace ChangeManagementSystem.ControlClasses
{
    public class DatabaseHandler
    {
        Database db;
        private DbCommand command;
        public string ConnectionString = "PegasusInHouseConString";

        public DatabaseHandler()
        {
            try
            {
                db = DatabaseFactory.CreateDatabase(ConnectionString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        internal DataSet ExecuteDataSet(string storedProcedureName,params string[] Parameters)
        {
            try
            {
                command = db.GetStoredProcCommand(storedProcedureName,
                                                           Parameters
                                                          );
                DataSet ds = db.ExecuteDataSet(command);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal int ExecuteNonQuery(string storedProcedureName,params object[] Parameters)
        {
            try
            {
                command = db.GetStoredProcCommand(storedProcedureName,
                                                           Parameters
                                                          );
                int rows = db.ExecuteNonQuery(command);
                return rows;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
