using System.Drawing;
using Excel = Microsoft.Office.Interop.Excel;
Excel.Application ex = new Microsoft.Office.Interop.Excel.Application();
ex.Visible = true; ex.SheetsInNewWorkbook = 1;
Excel.Workbook workBook = ex.Workbooks.Add(Type.Missing); ex.DisplayAlerts = false;
Excel.Worksheet sheet = (Excel.Worksheet)ex.Worksheets.get_Item(1); sheet.Name = "Chisla";
for (int i = 1; i <= 3; i++)
{
    for (int j = 1; j <= 3; j++)
    {
        int res = new Random().Next(1, 9); sheet.Cells[i, j] = string.Format("{0}", res);
    }
}