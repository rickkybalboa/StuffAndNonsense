using OfficeOpenXml;

namespace UploadFileTryer.Helpers
{
    // Trying to make a jagged list work:
    public static class ReadSheetHelper
    {
        public static List<List<string>> ReadXLS(string FilePath)
        {
            var eventsData = new List<List<string>>();
            FileInfo existingFile = new FileInfo(FilePath);
            using (ExcelPackage package = new ExcelPackage(existingFile))
            {
                //get the first worksheet in the workbook
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                int colCount = worksheet.Dimension.End.Column;  //get Column Count
                int rowCount = worksheet.Dimension.End.Row;     //get row count

                for (int row = 2; row <= rowCount; row++)
                {
                    List<string> sublist = new List<string>();   //makes a new sublist for each row (event)
                    for (int col = 1; col <= colCount; col++)
                    {
                        if (worksheet.Cells[row, col] != null && worksheet.Cells[row, col].Value != null)
                        {
                            sublist.Add(worksheet.Cells[row, col].Value.ToString().Trim());
                        }
                    }
                    eventsData.Add(sublist);
                }
                ////This foreach is just to test what I get out of the above function.
                //foreach (var field in eventsData)
                //    Console.WriteLine(field);

                return eventsData;

            }
        }
        public static void Display(List<List<string>> list)
        {
            //
            // Display everything in the List.
            //
            Console.WriteLine("Elements:");
            foreach (var sublist in list)
            {
                foreach (var value in sublist)
                {
                    Console.Write(value);
                    Console.Write(' ');
                }
                Console.WriteLine();
            }
        }
    }
}


