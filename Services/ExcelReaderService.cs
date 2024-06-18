using NPOI.XSSF.UserModel; // Para XLSX
using NPOI.HSSF.UserModel; // Para XLS
using NPOI.SS.UserModel;
using System;
using System.IO;

public class ExcelReaderService 
{
    public ExcelReaderService()
    {
        
    }
    public List<Receipt> ReadExcel(string filePath)
        {
            var receipts = new List<Receipt>();

            using (var file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                IWorkbook workbook = new XSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);

                for (int row = 1; row <= sheet.LastRowNum; row++)
                {
                    IRow currentRow = sheet.GetRow(row);
                    if (currentRow != null)
                    {
                        receipts.Add(new Receipt
                        {
                            Id = int.Parse(currentRow.GetCell(0).ToString()),
                            Description = currentRow.GetCell(1).ToString(),
                            Amount = decimal.Parse(currentRow.GetCell(2).ToString()),
                            Date = DateTime.Parse(currentRow.GetCell(3).ToString())
                        });
                    }
                }
            }

            return receipts;
        }
    }
