using System;
using System.Collections.Generic;
using Microsoft.Office.Interop.Excel;

namespace FuckingPricesApp
{
    class ExcelParser
    {
        private string _pathToFile;
        private List<Product> _products;
        public ExcelParser(string pathToExcelFile)
        {
            _pathToFile = pathToExcelFile;
            _products = new List<Product>();
        }
        public List<Product> Parse(int idColumn, int titleColumn, int priceColumn)
        {
            try
            {
                //  Открываем приложение
                var excelApp = new Application
                {
                    Visible = false
                };
                //  Открываем книгу
                var workBook = excelApp.Workbooks.Open(_pathToFile,
                                            Type.Missing, true, Type.Missing, Type.Missing,
                                            Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                            Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                            Type.Missing, Type.Missing);
                //  Открываем лист
                var workSheet = (Worksheet)workBook.Sheets[1];
                //  Получаем диапазон в виде столбца с номером idCol
                Range usedColumn = workSheet.UsedRange.Columns[idColumn];
                dynamic title;
                dynamic price;
                //  Проходим по этому столбцу
                for (int i = 0; i <= usedColumn.Cells.Count; i++)
                {   //  Проверка если в текущей ячейке есть артикул товара

                    if (int.TryParse(usedColumn.Cells[i].Value2, out int _))
                    {   //  Получаем номер строки этой ячейки
                        //  и в этой же строке из других столбцов получаем данные
                        // через try-catch потому, что выбрасывает исключение если ячейка пустая, нет бы null возвращать...
                        int row = usedColumn.Cells[i].Row;
                        try
                        {title = workSheet.Cells[row, titleColumn].Value2.ToString();}
                        catch
                        { continue; }
                        try
                        {price = workSheet.Cells[row, priceColumn].Value2.ToString()+ " ₽"; }
                        catch
                        { continue; }
                        //  Добавляем в список товар и определяем его свойства
                        _products.Add(new Product
                        {
                            Id = usedColumn.Cells[i].Value2.ToString(),
                            Title = title,
                            Price = price
                        });
                    }
                }

                //  Закрываем файл
                workBook.Close(false, Type.Missing, Type.Missing);
                excelApp.Quit();
            }
            catch(Exception) 
            {
                throw new Exception("Не удалось обработать файл, проверте целостность файла," +
                    "а также убедитесь, что на комптьютере установлен MS Excel.");
            }

            return _products;
        }
    }
}
