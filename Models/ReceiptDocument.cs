using System;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;

public class ReceiptDocument : IDocument
{
    private readonly Receipt _receipt;

    public ReceiptDocument(Receipt receipt)
    {
        _receipt = receipt;
    }

    public void Compose(IDocumentContainer container)
    {
        container
            .Page(page =>
            {
                page.Margin(50);
                page.Header().Text($"Receipt #{_receipt.Id}").FontSize(20).Bold();
                page.Content()
                    .Text(text =>
                    {
                        text.Span("Name: ").Bold();
                        text.Span(_receipt.Description);
                        text.EmptyLine();
                        text.Span("Amount: ").Bold();
                        text.Span($"${_receipt.Amount}");
                        text.EmptyLine();
                        text.Span("Date: ").Bold();
                        text.Span(_receipt.Date.ToString());
                    });
            });
    }
}