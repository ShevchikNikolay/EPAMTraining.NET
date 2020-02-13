using ClosedXML.Excel;
using System.Collections.Generic;
using System.Data;

namespace Serializer
{
    /// <summary>
    /// Generic class, that provide serialization in xlsx format.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class XlsxSerializer<T> where T :IList<T>
    {
        /// <summary>
        /// Method to serialize any list to xls(xlsx) format.
        /// </summary>
        /// <param name="report">Argument represents any List.</param>
        /// <param name="outputFileName">Argument represents name of output file.</param>
        public void Serialize(T report, string outputFileName)
        {
            using (var workbook = new XLWorkbook())
            {
                workbook.Worksheets.Add(GetDataTable(report));
                workbook.SaveAs(outputFileName);
            }
        }

        private DataTable GetDataTable(T report)
        {
            DataTable table = new DataTable
            {
                TableName = report.GetType().Name
            };
            foreach (var item in report[0].GetType().GetProperties())
            {
                table.Columns.Add(item.Name, item.PropertyType);
            }

            foreach (var item in report)
            {
                var arguments = new List<object>();
                var properties = item.GetType().GetProperties();
                foreach (var property in properties)
                {
                    arguments.Add(property.GetValue(item));
                }
                table.Rows.Add(arguments);
            }
            return table;
        }
    }
}
