using System;
using System.Collections.Generic;
using System.IO;

namespace ReceiptGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Por favor, proporcione la ruta al archivo de Excel y el directorio de salida.");
                return;
            }

            string excelFilePath = args[0];
            string outputDirectory = args[1];

            var excelService = new ExcelReaderService();
            var pdfService = new PdfGeneratorService();

            try
            {
                List<Receipt> receipts = excelService.ReadExcel(excelFilePath);

                if (!Directory.Exists(outputDirectory))
                {
                    Directory.CreateDirectory(outputDirectory);
                }

                foreach (var receipt in receipts)
                {
                    string outputPath = Path.Combine(outputDirectory, $"Receipt_{receipt.Id}.pdf");
                    pdfService.GeneratePdf(receipt, outputPath);
                }

                Console.WriteLine("Recibos generados exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocurrió un error: {ex.Message}");
            }
        }
    }
}
