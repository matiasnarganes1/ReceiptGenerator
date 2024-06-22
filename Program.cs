using System;
using System.Collections.Generic;
using System.IO;
using QuestPDF.Infrastructure;

namespace ReceiptGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            QuestPDF.Settings.License = LicenseType.Community;
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;

            string inputDirectory = Path.Combine(currentDirectory, "in");
            string outputDirectory = Path.Combine(currentDirectory, "out");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string excelFilePath = Path.Combine(inputDirectory, "receipts.xlsx");

            if (!File.Exists(excelFilePath))
            {
                Console.WriteLine($"El archivo de Excel no existe: {excelFilePath}");
                return;
            }

            var excelService = new ExcelReaderService();
            var pdfService = new PdfGeneratorService();

            try
            {
                List<Receipt> receipts = excelService.ReadExcel(excelFilePath);

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
