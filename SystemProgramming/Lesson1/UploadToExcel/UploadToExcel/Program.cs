using Excel = Microsoft.Office.Interop.Excel;

//Объявляем приложение
Excel.Application ex = new Excel.Application();

//Отобразить Excel
ex.Visible = true;

//Количество листов в рабочей книге
ex.SheetsInNewWorkbook = 2;

//Добавить рабочую книгу
Excel.Workbook workBook = ex.Workbooks.Add(Type.Missing);

//Отключить отображение окон с сообщениями
ex.DisplayAlerts = false;

//Получаем первый лист документа (счет начинается с 1)
Excel.Worksheet sheet = (Excel.Worksheet)ex.Worksheets.get_Item(1);

//Название листа (вкладки снизу)
sheet.Name = "My data";

//Пример заполнения ячеек
for (int i = 1; i <= 9; i++)
    for (int j = 1; j < 9; j++)
        sheet.Cells[i, j] = string.Format("Boom {0} {1}", i, j);

Console.WriteLine("Data uploaded");
