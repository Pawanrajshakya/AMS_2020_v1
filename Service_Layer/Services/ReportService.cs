using AutoMapper;
using Microsoft.Reporting.WebForms;
using Persistence_Layer.Interfaces;
using Persistence_Layer.ReportHelper;
using Service_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer.Services
{
    public class ReportService : IReportService
    {
        public ReportResult Get(string reportName, string reportPath, string format, string connectionString, string datasetName = "DataSet1")
        {
            try
            {
                var reportDataTable = new ReportDataTable(connectionString);

                var dataTable = reportDataTable.GetTable("sp_" + reportName);

                string mimeType;
                string encoding;
                string extension;
                string[] streams;
                Warning[] warnings;

                ReportDataSource rds = new ReportDataSource
                {
                    Name = datasetName,
                    Value = dataTable
                };

                //var currentDir = System.IO.Directory.GetCurrentDirectory().ToString();

                //LocalReport localReport = new LocalReport { ReportPath = @"" + currentDir +"\\" + reportPath };
                LocalReport localReport = new LocalReport { ReportPath = @"" + reportPath };
                localReport.DataSources.Clear();
                localReport.DataSources.Add(rds);

                byte[] bytes = localReport.Render(
                    format,
                    null,
                    out mimeType,
                    out encoding,
                    out extension,
                    out streams,
                    out warnings);

                return new ReportResult
                {
                    Content = bytes,
                    Extension = extension,
                    MediaType = mimeType
                };
            }
            catch (Exception e)
            {
                throw e;
            }
            

        }

        /// <summary>
        /// Return Report Result
        /// </summary>
        /// <param name="reportPath">physical report file path and name</param>
        /// <param name="dataTable">datatable matched exactly with store procedure used in the report</param>
        /// <param name="format">pdf or excel</param>
        /// <param name="datasetName">This refers to the dataset name in the RDLC file</param>
        /// <returns></returns>
        //public ReportResult Get(string reportPath, System.Data.DataTable dataTable, string format, string datasetName = "DataSet")
        //{
        //    try
        //    {
        //        string mimeType;
        //        string encoding;
        //        string extension;
        //        string[] streams;
        //        Warning[] warnings;

        //        ReportDataSource rds = new ReportDataSource
        //        {
        //            Name = datasetName,
        //            Value = dataTable
        //        };

        //        LocalReport localReport = new LocalReport { ReportPath = @"" + reportPath };
        //        localReport.DataSources.Clear();
        //        localReport.DataSources.Add(rds);

        //        byte[] bytes = localReport.Render(
        //            format,
        //            null,
        //            out mimeType,
        //            out encoding,
        //            out extension,
        //            out streams,
        //            out warnings);

        //        return new ReportResult
        //        {
        //            Content = bytes,
        //            Extension = extension,
        //            MediaType = mimeType
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public ReportResult Get(string ReportName, string format, string ConnectionString)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
