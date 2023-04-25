using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.IO;
using System.Windows;
using System.Collections.Generic;

namespace FuckingPricesApp
{
    class PageBuilder
    {
        private readonly int _dpi = 96;
        private RenderTargetBitmap _pageBitmap;
        private BitmapSource _productImage;
        private int _fontSize { get; set; }
        private Brush _posterBrush { get; set; }
        private Typeface _posterFont { get; set; }
        private int _backgroundImageHeight;
        private int _backgroundImageWidth;
        private int _priceRectWidth;
        private int _priceRectHeight;
        private int _priceRectRadius;
        private int _priceRectBorder;
        private int _offset;
        private int _topGap;
        private int _titleGap;
        private int _leftGap;
        private int _cellwidth;
        private int _cellHeight;
        private int _bottomGap;
        private int _rigthGap;
        private int _colums;
        private int _rows;
        private List<BitmapSource> _bitmapList;

        public PageBuilder(int colums, int rows)
        {
            _bitmapList = new List<BitmapSource>();
            //  Настройки шрифта
            _fontSize = 40;
            _posterFont = new Typeface(new FontFamily("Arial"),
                                      FontStyles.Normal,
                                      FontWeights.ExtraBold,
                                      FontStretches.SemiCondensed);
            _posterBrush = Brushes.Black;
            //  Размеры страницы
            _backgroundImageWidth = 1594;
            _backgroundImageHeight = 2254;
            //  Размеры прямоугольника цены
            _priceRectWidth = 200;
            _priceRectHeight = 60;
            _priceRectRadius = 20;
            _priceRectBorder = 5;
            //  Форматирование ячеек
            _offset = 3;
            _topGap = 55;
            _titleGap = 80;
            _leftGap = 50;
            _rows = rows;
            _colums = colums;
            _cellwidth = (_backgroundImageWidth - _leftGap * 2) / _colums;
            _cellHeight = (_backgroundImageHeight - _titleGap * 2) / rows;
            _bottomGap = _cellHeight + _topGap - _fontSize;
            _rigthGap = _cellwidth + _leftGap - _priceRectWidth - _offset;
        }
        public List<BitmapSource> GetCreatedPages(List<Product> productList, string fileName, bool isAddedFrontPage)
        {
            FormattedText formattedTextTitle;
            FormattedText formattedTextPrice;
            FormattedText formattedTextId;
            FormattedText formattedTextPageNumber;
            FormattedText formattedTextFileName;
            string title;

            //  Геренатор страниц
            var drawingVisual = new DrawingVisual();
            int rowsCounter = 1;
            int columsCounter = 1;
            int pageNumber = 1;

            for (int productCounter = 0; productCounter < productList.Count; )
            {
                using (var drawingContext = drawingVisual.RenderOpen())
                {
                    //  Белый фон страцницы
                    drawingContext.DrawRectangle(Brushes.White, null,
                        new Rect(0, 0, _backgroundImageWidth, _backgroundImageHeight));
                    while (true)
                    {
                        //  Настройка форамтирования текста
                        if (productList[productCounter].Description != null)
                        {
                            title = productList[productCounter].Title
                                    + " " + productList[productCounter].Description;
                        }
                        else
                            title = productList[productCounter].Title;

                        formattedTextTitle =
                            new FormattedText(title, System.Globalization.CultureInfo.CurrentCulture,
                                              FlowDirection.LeftToRight, _posterFont,
                                              (title.Length > 60) ? _fontSize-10 : _fontSize
                                              , _posterBrush, _dpi)
                            {
                                MaxTextWidth = _cellwidth - 1,
                                TextAlignment = TextAlignment.Left,
                                LineHeight = (title.Length > 60) ? _fontSize - 10 : _fontSize - 3,
                                MaxTextHeight = _cellwidth
                            };
                        formattedTextPrice = new FormattedText(productList[productCounter].Price, System.Globalization.CultureInfo.CurrentCulture,
                                              FlowDirection.LeftToRight, _posterFont, _fontSize + 1, _posterBrush, _dpi)
                        {
                            TextAlignment = TextAlignment.Center
                        };
                        formattedTextId = new FormattedText(productList[productCounter].Id, System.Globalization.CultureInfo.CurrentCulture,
                                              FlowDirection.LeftToRight, _posterFont, _fontSize - 1, _posterBrush, _dpi)
                        {
                            TextAlignment = TextAlignment.Left
                        };
                        formattedTextPageNumber = new FormattedText(pageNumber.ToString(), System.Globalization.CultureInfo.CurrentCulture,
                                              FlowDirection.LeftToRight, _posterFont, _fontSize, _posterBrush, _dpi)
                        {
                            TextAlignment = TextAlignment.Center
                        };
                        formattedTextFileName = new FormattedText(fileName, System.Globalization.CultureInfo.CurrentCulture,
                                              FlowDirection.LeftToRight, _posterFont, _fontSize, _posterBrush, _dpi)
                        {
                            TextAlignment = TextAlignment.Center
                        };

                        //  Формирование таблицы
                        //  Изображение товара
                        try
                        {   
                            _productImage = BitmapFrame.Create(new Uri(productList[productCounter].PathToImage));
                            drawingContext.DrawImage(_productImage,
                                new Rect(_cellwidth * columsCounter - _cellwidth + _leftGap,
                                        _cellHeight * rowsCounter - _cellHeight + _titleGap * 2,
                                        _cellwidth, _cellwidth - _titleGap));
                        }
                        catch (Exception){ }
                        //  Прямоугольник ячейки
                        drawingContext.DrawRectangle(null, new Pen(_posterBrush, 2),
                            new Rect(_cellwidth * columsCounter - _cellwidth + _leftGap,
                                    (_cellHeight * rowsCounter - _cellHeight) + _topGap,
                                    _cellwidth, _cellHeight));
                        // Текст названия
                        drawingContext.DrawText(formattedTextTitle,
                            new Point((_cellwidth * columsCounter) - _cellwidth + _leftGap + _offset,
                                        _cellHeight * rowsCounter - _cellHeight + _topGap + _offset));
                        //  Артикул товара
                        drawingContext.DrawRoundedRectangle(Brushes.White,
                            new Pen(Brushes.White, _priceRectBorder),
                            new Rect(((_cellwidth * columsCounter) - _cellwidth + _leftGap + _offset * 2),
                                    (_cellHeight * rowsCounter - _cellHeight + _bottomGap - _offset)+5,
                                    formattedTextId.Width, formattedTextId.Height-12), 5, 5);
                        drawingContext.DrawText(formattedTextId,
                            new Point((_cellwidth * columsCounter) - _cellwidth + _leftGap + _offset * 2,
                                        _cellHeight * rowsCounter - _cellHeight + _bottomGap - _offset));
                        //  Цена товара
                        drawingContext.DrawRoundedRectangle(Brushes.Orange,
                            new Pen(Brushes.Yellow, _priceRectBorder),
                            new Rect((_cellwidth * columsCounter) - _cellwidth + _rigthGap - _priceRectBorder,
                                    _cellHeight * rowsCounter - _cellHeight + _bottomGap - _priceRectHeight / 2,
                                    _priceRectWidth, _priceRectHeight), _priceRectRadius, _priceRectRadius);
                        drawingContext.DrawText(formattedTextPrice,
                            new Point((_cellwidth * columsCounter) - _cellwidth + _rigthGap + _priceRectWidth / 2,
                                     _cellHeight * rowsCounter - _cellHeight + _bottomGap - _priceRectBorder * 5));
                        
                        productCounter++;

                        //  Переход на следующий столбец
                        columsCounter++;
                        if (columsCounter > _colums)
                        {
                            columsCounter = 1;
                            rowsCounter++;
                        }
                        //  Если конец страницы или закончились товары
                        if (rowsCounter > _rows || productCounter == productList.Count)
                        {   //  Рисуем линию
                            drawingContext.DrawLine(new Pen(_posterBrush, 3),
                                new Point(_titleGap, _backgroundImageHeight - _topGap * 2 + 25),
                                new Point(_backgroundImageWidth - _titleGap, _backgroundImageHeight - _topGap * 2 + 25));
                            //  Название файла
                            drawingContext.DrawText(formattedTextFileName,
                                new Point(_backgroundImageWidth / 2 - (fileName.Length / 2),
                                _backgroundImageHeight - _topGap * 2 + 30));

                            rowsCounter = 1;
                            //  Номер страницы
                            if(isAddedFrontPage)
                            {   //  Если добавленна титульная страница, то добавляем номер страницы слева если четная
                                if (pageNumber % 2 == 0)
                                {
                                    drawingContext.DrawText(formattedTextPageNumber,
                                    new Point(_backgroundImageWidth - _leftGap * 2,
                                               _backgroundImageHeight - _topGap * 2 + 35));
                                } 
                                else
                                {   //  И справа если не четная
                                    drawingContext.DrawText(formattedTextPageNumber,
                                    new Point(_leftGap * 2,
                                    _backgroundImageHeight - _topGap * 2 + 35));
                                }
                            }
                            else
                            {   //  Если титульника нет, то справа если четная
                                if (pageNumber % 2 == 0)
                                {
                                    drawingContext.DrawText(formattedTextPageNumber,
                                        new Point(_leftGap * 2,
                                        _backgroundImageHeight - _topGap * 2 + 35));
                                }
                                else
                                {   //  И слева если нечетная
                                    drawingContext.DrawText(formattedTextPageNumber,
                                        new Point(_backgroundImageWidth - _leftGap * 2,
                                                   _backgroundImageHeight - _topGap * 2 + 35));
                                }
                            }
                            pageNumber++;
                            break;
                        }
                    }
                    drawingContext.Close();
                }
                //  Экземпляр сгенерированной страницы
                _pageBitmap = new RenderTargetBitmap(_backgroundImageWidth, _backgroundImageHeight,
                                                    _dpi, _dpi, PixelFormats.Pbgra32);
                _pageBitmap.Render(drawingVisual);
                _bitmapList.Add(_pageBitmap);
            }
            
            return _bitmapList;
        }
        public void SaveRender(List<BitmapSource> bitmapSources, string path)
        {
            for (int i = 0; i < bitmapSources.Count; i++)
            {
                var encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bitmapSources[i]));
                using (var stream = File.Create($@"{path}{i}.jpg"))
                {
                    encoder.Save(stream);
                }
            }
        }
    }
}
