using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Packaging;
using WordP = DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Text.RegularExpressions;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {

        String path = null;
        String amm1 = null;
        String amm2 = null;
        String amm3 = null;
        String cps = null;
        String enr = null;
        String misc = null;
        String mas = null;
        String mbsa = null;
        String sign = null;

        public Form1()
        {
            InitializeComponent();

            try
            {
                path = System.IO.File.ReadAllText(@"C:\DocGenerator\doc.cfg");
                amm1 = path + "amm1.docx";
                amm2 = path + "amm2.docx";
                amm3 = path + "amm3.docx";
                cps = path + "cps.docx";
                enr = path + "enr.docx";
                misc = path + "misc.docx";
                mas = path + "mas.docx";
                mbsa = path + "mbsa.docx";
                sign = path + "sign.docx";
            }
            catch (System.IO.FileNotFoundException)
            {
                MessageBox.Show("Create C:/doc.cfg and put valid document path!",
    "Error Message",
    MessageBoxButtons.OK,
    MessageBoxIcon.Exclamation,
    MessageBoxDefaultButton.Button1);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //:::::WORD DOCUMENT PROCESSING PART:::::
        public static void AddToTable(String fileName, String tableName, int elemNo, String txt, int elemRow = 0)
        {
            List<WordP.Table> tables = null;

            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(fileName, true))
            {
                tables = new List<WordP.Table>(wordDoc.MainDocumentPart.Document.Body.Elements<WordP.Table>());
                tables.ForEach(table =>
                {
                    WordP.TableProperties tblProperties = table.GetFirstChild<WordP.TableProperties>();
                    if (tblProperties != null)
                    {
                        WordP.TableCaption caption = tblProperties.GetFirstChild<WordP.TableCaption>();
                        if (caption != null)
                        {
                            if (caption.Val.HasValue && caption.Val.Value.Equals(tableName))
                            {

                                WordP.TableRow row = table.Elements<WordP.TableRow>().ElementAt(elemNo);

                                // Find the third cell in the row.
                                WordP.TableCell cell = row.Elements<WordP.TableCell>().ElementAt(elemRow);

                                // Find the first paragraph in the table cell.
                                WordP.Paragraph p = cell.Elements<WordP.Paragraph>().First();

                                // Find the first run in the paragraph.
                                WordP.Run r = p.Elements<WordP.Run>().First();

                                // Set the text for the run.
                                WordP.Text t = r.Elements<WordP.Text>().First();
                                t.Text = txt;

                                // you have got your table. process the rest.
                            }
                        }
                    }
                });



            }


        }

        public static String XLGetCellValue(String fileName, String sheetName, String cellName)
        {
            String value = null;


            using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Open(fileName, false))
            {
                WorkbookPart wb = spreadsheetDocument.WorkbookPart;
                Sheet sh = wb.Workbook.Descendants<Sheet>().FirstOrDefault(s => s.Name == sheetName);
                if (sh == null)
                {
                    throw new ArgumentException("no sheet");
                }
                WorksheetPart ws = (WorksheetPart)(wb.GetPartById(sh.Id));
                Cell c = ws.Worksheet.Descendants<Cell>().FirstOrDefault(s => s.CellReference == cellName);
                if (c != null)
                {
                    value = c.CellValue.InnerText;
                }



                if (c.DataType != null)
                {
                    switch (c.DataType.Value)
                    {
                        case CellValues.SharedString:
                            var stringTable = wb.SharedStringTablePart;
                            if (stringTable != null)
                            {
                                var textItem = stringTable.SharedStringTable.
                                    ElementAtOrDefault(int.Parse(value));
                                if (textItem != null)
                                    value = textItem.InnerText;
                            }
                            break;

                        case CellValues.Boolean:
                            switch (value)
                            {
                                case "0":
                                    value = "FALSE";
                                    break;
                                default:
                                    value = "TRUE";
                                    break;
                            }
                            break;

                    }
                }

            }

            return value;
        }
        // Given a Worksheet and an address (like "AZ254"), either return a cell reference, or 
        // create the cell reference and return it.
        private static Cell RetrieveCellReference(Worksheet ws, string addressName)
        {
            // Use regular expressions to get the row number and column name.
            // If the parameter wasn't well formed, this code
            // will fail:
            Regex rx = new Regex("^(?<col>\\D+)(?<row>\\d+)");
            Match m = rx.Match(addressName);
            uint rowNumber = uint.Parse(m.Result("${row}"));
            string colName = m.Result("${col}");

            // Retrieve reference to the sheet's data.
            SheetData sheetData = ws.GetFirstChild<SheetData>();

            // If the worksheet does not contain a row 
            // with the specified row index, insert one.
            var rows = sheetData.Elements<Row>();
            var theRow = rows.FirstOrDefault(r => r.RowIndex.Value == rowNumber);
            if (theRow == null)
            {
                theRow = new Row();
                theRow.RowIndex = rowNumber;


                Row refRow = null;
                foreach (Row row in rows)
                {
                    if (row.RowIndex > rowNumber)
                    {
                        refRow = row;
                        break;
                    }
                }
                // If refRow is null, InsertBefore appends.
                sheetData.InsertBefore(theRow, refRow);
            }
            // At this point, theRow refers to the row to contain the cell value.
            // The cell may or may not exist.

            // If the cell you need already exists, return it.
            // If there is not a cell with the specified address name, insert one.  
            var cells = theRow.Elements<Cell>();

            Cell theCell = cells.FirstOrDefault(c => c.CellReference.Value == addressName);
            if (theCell == null)
            {
                // Cell doesn't exist, so create one.
                theCell = new Cell();
                theCell.CellReference = addressName;
                // Must insert cell in the appropriate location.
                Cell refCell = null;
                foreach (Cell cell in cells)
                {
                    if (string.Compare(cell.CellReference.Value, addressName, true) > 0)
                    {
                        refCell = cell;
                        break;
                    }
                }
                // If refCell is null, InsertBefore appends.
                theRow.InsertBefore(theCell, refCell);
            }
            return theCell;


        }


        private static int InsertSharedStringItem(string text, SharedStringTablePart shareStringPart)
        {
            // If the part does not contain a SharedStringTable, create one.
            if (shareStringPart.SharedStringTable == null)
            {
                shareStringPart.SharedStringTable = new SharedStringTable();
            }

            int i = 0;

            // Iterate through all the items in the SharedStringTable. If the text already exists, return its index.
            foreach (SharedStringItem item in shareStringPart.SharedStringTable.Elements<SharedStringItem>())
            {
                if (item.InnerText == text)
                {
                    return i;
                }

                i++;
            }

            // The text does not exist in the part. Create the SharedStringItem and return its index.
            shareStringPart.SharedStringTable.AppendChild(new SharedStringItem(new DocumentFormat.OpenXml.Spreadsheet.Text(text)));
            shareStringPart.SharedStringTable.Save();

            return i;
        }

        public static bool XLInsertNumberIntoCell(
    string fileName, string sheetName, string addressName, String value)
        {
            // Given a file, a sheet, and a cell, insert a specified value.
            // For example: InsertNumberIntoCell("C:\Test.xlsx", "Sheet3", "C3", 14)

            // Assume failure.
            bool returnValue = false;

            // Open the document for editing.
            using (SpreadsheetDocument document = SpreadsheetDocument.Open(fileName, true))
            {
                WorkbookPart wbPart = document.WorkbookPart;

                Sheet theSheet = wbPart.Workbook.Descendants<Sheet>().
                  FirstOrDefault(s => s.Name == sheetName);
                if (theSheet != null)
                {
                    WorksheetPart wsPart = (WorksheetPart)(wbPart.GetPartById(theSheet.Id));
                    Worksheet ws = wsPart.Worksheet;
                    Cell theCell = RetrieveCellReference(ws, addressName);

                    // String ind = theCell.CellValue.InnerText;

                    var stringTable = wbPart.SharedStringTablePart;
                    //var textItem = stringTable.SharedStringTable.ElementAtOrDefault(int.Parse(ind));


                    int value1 = InsertSharedStringItem(value, stringTable);

                    theCell.CellValue = new CellValue(value1.ToString());
                    theCell.DataType = CellValues.SharedString;

                    //theCell.DataType = new DocumentFormat.OpenXml.EnumValue<CellValues>(CellValues.SharedString);

                    // Save the worksheet.
                    ws.Save();
                    returnValue = true;
                }

            }

            return returnValue;
        }

        //printing
        public static void printDocs(String fname)
        {
            System.Diagnostics.ProcessStartInfo si = new System.Diagnostics.ProcessStartInfo();
            si.UseShellExecute = true;
            si.FileName = fname;
            si.Verb = "print";
            System.Diagnostics.Process.Start(si);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {

                //Check Conditions::
                if (cb_sheet.Checked)
                    //Signature Page
                {
                    AddToTable(sign, "table1", 1, txt_enr.Text);
                    AddToTable(sign, "table3", 1, txt_case.Text, 1);
                    AddToTable(sign, "table1", 7, txt_country.Text);
                    AddToTable(sign, "table2", 1, txt_customer.Text.ToUpper());
                    AddToTable(sign, "table1", 5, txt_amm1.Text+","+ txt_amm2.Text + "," + txt_amm3.Text);
                    AddToTable(sign, "table1", 3, txt_po.Text);
                    printDocs(sign);
                }
                if (cb_enr.Checked)
                {
                    AddToTable(enr, "table1", 1, txt_enr.Text);
                    AddToTable(enr, "table3", 1, txt_case.Text, 1);
                    AddToTable(enr, "table1", 7, txt_country.Text);
                    AddToTable(enr, "table2", 1, txt_customer.Text.ToUpper());
                    printDocs(enr);
                }
                if (cb_cps.Checked)
                {
                    AddToTable(cps, "table1", 1, txt_enr.Text);
                    AddToTable(cps, "table1", 3, txt_po.Text);
                    AddToTable(cps, "table1", 7, txt_country.Text);
                    AddToTable(cps, "table3", 1, txt_case.Text, 1);
                    AddToTable(cps, "table2", 1, txt_customer.Text.ToUpper());
                    printDocs(cps);
                }
                if (cb_misc.Checked)
                {
                    AddToTable(misc, "table1", 1, txt_enr.Text);
                    AddToTable(misc, "table1", 7, txt_country.Text);
                    AddToTable(misc, "table3", 1, txt_case.Text, 1);
                    AddToTable(misc, "table2", 1, txt_customer.Text.ToUpper());
                    if (txt_misc.Text == "") txt_misc.Text = "1";
                    if (txt_misc.Text == null) txt_misc.Text = "1";
                   
                    for (int i = 0; i < Int32.Parse(txt_misc.Text); i++)
                    {
                        printDocs(misc);
                   }
                }
                if (cb_amm1.Checked)
                {
                    AddToTable(amm1, "table1", 5, txt_amm1.Text);
                    AddToTable(amm1, "table1", 7, txt_country.Text);
                    AddToTable(amm1, "table3", 1, txt_case.Text, 1);
                    AddToTable(amm1, "table2", 1, txt_customer.Text.ToUpper());
                    AddToTable(amm1, "table1", 1, txt_enr.Text);
                    printDocs(amm1);
                }
                if (cb_amm2.Checked)
                {
                    AddToTable(amm2, "table1", 5, txt_amm2.Text);
                    AddToTable(amm2, "table1", 7, txt_country.Text);
                    AddToTable(amm2, "table3", 1, txt_case.Text, 1);
                    AddToTable(amm2, "table2", 1, txt_customer.Text.ToUpper());
                    AddToTable(amm2, "table1", 1, txt_enr.Text);
                    printDocs(amm2);

                }
                if (cb_amm3.Checked)
                {
                    AddToTable(amm3, "table1", 5, txt_amm3.Text);
                    AddToTable(amm3, "table1", 7, txt_country.Text);
                    AddToTable(amm3, "table3", 1, txt_case.Text, 1);
                    AddToTable(amm3, "table2", 1, txt_customer.Text.ToUpper());
                    AddToTable(amm3, "table1", 1, txt_enr.Text);
                    printDocs(amm3);
                }
                if (cb_mast.Checked)
                {
                    AddToTable(mas, "table1", 7, txt_country.Text);
                    AddToTable(mas, "table3", 1, txt_case.Text, 1);
                    AddToTable(mas, "table2", 1, txt_customer.Text.ToUpper());
                    AddToTable(mas, "table1", 1, txt_mast.Text);
                    printDocs(mas);
                }
                if (cb_mbsa.Checked)
                {
                    AddToTable(mbsa, "table1", 7, txt_country.Text);
                    AddToTable(mbsa, "table3", 1, txt_case.Text, 1);
                    AddToTable(mbsa, "table2", 1, txt_customer.Text.ToUpper());
                    AddToTable(mbsa, "table1", 1, txt_mbsa.Text);
                    printDocs(mbsa);
                }


                MessageBox.Show("Done!");
            }
            catch (System.IO.IOException)
            {
                //
                // Dialog box with exclamation icon. [8]
                //
                MessageBox.Show("Please close Word!",
                    "Error Message",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);

            }
            catch (DocumentFormat.OpenXml.Packaging.OpenXmlPackageException)
            {
                //
                // Dialog box with exclamation icon. [8]
                //
                MessageBox.Show("Word Files Are missing, imposible to proceed!",
                    "Error Message",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cb_enr_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
