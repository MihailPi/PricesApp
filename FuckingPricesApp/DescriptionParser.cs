using System;
using System.Collections.Generic;
using System.IO;

namespace FuckingPricesApp
{
    class DescriptionParser
    {
        private readonly string _pathToFolder;
        private string pathToTxtFile;
        public DescriptionParser(string pathToFolder)
        {
            _pathToFolder = pathToFolder;
        }
        public void Parse(List<Product> productList)
        {
            foreach (var product in productList)
            {
                try
                {
                    pathToTxtFile = _pathToFolder + @"\" + product.Id + ".txt";
                    if (File.Exists(pathToTxtFile))
                        product.Description = File.ReadAllText(pathToTxtFile, 
                            System.Text.Encoding.GetEncoding(1251));
                    else
                        product.Description = "";
                }
                catch (Exception ex)
                { throw ex; }
            }
        }
    }
}
