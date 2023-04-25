using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System.Threading.Tasks;
using System.Linq;

namespace FuckingPricesApp
{
    public partial class Form1 : Form
    {
        static string pathToExcelFile;
        static string[] pathToGroupExcelFiles;
        static string pathToImageFolder;
        static string pathToGroupSaveFolder;
        static string pathToDescriptionFolder = String.Empty;
        static List<Product> listOfProduct;
        static PdfDocument pdfDocument;
        static DescriptionParser descriptionParser;
        static string tempPath = Path.GetTempPath() + @"Images/";//@"~Temp\";
        static bool IsGroupProces = false;
        static int idColumn;
        static int titleColumn;
        static int priceColumn;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        
        private void Form1_DragEnter(object sender, DragEventArgs e)
        {   //  Проверяем что элемент перетаскиваемый
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                e.Effect = DragDropEffects.All;
            }
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {   //  Обработка перенесенных в область окна файлов
            string[] dropFiles = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (var file in dropFiles)
            {   //  Если хоть один из них не .xls
                if (!Path.GetExtension(file).Equals(".xls"))
                {
                    MessageBox.Show("Не все из перенесенных файлов имеют формат .xls\n" +
                        "Попробуйте еще раз!", "Warning!");
                    return;
                }
            }
            
            //  Если файлов больше одного
            if (dropFiles.Length > 1)
            {
                pathToGroupExcelFiles = dropFiles;
                ChoseGroupLabel.Text = $"Файлов: {pathToGroupExcelFiles.Length}";
                PacketCheckBox.Checked = true;
                SaveGroupBotton.Enabled = true;
                ChoseImagesFolderButton_1.Enabled = false;
                ChoseDiscriptionButton.Enabled = false;
            }
            else
            {
                pathToExcelFile = dropFiles[0];
                ChoseLabel_1.Text = $"Выбран файл: {pathToExcelFile}";
                ChoseImagesFolderButton_1.Enabled = true;
                ChoseDiscriptionButton.Enabled = true;
            }
        }
        /// <summary>
        /// Обработчики кнопок и чек-боксов
        /// </summary>
        private void ChoseButton_1_Click(object sender, EventArgs e)
        {
            var choseExcelDialog = new OpenFileDialog()
            {
                Filter = "Excel|*.xls;*.xlsx"
            };
            if (choseExcelDialog.ShowDialog() == DialogResult.OK)
            {   //  Указываем путь к файлу в лейбле, и включаем кнопку выбора файлов
                ChoseLabel_1.Text = $"Выбран файл: {choseExcelDialog.FileName}";
                ChoseImagesFolderButton_1.Enabled = true;
                ChoseDiscriptionButton.Enabled = true;
                pathToExcelFile = choseExcelDialog.FileName;
            }
        }
        private void ChoseImagesFolder_1_Click(object sender, EventArgs e)
        {
            var choseImageFolderDialog = new FolderBrowserDialog();
            if(choseImageFolderDialog.ShowDialog()==DialogResult.OK)
            {   //  Указываем путь к папке, и включаем кнопку генерации
                ChoseFolderImagesLabel_1.Text = "✓";
                GenerateButton_1.Enabled = true;
                ColumnCheckBox.Visible = true;
                IdTextBox.Visible = true;
                TitleTextBox.Visible = true;
                PriceTextBox.Visible = true;
                AddCheckBox.Visible = true;
                pathToImageFolder = choseImageFolderDialog.SelectedPath;
            }
        }
        private void ChoseDiscriptionButton_Click(object sender, EventArgs e)
        {
            var choseDiscriptionFolderDialog = new FolderBrowserDialog();
            if (choseDiscriptionFolderDialog.ShowDialog() == DialogResult.OK)
            {   //  Указываем путь к папке, и включаем кнопку генерации
                ChoseFolderDiscriptionLabel.Text = "✓";
                pathToDescriptionFolder = choseDiscriptionFolderDialog.SelectedPath;
            }
        }
        private void GenerateButton_1_Click(object sender, EventArgs e)
        {
            if (!IsGroupProces)
                GenerateFileAsync();
            else
                GenerateGroupFIlesAsync();
        }
        private void SaveButton_1_Click(object sender, EventArgs e)
        {
            FileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "PDF |*.pdf";
            //  Добавляем имя из имени файла excel
            saveDialog.FileName = Path.GetFileNameWithoutExtension(pathToExcelFile);
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {   //  Сохраняем pdf и удаляем временные файлы
                pdfDocument.Info.Title = saveDialog.FileName;
                if (pdfDocument.PageCount > 0)
                    pdfDocument.Save(saveDialog.FileName);
                else
                    MessageBox.Show("PDF файл не был сохранен, " +
                        "небыло сгенерированно ниодной страницы!");
            }
        }
        private void PacketCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (PacketCheckBox.Checked)
            {
                ChoseButton_1.Visible = false;
                ChoseGroupButton.Visible = true;
                SaveGroupBotton.Visible = true;
                InstructionLabel_1.Text = "Выберете прайс-листы и папку для сохранения " +
                    "сгенерированных PDF:";
                IsGroupProces = true;
                SaveButton_1.Visible = false;
                ChoseGroupLabel.Visible = true;
                ChoseLabel_1.Visible = false;
                ChoseFolderDiscriptionLabel.Text = "";
                ChoseFolderImagesLabel_1.Text = "";
                SaveFolderLabel.Text = "";
                GenerateButton_1.Enabled = false;
            }
            else
            {
                ChoseButton_1.Visible = true;
                ChoseGroupButton.Visible = false;
                SaveGroupBotton.Visible = false;
                InstructionLabel_1.Text = "Выберете прайс-лист в формате Excel:";
                IsGroupProces = false;
                ProgressLable_1.Visible = false;
                GenerateButton_1.Enabled = false;
                ChoseGroupLabel.Visible = false;
                ChoseLabel_1.Visible = true;
                ChoseFolderDiscriptionLabel.Text = "";
                ChoseFolderImagesLabel_1.Text = "";
                SaveFolderLabel.Text = "";
            }
        }
        private void ChoseGroupButton_Click(object sender, EventArgs e)
        {
            var choseGroupExcelDialog = new OpenFileDialog()
            {
                Filter = "Excel|*.xls;*.xlsx",
                Multiselect = true
            };
            if (choseGroupExcelDialog.ShowDialog() == DialogResult.OK)
            {   //Получаем все пути к выбраным файлам
                pathToGroupExcelFiles = choseGroupExcelDialog.FileNames;
                ChoseGroupLabel.Text = $"Файлов: {pathToGroupExcelFiles.Length}";
                SaveGroupBotton.Enabled = true;
            }
        }
        private void SaveGroupBotton_Click(object sender, EventArgs e)
        {
            var choseSaveFolder = new FolderBrowserDialog();
            if (choseSaveFolder.ShowDialog() == DialogResult.OK)
            {   //  Указываем путь к папке, и включаем кнопку генерации
                ColumnCheckBox.Visible = true;
                IdTextBox.Visible = true;
                TitleTextBox.Visible = true;
                PriceTextBox.Visible = true;
                AddCheckBox.Visible = true;
                ChoseImagesFolderButton_1.Enabled = true;
                ChoseDiscriptionButton.Enabled = true;
                SaveFolderLabel.Text = "✓";
                pathToGroupSaveFolder = choseSaveFolder.SelectedPath;
            }
        }
        private void ColumnCheckBox_CheckedChanged(object sender, EventArgs e)
        {// Если включен то можно редактировать
            if (ColumnCheckBox.Checked)
            {
                IdTextBox.Enabled = true;
                TitleTextBox.Enabled = true;
                PriceTextBox.Enabled = true;
            }
            else
            {   //Если нет, возвращаем значение по умолчанию
                IdTextBox.Text = "3";
                TitleTextBox.Text = "4";
                PriceTextBox.Text = "5";
                IdTextBox.Enabled = false;
                TitleTextBox.Enabled = false;
                PriceTextBox.Enabled = false;
            }
        }
        /// <summary>
        /// Методы
        /// </summary>
        //  Генерирует один файл
        private async void GenerateFileAsync()
        {
            GenerateButton_1.Enabled = false;
            ProgressLable_1.Visible = true;
            SaveButton_1.Enabled = false;
            SaveButton_1.Visible = true;

            //  Чтобы не блокироват UI поток запускаем асинхронно в задаче
            await Task.Run(() =>
            {
                //  Из меню настроек получаем значения номеров колонок
                //  проверяем чтобы это были числа
                SetColumnValues();

                //  Пытаемся спарсить файл
                var excelParser = new ExcelParser(pathToExcelFile);
                try
                {
                    ProgressLable_1.Text = "Обработка файла Excel...";
                    listOfProduct = excelParser.Parse(idColumn, titleColumn, priceColumn);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                //  Если удалось генерируем изображения и создаем из них pdf файл
                if (listOfProduct != null)
                {
                    SetImagesPathsForProducts();
                    if (pathToDescriptionFolder != String.Empty)
                        SetDiscriptionForProducts();
                    try
                    {
                        ProgressLable_1.Text = "Создание страниц...";
                        CreateImages(Path.GetFileNameWithoutExtension(pathToExcelFile));
                        ProgressLable_1.Text = "Создание PDF файла...";
                        CreatePdfDocument(Path.GetFileNameWithoutExtension(pathToExcelFile));
                    }
                    catch(Exception) { MessageBox.Show("Не выбран файл Excel!"); };
                    ProgressLable_1.Text = "Готово!";
                }
                //  Включаем кнопку сохранения файла
                SaveButton_1.Enabled = true;
                GenerateButton_1.Enabled = true;
                //  Удаляем временные файлы
                if (Directory.Exists(tempPath))
                    Directory.Delete(tempPath, true);
            });
        }
        // Пакетная обработка
        private async void GenerateGroupFIlesAsync()
        {
            GenerateButton_1.Enabled = false;
            ProgressLable_1.Visible = true;

            await Task.Run(() =>
            {
                try
                {
                    for (int i = 0; i < pathToGroupExcelFiles.Length; i++)
                    {
                        SetColumnValues();
                        //  Пытаемся спарсить файл
                        var excelParser = new ExcelParser(pathToGroupExcelFiles[i]);
                        try
                        {
                            ProgressLable_1.Text = $"Обработка файла: " +
                                                   $"{i + 1}/{pathToGroupExcelFiles.Length}";
                            listOfProduct = excelParser.Parse(idColumn, titleColumn, priceColumn);
                        }
                        catch (Exception ex) { MessageBox.Show(ex.Message); }
                        //  Если удалось генерируем изображения и создаем из них pdf файл
                        if (listOfProduct != null)
                        {
                            SetImagesPathsForProducts();

                            if (pathToDescriptionFolder != String.Empty)
                                SetDiscriptionForProducts();

                            ProgressLable_1.Text = "Создание страниц...";
                            CreateImages(Path.GetFileNameWithoutExtension(
                                                    pathToGroupExcelFiles[i]));
                            ProgressLable_1.Text = "Создание PDF файла...";
                            CreatePdfDocument(Path.GetFileNameWithoutExtension(
                                                    pathToGroupExcelFiles[i]));
                        }
                        // Сохраняем файл
                        pdfDocument.Info.Title = Path.GetFileNameWithoutExtension(
                                                        pathToGroupExcelFiles[i]);
                        if (pdfDocument.PageCount > 0)
                            pdfDocument.Save(pathToGroupSaveFolder + $@"/{pdfDocument.Info.Title}.pdf");

                        //  Удаляем временные файлы
                        if (Directory.Exists(tempPath))
                            Directory.Delete(tempPath, true);
                    }
                }
                catch { MessageBox.Show("Что-то пошло не так! Возможно не достаточно оперативной памяти."); };
                GenerateButton_1.Enabled = true;
            });

            ProgressLable_1.Text = "Готово!";
        }
        //  Устанавливает значения номеров колонок для обработки Excel файла
        private void SetColumnValues()
        {
            idColumn = GetColumnNumberFromTextBoxes(IdTextBox.Text);
            titleColumn = GetColumnNumberFromTextBoxes(TitleTextBox.Text);
            priceColumn = GetColumnNumberFromTextBoxes(PriceTextBox.Text);
        }
        private void CreatePdfDocument(string path)
        {
            //  Считываем все сгенерированные в страницы из временной папки
            string[] tempFolderFiles = Directory.GetFiles(tempPath);
            var orderedTempFolderFiles = tempFolderFiles.OrderBy(x => x, new MyComparer());
            //  Создаем pdf документ
            pdfDocument = new PdfDocument();
            //  Если нужно добпвляем страницу с названием на основе названия файла excel
            if (AddCheckBox.Checked)
                AddFrontPageToPDF(path);

            foreach (var pricePage in orderedTempFolderFiles)
            {
                 PdfPage page = pdfDocument.AddPage();
                 XGraphics gfx = XGraphics.FromPdfPage(page);
                 //  Генерация страницы pdf
                 CreatePdfPage(gfx, pricePage, 0, 0, (int)page.Width, (int)page.Height);
                 gfx.Dispose();
            }

        }
        private void AddFrontPageToPDF(string path)
        {   //  Разделяем название на слова для корректной отрисовки в PDF
            var title = path.Split(' ');
            PdfPage page = pdfDocument.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont font = new XFont("Verdana", 35, XFontStyle.BoldItalic);
            for (int i = 0; i < title.Length; i++)
            {   //  Пишем название по словам
                gfx.DrawString(title[i],
                 font, XBrushes.Black, new XRect(0, i * font.Size, page.Width, page.Height),
                 XStringFormats.Center);
            }
        }
        private void CreatePdfPage(XGraphics gfx, string pricePage, int x, int y, int width, int height)
        {
            using (XImage image = XImage.FromFile(pricePage))
            {
                gfx.DrawImage(image, x, y, width, height);
            }
        }
        //  Создет страницы в виде изображений
        private void CreateImages(string path)
        {
            var pageBuilder = new PageBuilder(rows: 4, colums: 3);
            var list = pageBuilder.GetCreatedPages(listOfProduct, path, AddCheckBox.Checked);
            Directory.CreateDirectory(tempPath);
            pageBuilder.SaveRender(list, tempPath);
        }
        //  Устанавливает для Product путь к изображению
        private void SetImagesPathsForProducts()
        {
            string pathJpg;
            string pathPng;
            foreach (var product in listOfProduct)
            {
                pathJpg = pathToImageFolder + $@"\{product.Id}.jpg";
                pathPng = pathToImageFolder + $@"\{product.Id}.png";
                if (File.Exists(pathJpg))
                    product.PathToImage = pathJpg;
                else if (File.Exists(pathPng))
                    product.PathToImage = pathPng;
                else
                    product.PathToImage = "";
            }
        }
        private int GetColumnNumberFromTextBoxes(string numberColumn)
        {
            if (int.TryParse(numberColumn, out int result))
                return result;
            else
                return 1;
        }
        //  Добавляет описание из файлов для Product
        private void SetDiscriptionForProducts()
        {
            try
            {
                descriptionParser = new DescriptionParser(pathToDescriptionFolder);
                descriptionParser.Parse(listOfProduct);
            }
            catch { }
        }

    }
}
