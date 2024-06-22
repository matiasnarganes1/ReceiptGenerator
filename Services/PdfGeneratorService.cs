using System;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using QuestPDF.Fluent;

public class PdfGeneratorService
{
    public void GeneratePdf(Receipt receipt, string outputPath)
    {
        var document = new ReceiptDocument(receipt);
        document.GeneratePdf(outputPath);
        Console.WriteLine($"PDF created successfully at {outputPath}!");
    }
}
