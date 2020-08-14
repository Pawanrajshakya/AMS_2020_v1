using System.Data;
using DataAccessHelper;

namespace Persistence_Layer.ReportHelper
{
    public class ReportDataTable
    {
        string _connectionString;

        public ReportDataTable(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DataTable GetTable(string procedureName, params object[] parameterValues)
        {
            try
            {

                DataSet ds = DataAccessHelper.SqlHelper.ExecuteDataset(_connectionString, procedureName, parameterValues);

                if (ds != null && ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
            return null;
        }
    }
}