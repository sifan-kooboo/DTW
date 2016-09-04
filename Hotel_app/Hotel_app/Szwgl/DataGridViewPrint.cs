using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;


namespace Hotel_app.Szwgl
{
    
   public class DataGridViewPrint
    {
       public DataGridViewPrint()
       {

       }

        private DataGridView dataGridView;
        private PrintDocument printDocument;
        private PageSetupDialog pageSetupDialog;
        private PrintPreviewDialog printPreviewDialog;
        private int dgvIndex = 0;
        private int rowCount = 0;
        private int colCount = 0;
        private int x = 0;
        private int y = 0;
        int i = 0;
        private int rowGap = 60;
        private int leftMargin = 50;
        private Font font = new Font("Arial", 10);
        private Font headingFont = new Font("Arial", 11, FontStyle.Underline);
        private Font captionFont = new Font("Arial", 10, FontStyle.Bold);
        private Brush brush = new SolidBrush(Color.Black);
        private string cellValue = string.Empty;

        public DataGridViewPrint(DataGridView dataGridView)
        {
            this.dataGridView = dataGridView;
            printDocument = new PrintDocument();
            printDocument.PrintPage += new PrintPageEventHandler(this.printDocument_PrintPage);
        }

        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //for (; dgvIndex < dataGridView.Length; dgvIndex++)

            rowCount = dataGridView.Rows.Count - 1;
            colCount = dataGridView.ColumnCount;
            //print headings
            y += rowGap;
            x = leftMargin;
            for (int j = 0; j < colCount; j++)
            {
                if (dataGridView.Columns[j].Width > 0)
                {
                    cellValue = dataGridView.Columns[j].HeaderText;
                    e.Graphics.FillRectangle(new SolidBrush(Color.LightGray), x, y, dataGridView.Columns[j].Width, rowGap);
                    e.Graphics.DrawRectangle(Pens.Black, x, y, dataGridView.Columns[j].Width, rowGap);
                    e.Graphics.DrawString(cellValue, headingFont, brush, x, y);
                    x += dataGridView.Columns[j].Width;
                }
            }

            //print all rows
            for (; i < rowCount; i++)
            {
                y += rowGap;
                x = leftMargin;
                for (int j = 0; j < colCount; j++)
                {
                    if (dataGridView.Columns[j].Width > 0)
                    {
                        cellValue = dataGridView.Rows[i].Cells[j].Value.ToString();
                        e.Graphics.DrawRectangle(Pens.Black, x, y, dataGridView.Columns[j].Width, rowGap);
                        e.Graphics.DrawString(cellValue, font, brush, x, y);
                        x += dataGridView.Columns[j].Width;
                    }
                }
                if (y >= e.PageBounds.Height - 80)
                {
                    // 允許多頁打印
                    y = 0;
                    e.HasMorePages = true;
                    i++;
                    return;
                }
            }
            y += rowGap;
            for (int j = 0; j < colCount; j++)
            {
                e.Graphics.DrawString(" ", font, brush, x, y);
            }
            i = 0;

            e.HasMorePages = false;
        }

        public PrintDocument GetPrintDocument()
        {
            return printDocument;
        }

        public void Print()
        {
            try
            {
                pageSetupDialog = new PageSetupDialog();
                pageSetupDialog.Document = printDocument;
                PageSettings ps = new PageSettings();
                pageSetupDialog.PageSettings = ps;
                pageSetupDialog.ShowDialog();
                printPreviewDialog = new PrintPreviewDialog();
                printPreviewDialog.Document = printDocument;
                printPreviewDialog.Height = 600;
                printPreviewDialog.Width = 800;
                printPreviewDialog.ShowDialog();
            }
            catch (Exception e)
            {
                throw new Exception("Printer error." + e.Message);
            }
        }
    }
}
