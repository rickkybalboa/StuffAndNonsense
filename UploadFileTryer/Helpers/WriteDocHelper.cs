using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Syncfusion.DocIO.DLS;

namespace UploadFileTryer.Helpers
{

    public static class WriteDocHelper
    {

        public static void WriteDoc(string? dayName, string fileNameTemplate, string fileNameOutput, string fileExcelSheet)
        {
            //Reads the excel sheet
            List<List<string>>? eventList = ReadSheetHelper.ReadXLS(fileExcelSheet);

            //Does the thing
            for (int i = 0; i < eventList.Count; i++)
            {
                switch (i)
                {
                    case 0:
                        {
                            WordDocument makeDoc = new WordDocument();
                            //Opens the source document
                            WordDocument sourceDocument = new WordDocument(fileNameTemplate);
                            //Processes  each section in the Word document
                            for (int v = 0; v < sourceDocument.Sections.Count; v++)
                            {
                                //Clones and adds source document sections to the destination document
                                makeDoc.Sections.Add(sourceDocument.Sections[v].Clone());
                                //Saves and closes the document instance
                                makeDoc.Save(fileNameOutput);
                                //makeDoc.Close();
                            }
                            makeDoc.Replace("XXXX", dayName, true, true);
                            makeDoc.Close();

                            for (int j = 0; j < eventList[i].Count; j++)
                            {
                                WordDocument modifyDoc = new WordDocument(fileNameOutput);
                                //modifyDoc.Replace("XXXX", dayName, true, true);

                                switch (j)
                                {
                                    case (0):
                                        {
                                            Console.WriteLine("j is {0} -- in Case 0", j);
                                            var eventName = eventList[i][j].Split(" ");
                                            modifyDoc.Replace("EVENT", $"{eventList[i][j]}", true, true);
                                            modifyDoc.Replace("EVENT_R", $"{eventName[0]}", true, true);
                                            modifyDoc.Save(fileNameOutput);
                                            break;
                                        }

                                    case 5:
                                        {
                                            Console.WriteLine("j is {0} -- in Case 5", j);

                                            modifyDoc.Replace("RECORD", $"{eventList[i][j]}", true, true);
                                            modifyDoc.Save(fileNameOutput);
                                            break;
                                        }

                                    default:
                                        {
                                            Console.WriteLine("j is {0} -- in default case", j);
                                            modifyDoc.Replace($"Student{j}", $"{eventList[i][j]}", false, true);
                                            modifyDoc.Save(fileNameOutput);
                                            modifyDoc.Close();
                                            break;
                                        }

                                }

                            }

                            break;
                        }

                    default:
                        {
                            WordDocument updateDoc = new WordDocument(fileNameOutput);
                            //Opens the source document
                            WordDocument sourceDocument = new WordDocument(fileNameTemplate);
                            //Processes  each section in the Word document
                            for (int v = 0; v < sourceDocument.Sections.Count; v++)
                            {
                                //Clones and adds source document sections to the destination document
                                updateDoc.Sections.Add(sourceDocument.Sections[v].Clone());
                                //Saves and closes the document instance
                                updateDoc.Save(fileNameOutput);
                                updateDoc.Close();
                            }
                            for (int j = 0; j < eventList[i].Count; j++)
                            {
                                WordDocument modifyDoc = new WordDocument(fileNameOutput);
                                modifyDoc.Replace("XXXX", dayName, true, true);

                                switch (j)
                                {
                                    case (0):
                                        {
                                            Console.WriteLine("j is {0} -- in Case 0", j);
                                            var eventName = eventList[i][j].Split(" ");
                                            modifyDoc.Replace("EVENT", $"{eventList[i][j]}", true, true);
                                            modifyDoc.Replace("EVENT_R", $"{eventName[0]}", true, true);
                                            modifyDoc.Save(fileNameOutput);
                                            break;
                                        }

                                    case 5:
                                        {
                                            Console.WriteLine("j is {0} -- in Case 5", j);

                                            modifyDoc.Replace("RECORD", $"{eventList[i][j]}", true, true);
                                            modifyDoc.Save(fileNameOutput);
                                            break;
                                        }

                                    default:
                                        {
                                            Console.WriteLine("j is {0} -- in default case", j);
                                            modifyDoc.Replace($"Student{j}", $"{eventList[i][j]}", false, true);
                                            modifyDoc.Save(fileNameOutput);
                                            modifyDoc.Close();
                                            break;
                                        }
                                }
                            }

                            break;
                        }
                }
            }

        }
    }        
}
