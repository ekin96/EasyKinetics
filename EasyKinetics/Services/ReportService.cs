using System;
using System.IO;
using System.Threading.Tasks;
using System.Security.Permissions;
using EasyKinetics.Models;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

namespace EasyKinetics.Services
{
    public static class ReportService
    {
        public static async Task SEKReportWriterAsync()
        {
            //if (vEK1.Kcat == 0) return;

            string CurDir = Directory.GetCurrentDirectory();

            //System.Security.AccessControl.AccessControlActions.Change 

            string ReportFolder = "EasyKinetics_Reports";

            string DesktopPath = @"C:\";

            string ReportPath = Path.Combine(DesktopPath, ReportFolder);

            Directory.CreateDirectory(ReportPath);

            if (!Directory.Exists(ReportPath))
            {
                try
                {
                    Directory.CreateDirectory(ReportPath);
                }
                catch (IOException ie)
                {
                    MessageDialog msg = new MessageDialog("IO Error: " + ie.Message);
                    await msg.ShowAsync();
                }
                catch (Exception e)
                {
                    MessageDialog msg = new MessageDialog("General Error: " + e.Message);
                    await msg.ShowAsync();
                }
            }

            string ReportDir = await pickDirectory(ReportFolder);

            Directory.SetCurrentDirectory(ReportDir);
            CurDir = Directory.GetCurrentDirectory();

/*            string ReportDate = GetReportDate();
            string ReportName = String.Concat("Simple Enzimatic Kinetics_Report_", ReportDate, ".txt");

            using (StreamWriter sw = File.CreateText(ReportName))
            {
                sw.WriteLine("Simple Enzyme Kinetics Report \n");
                sw.WriteLine(String.Concat(
                    "DateTime: ",
                    ReportDate.Substring(6, 2), "-",  // giorno
                    ReportDate.Substring(4, 2), "-",  // mese
                    ReportDate.Substring(0, 4), " ",  // anno
                    ReportDate.Substring(8, 2), ":",  // ore
                    ReportDate.Substring(10, 2), ":", // minuti
                    ReportDate.Substring(12, 2), "\n" // secondi
                ));

                sw.WriteLine(GetFormattedString(0, "Input", vEK1.EnzymeSubunits.ToString("#0.000000"), " "));
                sw.WriteLine(GetFormattedString(4, "Number of enzyme subunits", vEK1.EnzymeSubunits.ToString("#0.000000"), " "));
                sw.WriteLine(GetFormattedString(4, "Product Molecular Weight", vEK1.MolecularWeight.ToString("#0.000000"), "g/mol"));

                sw.WriteLine("");
                sw.WriteLine(GetFormattedString("Samples absorption change per minute", "", ""));
                sw.WriteLine(GetFormattedString("    Lower substrate concentration", vEK1.lSC.ToString("#0.000000"), "\u03BCM"));
                sw.WriteLine(GetFormattedString("        1st sample", vEK1.lSC_dAbsmin_1.ToString("#0.000000"), "\u0394Abs/min"));
                sw.WriteLine(GetFormattedString("        2nd sample", vEK1.lSC_dAbsmin_2.ToString("#0.000000"), "\u0394Abs/min"));
                sw.WriteLine(GetFormattedString("    Higher substrate concentration", vEK1.hSC.ToString("#0.000000"), "\u03BCM"));
                sw.WriteLine(GetFormattedString("        1st sample", vEK1.hSC_dAbsmin_1.ToString("#0.000000"), "\u0394Abs/min"));
                sw.WriteLine(GetFormattedString("        2nd sample", vEK1.hSC_dAbsmin_2.ToString("#0.000000"), "\u0394Abs/min"));
                sw.WriteLine(GetFormattedString("    Very high substrate concentration", vEK1.Absorbance_SubstrateConcentration.ToString("#0.000000"), "\u03BCM"));
                sw.WriteLine(GetFormattedString("        Test result", vEK1.Absorbance.ToString("#0.000000"), "\u0394Abs/min"));

                sw.WriteLine("");
                sw.WriteLine("Enzymatic Units Assay");
                sw.WriteLine(GetFormattedString("Molar extinction coefficient", vEK1.epsilon0.ToString("#0.000000"), String.Empty));
                sw.WriteLine(GetFormattedString("Optical path", vEK1.OpticalPath.ToString("#0.000000"), "cm"));
                sw.WriteLine(GetFormattedString("Initial solution volume", vEK1.Vi.ToString("#0.000000"), "\u03BCl"));
                sw.WriteLine(GetFormattedString("Final solution volume", vEK1.Vf.ToString("#0.000000"), "\u03BCl"));

                sw.WriteLine("");
                sw.WriteLine("Resulting Reaction Parameters: \n");
                sw.WriteLine(GetFormattedString("Type of enzyme", vEK1.EnzymeType.ToString(), String.Empty));
                if (vEK1.SubstrateInhibition == 1)
                {
                    sw.WriteLine(GetFormattedString(String.Empty, "Substrate-Inhibition present", String.Empty));
                }
                sw.WriteLine(GetFormattedString("Vmax", vEK1.Vmax.ToString("#0.000000"), "\u0394Abs/min"));
                sw.WriteLine(GetFormattedString("Km", vEK1.Km.ToString("#0.000000"), "\u03BCM"));
                sw.WriteLine(GetFormattedString("Units/ml", vEK1.Unitsml.ToString("#0.000000"), "ml\u05BE\u00B9"));
                sw.WriteLine(GetFormattedString("Kcat", vEK1.Kcat.ToString("#0.000000"), "sec\u05BE\u00B9"));
                sw.WriteLine(GetFormattedString("Catalitic Efficiency", String.Concat("10^(", vEK1.Kcat.ToString("#0.000000"), ")"), String.Empty));
                
            }*/
        }

