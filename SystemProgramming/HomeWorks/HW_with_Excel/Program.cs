using Aspose.Cells.Utility;
using Excel = Microsoft.Office.Interop.Excel;

string jsonInput = File.ReadAllText("D:/shag/SystemProgramming/HomeWorks/HW_with_Excel/airports.json{");

//Объявляем приложение
Excel.Application ex = new Excel.Application();

//Отобразить Excel
ex.Visible = true;

//Количество листов в рабочей книге
ex.SheetsInNewWorkbook = 1;

//Добавить рабочую книгу
Excel.Workbook workBook = ex.Workbooks.Add(Type.Missing);

//Отключить отображение окон с сообщениями
ex.DisplayAlerts = false;

//Получаем первый лист документа (счет начинается с 1)
Excel.Worksheet sheet = (Excel.Worksheet)ex.Worksheets.get_Item(1);

//Название листа (вкладки снизу)
sheet.Name = "Airports";

JsonLayoutOptions options = new JsonLayoutOptions();
options.ArrayAsTable = true;

//Пример заполнения ячеек
for (int i = 1; i < 6; i++)
{
    sheet.Cells[i].Value = jsonInput;
}


Console.WriteLine("Data uploaded");



