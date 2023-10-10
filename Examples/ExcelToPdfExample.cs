using ceTe.DynamicPDF.Conversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicPDFCoreSuite.Examples
{
    class ExcelToPdfExample
    {
        public static void Run()
        {
            ExampleOne();
            ExampleTwo();
        }

        public static void ExampleOne()
        {
            ExcelConversionOptions options = new ExcelConversionOptions(false);
            ExcelConverter excelConverter = new ExcelConverter(Util.GetPath("Resources/Data/HelloWorldExcel.xls"), options);
            excelConverter.Convert(Util.GetPath("Output/excel-one-output.pdf"));
        }

        public static void ExampleTwo()
        {
            Converter.Convert(Util.GetPath("Resources/Data/HelloWorldExcel.xls"), Util.GetPath("Output/excel-two-output.pdf"));
        }
    }
}
