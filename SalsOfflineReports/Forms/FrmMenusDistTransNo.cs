using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using SalsOfflineReports.Class;
using Application = Microsoft.Office.Interop.Excel.Application;


namespace SalsOfflineReports.Forms
{
    public partial class FrmMenusDistTransNo : Form
    {
        private readonly PegasusEntities _dbEntities = new PegasusEntities();
        private readonly DeptRequisationViewModel _deptreq = new DeptRequisationViewModel();
        private readonly BookingDetailsViewModel _book = new BookingDetailsViewModel();
        private readonly BookMenusViewModel bookMenus = new BookMenusViewModel();
        private readonly AddonsViewModel addonsMenus=new AddonsViewModel();

        public FrmMenusDistTransNo()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            if (txt_transNo.Text == String.Empty)
            {
                MessageBox.Show(@"No Transaction No. Found", @" Transaction No. Not Found", MessageBoxButtons.OK);
                txt_transNo.Focus();
            }
            else
            {

                int trNo = Convert.ToInt32(txt_transNo.Text.Trim());

                var path = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                var isrecordexist = _dbEntities.Bookings
                    .FirstOrDefault(x => x.trn_Id == trNo);

                if (isrecordexist != null)
                {

                    //var exlApp = new Application { Visible = true };
                    var exlApp = new Application();
                    var exlWorkBook = (Excel._Workbook)(exlApp.Workbooks.Add(""));
                    var exlWorkSheet = (Excel._Worksheet)exlWorkBook.ActiveSheet;
                    object misvalue = System.Reflection.Missing.Value;

                    try
                    {
                        int bookrow = 0;

                        //get bookking details
                        var bookingDetails = _book.GetBookingDetails(trNo);

                        if (bookingDetails != null)
                        {
                            DateTime eventTime = DateTime.Today.Add(bookingDetails.EventDate.TimeOfDay);
                            var displaytime = eventTime.ToString("hh:mm tt");

                            Excel.Style style = exlWorkBook.Styles.Add("inputstyle");
                            style.Font.Name = "Courier New";

                            //get list of departments
                            var listofdept = _deptreq.GetDeptByRequisation(trNo);

                            int row = 1;
                            int j = 0;
                          


                            var deptRequisationViewModels = listofdept as IList<DeptRequisationViewModel> ?? listofdept.ToList();
                            //int rowcount = deptRequisationViewModels.Count() / 2;

                            //rowline = rowcount % 2 == 0 ? rowcount : rowcount + 1;
                            int columnjump = 0;
                            bookrow = 21;

                            for (int i = 0; i < deptRequisationViewModels.Count(); i++)
                            {
                                int col = 0;


                                if (i == 2)
                                {
                                    row = 25;
                                    bookrow = bookrow + 27;
                                }

                                else if (i == 4)
                                {

                                    row = 1;
                                    columnjump = 12;
                                    bookrow = 21;
                                }
                                else if (i == 6)
                                {
                                    row = 1;
                                    columnjump = 24;
                                }

                                //get mod for column ordering
                                //col = i % 2 == 0 ? 1 : 8;

                                if (i % 2 == 0)
                                {
                                    col = columnjump + 1;
                                    j = 0;
                                

                                   
                                }
                                else
                                {
                                    col = columnjump + 7;
                                    j = 0;
                                }
                          
                                //Department
                                exlWorkSheet.Range[exlWorkSheet.Cells[row, col], exlWorkSheet.Cells[row, col + 1]].Merge();
                                exlWorkSheet.Range[exlWorkSheet.Cells[row, col], exlWorkSheet.Cells[row, col + 1]].Font.Bold = true;
                                exlWorkSheet.Range[exlWorkSheet.Cells[row, col], exlWorkSheet.Cells[row, col + 1]].Font.Size = 14;
                                exlWorkSheet.Cells[row, col] = "Department:";

                                exlWorkSheet.Range[exlWorkSheet.Cells[row, col + 2], exlWorkSheet.Cells[row, col + 4]].Font.Size = 14;
                                exlWorkSheet.Range[exlWorkSheet.Cells[row, col + 2], exlWorkSheet.Cells[row, col + 4]].Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                                exlWorkSheet.Range[exlWorkSheet.Cells[row, col + 2], exlWorkSheet.Cells[row, col + 4]].Merge();
                                exlWorkSheet.Cells[row, col + 2] = deptRequisationViewModels.ElementAt(i).Deptname;

                                //var dept= deptRequisationViewModels.ElementAt(i).Deptname;

                                //Event Date
                                j = j + 1;
                                exlWorkSheet.Range[exlWorkSheet.Cells[row + j, col], exlWorkSheet.Cells[row + j, col + 1]].Merge();
                                //exlWorkSheet.Range[exlWorkSheet.Cells[row+j, col], exlWorkSheet.Cells[row + j, col + 1]].Font.Bold = true;
                                exlWorkSheet.Range[exlWorkSheet.Cells[row + j, col], exlWorkSheet.Cells[row + j, col + 1]].Font.Size = 13;
                                exlWorkSheet.Cells[row + j, col] = "Event Date:";


                                exlWorkSheet.Range[exlWorkSheet.Cells[row + j, col + 2], exlWorkSheet.Cells[row + j, col + 4]].Style = "inputstyle";
                                exlWorkSheet.Range[exlWorkSheet.Cells[row + j, col + 2], exlWorkSheet.Cells[row + j, col + 4]].Font.Size = 13;
                                exlWorkSheet.Range[exlWorkSheet.Cells[row + j, col + 2], exlWorkSheet.Cells[row + j, col + 4]].Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                                exlWorkSheet.Range[exlWorkSheet.Cells[row + j, col + 2], exlWorkSheet.Cells[row + j, col + 4]].Merge();
                                exlWorkSheet.Range[exlWorkSheet.Cells[row + j, col + 2], exlWorkSheet.Cells[row + j, col + 4]].HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                                exlWorkSheet.Cells[row + j, col + 2] = bookingDetails.EventDate.ToString("MMM d,yyyy");

                                //Event Time
                                j = j + 1;
                                exlWorkSheet.Range[exlWorkSheet.Cells[row + j, col], exlWorkSheet.Cells[row + j, col + 1]].Merge();
                                //exlWorkSheet.Range[exlWorkSheet.Cells[row, col], exlWorkSheet.Cells[row, col + 1]].Font.Bold = true;
                                exlWorkSheet.Range[exlWorkSheet.Cells[row + j, col], exlWorkSheet.Cells[row + j, col + 1]].Font.Size = 13;
                                exlWorkSheet.Cells[row + j, col] = "Event Time:";


                                exlWorkSheet.Range[exlWorkSheet.Cells[row + j, col + 2], exlWorkSheet.Cells[row + j, col + 4]].Style = "inputstyle";
                                exlWorkSheet.Range[exlWorkSheet.Cells[row + j, col + 2], exlWorkSheet.Cells[row + j, col + 4]].Font.Size = 13;
                                exlWorkSheet.Range[exlWorkSheet.Cells[row + j, col + 2], exlWorkSheet.Cells[row + j, col + 4]].Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                                exlWorkSheet.Range[exlWorkSheet.Cells[row + j, col + 2], exlWorkSheet.Cells[row + j, col + 4]].Merge();
                                exlWorkSheet.Range[exlWorkSheet.Cells[row + j, col + 2],
                                    exlWorkSheet.Cells[row + j, col + 4]].HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                                exlWorkSheet.Cells[row + j, col + 2] = displaytime;

                                //No of Pax
                                j = j + 1;
                                exlWorkSheet.Range[exlWorkSheet.Cells[row + j, col], exlWorkSheet.Cells[row + j, col + 1]].Merge();
                                //exlWorkSheet.Range[exlWorkSheet.Cells[row, col], exlWorkSheet.Cells[row, col + 1]].Font.Bold = true;
                                exlWorkSheet.Range[exlWorkSheet.Cells[row + j, col], exlWorkSheet.Cells[row + j, col + 1]].Font.Size = 13;
                                exlWorkSheet.Cells[row + j, col] = "No of Pax:";


                                exlWorkSheet.Range[exlWorkSheet.Cells[row + j, col + 2], exlWorkSheet.Cells[row + j, col + 4]].Style = "inputstyle";
                                exlWorkSheet.Range[exlWorkSheet.Cells[row + j, col + 2], exlWorkSheet.Cells[row + j, col + 4]].Font.Size = 13;
                                exlWorkSheet.Range[exlWorkSheet.Cells[row + j, col + 2], exlWorkSheet.Cells[row + j, col + 4]].Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                                exlWorkSheet.Range[exlWorkSheet.Cells[row + j, col + 2], exlWorkSheet.Cells[row + j, col + 4]].Merge();
                                exlWorkSheet.Range[exlWorkSheet.Cells[row + j, col + 2], exlWorkSheet.Cells[row + j, col + 4]].HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                                exlWorkSheet.Cells[row + j, col + 2] = bookingDetails.NoofPax.ToString();

                                //Venue
                                j = j + 1;
                                exlWorkSheet.Range[exlWorkSheet.Cells[row + j, col], exlWorkSheet.Cells[row + j, col + 1]].Merge();
                                //exlWorkSheet.Range[exlWorkSheet.Cells[row, col], exlWorkSheet.Cells[row, col + 1]].Font.Bold = true;
                                exlWorkSheet.Range[exlWorkSheet.Cells[row + j, col], exlWorkSheet.Cells[row + j, col + 1]].Font.Size = 13;
                                exlWorkSheet.Cells[row + j, col] = "Event Venue:";


                                exlWorkSheet.Range[exlWorkSheet.Cells[row + j, col + 2], exlWorkSheet.Cells[row + j, col + 4]].Style = "inputstyle";
                                exlWorkSheet.Range[exlWorkSheet.Cells[row + j, col + 2], exlWorkSheet.Cells[row + j, col + 4]].Font.Size = 13;
                                exlWorkSheet.Range[exlWorkSheet.Cells[row + j, col + 2], exlWorkSheet.Cells[row + j, col + 4]].Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                                exlWorkSheet.Range[exlWorkSheet.Cells[row + j, col + 2], exlWorkSheet.Cells[row + j, col + 4]].Merge();
                                exlWorkSheet.Range[exlWorkSheet.Cells[row + j, col + 2], exlWorkSheet.Cells[row + j, col + 4]].HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                                exlWorkSheet.Cells[row + j, col + 2] = bookingDetails.EventVenue;


                                //======================= Menus ========================================================================

                                j = j + 2;
                                exlWorkSheet.Range[exlWorkSheet.Cells[row + j, col], exlWorkSheet.Cells[row + j, col + 4]].Merge();
                                exlWorkSheet.Range[exlWorkSheet.Cells[row + j, col], exlWorkSheet.Cells[row + j, col + 4]].Font.Bold = true;
                                exlWorkSheet.Range[exlWorkSheet.Cells[row + j, col], exlWorkSheet.Cells[row + j, col + 4]].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                exlWorkSheet.Range[exlWorkSheet.Cells[row + j, col], exlWorkSheet.Cells[row + j, col + 4]].Font.Size = 13;
                                exlWorkSheet.Range[exlWorkSheet.Cells[row + j, col], exlWorkSheet.Cells[row + j, col + 4]].Font.Underline = true;
                                exlWorkSheet.Cells[row + j, col] = "MENUS:";

                                int ele = i;

                                var menus = bookMenus.GetBookMenus(trNo)
                                    .Where(m => m.deptid == deptRequisationViewModels.ElementAt(ele).DeptId);



                                int menurow = row + j + 1;
                                int menucount = 1;

                                foreach (var menu in menus)//===============List all Menus========================================================================
                                {

                                    exlWorkSheet.Range[exlWorkSheet.Cells[menurow + menucount, col], exlWorkSheet.Cells[menurow + menucount, col]].Style = "inputstyle";
                                    exlWorkSheet.Range[exlWorkSheet.Cells[menurow + menucount, col], exlWorkSheet.Cells[menurow + menucount, col]].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                    exlWorkSheet.Range[exlWorkSheet.Cells[menurow + menucount, col], exlWorkSheet.Cells[menurow + menucount, col]].Font.Bold = true;
                                    exlWorkSheet.Range[exlWorkSheet.Cells[menurow + menucount, col], exlWorkSheet.Cells[menurow + menucount, col]].Font.Size = 12;
                                    exlWorkSheet.Cells[menurow + menucount, col] = $"{menucount}.";


                                    exlWorkSheet.Range[exlWorkSheet.Cells[menurow + menucount, col + 1], exlWorkSheet.Cells[menurow + menucount, col + 3]].Style = "inputstyle";
                                    exlWorkSheet.Range[exlWorkSheet.Cells[menurow + menucount, col + 1], exlWorkSheet.Cells[menurow + menucount, col + 3]].HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                                    exlWorkSheet.Range[exlWorkSheet.Cells[menurow + menucount, col + 1], exlWorkSheet.Cells[menurow + menucount, col + 3]].Font.Size = 12;
                                    exlWorkSheet.Cells[menurow + menucount, col + 1] = menu.menu_name;

                                    menucount++;

                                }
                                //====================================================================================================================================

                                var addons = addonsMenus.BookAddonsList().Where(m => m.deptId == deptRequisationViewModels.ElementAt(ele).DeptId && m.TransId==trNo);

                                //add-ons list
                                foreach (var addon in addons)
                                {
                                    exlWorkSheet.Range[exlWorkSheet.Cells[menurow + menucount, col], exlWorkSheet.Cells[menurow + menucount, col]].Style = "inputstyle";
                                    exlWorkSheet.Range[exlWorkSheet.Cells[menurow + menucount, col], exlWorkSheet.Cells[menurow + menucount, col]].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                    exlWorkSheet.Range[exlWorkSheet.Cells[menurow + menucount, col], exlWorkSheet.Cells[menurow + menucount, col]].Font.Bold = true;
                                    exlWorkSheet.Range[exlWorkSheet.Cells[menurow + menucount, col], exlWorkSheet.Cells[menurow + menucount, col]].Font.Size = 12;
                                    exlWorkSheet.Cells[menurow + menucount, col] = $"{menucount}.";


                                    exlWorkSheet.Range[exlWorkSheet.Cells[menurow + menucount, col + 1], exlWorkSheet.Cells[menurow + menucount, col + 3]].Style = "inputstyle";
                                    exlWorkSheet.Range[exlWorkSheet.Cells[menurow + menucount, col + 1], exlWorkSheet.Cells[menurow + menucount, col + 3]].HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                                    exlWorkSheet.Range[exlWorkSheet.Cells[menurow + menucount, col + 1], exlWorkSheet.Cells[menurow + menucount, col + 3]].Font.Size = 12;
                                    exlWorkSheet.Cells[menurow + menucount, col + 1] = addon.AddonsDescription;
                                }

                                //Customer
                                exlWorkSheet.Range[exlWorkSheet.Cells[bookrow, col], exlWorkSheet.Cells[bookrow, col + 1]].Merge();
                                exlWorkSheet.Range[exlWorkSheet.Cells[bookrow, col], exlWorkSheet.Cells[bookrow, col + 1]].Font.Bold = true;
                                exlWorkSheet.Range[exlWorkSheet.Cells[bookrow, col], exlWorkSheet.Cells[bookrow, col + 1]].Font.Size = 13;
                                exlWorkSheet.Cells[bookrow, col] = "Customer:";


                                exlWorkSheet.Range[exlWorkSheet.Cells[bookrow, col + 2], exlWorkSheet.Cells[bookrow, col + 4]].Style = "inputstyle";
                                exlWorkSheet.Range[exlWorkSheet.Cells[bookrow, col + 2], exlWorkSheet.Cells[bookrow, col + 4]].Font.Size = 13;
                                exlWorkSheet.Range[exlWorkSheet.Cells[bookrow, col + 2], exlWorkSheet.Cells[bookrow, col + 4]].Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                                exlWorkSheet.Range[exlWorkSheet.Cells[bookrow, col + 2], exlWorkSheet.Cells[bookrow, col + 4]].Merge();
                                exlWorkSheet.Range[exlWorkSheet.Cells[bookrow, col + 2], exlWorkSheet.Cells[bookrow, col + 4]].HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                                exlWorkSheet.Cells[bookrow, col + 2] = bookingDetails.CustomerName;


                                //Book No
                                exlWorkSheet.Range[exlWorkSheet.Cells[bookrow+1, col], exlWorkSheet.Cells[bookrow+1, col + 1]].Merge();
                                exlWorkSheet.Range[exlWorkSheet.Cells[bookrow+1, col], exlWorkSheet.Cells[bookrow+1, col + 1]].Font.Bold = true;
                                exlWorkSheet.Range[exlWorkSheet.Cells[bookrow+1, col], exlWorkSheet.Cells[bookrow+1, col + 1]].Font.Size = 13;
                                exlWorkSheet.Cells[bookrow+1, col] = "Book No:";


                                exlWorkSheet.Range[exlWorkSheet.Cells[bookrow+1, col + 2], exlWorkSheet.Cells[bookrow+1, col + 4]].Style = "inputstyle";
                                exlWorkSheet.Range[exlWorkSheet.Cells[bookrow+1, col + 2], exlWorkSheet.Cells[bookrow+1, col + 4]].Font.Size = 13;
                                exlWorkSheet.Range[exlWorkSheet.Cells[bookrow+1, col + 2], exlWorkSheet.Cells[bookrow+1, col + 4]].Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                                exlWorkSheet.Range[exlWorkSheet.Cells[bookrow+1, col + 2], exlWorkSheet.Cells[bookrow+1, col + 4]].Merge();
                                exlWorkSheet.Range[exlWorkSheet.Cells[bookrow+1, col + 2], exlWorkSheet.Cells[bookrow+1, col + 4]].HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                                exlWorkSheet.Cells[bookrow+1, col + 2] = bookingDetails.TransId;

                                //bookrow = 23;

                                if (bookrow == 21)
                                {
                                    int seprow = bookrow + 2;
                                    //line separator
                                    exlWorkSheet.Range[exlWorkSheet.Cells[seprow, col], exlWorkSheet.Cells[seprow, col + 4]].Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDashDot;

                                }

                            }




                            exlWorkSheet.PageSetup.LeftMargin = 0.6;
                            exlWorkSheet.PageSetup.RightMargin = 0.6;
                            exlWorkSheet.PageSetup.TopMargin = 0.8;
                            exlWorkSheet.PageSetup.BottomMargin = 0.8;

                            //exlWorkSheet.PrintPreview();
                            exlApp.Visible = false;
                            exlApp.UserControl = false;
                            exlWorkBook.SaveAs(path + "\\requisation.xlsx", Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing, false, false, Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                        }
                        else
                        {
                            MessageBox.Show(@"Invalid Operation", @" Record Does Not Exist", MessageBoxButtons.OK);
                            txt_transNo.Focus();
                        }
                    }
                    catch (Exception exception)
                    {
                        if (exception.InnerException != null)
                            MessageBox.Show(@"Invalid Operation", exception.InnerException.Message,
                                MessageBoxButtons.OK);
                    }
                    finally
                    {
                        exlApp.WindowState = Microsoft.Office.Interop.Excel.XlWindowState.xlMaximized;
                        exlApp.Visible = true;
                        exlApp.ActiveWorkbook.PrintPreview();
                        //exlWorkSheet.PrintPreview();
                        exlWorkBook.Close();
                        exlApp.Quit();

                        Marshal.ReleaseComObject(exlWorkSheet);
                        Marshal.ReleaseComObject(exlWorkBook);

                        GC.GetTotalMemory(false);
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                        GC.Collect();
                        GC.GetTotalMemory(true);


                        Close();

                    }





                }
                else
                {
                    MessageBox.Show(@"Invalid Operation", @" Record Does Not Exist", MessageBoxButtons.OK);
                    txt_transNo.Focus();
                }

            }
        }

        private void txt_transNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
                txt_transNo.Focus();
            }
        }
    }
}
