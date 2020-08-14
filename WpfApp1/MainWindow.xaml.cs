using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int CountInput;

        public MainWindow()
        {
            InitializeComponent();
        }

        struct PhotoDateYearMonthDay
        {
            public string PhotoDate { get; set; }
            public string PhotoYear { get; set; }
            public string PhotoMonth { get; set; }
            public string PhotoDay { get; set; }
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void BtnOpenFolderInput_Click(object sender, RoutedEventArgs e)
        {

            var openFolderDialog = new CommonOpenFileDialog
            {
                IsFolderPicker = true
            };
            CommonFileDialogResult result = openFolderDialog.ShowDialog();
            if (result == CommonFileDialogResult.Ok)
            {
                txbFolderInput.Text = openFolderDialog.FileName;
            }
            if (txbFolderInput.Text != "")
            {
                SearchAddFiles();
                ListViewOutput.Items.Clear();
                ListViewFailed.Items.Clear();
                lblCountOutput.Content = "Count: 0";
                lblCountFailed.Content = "Failed: 0";
                pBar1.Minimum = 0;
                // Set Maximum to the total number of files to copy.
                pBar1.Maximum = 100;
                // Set the initial value of the ProgressBar.
                pBar1.Value = 0;
            }

        }

        private void SearchAddFiles()
        {
            CountInput = 0;
            var extensions = new List<string> { ".jpg", ".jpeg", ".png", ".tiff", ".JPG", ".JPEG", ".PNG", ".TIFF" };
            ListViewInput.Items.Clear();
            string[] fileEntries = Directory.GetFiles(txbFolderInput.Text, "*.*", SearchOption.AllDirectories)
                    .Where(f => extensions.IndexOf(System.IO.Path.GetExtension(f)) >= 0).ToArray();
            foreach (string fileName in fileEntries)
            {
                ListViewInput.Items.Add(fileName);
                CountInput++;
            }
            lblCountInput.Content = "Count: " + CountInput;

        }

        private void BtnOpenFolderOutput_Click(object sender, RoutedEventArgs e)
        {
            var openFolderDialog = new CommonOpenFileDialog
            {
                IsFolderPicker = true
            };
            CommonFileDialogResult result = openFolderDialog.ShowDialog();
            if (result == CommonFileDialogResult.Ok)
            {
                txbFolderOutput.Text = openFolderDialog.FileName;
            }
        }

        private void ChbMakeFolders_Click(object sender, RoutedEventArgs e)
        {
            chbMakeFoldersYear.IsChecked = chbMakeFolders.IsChecked;
            chbMakeFoldersMonth.IsChecked = chbMakeFolders.IsChecked;
            chbMakeFoldersDay.IsChecked = chbMakeFolders.IsChecked;
        }


        private void ChbRenameOriginal_Click(object sender, RoutedEventArgs e)
        {
            chbMakeFolders.IsChecked = !chbRenameOriginal.IsChecked;
            chbMakeFoldersYear.IsChecked = chbMakeFolders.IsChecked;
            chbMakeFoldersMonth.IsChecked = chbMakeFolders.IsChecked;
            chbMakeFoldersDay.IsChecked = chbMakeFolders.IsChecked;
            chbDeleteOriginal.IsChecked = false;
            chbMakeFolders.IsEnabled = !chbRenameOriginal.IsChecked.Value;
            chbMakeFoldersYear.IsEnabled = chbMakeFolders.IsChecked.Value;
            chbMakeFoldersMonth.IsEnabled = chbMakeFolders.IsChecked.Value;
            chbMakeFoldersDay.IsEnabled = chbMakeFolders.IsChecked.Value;
            chbDeleteOriginal.IsEnabled = chbMakeFolders.IsChecked.Value;
            txbFolderOutput.Text = chbRenameOriginal.IsChecked.Value ? "   " : "";
            btnOpenFolderOutput.IsEnabled = !chbRenameOriginal.IsChecked.Value;
            txbFolderOutput.IsEnabled = !chbRenameOriginal.IsChecked.Value;
        }


        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            GridLists.Height = this.ActualHeight - 190;
        }


        private void ListViewInput_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            string selectedFile = ListViewInput.SelectedItems[0].ToString();

            // If it's a file open it
            if (File.Exists(System.IO.Path.Combine(selectedFile)))
            {
                try
                {
                    System.Diagnostics.Process.Start(selectedFile);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.StackTrace);
                }
            }
        }

        private void ListViewOutput_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            string selectedFile = ListViewOutput.SelectedItems[0].ToString();

            // If it's a file open it
            if (File.Exists(System.IO.Path.Combine(selectedFile)))
            {
                try
                {
                    System.Diagnostics.Process.Start(selectedFile);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.StackTrace);
                }
            }
        }


        private void BtnRename_Click(object sender, RoutedEventArgs e)
        {
            if ((txbFolderInput.Text != "") && (txbFolderOutput.Text != "") && (ListViewInput.Items.Count > 0))
            {
                pBar1.Minimum = 1;
                // Set Maximum to the total number of files to copy.
                pBar1.Maximum = CountInput;
                // Set the initial value of the ProgressBar.
                pBar1.Value = 1;

                int ind = new int();
                int indFailed = new int();

                ListViewOutput.Items.Clear();
                ListViewFailed.Items.Clear();

                lblCountOutput.Content = "Count: 0";
                lblCountFailed.Content = "Failed: 0";

                foreach (string ListFileName in ListViewInput.Items)
                {
                    try
                    {
                        var PhotoStruct = ReturnDataFile(ListFileName,ind);

                        var fileName = PhotoStruct.PhotoDate;

                        if (chbRenameOriginal.IsChecked.Value)
                        {
                            FileInfo file = new FileInfo(ListFileName);
                            var destFile = System.IO.Path.Combine(file.Directory.FullName, fileName);
                            System.IO.File.Move(ListFileName, destFile);
                            ListViewOutput.Items.Add(destFile);
                        }
                        else
                        {
                            var FolderName = txbFolderOutput.Text + (chbMakeFoldersYear.IsChecked.Value ? "\\" + PhotoStruct.PhotoYear : "")
                                + (chbMakeFoldersMonth.IsChecked.Value ? "\\" + PhotoStruct.PhotoYear + "_" + PhotoStruct.PhotoMonth : "")
                                + (chbMakeFoldersDay.IsChecked.Value ? "\\" + PhotoStruct.PhotoYear + "_" + PhotoStruct.PhotoMonth + "_" + PhotoStruct.PhotoDay : "");
                            if (!Directory.Exists(FolderName))
                            {
                                Directory.CreateDirectory(FolderName);
                            }
                            var destFile = System.IO.Path.Combine(FolderName, fileName);
                            File.Copy(ListFileName, destFile, true);
                            ListViewOutput.Items.Add(destFile);
                            if (chbDeleteOriginal.IsChecked.Value)
                            {
                                File.Delete(ListFileName);
                            }
                        }
                        ind++;
                        pBar1.Value++;
                    }
                    catch (Exception)
                    {

                        ListViewFailed.Items.Add(ListFileName);
                        indFailed++;
                    }
                }
                if (chbDeleteOriginal.IsChecked.Value)
                {
                    ListViewInput.Items.Clear();
                    lblCountInput.Content = "Count: 0";
                }
                lblCountOutput.Content = "Count: " + ind;
                lblCountFailed.Content = "Failed: " + indFailed;
            }
        }

        private static PhotoDateYearMonthDay ReturnDataFile(string fileName, int ind)
        {
            PhotoDateYearMonthDay PhotoStruct = new PhotoDateYearMonthDay();
            BitmapCreateOptions createOptions = BitmapCreateOptions.PreservePixelFormat | BitmapCreateOptions.IgnoreColorProfile;

            using (Stream sourceStream = File.Open(fileName, FileMode.Open, FileAccess.Read))
            {
                BitmapDecoder sourceDecoder = BitmapDecoder.Create(sourceStream, createOptions, BitmapCacheOption.Default);
                // Check source is has valid frames 
                if (sourceDecoder.Frames[0] != null && sourceDecoder.Frames[0].Metadata != null)
                {
                    sourceDecoder.Frames[0].Metadata.Freeze();
                    // Get a clone copy of the metadata
                    BitmapMetadata sourceMetadata = sourceDecoder.Frames[0].Metadata.Clone() as BitmapMetadata;

                    PhotoStruct.PhotoDate = Convert.ToDateTime(sourceMetadata.DateTaken).ToString("yyyy_MM_dd HH_mm_ss") +"_"+ ind + "." + sourceMetadata.Format;
                    PhotoStruct.PhotoYear = Convert.ToDateTime(sourceMetadata.DateTaken).ToString("yyyy");
                    PhotoStruct.PhotoMonth = Convert.ToDateTime(sourceMetadata.DateTaken).ToString("MM");
                    PhotoStruct.PhotoDay = Convert.ToDateTime(sourceMetadata.DateTaken).ToString("dd");
                }
            }
            return PhotoStruct;
        }

    }
}