        public static async Task<string> pickDirectory(string repDir)
        {
            string folderName = repDir.Trim();

            // Section: Allows the user to choose their folder.
            FolderPicker fpFolder = new FolderPicker();
            fpFolder.SuggestedStartLocation = PickerLocationId.Desktop;
            fpFolder.ViewMode = PickerViewMode.Thumbnail;
            fpFolder.FileTypeFilter.Add("*");
            StorageFolder sfFolder = await fpFolder.PickSingleFolderAsync();

            if (sfFolder.Name != null)
            {
                // Gives the StorageFolder permissions to modify files in the specified folder.
                Windows.Storage.AccessCache.StorageApplicationPermissions.FutureAccessList.AddOrReplace("CSharp_Temp", sfFolder);

                // creates our folder
                await sfFolder.CreateFolderAsync(folderName, CreationCollisionOption.FailIfExists);

                // returns a string of our path back to the user
                return string.Concat(sfFolder.Path, @"\", folderName);
            }
            else
            {
                MessageDialog msg = new MessageDialog("Need to choose a folder.");
                await msg.ShowAsync();
                return "Error: Choose new folder.";
            }
        }

        public static string GetReportDate()
        {
            string Report_Date = String.Concat(
                DateTime.Now.Year.ToString("0000"),
                DateTime.Now.Month.ToString("00"),
                DateTime.Now.Day.ToString("00"),
                DateTime.Now.Hour.ToString("00"),
                DateTime.Now.Minute.ToString("00"),
                DateTime.Now.Second.ToString("00")
            );
            return Report_Date;
        }

        public static string GetFormattedString(int ptab, string ptext, string ctext, string stext)
        {
            string ftext = String.Empty;

            for (int i = 0; i < ptab; i++)
            {
                ftext += " ";
            }

            ftext = ptext;

            for (int i = ptext.Length; i < 40; i++)
            {
                ftext += " ";
            }

            ftext += ": ";

            if (ptext != "Type of enzyme")
            {
                for (int i = 0; i < 10.0 - ctext.Length; i++)
                {
                    ftext += " ";
                }
            }

            ftext += ctext;

            ftext += " " + stext;

            return ftext;
        }
    }
}
