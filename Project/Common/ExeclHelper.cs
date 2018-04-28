using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Common
{
   public  class ExeclHelper
    {
        /// <summary>
        /// Excel导入(.xls)
        /// </summary>
        /// <returns></returns>
        public static DataTable XlsExcel(HttpPostedFileBase fostFile)
        {
            try
            {
                Stream streamfile = fostFile.InputStream;
                HSSFWorkbook hssfworkbook = new HSSFWorkbook(streamfile);
                ISheet sheet = hssfworkbook.GetSheetAt(0);
                DataTable table = new DataTable();
                IRow headerRow = sheet.GetRow(0);//第一行为标题行
                int cellCount = headerRow.LastCellNum;
                int rowCount = sheet.LastRowNum;
                for (int i = headerRow.FirstCellNum; i < cellCount; i++)
                {
                    DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
                    table.Columns.Add(column);
                }
                for (int i = (sheet.FirstRowNum + 1); i <= rowCount; i++)
                {
                    IRow row = sheet.GetRow(i);
                    DataRow dataRow = table.NewRow();
                    if (row != null)
                    {
                        for (int j = row.FirstCellNum; j < cellCount; j++)
                        {
                            if (row.GetCell(j) != null)
                                dataRow[j] = GetCellValue(row.GetCell(j));
                        }
                    }
                    table.Rows.Add(dataRow);
                }
                return table;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Excel导入(..xlsx)
        /// </summary>
        /// <returns></returns>
        public static DataTable XlsxExcel(HttpPostedFileBase fostFile)
        {
            try
            {
                Stream streamfile = fostFile.InputStream;
                XSSFWorkbook hssfworkbook = new XSSFWorkbook(streamfile); // 创建一个Excel文件    
                ISheet sheet = hssfworkbook.GetSheetAt(0);
                DataTable table = new DataTable();
                IRow headerRow = sheet.GetRow(0);//第一行为标题行
                int cellCount = headerRow.LastCellNum;
                int rowCount = sheet.LastRowNum;
                for (int i = headerRow.FirstCellNum; i < cellCount; i++)
                {
                    DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
                    table.Columns.Add(column);
                }
                for (int i = (sheet.FirstRowNum + 1); i <= rowCount; i++)
                {
                    IRow row = sheet.GetRow(i);
                    DataRow dataRow = table.NewRow();
                    if (row != null)
                    {
                        for (int j = row.FirstCellNum; j < cellCount; j++)
                        {
                            if (row.GetCell(j) != null)
                                dataRow[j] = GetCellValue(row.GetCell(j));
                        }
                    }
                    table.Rows.Add(dataRow);
                }
                return table;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// 根据Excel列类型获取列的值
        /// </summary>
        /// <param name="cell">Excel列</param>
        /// <returns></returns>
        private static string GetCellValue(ICell cell)
        {
            if (cell == null)
                return string.Empty;
            switch (cell.CellType)
            {
                case CellType.Blank:
                    return string.Empty;
                case CellType.Boolean:
                    return cell.BooleanCellValue.ToString();
                case CellType.Error:
                    return cell.ErrorCellValue.ToString();
                case CellType.Unknown:
                default:
                case CellType.Numeric:
                    return cell.ToString();
                case CellType.String:
                    return cell.StringCellValue;
                case CellType.Formula:
                    try
                    {
                        HSSFFormulaEvaluator e = new HSSFFormulaEvaluator(cell.Sheet.Workbook);
                        e.EvaluateInCell(cell);
                        return cell.ToString();
                    }
                    catch
                    {
                        return cell.NumericCellValue.ToString();
                    }
            }
        }



    }
}
