using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System;

public class PdfGeneratorService
{
    public void GeneratePdf(Receipt receipt, string outputPath)
    {
        using (var writer = new PdfWriter(outputPath))
        {
            using (var pdf = new PdfDocument(writer))
            {
                var document = new Document(pdf);

                document.Add(new Paragraph($"Receipt #{receipt.Id}")
                    .SetFontSize(20)
                    .SetBold());

                document.Add(new Paragraph($"Name: {receipt.Description}"));
                document.Add(new Paragraph($"Amount: ${receipt.Amount}"));
                document.Add(new Paragraph($"Date: {receipt.Date.ToString("d")}"));
            }
        }

        Console.WriteLine($"PDF created successfully at {outputPath}!");
    }
}
