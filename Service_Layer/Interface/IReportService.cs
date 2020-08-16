using Persistence_Layer.ReportHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer.Interface
{
    public interface IReportService
    {
        /// <summary>
        /// Return Report Result
        /// </summary>
        /// <param name="reportPath">physical report file path and name</param>
        /// <param name="dataTable">datatable matched exactly with store procedure used in the report</param>
        /// <param name="format">pdf or excel</param>
        /// <param name="datasetName">This refers to the dataset name in the RDLC file</param>
        /// <returns></returns>
        // ReportResult Get(string reportPath, System.Data.DataTable dataTable, string format, string datasetName = "DataSet");

        ReportResult Get(string reportName, string reportPath, string format, string connectionString, string datasetName = "DataSet");
    }
}