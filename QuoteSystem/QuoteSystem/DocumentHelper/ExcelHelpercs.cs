using NPOI.SS.UserModel;
using System;
using System.Data;
using System.IO;
using System.Text;


namespace QuoteSystem.DocumentHelper
{
    public class ExcelHelper
    {
        public DataTable ReadExcelFile(string filename, params ExcelDataType[] ColumnDateTypes)
        {
            DataTable dt = new DataTable("dt");

            DataRow dr;

            StringBuilder sb = new StringBuilder();

            using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                IWorkbook workbook = WorkbookFactory.Create(fs);
                ISheet sheet = workbook.GetSheetAt(0);

                int j;
                IRow row;

                if (ColumnDateTypes.Length <= 0)
                {
                    row = sheet.GetRow(0);
                    ColumnDateTypes = new ExcelDataType[row.LastCellNum];

                    for (int i = 0; i < row.LastCellNum; i++)
                    {
                        ICell cell = row.GetCell(i);
                        ColumnDateTypes[i] = GetCellDataType(cell);
                    }
                }

                for (j = 0; j < ColumnDateTypes.Length; j++)
                {
                    Type tp = GetDataTableType(ColumnDateTypes[j]);
                    dt.Columns.Add("c" + j, tp);
                }

                for (int i = 0; i <= sheet.PhysicalNumberOfRows; i++)
                {
                    row = sheet.GetRow(i);

                    if (row == null)
                    {
                        continue;
                    }

                    try
                    {
                        dr = dt.NewRow();

                        for (j = 0; j < ColumnDateTypes.Length; j++)
                        {
                            dr["c" + j] = GetCellData(ColumnDateTypes[j], row, j);
                        }

                        dt.Rows.Add(dr);
                    }
                    catch (Exception er)
                    {
                        sb.Append(string.Format("Line {} error: {1}\r\n", i + 1, er.Message));
                        continue;
                    }
                }
            }

            return dt;
        }


        private object GetCellData(ExcelDataType datatype, IRow row, int column)
        {
            switch (datatype)
            {
                case ExcelDataType.String:
                    try
                    {
                        return row.GetCell(column).DateCellValue;
                    }
                    catch (Exception)
                    {
                        try
                        {
                            return row.GetCell(column).StringCellValue;
                        }
                        catch (Exception)
                        {
                            return row.GetCell(column).NumericCellValue;
                        }
                    }
                case ExcelDataType.Bool:
                    try
                    {
                        return row.GetCell(column).BooleanCellValue;
                    }
                    catch (Exception)
                    {

                        return row.GetCell(column).StringCellValue;
                    }

                case ExcelDataType.Datetime:
                    try
                    {
                        return row.GetCell(column).DateCellValue;
                    }
                    catch (Exception)
                    {

                        return row.GetCell(column).StringCellValue;
                    }

                case ExcelDataType.Numeric:
                    try
                    {
                        return row.GetCell(column).NumericCellValue;
                    }
                    catch (Exception)
                    {

                        return row.GetCell(column).StringCellValue;
                    }

                case ExcelDataType.RichText:
                    try
                    {
                        return row.GetCell(column).RichStringCellValue;
                    }
                    catch (Exception)
                    {

                        return row.GetCell(column).StringCellValue;
                    }

                case ExcelDataType.Error:
                    try
                    {
                        return row.GetCell(column).ErrorCellValue;
                    }
                    catch (Exception)
                    {

                        return row.GetCell(column).StringCellValue;
                    }

                case ExcelDataType.Blank:
                    try
                    {
                        return row.GetCell(column).StringCellValue;
                    }
                    catch (Exception)
                    {

                        return "";
                    }

                default:
                    return "";
            }

        }


        private Type GetDataTableType(ExcelDataType dataType)
        {
            Type tp = typeof(string);

            switch (dataType)
            {
                case ExcelDataType.Bool:
                    tp = typeof(bool);
                    break;
                case ExcelDataType.Datetime:
                    tp = typeof(DateTime);
                    break;
                case ExcelDataType.Numeric:
                    tp = typeof(double);
                    break;
                case ExcelDataType.Error:
                    tp = typeof(string);
                    break;
                case ExcelDataType.Blank:
                    tp = typeof(string);
                    break;
            }

            return tp;
        }


        private ExcelDataType GetCellDataType(ICell hs)
        {
            ExcelDataType dtype = ExcelDataType.Error;
            DateTime t1;
            string cellvalue = "";

            switch (hs.CellType)
            {
                case CellType.Blank:
                    dtype = ExcelDataType.String;
                    cellvalue = hs.StringCellValue;
                    break;
                case CellType.Boolean:
                    dtype = ExcelDataType.Bool;
                    break;
                case CellType.Numeric:
                    dtype = ExcelDataType.Numeric;
                    cellvalue = hs.NumericCellValue.ToString();
                    break;
                case CellType.String:
                    dtype = ExcelDataType.String;
                    cellvalue = hs.StringCellValue;
                    break;
                case CellType.Error:
                    dtype = ExcelDataType.Error;
                    break;
                case CellType.Formula:
                    dtype = ExcelDataType.Datetime;
                    break;
            }

            if (cellvalue != "" && DateTime.TryParse(cellvalue, out t1))
            {
                dtype = ExcelDataType.Datetime;
            }
            return dtype;
        }
    }

    public enum ExcelDataType
    {
        String,
        Bool,
        Datetime,
        Numeric,
        RichText,
        Blank,
        Error
    }
}