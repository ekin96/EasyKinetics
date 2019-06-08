/**
   EasyKinetics (tools for analyses of enzymatic solutions)
   Copyright 2018-2019 by Gabriele Morabito<bioinformaticgears@gmail.com>
  
   This file is part of EasyKinetics application.
   
   EasyKinetics is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License 
   as published by the Free Software Foundation, either version 3 of the License, or any later version.
   
   EasyKinetics is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty 
   of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
 
   You should have received a copy of the GNU General Public License along with this program.
   If not, see <http://www.gnu.org/licenses/> .

   license GPL-3.0-or-later
 */

/* MAIN PAGE MANAGEMENT MODULE
   This module contains:
   - the starting activities initializing EasyKinetics
   - the actions performed clicking buttons on the different masks
   - the actions and checks triggered by data input
*/

using EasyKinetics.Models;
using EasyKinetics.Services;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml.Controls;

namespace EasyKinetics.Views
{
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        /*
            Procedure in EasyKinetics start:
                a - initialization of general components
                b - display of "Simple Enzyme Kinetics" mask, hiding the other ones
                c - reset of EasyKinetics flags
                d - hiding of Message Box, used to alert users for warnings and errors
                e - initialization of "Simple Enzyme Kinetics" mask and data vector
        */
        public MainPage()
        {
            InitializeComponent();

            cEK2.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            cEK3.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            cEK4.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            cEK5.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            cEK1.Visibility = Windows.UI.Xaml.Visibility.Visible;

            ComputingService.Reset_Flags();
            HideMsgBox();
            Initialize_EK1();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Set<T>(ref T storage, T value, [CallerMemberName]string propertyName = null)
        {
            if (Equals(storage, value))
            {
                return;
            }

            storage = value;
            OnPropertyChanged(propertyName);
        }

        private void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        /*
            Procedure to display Message Box, used to alert users for warnings and errors
        */
        private void ShowMsgBox(string MsgTitle, string MsgText)
        {
            if (MsgTitle == "Error")
            {
                MsgBoxText.Text = "REPEAT MEASUREMENTS\r\n\r\n";
            }
            else
            {
                MsgBoxText.Text = "SET DATA\r\n\r\n";
            }
            MsgBoxText.Text += MsgText;

            MsgBoxBrdEx.Width  = 462;
            MsgBoxBrdEx.Height = 232;
            MsgBoxBrdIn.Width  = 442;
            MsgBoxBrdIn.Height = 212;
            MsgBoxTitle.Width  = 422;
            MsgBoxTitle.Height = 30;
            MsgBoxText.Width   = 422;
            MsgBoxText.Height  = 100;
            MsgBoxBtBrd.Width  = 80;
            MsgBoxBtBrd.Height = 40;
            MsgBoxBtn.Width    = 80;
            MsgBoxBtn.Height   = 40;
        }

        /*
            Procedure to manage clicking of "Close" button in Message Box, used to alert users for warnings and errors
        */
        private void CloseMsgBox(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            HideMsgBox();
        }

        /*
            Procedure to hide Message Box, used to alert users for warnings and errors
        */
        private void HideMsgBox()
        {
            MsgBoxBrdEx.Width  = 0;
            MsgBoxBrdEx.Height = 0;
            MsgBoxBrdIn.Width  = 0;
            MsgBoxBrdIn.Height = 0;
            MsgBoxTitle.Width  = 0;
            MsgBoxTitle.Height = 0;
            MsgBoxText.Width   = 0;
            MsgBoxText.Height  = 0;
            MsgBoxBtBrd.Width = 0;
            MsgBoxBtBrd.Height = 0;
            MsgBoxBtn.Width    = 0;
            MsgBoxBtn.Height   = 0;
        }

        /*
            Procedure to manage clicking of "Close" button in License Message Box, used to alert users about license
        */
        private void CloseLicMsgBox(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            HideLicMsgBox();
        }

        /*
            Procedure to hide License Message Box, used to alert users about license
        */
        private void HideLicMsgBox()
        {
            LicMsgBoxBrdEx.Width = 0;
            LicMsgBoxBrdEx.Height = 0;
            LicMsgBoxBrdIn.Width = 0;
            LicMsgBoxBrdIn.Height = 0;
            LicMsgBoxTitle_a.Width = 0;
            LicMsgBoxTitle_a.Height = 0;
            LicMsgBoxTitle_b.Width = 0;
            LicMsgBoxTitle_b.Height = 0;
            LicMsgBoxText.Width = 0;
            LicMsgBoxText.Height = 0;
            LicMsgBoxLicBrd.Width = 0;
            LicMsgBoxLicBrd.Height = 0;
            LicMsgBoxLicBtn.Width = 0;
            LicMsgBoxLicBtn.Height = 0;
            LicMsgBoxCloseBrd.Width = 0;
            LicMsgBoxCloseBrd.Height = 0;
            LicMsgBoxCloseBtn.Width = 0;
            LicMsgBoxCloseBtn.Height = 0;
        }

        /*
            Procedure to show License Message Box, used to alert users about license
        */
        private void ShowLicMsgBox(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            LicMsgBoxBrdEx.Width = 432;
            LicMsgBoxBrdEx.Height = 232;
            LicMsgBoxBrdIn.Width = 442;
            LicMsgBoxBrdIn.Height = 212;
            LicMsgBoxTitle_a.Width = 422;
            LicMsgBoxTitle_a.Height = 30;
            LicMsgBoxTitle_b.Width = 422;
            LicMsgBoxTitle_b.Height = 30;
            LicMsgBoxText.Width = 422;
            LicMsgBoxText.Height = 60;
            LicMsgBoxLicBrd.Width = 80;
            LicMsgBoxLicBrd.Height = 40;
            LicMsgBoxLicBtn.Width = 80;
            LicMsgBoxLicBtn.Height = 40;
            LicMsgBoxCloseBrd.Width = 80;
            LicMsgBoxCloseBrd.Height = 40;
            LicMsgBoxCloseBtn.Width = 80;
            LicMsgBoxCloseBtn.Height = 40;
        }

        /*
            Procedure to show the Open Source License
        */
        private void ShowLicense(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            int curr_page = 1;
            flagLicense.currPage = curr_page;
            LicenseBoxPageNo.Text = curr_page.ToString("#0");
            string license_page = LicenseServices.GetLicensePage(curr_page);
            LicenseBoxText.Text = license_page;
            flagLicense.showPage = 1;
            ShowLicenseBox();
        }

        /*
            Procedure to hide the Open Source License
        */
        private void HideLicense(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            int curr_page = 1;
            flagLicense.currPage = curr_page;
            LicenseBoxPageNo.Text = "0";
            LicenseBoxText.Text = "";
            flagLicense.showPage = 0;
            ShowLicenseBox();
        }

        /*
            Procedure to view previous page of the Open Source License
        */
        private void LicensePreviousPage(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            int curr_page = flagLicense.currPage;
            if (curr_page > 1)
            {
                curr_page = curr_page - 1;
                flagLicense.currPage = curr_page;
                LicenseBoxPageNo.Text = curr_page.ToString("#0");
                string license_page = LicenseServices.GetLicensePage(curr_page);
                LicenseBoxText.Text = license_page;
            }
        }

        /*
            Procedure to view previous page of the Open Source License
        */
        private void LicenseNextPage(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            int curr_page = flagLicense.currPage;
            if (curr_page < 16)
            {
                curr_page = curr_page + 1;
                flagLicense.currPage = curr_page;
                LicenseBoxPageNo.Text = curr_page.ToString("#0");
                string license_page = LicenseServices.GetLicensePage(curr_page);
                LicenseBoxText.Text = license_page;
            }
        }

        /*
            Procedure to check the License page value inserted by the user
        */
        private void LicenseBoxPageNo_TextChanged(object sender, TextChangedEventArgs e)
        {
            string user_request = ComputingService.NumField(LicenseBoxPageNo.Text);
            LicenseBoxPageNo.Text = user_request;
            LicenseBoxPageNo.Select(user_request.Length, 0);
        }

        /*
            Procedure to change the License page requested by the user after moving the mouse
        */
        private void LicenseBoxPageNo_LostFocus(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            int requested_page = Int16.Parse("0" + LicenseBoxPageNo.Text);
            if (requested_page >= 1 && requested_page <= 16 && requested_page != flagLicense.currPage)
            {
                int curr_page = requested_page;
                flagLicense.currPage = curr_page;
                string license_page = LicenseServices.GetLicensePage(curr_page);
                LicenseBoxText.Text = license_page;
            }
            else if (requested_page < 1 || requested_page > 16)
            {
                LicenseBoxPageNo.Text = flagLicense.currPage.ToString("#0");
            }
        }

        /*
            Procedure to change the License page requested by the user clicking the ENTER key on the the keyboard
        */
        private void LicenseBoxPageNo_KeyDown(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                int requested_page = Int16.Parse("0" + LicenseBoxPageNo.Text);
                if (requested_page >= 1 && requested_page <= 16 && requested_page != flagLicense.currPage)
                {
                    int curr_page = requested_page;
                    flagLicense.currPage = curr_page;
                    string license_page = LicenseServices.GetLicensePage(curr_page);
                    LicenseBoxText.Text = license_page;
                }
                else if (requested_page < 1 || requested_page > 16)
                {
                    LicenseBoxPageNo.Text = flagLicense.currPage.ToString("#0");
                }
            }
        }

        /*
            Procedure to show or hide the License pop-up depending on the value of flag showPage in vector flagLicense
        */
        private void ShowLicenseBox()
        {
            LicenseBoxBrdEx.Width     = 572 * flagLicense.showPage;
            LicenseBoxBrdEx.Height    = 627 * flagLicense.showPage;
            LicenseBoxBrdIn.Width     = 562 * flagLicense.showPage;
            LicenseBoxBrdIn.Height    = 617 * flagLicense.showPage;
            LicenseBoxText.Width      = 542 * flagLicense.showPage;
            LicenseBoxText.Height     = 560 * flagLicense.showPage;
            LicenseBoxCloseBrd.Width  =  80 * flagLicense.showPage;
            LicenseBoxCloseBrd.Height =  40 * flagLicense.showPage;
            LicenseBoxCloseBtn.Width  =  80 * flagLicense.showPage;
            LicenseBoxCloseBtn.Height =  40 * flagLicense.showPage;
            LicenseBoxBackBrd.Width   =  60 * flagLicense.showPage;
            LicenseBoxBackBrd.Height  =  30 * flagLicense.showPage;
            LicenseBoxBackTxt.Width   =  20 * flagLicense.showPage;
            LicenseBoxBackTxt.Height  =  60 * flagLicense.showPage;
            LicenseBoxBackBtn.Width   =  60 * flagLicense.showPage;
            LicenseBoxBackBtn.Height  =  30 * flagLicense.showPage;
            LicenseBoxFwdBrd.Width    =  60 * flagLicense.showPage;
            LicenseBoxFwdBrd.Height   =  30 * flagLicense.showPage;
            LicenseBoxFwdTxt.Width    =  20 * flagLicense.showPage;
            LicenseBoxFwdTxt.Height   =  60 * flagLicense.showPage;
            LicenseBoxFwdBtn.Width    =  60 * flagLicense.showPage;
            LicenseBoxFwdBtn.Height   =  30 * flagLicense.showPage;
            LicenseBoxPageTxt.Width   =  45 * flagLicense.showPage;
            LicenseBoxPageTxt.Height  =  25 * flagLicense.showPage;
            LicenseBoxPageNo.Width    =  70 * flagLicense.showPage;
            LicenseBoxPageNo.Height   =  30 * flagLicense.showPage;
        }

        /*
            Procedure to initialize "Simple Enzyme Kinetics" mask and data vector
        */
        private void Initialize_EK1()
        {
            vEK1.lSC = 0;
            vEK1.lSC_dAbsmin_1 = 0;
            vEK1.lSC_dAbsmin_2 = 0;
            vEK1.lSC_dAbsmin = 0;
            vEK1.hSC = 0;
            vEK1.hSC_dAbsmin_1 = 0;
            vEK1.hSC_dAbsmin_2 = 0;
            vEK1.hSC_dAbsmin = 0;
            vEK1.Absorbance = 0;
            vEK1.Absorbance_SubstrateConcentration = 0;
            vEK1.ExpectedAbsorbance = 0;
            vEK1.SubstrateInhibition = 0;
            vEK1.x1 = 0;
            vEK1.x2 = 0;
            vEK1.y1 = 0;
            vEK1.y2 = 0;
            vEK1.tg_angolo = 0;
            vEK1.Vmax = 0;
            vEK1.reverse_Vmax = 0;
            vEK1.Km = 0;
            vEK1.reverse_Km = 0;
            vEK1.Ki = 1;
            vEK1.epsilon0 = 0;
            vEK1.OpticalPath = 0;
            vEK1.Vi = 0;
            vEK1.Vf = 0;
            vEK1.Unitsml = 0;
            vEK1.Kcat = 0;
            vEK1.CatalEff = 0;
            vEK1.SubstrateConcentration = 0;
            vEK1.HillCoeff = 0;
            vEK1.MolecularWeight = 0;
            vEK1.v0 = 0;
            vEK1.vmoli = 0;
            vEK1.SolProt_1 = 0;
            vEK1.SolProt_2 = 0;
            vEK1.SolBlank_1 = 0;
            vEK1.SolBlank_2 = 0;
            vEK1.vetot = 0;
            vEK1.vbtot = 0;
            vEK1.ConcProt = 0;
            vEK1.AttSpec = 0;

            EK1_lSC.Text = "0";
            EK1_lSC_dAbsmin1.Text = "0";
            EK1_lSC_dAbsmin2.Text = "0";
            EK1_lSC_dAbsmin.Text = "";
            EK1_hSC.Text = "0";
            EK1_hSC_dAbsmin1.Text = "0";
            EK1_hSC_dAbsmin2.Text = "0";
            EK1_hSC_dAbsmin.Text = "";
            EK1_Absorbance.Text = "";
            EK1_Absorb_SubstrConc.Text = "";
            EK1_ExpectedAbsorbance.Text = "";
            EK1_Absorb_Flag.Text = "";
            EK1_x1.Text = "";
            EK1_x2.Text = "";
            EK1_y1.Text = "";
            EK1_y2.Text = "";
            EK1_tgAngolo.Text = "";
            EK1_Vmax.Text = "";
            EK1_reverseVmax.Text = "";
            EK1_Km.Text = "";
            EK1_reverseKm.Text = "";
            EK1_Mec.Text = "0";
            EK1_OpticalPath.Text = "0";
            EK1_InitSolVol.Text = "0";
            EK1_FinSolVol.Text = "0";
            EK1_Unitsml.Text = "";
            EK1_Kcat.Text = "";
            EK1_CatalEff.Text = "";
            EK1_SubstrateConc.Text = "";
            EK1_HillCoeff.Text = "";
            EK1_MolecularWeight.Text = "";
            EK1_V0.Text = "";
            EK1_Vmoli.Text = "";
            EK1_SolProta.Text = "0";
            EK1_SolProtb.Text = "0";
            EK1_SolBlanka.Text = "0";
            EK1_SolBlankb.Text = "0";
            EK1_vetot.Text = "";
            EK1_vbtot.Text = "";
            EK1_ConcProt.Text = "";
            EK1_AttSpec.Text = "";
            EK1_Absorb_Result.Text = "";
        }

        /*
            Procedure to initialize "Inhibition Kinetics" mask and data vector
        */
        private void Initialize_EK2()
        {
            vEK2.BlSC = 0;
            vEK2.BlSC_dAbsmin_1 = 0;
            vEK2.BlSC_dAbsmin_2 = 0;
            vEK2.BlSC_dAbsmin = 0;
            vEK2.BhSC = 0;
            vEK2.BhSC_dAbsmin_1 = 0;
            vEK2.BhSC_dAbsmin_2 = 0;
            vEK2.BhSC_dAbsmin = 0;
            vEK2.BAbsorbance = 0;
            vEK2.BAbsorbance_SubstrateConcentration = 0;
            vEK2.BExpectedAbsorbance = 0;
            vEK2.BSubstrateInhibition = 0;
            vEK2.By1 = 0;
            vEK2.By2 = 0;
            vEK2.Btg_angolo = 0;
            vEK2.BVmax = 0;
            vEK2.Breverse_Vmax = 0;
            vEK2.BKm = 0;
            vEK2.Breverse_Km = 0;
            vEK2.BHillCoeff = 0;
            vEK2.Ki = 1;
            vEK2.InhibitorConcentration = 0;
            vEK2.InhibitionType = "";
            vEK2.IlSC = 0; ;
            vEK2.IlSC_dAbsmin_1 = 0;
            vEK2.IlSC_dAbsmin_2 = 0;
            vEK2.IlSC_dAbsmin = 0;
            vEK2.IhSC = 0;
            vEK2.IhSC_dAbsmin_1 = 0;
            vEK2.IhSC_dAbsmin_2 = 0;
            vEK2.IhSC_dAbsmin = 0;
            vEK2.Iy1 = 0;
            vEK2.Iy2 = 0;
            vEK2.Itg_angolo = 0;
            vEK2.IVmax = 0;
            vEK2.Ireverse_Vmax = 0;
            vEK2.IKm = 0;
            vEK2.Ireverse_Km = 0;
            vEK2.IHillCoeff = 0;
            vEK2.x1 = 0;
            vEK2.x2 = 0;
            vEK2.epsilon0 = 0;
            vEK2.OpticalPath = 0;
            vEK2.Vf = 0;
            vEK2.SubstrateConcentration = 0;
            vEK2.Bv0 = 0;
            vEK2.Bvmoli = 0;
            vEK2.Iv0 = 0;
            vEK2.Ivmoli = 0;
            vEK2.ActiveEnzymePerc = 0;

            EK2_BlSC.Text = "0";
            EK2_BlSC_dAbsmin1.Text = "0";
            EK2_BlSC_dAbsmin2.Text = "0";
            EK2_BlSC_dAbsmin.Text = "";
            EK2_BhSC.Text = "0";
            EK2_BhSC_dAbsmin1.Text = "0";
            EK2_BhSC_dAbsmin2.Text = "0";
            EK2_BhSC_dAbsmin.Text = "";
            EK2_BAbsorbance.Text = "";
            EK2_BAbsor_SubsConc.Text = "";
            EK2_BExpectedAbsorb.Text = "";
            EK2_Absorb_Flag.Text = "";
            EK2_By1.Text = "";
            EK2_By2.Text = "";
            EK2_BtgAngolo.Text = "";
            EK2_BVmax.Text = "";
            EK2_BreverseVmax.Text = "";
            EK2_BKm.Text = "";
            EK2_BreverseKm.Text = "";
            EK2_BHillCoeff.Text = "";
            EK2_InhibitorConc.Text = "";
            EK2_InhibitionType.Text = "";
            EK2_IlSC.Text = "0";
            EK2_IlSC_dAbsmin1.Text = "0";
            EK2_IlSC_dAbsmin2.Text = "0";
            EK2_IlSC_dAbsmin.Text = "";
            EK2_IhSC.Text = "0";
            EK2_IhSC_dAbsmin1.Text = "0";
            EK2_IhSC_dAbsmin2.Text = "0";
            EK2_IhSC_dAbsmin.Text = "";
            EK2_Iy1.Text = "";
            EK2_Iy2.Text = "";
            EK2_ItgAngolo.Text = "";
            EK2_IVmax.Text = "";
            EK2_IreverseVmax.Text = "";
            EK2_IKm.Text = "";
            EK2_IreverseKm.Text = "";
            EK2_IHillCoeff.Text = "";
            EK2_x1.Text = "";
            EK2_x2.Text = "";
            EK2_Mec.Text = "";
            EK2_OpticalPath.Text = "";
            EK2_FinSolVol.Text = "";
            EK2_SubstrateConc.Text = "";
            EK2_BV0.Text = "";
            EK2_BVmoli.Text = "";
            EK2_IV0.Text = "";
            EK2_IVmoli.Text = "";
            EK2_ActiveEnzymPerc.Text = "";

            EK2_BAbsor_Result.Text = "";

            EK2_MessageBox.Text = "";
        }

        /*
            Procedure to initialize "Enzymatic Units Assay" mask and data vector
        */
        private void Initialize_EK3()
        {
            vEK3.dAbsmin_1 = 0;
            vEK3.dAbsmin_2 = 0;
            vEK3.dAbsmin_3 = 0;
            vEK3.dAbsmin = 0;
            vEK3.epsilon0 = 0;
            vEK3.OpticaltPath = 0;
            vEK3.Vi = 0;
            vEK3.Vf = 0;
            vEK3.Unitsml = 0;

            EK3_dAbsmin_a.Text = "0";
            EK3_dAbsmin_b.Text = "0";
            EK3_dAbsmin_c.Text = "0";

            EK3_Mec.Text = "0";
            EK3_OpticalPath.Text = "0";
            EK3_InitSolVol.Text = "0";
            EK3_FinSolVol.Text = "0";
            EK3_Unitsml.Text = "";

            EK3_MessageBox.Text = "";
        }

        /*
            Procedure to initialize "Calculation of dAbs/min" mask
        */
        private void Initialize_EK4()
        {
            EK4_Abs_015.Text = "0";
            EK4_Abs_115.Text = "0";
            EK4_Abs_215.Text = "0";
            EK4_Abs_315.Text = "0";
            EK4_Abs_415.Text = "0";
        }

        /*
            Procedure to initialize "Bradford Assay" mask and data vector
        */
        private void Initialize_EK5()
        {
            vEK5.SolProt_1 = 0;
            vEK5.SolProt_2 = 0;
            vEK5.vetot = 0;

            vEK5.SolBlank_1 = 0;
            vEK5.SolBlank_2 = 0;
            vEK5.vbtot = 0;

            vEK5.OpticaltPath = 0;
            vEK5.Vi = 0;
            vEK5.ConcProt = 0;

            EK5_OpticalPath.Text = "0";
            EK5_InitSolVol.Text = "0";
            EK5_ConcProt.Text = "";

            EK5_SolProta.Text = "0";
            EK5_SolProtb.Text = "0";
            EK5_SolBlanka.Text = "0";
            EK5_SolBlankb.Text = "0";

            EK5_MessageBox.Text = "";
        }

        /*
            Procedure to manage clicking of "Simple Enzyme Kinetics" button in the Main Page:
                a - display of "Simple Enzyme Kinetics" mask, hiding the other ones
                b - reset of EasyKinetics flags
                c - hiding of Message Box, used to alert users for warnings and errors
        */
        private void SEK_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            cEK2.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            cEK3.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            cEK4.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            cEK5.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            cEK1.Visibility = Windows.UI.Xaml.Visibility.Visible;

            ComputingService.Reset_Flags();
            HideMsgBox();
        }

        /*
            Procedure to manage loading of "Simple Enzyme Kinetics" button in the Main Page:
                a - initialization of "Simple Enzyme Kinetics" mask and data vector
                b - initialization of "Simple Enzyme Kinetics" chart
        */
        private void SEK_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Initialize_EK1();
            ComputingService.Initialize_Chart();
        }

        /*
            Procedure to manage clicking of "Inhibition Kinetics" button in the Main Page:
                a - display of "Inhibition Kinetics" mask, hiding the other ones
                b - reset of EasyKinetics flags
                c - hiding of Message Box, used to alert users for warnings and errors
        */
        private void IK_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            cEK1.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            cEK3.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            cEK4.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            cEK5.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            cEK2.Visibility = Windows.UI.Xaml.Visibility.Visible;

            ComputingService.Reset_Flags();
            HideMsgBox();
        }

        /*
            Procedure to manage loading of "Inhibition Kinetics" button in the Main Page:
                a - initialization of "Inhibition Kinetics" mask and data vector
                b - initialization of "Inhibition Kinetics" chart
        */
        private void IK_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Initialize_EK2();
            ComputingService.Initialize_Chart();
        }

        /*
            Procedure to manage clicking of "Enzymatic Units Assay" button in the Main Page:
                a - display of "Enzymatic Units Assay" mask, hiding the other ones
                b - reset of EasyKinetics flags
                c - hiding of Message Box, used to alert users for warnings and errors
        */
        private void EUA_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            cEK1.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            cEK2.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            cEK4.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            cEK5.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            cEK3.Visibility = Windows.UI.Xaml.Visibility.Visible;

            ComputingService.Reset_Flags();
            HideMsgBox();
        }

        /*
            Procedure to manage loading of "Enzymatic Units Assay" button in the Main Page:
                a - initialization of "Enzymatic Units Assay" mask and data vector
        */
        private void EUA_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Initialize_EK3();
        }

        /*
            Procedure to manage clicking of "Calculation of dAbs/min" button in the Main Page:
                a - display of "Calculation of dAbs/min" mask, hiding the other ones
                b - reset of EasyKinetics flags
                c - hiding of Message Box, used to alert users for warnings and errors
        */
        private void dAM_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            cEK1.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            cEK2.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            cEK3.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            cEK5.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            cEK4.Visibility = Windows.UI.Xaml.Visibility.Visible;

            ComputingService.Reset_Flags();
            HideMsgBox();
        }

        /*
            Procedure to manage loading of "Calculation of dAbs/min" button in the Main Page:
                a - initialization of "Calculation of dAbs/min" mask and data vector
        */
        private void dAM_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Initialize_EK4();
        }

        /*
            Procedure to manage clicking of "Bradford Assay" button in the Main Page:
                a - display of "Bradford Assay" mask, hiding the other ones
                b - reset of EasyKinetics flags
                c - hiding of Message Box, used to alert users for warnings and errors
        */
        private void BA_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            cEK1.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            cEK2.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            cEK3.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            cEK4.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            cEK5.Visibility = Windows.UI.Xaml.Visibility.Visible;

            ComputingService.Reset_Flags();
            HideMsgBox();
        }

        /*
           Procedure to manage loading of "Bradford Assay" button in the Main Page:
               a - initialization of "Bradford Assay" mask and data vector
        */
        private void BA_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Initialize_EK5();
        }

        /*
           Simple Enzyme Kinetics analysis: effects of parameter "x1"
        */
        private void EK1_x1_TextChanged(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ComputingService.EK1_tgAngolo();
            if (vEK1.tg_angolo > 0)
            {
                EK1_tgAngolo.Text = vEK1.tg_angolo.ToString("#0.00000000");
            }
        }

        /*
           Simple Enzyme Kinetics analysis: effects of parameter "x2"
        */
        private void EK1_x2_TextChanged(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ComputingService.EK1_tgAngolo();
            if (vEK1.tg_angolo > 0)
            {
                EK1_tgAngolo.Text = vEK1.tg_angolo.ToString("#0.00000000");
            }

            ComputingService.EK1_ReverseVmax();
            if (vEK1.reverse_Vmax > 0)
            {
                EK1_reverseVmax.Text = vEK1.reverse_Vmax.ToString("#0.00000000");
            }
        }

        /*
           Simple Enzyme Kinetics analysis: effects of parameter "Lower Substrate Concentration"
        */
        private void EK1_lSC_TextChanged(object sender, TextChangedEventArgs e)
        {
            string s_out = ComputingService.NumField(EK1_lSC.Text);
            vEK1.lSC = Double.Parse("0" + s_out);
            EK1_lSC.Text = s_out;
            EK1_lSC.Select(s_out.Length, 0);

            ComputingService.EK1_x2();
            if (vEK1.x2 > 0)
            {
                EK1_x2.Text = vEK1.x2.ToString("#0.00000000");
            }
        }

        /*
           Simple Enzyme Kinetics analysis: effects of parameter "Absorbance Change per Minute of 1st sample in Lower Substrate Concentration"
        */
        private void EK1_lSC_dAbsmin1_TextChanged(object sender, TextChangedEventArgs e)
        {
            string s_out = ComputingService.NumField(EK1_lSC_dAbsmin1.Text);
            vEK1.lSC_dAbsmin_1 = Double.Parse("0" + s_out);
            EK1_lSC_dAbsmin1.Text = s_out;
            EK1_lSC_dAbsmin1.Select(s_out.Length, 0);

            ComputingService.EK1_lSC_dAbsmin();
            EK1_lSC_dAbsmin.Text = vEK1.lSC_dAbsmin.ToString("#0.00000000");
        }

        /*
           Simple Enzyme Kinetics analysis: effects of parameter "Absorbance Change per Minute in 2nd sample in Lower Substrate Concentration"
        */
        private void EK1_lSC_dAbsmin2_TextChanged(object sender, TextChangedEventArgs e)
        {
            string s_out = ComputingService.NumField(EK1_lSC_dAbsmin2.Text);
            vEK1.lSC_dAbsmin_2 = Double.Parse("0" + s_out);
            EK1_lSC_dAbsmin2.Text = s_out;
            EK1_lSC_dAbsmin2.Select(s_out.Length, 0);

            ComputingService.EK1_lSC_dAbsmin();
            EK1_lSC_dAbsmin.Text = vEK1.lSC_dAbsmin.ToString("#0.00000000");
        }

        /*
           Simple Enzyme Kinetics analysis: effects of parameter "average Absorbance Change per Minute in Lower Substrate Concentration"
        */
        private void EK1_lSC_dAbsmin_TextChanged(object sender, TextChangedEventArgs e)
        {
            ComputingService.EK1_y2();
            if (vEK1.y2 > 0)
            {
                EK1_y2.Text = vEK1.y2.ToString("#0.00000000");
            }
        }

        /*
           Simple Enzyme Kinetics analysis: effects of parameter "Higher Substrate Concentration"
        */
        private void EK1_hSC_TextChanged(object sender, TextChangedEventArgs e)
        {
            string s_out = ComputingService.NumField(EK1_hSC.Text);
            vEK1.hSC = Double.Parse("0" + s_out);
            EK1_hSC.Text = s_out;
            EK1_hSC.Select(s_out.Length, 0);

            ComputingService.EK1_x1();
            if (vEK1.x1 > 0)
            {
                EK1_x1.Text = vEK1.x1.ToString("#0.00000000");
            }

            ComputingService.EK1_HillCoeff();
            if (vEK1.HillCoeff > 0)
            {
                EK1_HillCoeff.Text = vEK1.HillCoeff.ToString("#0.00");
            }
        }

        /*
           Simple Enzyme Kinetics analysis: effects of parameter "Absorbance Change per Minute of 1st sample in Higher Substrate Concentration"
        */
        private void EK1_hSC_dAbsmin1_TextChanged(object sender, TextChangedEventArgs e)
        {
            string s_out = ComputingService.NumField(EK1_hSC_dAbsmin1.Text);
            vEK1.hSC_dAbsmin_1 = Double.Parse("0" + s_out);
            EK1_hSC_dAbsmin1.Text = s_out;
            EK1_hSC_dAbsmin1.Select(s_out.Length, 0);

            ComputingService.EK1_hSC_dAbsmin();
            EK1_hSC_dAbsmin.Text = vEK1.hSC_dAbsmin.ToString("#0.00000000");
        }

        /*
           Simple Enzyme Kinetics analysis: effects of parameter "Absorbance Change per Minute of 2nd sample in Higher Substrate Concentration"
        */
        private void EK1_hSC_dAbsmin2_TextChanged(object sender, TextChangedEventArgs e)
        {
            string s_out = ComputingService.NumField(EK1_hSC_dAbsmin2.Text);
            vEK1.hSC_dAbsmin_2 = Double.Parse("0" + s_out);
            EK1_hSC_dAbsmin2.Text = s_out;
            EK1_hSC_dAbsmin2.Select(s_out.Length, 0);

            ComputingService.EK1_hSC_dAbsmin();
            EK1_hSC_dAbsmin.Text = vEK1.hSC_dAbsmin.ToString("#0.00000000");
        }

        /*
           Simple Enzyme Kinetics analysis: effects of parameter "average Absorbance Change per Minute in Higher Substrate Concentration"
        */
        private void EK1_hSC_dAbsmin_TextChanged(object sender, TextChangedEventArgs e)
        {
            ComputingService.EK1_y1();
            if (vEK1.y1 > 0)
            {
                EK1_y1.Text = vEK1.y1.ToString("#0.00000000");
            }

            ComputingService.EK1_HillCoeff();
            if (vEK1.HillCoeff > 0)
            {
                EK1_HillCoeff.Text = vEK1.HillCoeff.ToString("#0.00");
            }
        }

        /*
           Simple Enzyme Kinetics analysis: effects of parameter "Absorbance Change per Minute in Substrate Inhibition check sample"
        */
        private void EK1_Absorbance_TextChanged(object sender, TextChangedEventArgs e)
        {
            string s_out = ComputingService.NumField(EK1_Absorbance.Text);
            vEK1.Absorbance = Double.Parse("0" + s_out);
            EK1_Absorbance.Text = s_out;
            EK1_Absorbance.Select(s_out.Length, 0);

            ComputingService.EK1_Unitsml();
            if (vEK1.Unitsml > 0)
            {
                EK1_Unitsml.Text = vEK1.Unitsml.ToString("#0.00000000");
            }

            ComputingService.EK1_SubstrateInhibition();
            EK1_Absorb_Flag.Text = vEK1.SubstrateInhibition.ToString("#0");
        }

        /*
           Simple Enzyme Kinetics analysis: effects of parameter "Substrate Inhibition check flag"
        */
        private void EK1_Absorb_Flag_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (vEK1.SubstrateInhibition == 1)
            {
                EK1_Absorb_Result.Text = "Substrate-Inhibition present";
            }
            else
            {
                EK1_Absorb_Result.Text = "Substrate-Inhibition absent";
            }

            ChartParameters.SubstrateInhibitionFlag = vEK1.SubstrateInhibition;
        }

        /*
           Simple Enzyme Kinetics analysis: effects of parameter "Substrate Inhibition check result"
        */
        private void EK1_Absorb_Result_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (EK1_Absorb_Result.Text == "Substrate-Inhibition present")
            {
                EK1_Absorb_Result.Width = 200;
                EK1_Absorb_Result.Height = 24;
            }
            else
            {
                EK1_Absorb_Result.Width = 0;
                EK1_Absorb_Result.Height = 0;
            }

            if (vEK1.Ki > 0)
            {
                EK1_Ki.Text = vEK1.Ki.ToString("#0.00000000");
            }

            ChartParameters.Ki = vEK1.Ki;
        }

        /*
           Simple Enzyme Kinetics analysis: effects of parameter "Molecular Weight"
        */
        private void EK1_MolecularWeight_TextChanged(object sender, TextChangedEventArgs e)
        {
            string s_out = ComputingService.NumField(EK1_MolecularWeight.Text);
            vEK1.MolecularWeight = Double.Parse("0" + s_out);
            EK1_MolecularWeight.Text = s_out;
            EK1_MolecularWeight.Select(s_out.Length, 0);

            ComputingService.EK1_Kcat();
            if (vEK1.Kcat > 0)
            {
                EK1_Kcat.Text = vEK1.Kcat.ToString("#0.00000000");
            }
        }

        /*
           Simple Enzyme Kinetics analysis: effects of parameter "Molar Extinction Coefficient"
        */
        private void EK1_Mec_TextChanged(object sender, TextChangedEventArgs e)
        {
            string s_out = ComputingService.NumField(EK1_Mec.Text);
            vEK1.epsilon0 = Double.Parse("0" + s_out);
            EK1_Mec.Text = s_out;
            EK1_Mec.Select(s_out.Length, 0);

            ComputingService.EK1_Kcat();
            if (vEK1.Kcat > 0)
            {
                EK1_Kcat.Text = vEK1.Kcat.ToString("#0.00000000");
            }

            ComputingService.EK1_Unitsml();
            if (vEK1.Unitsml > 0)
            {
                EK1_Unitsml.Text = vEK1.Unitsml.ToString("#0.00000000");
            }

            ComputingService.EK1_Vmoli();
            if (vEK1.vmoli > 0)
            {
                EK1_Vmoli.Text = vEK1.vmoli.ToString("#0.00000000");
            }
        }

        /*
           Simple Enzyme Kinetics analysis: effects of parameter "Optical Path"
        */
        private void EK1_OpticalPath_TextChanged(object sender, TextChangedEventArgs e)
        {
            string s_out = ComputingService.NumField(EK1_OpticalPath.Text);
            vEK1.OpticalPath = Double.Parse("0" + s_out);
            EK1_OpticalPath.Text = s_out;
            EK1_OpticalPath.Select(s_out.Length, 0);

            ComputingService.EK1_Kcat();
            if (vEK1.Kcat > 0)
            {
                EK1_Kcat.Text = vEK1.Kcat.ToString("#0.00000000");
            }

            ComputingService.EK1_Unitsml();
            if (vEK1.Unitsml > 0)
            {
                EK1_Unitsml.Text = vEK1.Unitsml.ToString("#0.00000000");
            }

            ComputingService.EK1_Vmoli();
            if (vEK1.vmoli > 0)
            {
                EK1_Vmoli.Text = vEK1.vmoli.ToString("#0.00000000");
            }

            ComputingService.EK1_ConcProt();
            if (vEK1.ConcProt > 0)
            {
                EK1_ConcProt.Text = vEK1.ConcProt.ToString("#0.00000000");
            }
        }

        /*
           Simple Enzyme Kinetics analysis: effects of parameter "Initial Solution Volume"
        */
        private void EK1_InitSolVol_TextChanged(object sender, TextChangedEventArgs e)
        {
            string s_out = ComputingService.NumField(EK1_InitSolVol.Text);
            vEK1.Vi = Double.Parse("0" + s_out);
            EK1_InitSolVol.Text = s_out;
            EK1_InitSolVol.Select(s_out.Length, 0);

            ComputingService.EK1_Unitsml();
            if (vEK1.Unitsml > 0)
            {
                EK1_Unitsml.Text = vEK1.Unitsml.ToString("#0.00000000");
            }

            ComputingService.EK1_ConcProt();
            if (vEK1.ConcProt > 0)
            {
                EK1_ConcProt.Text = vEK1.ConcProt.ToString("#0.00000000");
            }
        }

        /*
           Simple Enzyme Kinetics analysis: effects of parameter "Final Solution Volume"
        */
        private void EK1_FinSolVol_TextChanged(object sender, TextChangedEventArgs e)
        {
            string s_out = ComputingService.NumField(EK1_FinSolVol.Text);
            vEK1.Vf = Double.Parse("0" + s_out);
            EK1_FinSolVol.Text = s_out;
            EK1_FinSolVol.Select(s_out.Length, 0);

            ComputingService.EK1_Unitsml();
            if (vEK1.Unitsml > 0)
            {
                EK1_Unitsml.Text = vEK1.Unitsml.ToString("#0.00000000");
            }

            ComputingService.EK1_Vmoli();
            if (vEK1.vmoli > 0)
            {
                EK1_Vmoli.Text = vEK1.vmoli.ToString("#0.00000000");
            }

            ComputingService.EK1_ConcProt();
            if (vEK1.ConcProt > 0)
            {
                EK1_ConcProt.Text = vEK1.ConcProt.ToString("#0.00000000");
            }
        }

        /*
           Simple Enzyme Kinetics analysis: effects of parameter "y1"
        */
        private void EK1_y1_TextChanged(object sender, TextChangedEventArgs e)
        {
            ComputingService.EK1_tgAngolo();
            if (vEK1.tg_angolo > 0)
            {
                EK1_tgAngolo.Text = vEK1.tg_angolo.ToString("#0.00000000");
            }
        }

        /*
           Simple Enzyme Kinetics analysis: effects of parameter "y2"
        */
        private void EK1_y2_TextChanged(object sender, TextChangedEventArgs e)
        {
            ComputingService.EK1_tgAngolo();
            if (vEK1.tg_angolo > 0)
            {
                EK1_tgAngolo.Text = vEK1.tg_angolo.ToString("#0.00000000");
            }

            ComputingService.EK1_ReverseVmax();
            if (vEK1.reverse_Vmax > 0)
            {
                EK1_reverseVmax.Text = vEK1.reverse_Vmax.ToString("#0.00000000");
            }
        }

        /*
           Simple Enzyme Kinetics analysis: effects of parameter "Tangent of the Angle"
        */
        private void EK1_tgAngolo_TextChanged(object sender, TextChangedEventArgs e)
        {
            ComputingService.EK1_ReverseVmax();
            if (vEK1.reverse_Vmax > 0)
            {
                EK1_reverseVmax.Text = vEK1.reverse_Vmax.ToString("#0.00000000");
            }

            ComputingService.EK1_ReverseKm();
            if (vEK1.reverse_Km > 0)
            {
                EK1_reverseKm.Text = vEK1.reverse_Km.ToString("#0.00000000");
            }
        }

        /*
           Simple Enzyme Kinetics analysis: effects of parameter "Reverse of Vmax"
        */
        private void EK1_reverseVmax_TextChanged(object sender, TextChangedEventArgs e)
        {
            ComputingService.EK1_Vmax();
            if (vEK1.Vmax > 0)
            {
                EK1_Vmax.Text = vEK1.Vmax.ToString("#0.00000000");
            }

            ComputingService.EK1_ReverseKm();
            if (vEK1.reverse_Km > 0)
            {
                EK1_reverseKm.Text = vEK1.reverse_Km.ToString("#0.00000000");
            }
        }

        /*
           Simple Enzyme Kinetics analysis: effects of parameter "Vmax"
        */
        private void EK1_Vmax_TextChanged(object sender, TextChangedEventArgs e)
        {
            ChartParameters.Vmax = vEK1.Vmax;
            ChartParameters.iVmax = 0;

            ComputingService.EK1_Kcat();
            if (vEK1.Kcat > 0)
            {
                EK1_Kcat.Text = vEK1.Kcat.ToString("#0.00000000");
            }

            ComputingService.EK1_V0();
            if (vEK1.v0 > 0)
            {
                EK1_V0.Text = vEK1.v0.ToString("#0.00000000");
            }

            ComputingService.EK1_ExpectedAbsorbance();
            if (vEK1.ExpectedAbsorbance > 0)
            {
                EK1_ExpectedAbsorbance.Text = vEK1.ExpectedAbsorbance.ToString("#0.00000000");
            }

            ComputingService.EK1_SubstrateInhibition();
            EK1_Absorb_Flag.Text = vEK1.SubstrateInhibition.ToString("#0");

            ComputingService.EK1_HillCoeff();
            if (vEK1.HillCoeff > 0)
            {
                EK1_HillCoeff.Text = vEK1.HillCoeff.ToString("#0.00");
            }
        }

        /*
           Simple Enzyme Kinetics analysis: effects of parameter "Units/ml"
        */
        private void EK1_Unitsml_TextChanged(object sender, TextChangedEventArgs e)
        {
            ComputingService.EK1_AttSpec();
            if (vEK1.AttSpec > 0)
            {
                EK1_AttSpec.Text = vEK1.AttSpec.ToString("#0.00000000");
            }
        }

        /*
           Simple Enzyme Kinetics analysis: effects of parameter "Reverse of Km"
        */
        private void EK1_reverseKm_TextChanged(object sender, TextChangedEventArgs e)
        {
            ComputingService.EK1_Km();
            if (vEK1.Km > 0)
            {
                EK1_Km.Text = vEK1.Km.ToString("#0.00000000");
            }
        }

        /*
           Simple Enzyme Kinetics analysis: effects of parameter "Km"
        */
        private void EK1_Km_TextChanged(object sender, TextChangedEventArgs e)
        {
            ChartParameters.Km = vEK1.Km;
            ChartParameters.iKm = 0;

            ComputingService.EK1_CatalEff();
            if (vEK1.CatalEff > 0)
            {
                EK1_CatalEff.Text = vEK1.CatalEff.ToString("#0.00000000");
            }

            ComputingService.EK1_V0();
            if (vEK1.v0 > 0)
            {
                EK1_V0.Text = vEK1.v0.ToString("#0.00000000");
            }

            ComputingService.EK1_Absorbance_SubstrateConcentration();
            if (vEK1.Absorbance_SubstrateConcentration > 0)
            {
                EK1_Absorb_SubstrConc.Text = vEK1.Absorbance_SubstrateConcentration.ToString("#0.00000000");
            }

            ComputingService.EK1_ExpectedAbsorbance();
            EK1_ExpectedAbsorbance.Text = vEK1.ExpectedAbsorbance.ToString("#0.00000000");

            ComputingService.EK1_SubstrateInhibition();
            EK1_Absorb_Flag.Text = vEK1.SubstrateInhibition.ToString("#0");

            ComputingService.EK1_HillCoeff();
            if (vEK1.HillCoeff > 0)
            {
                EK1_HillCoeff.Text = vEK1.HillCoeff.ToString("#0.00");
            }
        }

        /*
           Simple Enzyme Kinetics analysis: effects of parameter "Expected Absorbance Change per Minute in Substrate Inhibition check sample"
        */
        private void EK1_ExpectedAbsorbance_TextChanged(object sender, TextChangedEventArgs e)
        {
            ComputingService.EK1_SubstrateInhibition();
            EK1_Absorb_Flag.Text = vEK1.SubstrateInhibition.ToString("#0");
        }

        /*
           Simple Enzyme Kinetics analysis: effects of parameter "Substrate Concentration in Substrate Inhibition check sample"
        */
        private void EK1_Absorb_SubstrConc_TextChanged(object sender, TextChangedEventArgs e)
        {
            ComputingService.EK1_ExpectedAbsorbance();
            if (vEK1.ExpectedAbsorbance > 0)
            {
                EK1_ExpectedAbsorbance.Text = vEK1.ExpectedAbsorbance.ToString("#0.00000000");
            }

            ComputingService.EK1_SubstrateInhibition();
            EK1_Absorb_Flag.Text = vEK1.SubstrateInhibition.ToString("#0");
        }

        /*
           Simple Enzyme Kinetics analysis: effects of parameter "Kcat"
        */
        private void EK1_Kcat_TextChanged(object sender, TextChangedEventArgs e)
        {
            ComputingService.EK1_CatalEff();
            if (vEK1.CatalEff > 0)
            {
                EK1_CatalEff.Text = vEK1.CatalEff.ToString("#0.00000000");
            }
        }

        /*
           Simple Enzyme Kinetics analysis: effects of parameter "Substrate Concentratione"
        */
        private void EK1_SubstrateConc_TextChanged(object sender, TextChangedEventArgs e)
        {
            string s_out = ComputingService.NumField(EK1_SubstrateConc.Text);
            vEK1.SubstrateConcentration = Double.Parse("0" + s_out);
            EK1_SubstrateConc.Text = s_out;
            EK1_SubstrateConc.Select(s_out.Length, 0);

            ComputingService.EK1_V0();
            if (vEK1.v0 > 0)
            {
                EK1_V0.Text = vEK1.v0.ToString("#0.00000000");
            }
        }

        /*
           Simple Enzyme Kinetics analysis: effects of parameter "Hill Coefficient"
        */
        private void EK1_HillCoeff_TextChanged(object sender, TextChangedEventArgs e)
        {
            ChartParameters.Mask = "SEK";
            ChartParameters.nH = vEK1.HillCoeff;

            ComputingService.EK1_V0();
            if (vEK1.v0 > 0)
            {
                EK1_V0.Text = vEK1.v0.ToString("#0.00000000");
            }

            ComputingService.EK1_ExpectedAbsorbance();
            if (vEK1.ExpectedAbsorbance > 0)
            {
                EK1_ExpectedAbsorbance.Text = vEK1.ExpectedAbsorbance.ToString("#0.00000000");
            }
        }

        /*
           Simple Enzyme Kinetics analysis: effects of parameter "Computed Reaction Rate"
        */
        private void EK1_v0_TextChanged(object sender, TextChangedEventArgs e)
        {
            ComputingService.EK1_Vmoli();
            if (vEK1.vmoli > 0)
            {
                EK1_Vmoli.Text = vEK1.vmoli.ToString("#0.00000000");
            }
        }

        /*
           Simple Enzyme Kinetics analysis: effects of parameter "Absorbance Change per Minute of 1st sample of solution with proteins in Bradford Assay"
        */
        private void EK1_SolProta_TextChanged(object sender, TextChangedEventArgs e)
        {
            string s_out = ComputingService.NumField(EK1_SolProta.Text);
            vEK1.SolProt_1 = Double.Parse("0" + s_out);
            EK1_SolProta.Text = s_out;
            EK1_SolProta.Select(s_out.Length, 0);

            ComputingService.EK1_vetot();
            EK1_vetot.Text = vEK1.vetot.ToString("#0.00000000");
        }

        /*
           Simple Enzyme Kinetics analysis: effects of parameter "Absorbance Change per Minute of 2nd sample of solution with proteins in Bradford Assay"
        */
        private void EK1_SolProtb_TextChanged(object sender, TextChangedEventArgs e)
        {
            string s_out = ComputingService.NumField(EK1_SolProtb.Text);
            vEK1.SolProt_2 = Double.Parse("0" + s_out);
            EK1_SolProtb.Text = s_out;
            EK1_SolProtb.Select(s_out.Length, 0);

            ComputingService.EK1_vetot();
            EK1_vetot.Text = vEK1.vetot.ToString("#0.00000000");
        }

        /*
           Simple Enzyme Kinetics analysis: effects of parameter "Absorbance Change per Minute of 1st sample of solution without proteins in Bradford Assay"
        */
        private void EK1_SolBlanka_TextChanged(object sender, TextChangedEventArgs e)
        {
            string s_out = ComputingService.NumField(EK1_SolBlanka.Text);
            vEK1.SolBlank_1 = Double.Parse("0" + s_out);
            EK1_SolBlanka.Text = s_out;
            EK1_SolBlanka.Select(s_out.Length, 0);

            ComputingService.EK1_vbtot();
            EK1_vbtot.Text = vEK1.vbtot.ToString("#0.00000000");
        }

        /*
           Simple Enzyme Kinetics analysis: effects of parameter "Absorbance Change per Minute of 2nd sample of solution without proteins in Bradford Assay"
        */
        private void EK1_SolBlankb_TextChanged(object sender, TextChangedEventArgs e)
        {
            string s_out = ComputingService.NumField(EK1_SolBlankb.Text);
            vEK1.SolBlank_2 = Double.Parse("0" + s_out);
            EK1_SolBlankb.Text = s_out;
            EK1_SolBlankb.Select(s_out.Length, 0);

            ComputingService.EK1_vbtot();
            EK1_vbtot.Text = vEK1.vbtot.ToString("#0.00000000");
        }

        /*
           Simple Enzyme Kinetics analysis: effects of parameter "average Absorbance Change per Minute of solution with proteins in Bradford Assay"
        */
        private void EK1_vetot_TextChanged(object sender, TextChangedEventArgs e)
        {
            ComputingService.EK1_ConcProt();
            if (vEK1.ConcProt > 0)
            {
                EK1_ConcProt.Text = vEK1.ConcProt.ToString("#0.00000000");
            }
        }

        /*
           Simple Enzyme Kinetics analysis: effects of parameter "average Absorbance Change per Minute of solution without proteins in Bradford Assay"
        */
        private void EK1_vbtot_TextChanged(object sender, TextChangedEventArgs e)
        {
            ComputingService.EK1_ConcProt();
            if (vEK1.ConcProt > 0)
            {
                EK1_ConcProt.Text = vEK1.ConcProt.ToString("#0.00000000");
            }
        }

        /*
           Simple Enzyme Kinetics analysis: effects of parameter "proteins concentration in Bradford Assay"
        */
        private void EK1_ConcProt_TextChanged(object sender, TextChangedEventArgs e)
        {
            ComputingService.EK1_Kcat();
            if (vEK1.Kcat > 0)
            {
                EK1_Kcat.Text = vEK1.Kcat.ToString("#0.00000000");
            }

            ComputingService.EK1_AttSpec();
            if (vEK1.AttSpec > 0)
            {
                EK1_AttSpec.Text = vEK1.AttSpec.ToString("#0.00000000");
            }
        }

        /*
           Simple Enzyme Kinetics analysis: procedure to display or to hide hidden parameters to check values correctness
        */
        private void EK1_Test_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (flagTest.fEK1 == 1)
            {
                flagTest.fEK1 = 0;
            }
            else
            {
                flagTest.fEK1 = 1;
            }

            EK1_x1_ptxt.Width = 100 * flagTest.fEK1;
            EK1_x1_ptxt.Height = 24 * flagTest.fEK1;
            EK1_x1.Width = 100 * flagTest.fEK1;
            EK1_x1.Height = 24 * flagTest.fEK1;

            EK1_x2_ptxt.Width = 100 * flagTest.fEK1;
            EK1_x2_ptxt.Height = 24 * flagTest.fEK1;
            EK1_x2.Width = 100 * flagTest.fEK1;
            EK1_x2.Height = 24 * flagTest.fEK1;

            EK1_lSC_dAbsmin_ptxt.Width = 30 * flagTest.fEK1;
            EK1_lSC_dAbsmin_ptxt.Height = 24 * flagTest.fEK1;
            EK1_lSC_dAbsmin.Width = 90 * flagTest.fEK1;
            EK1_lSC_dAbsmin.Height = 24 * flagTest.fEK1;

            EK1_y2_ptxt.Width = 30 * flagTest.fEK1;
            EK1_y2_ptxt.Height = 24 * flagTest.fEK1;
            EK1_y2.Width = 90 * flagTest.fEK1;
            EK1_y2.Height = 24 * flagTest.fEK1;

            EK1_hSC_dAbsmin_ptxt.Width = 30 * flagTest.fEK1;
            EK1_hSC_dAbsmin_ptxt.Height = 24 * flagTest.fEK1;
            EK1_hSC_dAbsmin.Width = 90 * flagTest.fEK1;
            EK1_hSC_dAbsmin.Height = 24 * flagTest.fEK1;

            EK1_y1_ptxt.Width = 30 * flagTest.fEK1;
            EK1_y1_ptxt.Height = 24 * flagTest.fEK1;
            EK1_y1.Width = 90 * flagTest.fEK1;
            EK1_y1.Height = 24 * flagTest.fEK1;

            EK1_tgAngolo_ptxt.Width = 40 * flagTest.fEK1;
            EK1_tgAngolo_ptxt.Height = 24 * flagTest.fEK1;
            EK1_tgAngolo.Width = 90 * flagTest.fEK1;
            EK1_tgAngolo.Height = 24 * flagTest.fEK1;

            EK1_reverseVmax_ptxt.Width = 40 * flagTest.fEK1;
            EK1_reverseVmax_ptxt.Height = 24 * flagTest.fEK1;
            EK1_reverseVmax.Width = 100 * flagTest.fEK1;
            EK1_reverseVmax.Height = 24 * flagTest.fEK1;

            EK1_reverseKm_ptxt.Width = 40 * flagTest.fEK1;
            EK1_reverseKm_ptxt.Height = 24 * flagTest.fEK1;
            EK1_reverseKm.Width = 100 * flagTest.fEK1;
            EK1_reverseKm.Height = 24 * flagTest.fEK1;

            EK1_vetot_ptxt.Width = 40 * flagTest.fEK1;
            EK1_vetot_ptxt.Height = 24 * flagTest.fEK1;
            EK1_vetot.Width = 100 * flagTest.fEK1;
            EK1_vetot.Height = 24 * flagTest.fEK1;

            EK1_vbtot_ptxt.Width = 40 * flagTest.fEK1;
            EK1_vbtot_ptxt.Height = 24 * flagTest.fEK1;
            EK1_vbtot.Width = 100 * flagTest.fEK1;
            EK1_vbtot.Height = 24 * flagTest.fEK1;
        }

        /*
           Simple Enzyme Kinetics analysis: reset of mask, data vector and chart
        */
        private void EK1_Reset_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            HideMsgBox();
            Initialize_EK1();
            ComputingService.Initialize_Chart();
        }

        /*
           Inhibition Kinetics analysis: effects of parameter "x1"
        */
        private void EK2_x1_TextChanged(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ComputingService.EK2_BtgAngolo();
            if (vEK2.Btg_angolo > 0)
            {
                EK2_BtgAngolo.Text = vEK2.Btg_angolo.ToString("#0.00000000");
            }

            ComputingService.EK2_ItgAngolo();
            if (vEK2.Itg_angolo > 0)
            {
                EK2_ItgAngolo.Text = vEK2.Itg_angolo.ToString("#0.00000000");
            }
        }

        /*
           Inhibition Kinetics analysis: effects of parameter "x2"
        */
        private void EK2_x2_TextChanged(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ComputingService.EK2_BtgAngolo();
            if (vEK2.Btg_angolo > 0)
            {
                EK2_BtgAngolo.Text = vEK2.Btg_angolo.ToString("#0.00000000");
            }

            ComputingService.EK2_ItgAngolo();
            if (vEK2.Itg_angolo > 0)
            {
                EK2_ItgAngolo.Text = vEK2.Itg_angolo.ToString("#0.00000000");
            }

            ComputingService.EK2_BReverseVmax();
            if (vEK2.Breverse_Vmax > 0)
            {
                EK2_BreverseVmax.Text = vEK2.Breverse_Vmax.ToString("#0.00000000");
            }

            ComputingService.EK2_IReverseVmax();
            if (vEK2.Ireverse_Vmax > 0)
            {
                EK2_IreverseVmax.Text = vEK2.Ireverse_Vmax.ToString("#0.00000000");
            }
        }

        /*
           Inhibition Kinetics analysis: effects of parameter "Lower Substrate Concentration in absence of inhibitor"
        */
        private void EK2_BlSC_TextChanged(object sender, TextChangedEventArgs e)
        {
            string s_out = ComputingService.NumField(EK2_BlSC.Text);
            vEK2.BlSC = Double.Parse("0" + s_out);
            EK2_BlSC.Text = s_out;
            EK2_BlSC.Select(s_out.Length, 0);

            ComputingService.EK2_IlSC();
            if (vEK2.IlSC > 0)
            {
                EK2_IlSC.Text = vEK2.IlSC.ToString("#0.00000000");
            }

            ComputingService.EK2_x2();
            if (vEK2.x2 > 0)
            {
                EK2_x2.Text = vEK2.x2.ToString("#0.00000000");
            }
        }

        /*
           Inhibition Kinetics analysis: effects of parameter "Absorbance Change per Minute of 1st sample in Lower Substrate Concentration in absence of inhibitor"
        */
        private void EK2_BlSC_dAbsmin1_TextChanged(object sender, TextChangedEventArgs e)
        {
            string s_out = ComputingService.NumField(EK2_BlSC_dAbsmin1.Text);
            vEK2.BlSC_dAbsmin_1 = Double.Parse("0" + s_out);
            EK2_BlSC_dAbsmin1.Text = s_out;
            EK2_BlSC_dAbsmin1.Select(s_out.Length, 0);

            ComputingService.EK2_BlSC_dAbsmin();
            EK2_BlSC_dAbsmin.Text = vEK2.BlSC_dAbsmin.ToString("#0.00000000");
        }

        /*
           Inhibition Kinetics analysis: effects of parameter "Absorbance Change per Minute of 2nd sample in Lower Substrate Concentration in absence of inhibitor"
        */
        private void EK2_BlSC_dAbsmin2_TextChanged(object sender, TextChangedEventArgs e)
        {
            string s_out = ComputingService.NumField(EK2_BlSC_dAbsmin2.Text);
            vEK2.BlSC_dAbsmin_2 = Double.Parse("0" + s_out);
            EK2_BlSC_dAbsmin2.Text = s_out;
            EK2_BlSC_dAbsmin2.Select(s_out.Length, 0);

            ComputingService.EK2_BlSC_dAbsmin();
            EK2_BlSC_dAbsmin.Text = vEK2.BlSC_dAbsmin.ToString("#0.00000000");
        }

        /*
           Inhibition Kinetics analysis: effects of parameter "average Absorbance Change per Minute in Lower Substrate Concentration in absence of inhibitor"
        */
        private void EK2_BlSC_dAbsmin_TextChanged(object sender, TextChangedEventArgs e)
        {
            ComputingService.EK2_By2();
            if (vEK2.By2 > 0)
            {
                EK2_By2.Text = vEK2.By2.ToString("#0.00000000");
            }

            ComputingService.EK2_ActiveEnzymPerc();
            if (vEK2.ActiveEnzymePerc > 0)
            {
                EK2_ActiveEnzymPerc.Text = vEK2.ActiveEnzymePerc.ToString("#0.00%");
            }
        }

        /*
           Inhibition Kinetics analysis: effects of parameter "Higher Substrate Concentration in absence of inhibitor"
        */
        private void EK2_BhSC_TextChanged(object sender, TextChangedEventArgs e)
        {
            string s_out = ComputingService.NumField(EK2_BhSC.Text);
            vEK2.BhSC = Double.Parse("0" + s_out);
            EK2_BhSC.Text = s_out;
            EK2_BhSC.Select(s_out.Length, 0);

            ComputingService.EK2_IhSC();
            if (vEK2.IhSC > 0)
            {
                EK2_IhSC.Text = vEK2.IhSC.ToString("#0.00000000");
            }

            ComputingService.EK2_x1();
            if (vEK2.x1 > 0)
            {
                EK2_x1.Text = vEK2.x1.ToString("#0.00000000");
            }

            ComputingService.EK2_BHillCoeff();
            if (vEK2.BHillCoeff > 0)
            {
                EK2_BHillCoeff.Text = vEK2.BHillCoeff.ToString("#0.00");
            }
        }

        /*
           Inhibition Kinetics analysis: effects of parameter "Lower Substrate Concentration in presence of inhibitor"
        */
        private void EK2_IlSC_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        /*
           Inhibition Kinetics analysis: effects of parameter "Higher Substrate Concentration in presence of inhibitor"
        */
        private void EK2_IhSC_TextChanged(object sender, TextChangedEventArgs e)
        {
            ComputingService.EK2_IHillCoeff();
            if (vEK2.IHillCoeff > 0)
            {
                EK2_IHillCoeff.Text = vEK2.IHillCoeff.ToString("#0.00");
            }
        }

        /*
           Inhibition Kinetics analysis: effects of parameter "Absorbance Change per Minute of 1st sample in Higher Substrate Concentration in absence of inhibitor"
        */
        private void EK2_BhSC_dAbsmin1_TextChanged(object sender, TextChangedEventArgs e)
        {
            string s_out = ComputingService.NumField(EK2_BhSC_dAbsmin1.Text);
            vEK2.BhSC_dAbsmin_1 = Double.Parse("0" + s_out);
            EK2_BhSC_dAbsmin1.Text = s_out;
            EK2_BhSC_dAbsmin1.Select(s_out.Length, 0);

            ComputingService.EK2_BhSC_dAbsmin();
            EK2_BhSC_dAbsmin.Text = vEK2.BhSC_dAbsmin.ToString("#0.00000000");
        }

        /*
           Inhibition Kinetics analysis: effects of parameter "Absorbance Change per Minute of 2nd sample in Higher Substrate Concentration in absence of inhibitor"
        */
        private void EK2_BhSC_dAbsmin2_TextChanged(object sender, TextChangedEventArgs e)
        {
            string s_out = ComputingService.NumField(EK2_BhSC_dAbsmin2.Text);
            vEK2.BhSC_dAbsmin_2 = Double.Parse("0" + s_out);
            EK2_BhSC_dAbsmin2.Text = s_out;
            EK2_BhSC_dAbsmin2.Select(s_out.Length, 0);

            ComputingService.EK2_BhSC_dAbsmin();
            EK2_BhSC_dAbsmin.Text = vEK2.BhSC_dAbsmin.ToString("#0.00000000");
        }

        /*
           Inhibition Kinetics analysis: effects of parameter "average Absorbance Change per Minute in Higher Substrate Concentration in absence of inhibitor"
        */
        private void EK2_BhSC_dAbsmin_TextChanged(object sender, TextChangedEventArgs e)
        {
            ComputingService.EK2_By1();
            if (vEK2.By1 > 0)
            {
                EK2_By1.Text = vEK2.By1.ToString("#0.00000000");
            }

            ComputingService.EK2_BHillCoeff();
            if (vEK2.BHillCoeff > 0)
            {
                EK2_BHillCoeff.Text = vEK2.BHillCoeff.ToString("#0.00");
            }
        }

        /*
           Inhibition Kinetics analysis: effects of parameter "y1 in absence of inhibitor"
        */
        private void EK2_By1_TextChanged(object sender, TextChangedEventArgs e)
        {
            ComputingService.EK2_BtgAngolo();
            if (vEK2.Btg_angolo > 0)
            {
                EK2_BtgAngolo.Text = vEK2.Btg_angolo.ToString("#0.00000000");
            }
        }

        /*
           Inhibition Kinetics analysis: effects of parameter "y2 in absence of inhibitor"
        */
        private void EK2_By2_TextChanged(object sender, TextChangedEventArgs e)
        {
            ComputingService.EK2_BtgAngolo();
            if (vEK2.Btg_angolo > 0)
            {
                EK2_BtgAngolo.Text = vEK2.Btg_angolo.ToString("#0.00000000");
            }

            ComputingService.EK2_BReverseVmax();
            if (vEK2.Breverse_Vmax > 0)
            {
                EK2_BreverseVmax.Text = vEK2.Breverse_Vmax.ToString("#0.00000000");
            }
        }

        /*
           Inhibition Kinetics analysis: effects of parameter "Tangent of Angle in absence of inhibitor"
        */
        private void EK2_BtgAngolo_TextChanged(object sender, TextChangedEventArgs e)
        {
            ComputingService.EK2_BReverseVmax();
            if (vEK2.Breverse_Vmax > 0)
            {
                EK2_BreverseVmax.Text = vEK2.Breverse_Vmax.ToString("#0.00000000");
            }

            ComputingService.EK2_BReverseKm();
            if (vEK2.Breverse_Km > 0)
            {
                EK2_BreverseKm.Text = vEK2.Breverse_Km.ToString("#0.00000000");
            }
        }

        /*
           Inhibition Kinetics analysis: effects of parameter "Reverse of Vmax in absence of inhibitor"
        */
        private void EK2_BreverseVmax_TextChanged(object sender, TextChangedEventArgs e)
        {
            ComputingService.EK2_BVmax();
            if (vEK2.BVmax > 0)
            {
                EK2_BVmax.Text = vEK2.BVmax.ToString("#0.00000000");
            }

            ComputingService.EK2_BReverseKm();
            if (vEK2.Breverse_Km > 0)
            {
                EK2_BreverseKm.Text = vEK2.Breverse_Km.ToString("#0.00000000");
            }
        }

        /*
           Inhibition Kinetics analysis: effects of parameter "Reverse of Km in absence of inhibitor"
        */
        private void EK2_BreverseKm_TextChanged(object sender, TextChangedEventArgs e)
        {
            ComputingService.EK2_BKm();
            if (vEK2.BKm > 0)
            {
                EK2_BKm.Text = vEK2.BKm.ToString("#0.00000000");
            }
        }

        /*
           Inhibition Kinetics analysis: effects of parameter "Hill Coefficient in absence of inhibitor"
        */
        private void EK2_BHillCoeff_TextChanged(object sender, TextChangedEventArgs e)
        {
            ChartParameters.Mask = "IK";
            ChartParameters.nH = vEK2.BHillCoeff;

            ComputingService.EK2_BV0();
            if (vEK2.Bv0 > 0)
            {
                EK2_BV0.Text = vEK2.Bv0.ToString("#0.00000000");
            }

            ComputingService.EK2_InhibitionType();
            EK2_InhibitionType.Text = vEK2.InhibitionType.ToString();

            ComputingService.EK2_BExpectedAbsorbance();
            if (vEK2.BExpectedAbsorbance > 0)
            {
                EK2_BExpectedAbsorb.Text = vEK2.BExpectedAbsorbance.ToString("#0.00000000");
            }
        }

        /*
           Inhibition Kinetics analysis: effects of parameter "Hill Coefficient in presence of inhibitor"
        */
        private void EK2_IHillCoeff_TextChanged(object sender, TextChangedEventArgs e)
        {
            ChartParameters.inH = vEK2.IHillCoeff;

            ComputingService.EK2_InhibitionType();
            EK2_InhibitionType.Text = vEK2.InhibitionType.ToString();

            ComputingService.EK2_IV0();
            if (vEK2.Iv0 > 0)
            {
                EK2_IV0.Text = vEK2.Iv0.ToString("#0.00000000");
            }

            ComputingService.EK2_BExpectedAbsorbance();
            if (vEK2.BExpectedAbsorbance > 0)
            {
                EK2_BExpectedAbsorb.Text = vEK2.BExpectedAbsorbance.ToString("#0.00000000");
            }
        }

        /*
           Inhibition Kinetics analysis: effects of parameter "Computed Reaction Rate in absence of inhibitor"
        */
        private void EK2_BV0_TextChanged(object sender, TextChangedEventArgs e)
        {
            ComputingService.EK2_BVmoli();
            if (vEK2.Bvmoli > 0)
            {
                EK2_BVmoli.Text = vEK2.Bvmoli.ToString("#0.00000000");
            }
        }

        /*
           Inhibition Kinetics analysis: effects of parameter "Final Solution Volume"
        */
        private void EK2_FinSolVol_TextChanged(object sender, TextChangedEventArgs e)
        {
            string s_out = ComputingService.NumField(EK2_FinSolVol.Text);
            vEK2.Vf = Double.Parse("0" + s_out);
            EK2_FinSolVol.Text = s_out;
            EK2_FinSolVol.Select(s_out.Length, 0);

            ComputingService.EK2_BVmoli();
            if (vEK2.Bvmoli > 0)
            {
                EK2_BVmoli.Text = vEK2.Bvmoli.ToString("#0.00000000");
            }

            ComputingService.EK2_IVmoli();
            if (vEK2.Ivmoli > 0)
            {
                EK2_IVmoli.Text = vEK2.Ivmoli.ToString("#0.00000000");
            }
        }

        /*
           Inhibition Kinetics analysis: effects of parameter "Molar Extinction Coefficient"
        */
        private void EK2_Mec_TextChanged(object sender, TextChangedEventArgs e)
        {
            string s_out = ComputingService.NumField(EK2_Mec.Text);
            vEK2.epsilon0 = Double.Parse("0" + s_out);
            EK2_Mec.Text = s_out;
            EK2_Mec.Select(s_out.Length, 0);

            ComputingService.EK2_BVmoli();
            if (vEK2.Bvmoli > 0)
            {
                EK2_BVmoli.Text = vEK2.Bvmoli.ToString("#0.00000000");
            }

            ComputingService.EK2_IVmoli();
            if (vEK2.Ivmoli > 0)
            {
                EK2_IVmoli.Text = vEK2.Ivmoli.ToString("#0.00000000");
            }
        }

        /*
           Inhibition Kinetics analysis: effects of parameter "Optical Path"
        */
        private void EK2_OpticalPath_TextChanged(object sender, TextChangedEventArgs e)
        {
            string s_out = ComputingService.NumField(EK2_OpticalPath.Text);
            vEK2.OpticalPath = Double.Parse("0" + s_out);
            EK2_OpticalPath.Text = s_out;
            EK2_OpticalPath.Select(s_out.Length, 0);

            ComputingService.EK2_BVmoli();
            if (vEK2.Bvmoli > 0)
            {
                EK2_BVmoli.Text = vEK2.Bvmoli.ToString("#0.00000000");
            }

            ComputingService.EK2_IVmoli();
            if (vEK2.Ivmoli > 0)
            {
                EK2_IVmoli.Text = vEK2.Ivmoli.ToString("#0.00000000");
            }
        }

        /*
           Inhibition Kinetics analysis: effects of parameter "Inhibitor Concentration"
        */
        private void EK2_InhibitorConcentration_TextChanged(object sender, TextChangedEventArgs e)
        {
            string s_out = ComputingService.NumField(EK2_InhibitorConc.Text);
            vEK2.InhibitorConcentration = Double.Parse("0" + s_out);
            EK2_InhibitorConc.Text = s_out;
            EK2_InhibitorConc.Select(s_out.Length, 0);
        }

        /*
           Inhibition Kinetics analysis: effects of parameter "Vmax in absence of inhibitor"
        */
        private void EK2_BVmax_TextChanged(object sender, TextChangedEventArgs e)
        {
            ChartParameters.Vmax = vEK2.BVmax;

            ComputingService.EK2_BV0();
            if (vEK2.Bv0 > 0)
            {
                EK2_BV0.Text = vEK2.Bv0.ToString("#0.00000000");
            }

            ComputingService.EK2_BExpectedAbsorbance();
            if (vEK2.BExpectedAbsorbance > 0)
            {
                EK2_BExpectedAbsorb.Text = vEK2.BExpectedAbsorbance.ToString("#0.00000000");
            }

            ComputingService.EK2_BSubstrateInhibition();
            EK2_Absorb_Flag.Text = vEK2.BSubstrateInhibition.ToString("#0");

            ComputingService.EK2_BHillCoeff();
            if (vEK2.BHillCoeff > 0)
            {
                EK2_BHillCoeff.Text = vEK2.BHillCoeff.ToString("#0.00");
            }
        }

        /*
           Inhibition Kinetics analysis: effects of parameter "Km in absence of inhibitor"
        */
        private void EK2_BKm_TextChanged(object sender, TextChangedEventArgs e)
        {
            ChartParameters.Km = vEK2.BKm;

            ComputingService.EK2_BV0();
            if (vEK2.Bv0 > 0)
            {
                EK2_BV0.Text = vEK2.Bv0.ToString("#0.00000000");
            }

            ComputingService.EK2_BAbsorbance_SubstrateConcentration();
            if (vEK2.BAbsorbance_SubstrateConcentration > 0)
            {
                EK2_BAbsor_SubsConc.Text = vEK2.BAbsorbance_SubstrateConcentration.ToString("#0.00000000");
            }

            ComputingService.EK2_BExpectedAbsorbance();
            if (vEK2.BExpectedAbsorbance > 0)
            {
                EK2_BExpectedAbsorb.Text = vEK2.BExpectedAbsorbance.ToString("#0.00000000");
            }

            ComputingService.EK2_BSubstrateInhibition();
            EK2_Absorb_Flag.Text = vEK2.BSubstrateInhibition.ToString("#0");

            ComputingService.EK2_BHillCoeff();
            if (vEK2.BHillCoeff > 0)
            {
                EK2_BHillCoeff.Text = vEK2.BHillCoeff.ToString("#0.00");
            }
        }

        /*
           Inhibition Kinetics analysis: effects of parameter "Substrate Inhibition check flag"
        */
        private void EK2_Absorb_Flag_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (vEK2.BSubstrateInhibition == 1)
            {
                EK2_BAbsor_Result.Text = "Substrate-Inhibition present";
            }
            else
            {
                EK2_BAbsor_Result.Text = "Substrate-Inhibition absent";
            }

            //ChartParameters.SubstrateInhibitionFlag = vEK2.BSubstrateInhibition;
        }

        /*
           Inhibition Kinetics analysis: effects of parameter "Substrate Inhibition check result"
        */
        private void EK2_BAbsor_Result_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (EK2_BAbsor_Result.Text == "Substrate-Inhibition present")
            {
                EK2_BAbsor_Result.Width = 200;
                EK2_BAbsor_Result.Height = 24;
            }
            else
            {
                EK2_BAbsor_Result.Width = 0;
                EK2_BAbsor_Result.Height = 0;
            }

            if (vEK2.Ki > 0)
            {
                EK2_BKi.Text = vEK2.Ki.ToString("#0.00000000");
            }

            //ChartParameters.Ki = vEK2.Ki;
        }

        /*
           Inhibition Kinetics analysis: effects of parameter "Substrate Concentration in Substrate Inhibition check sample"
        */
        private void EK2_BAbsor_SubsConc_TextChanged(object sender, TextChangedEventArgs e)
        {
            ComputingService.EK2_BExpectedAbsorbance();
            if (vEK2.BExpectedAbsorbance > 0)
            {
                EK2_BExpectedAbsorb.Text = vEK2.BExpectedAbsorbance.ToString("#0.00000000");
            }

            ComputingService.EK2_BSubstrateInhibition();
            EK2_Absorb_Flag.Text = vEK2.BSubstrateInhibition.ToString("#0");
        }

        /*
           Inhibition Kinetics analysis: effects of parameter "Absorbance Change per Minute in Substrate Inhibition check sample"
        */
        private void EK2_BAbsorbance_TextChanged(object sender, TextChangedEventArgs e)
        {
            string s_out = ComputingService.NumField(EK2_BAbsorbance.Text);
            vEK2.BAbsorbance = Double.Parse("0" + s_out);
            EK2_BAbsorbance.Text = s_out;
            EK2_BAbsorbance.Select(s_out.Length, 0);

            ComputingService.EK2_BSubstrateInhibition();
            EK2_Absorb_Flag.Text = vEK2.BSubstrateInhibition.ToString("#0");
        }

        /*
           Inhibition Kinetics analysis: effects of parameter "Expected Absorbance Change per Minute in Substrate Inhibition check sample"
        */
        private void EK2_BExpectedAbsorb_TextChanged(object sender, TextChangedEventArgs e)
        {
            ComputingService.EK2_BSubstrateInhibition();
            EK2_Absorb_Flag.Text = vEK2.BSubstrateInhibition.ToString("#0");
        }

        /*
           Inhibition Kinetics analysis: effects of parameter "Absorbance Change per Minute of 1st sample in Lower Substrate concentration in presence of inhibitor"
        */
        private void EK2_IlSC_dAbsmin1_TextChanged(object sender, TextChangedEventArgs e)
        {
            string s_out = ComputingService.NumField(EK2_IlSC_dAbsmin1.Text);
            vEK2.IlSC_dAbsmin_1 = Double.Parse("0" + s_out);
            EK2_IlSC_dAbsmin1.Text = s_out;
            EK2_IlSC_dAbsmin1.Select(s_out.Length, 0);

            ComputingService.EK2_IlSC_dAbsmin();
            EK2_IlSC_dAbsmin.Text = vEK2.IlSC_dAbsmin.ToString("#0.00000000");
        }

        /*
           Inhibition Kinetics analysis: effects of parameter "Absorbance Change per Minute of 2nd sample in Lower Substrate concentration in presence of inhibitor"
        */
        private void EK2_IlSC_dAbsmin2_TextChanged(object sender, TextChangedEventArgs e)
        {
            string s_out = ComputingService.NumField(EK2_IlSC_dAbsmin2.Text);
            vEK2.IlSC_dAbsmin_2 = Double.Parse("0" + s_out);
            EK2_IlSC_dAbsmin2.Text = s_out;
            EK2_IlSC_dAbsmin2.Select(s_out.Length, 0);

            ComputingService.EK2_IlSC_dAbsmin();
            EK2_IlSC_dAbsmin.Text = vEK2.IlSC_dAbsmin.ToString("#0.00000000");
        }

        /*
           Inhibition Kinetics analysis: effects of parameter "average Absorbance Change per Minute in Lower Substrate concentration in presence of inhibitor"
        */
        private void EK2_IlSC_dAbsmin_TextChanged(object sender, TextChangedEventArgs e)
        {
            ComputingService.EK2_Iy2();
            if (vEK2.Iy2 > 0)
            {
                EK2_Iy2.Text = vEK2.Iy2.ToString("#0.00000000");
            }

            ComputingService.EK2_ActiveEnzymPerc();
            if (vEK2.ActiveEnzymePerc > 0)
            {
                EK2_ActiveEnzymPerc.Text = vEK2.ActiveEnzymePerc.ToString("#0.00%");
            }
        }

        /*
           Inhibition Kinetics analysis: effects of parameter "Absorbance Change per Minute of 1st sample in Higher Substrate concentration in presence of inhibitor"
        */
        private void EK2_IhSC_dAbsmin1_TextChanged(object sender, TextChangedEventArgs e)
        {
            string s_out = ComputingService.NumField(EK2_IhSC_dAbsmin1.Text);
            vEK2.IhSC_dAbsmin_1 = Double.Parse("0" + s_out);
            EK2_IhSC_dAbsmin1.Text = s_out;
            EK2_IhSC_dAbsmin1.Select(s_out.Length, 0);

            ComputingService.EK2_IhSC_dAbsmin();
            EK2_IhSC_dAbsmin.Text = vEK2.IhSC_dAbsmin.ToString("#0.00000000");
        }

        /*
           Inhibition Kinetics analysis: effects of parameter "Absorbance Change per Minute of 2nd sample in Higher Substrate concentration in presence of inhibitor"
        */
        private void EK2_IhSC_dAbsmin2_TextChanged(object sender, TextChangedEventArgs e)
        {
            string s_out = ComputingService.NumField(EK2_IhSC_dAbsmin2.Text);
            vEK2.IhSC_dAbsmin_2 = Double.Parse("0" + s_out);
            EK2_IhSC_dAbsmin2.Text = s_out;
            EK2_IhSC_dAbsmin2.Select(s_out.Length, 0);

            ComputingService.EK2_IhSC_dAbsmin();
            EK2_IhSC_dAbsmin.Text = vEK2.IhSC_dAbsmin.ToString("#0.00000000");
        }

        /*
           Inhibition Kinetics analysis: effects of parameter "average Absorbance Change per Minute in Higher Substrate concentration in presence of inhibitor"
        */
        private void EK2_IhSC_dAbsmin_TextChanged(object sender, TextChangedEventArgs e)
        {
            ComputingService.EK2_Iy1();
            if (vEK2.Iy1 > 0)
            {
                EK2_Iy1.Text = vEK2.Iy1.ToString("#0.00000000");
            }

            ComputingService.EK2_IHillCoeff();
            if (vEK2.IHillCoeff > 0)
            {
                EK2_IHillCoeff.Text = vEK2.IHillCoeff.ToString("#0.00");
            }
        }

        /*
           Inhibition Kinetics analysis: effects of parameter "y1 in presence of inhibitor"
        */
        private void EK2_Iy1_TextChanged(object sender, TextChangedEventArgs e)
        {
            ComputingService.EK2_ItgAngolo();
            if (vEK2.Itg_angolo > 0)
            {
                EK2_ItgAngolo.Text = vEK2.Itg_angolo.ToString("#0.00000000");
            }
        }

        /*
           Inhibition Kinetics analysis: effects of parameter "y2 in presence of inhibitor"
        */
        private void EK2_Iy2_TextChanged(object sender, TextChangedEventArgs e)
        {
            ComputingService.EK2_ItgAngolo();
            if (vEK2.Itg_angolo > 0)
            {
                EK2_ItgAngolo.Text = vEK2.Itg_angolo.ToString("#0.00000000");
            }

            ComputingService.EK2_IReverseVmax();
            if (vEK2.Ireverse_Vmax > 0)
            {
                EK2_IreverseVmax.Text = vEK2.Ireverse_Vmax.ToString("#0.00000000");
            }
        }

        /*
           Inhibition Kinetics analysis: effects of parameter "Tangent of Angle in presence of inhibitor"
        */
        private void EK2_ItgAngolo_TextChanged(object sender, TextChangedEventArgs e)
        {
            ComputingService.EK2_IReverseVmax();
            if (vEK2.Ireverse_Vmax > 0)
            {
                EK2_IreverseVmax.Text = vEK2.Ireverse_Vmax.ToString("#0.00000000");
            }

            ComputingService.EK2_IReverseKm();
            if (vEK2.Ireverse_Km > 0)
            {
                EK2_IreverseKm.Text = vEK2.Ireverse_Km.ToString("#0.00000000");
            }
        }

        /*
           Inhibition Kinetics analysis: effects of parameter "Reverse of Vmax in presence of inhibitor"
        */
        private void EK2_IreverseVmax_TextChanged(object sender, TextChangedEventArgs e)
        {
            ComputingService.EK2_IVmax();
            if (vEK2.IVmax > 0)
            {
                EK2_IVmax.Text = vEK2.IVmax.ToString("#0.00000000");
            }

            ComputingService.EK2_IReverseKm();
            if (vEK2.Ireverse_Km > 0)
            {
                EK2_IreverseKm.Text = vEK2.Ireverse_Km.ToString("#0.00000000");
            }
        }

        /*
           Inhibition Kinetics analysis: effects of parameter "Reverse of Km in presence of inhibitor"
        */
        private void EK2_IreverseKm_TextChanged(object sender, TextChangedEventArgs e)
        {
            ComputingService.EK2_IKm();
            if (vEK2.IKm > 0)
            {
                EK2_IKm.Text = vEK2.IKm.ToString("#0.00000000");
            }
        }

        /*
           Inhibition Kinetics analysis: effects of parameter "Vmax in presence of inhibitor"
        */
        private void EK2_IVmax_TextChanged(object sender, TextChangedEventArgs e)
        {
            ChartParameters.iVmax = vEK2.IVmax;

            ComputingService.EK2_InhibitionType();
            EK2_InhibitionType.Text = vEK2.InhibitionType.ToString();

            ComputingService.EK2_IV0();
            if (vEK2.Iv0 > 0)
            {
                EK2_IV0.Text = vEK2.Iv0.ToString("#0.00000000");
            }

            ComputingService.EK2_IHillCoeff();
            if (vEK2.IHillCoeff > 0)
            {
                EK2_IHillCoeff.Text = vEK2.IHillCoeff.ToString("#0.00");
            }
        }

        /*
           Inhibition Kinetics analysis: effects of parameter "Km in presence of inhibitor"
        */
        private void EK2_IKm_TextChanged(object sender, TextChangedEventArgs e)
        {
            ChartParameters.iKm = vEK2.IKm;

            ComputingService.EK2_InhibitionType();
            EK2_InhibitionType.Text = vEK2.InhibitionType.ToString();

            ComputingService.EK2_IV0();
            if (vEK2.Iv0 > 0)
            {
                EK2_IV0.Text = vEK2.Iv0.ToString("#0.00000000");
            }

            ComputingService.EK2_IHillCoeff();
            if (vEK2.IHillCoeff > 0)
            {
                EK2_IHillCoeff.Text = vEK2.IHillCoeff.ToString("#0.00");
            }
        }

        /*
           Inhibition Kinetics analysis: effects of parameter "Computed Reaction Rate in presence of inhibitor"
        */
        private void EK2_IV0_TextChanged(object sender, TextChangedEventArgs e)
        {
            string s_out = ComputingService.NumField(EK2_IV0.Text);
            vEK2.Iv0 = Double.Parse("0" + s_out);
            EK2_IV0.Text = s_out;
            EK2_IV0.Select(s_out.Length, 0);

            ComputingService.EK2_IVmoli();
            if (vEK2.Ivmoli > 0)
            {
                EK2_IVmoli.Text = vEK2.Ivmoli.ToString("#0.00000000");
            }
        }

        /*
           Inhibition Kinetics analysis: effects of parameter "Substrate Concentration"
        */
        private void EK2_SubstrateConcentration_TextChanged(object sender, TextChangedEventArgs e)
        {
            string s_out = ComputingService.NumField(EK2_SubstrateConc.Text);
            vEK2.SubstrateConcentration = Double.Parse("0" + s_out);
            EK2_SubstrateConc.Text = s_out;
            EK2_SubstrateConc.Select(s_out.Length, 0);

            ComputingService.EK2_BV0();
            if (vEK2.Bv0 > 0)
            {
                EK2_BV0.Text = vEK2.Bv0.ToString("#0.00000000");
            }

            ComputingService.EK2_IV0();
            if (vEK2.Iv0 > 0)
            {
                EK2_IV0.Text = vEK2.Iv0.ToString("#0.00000000");
            }
        }

        /*
           Inhibitor Kinetics analysis: procedure to display or to hide hidden parameters to check values correctness
        */
        private void EK2_Test_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (flagTest.fEK2 == 1)
            {
                flagTest.fEK2 = 0;
            }
            else
            {
                flagTest.fEK2 = 1;
            }

            EK2_x1_ptxt.Width = 100 * flagTest.fEK1;
            EK2_x1_ptxt.Height = 24 * flagTest.fEK1;
            EK2_x1.Width = 100 * flagTest.fEK1;
            EK2_x1.Height = 24 * flagTest.fEK1;

            EK2_x2_ptxt.Width = 100 * flagTest.fEK1;
            EK2_x2_ptxt.Height = 24 * flagTest.fEK1;
            EK2_x2.Width = 100 * flagTest.fEK1;
            EK2_x2.Height = 24 * flagTest.fEK1;

            EK2_BlSC_dAbsmin_ptxt.Width = 30 * flagTest.fEK1;
            EK2_BlSC_dAbsmin_ptxt.Height = 24 * flagTest.fEK1;
            EK2_BlSC_dAbsmin.Width = 90 * flagTest.fEK1;
            EK2_BlSC_dAbsmin.Height = 24 * flagTest.fEK1;

            EK2_By2_ptxt.Width = 30 * flagTest.fEK1;
            EK2_By2_ptxt.Height = 24 * flagTest.fEK1;
            EK2_By2.Width = 90 * flagTest.fEK1;
            EK2_By2.Height = 24 * flagTest.fEK1;

            EK2_BhSC_dAbsmin_ptxt.Width = 30 * flagTest.fEK1;
            EK2_BhSC_dAbsmin_ptxt.Height = 24 * flagTest.fEK1;
            EK2_BhSC_dAbsmin.Width = 90 * flagTest.fEK1;
            EK2_BhSC_dAbsmin.Height = 24 * flagTest.fEK1;

            EK2_By1_ptxt.Width = 30 * flagTest.fEK1;
            EK2_By1_ptxt.Height = 24 * flagTest.fEK1;
            EK2_By1.Width = 90 * flagTest.fEK1;
            EK2_By1.Height = 24 * flagTest.fEK1;

            EK2_IlSC_dAbsmin_ptxt.Width = 30 * flagTest.fEK1;
            EK2_IlSC_dAbsmin_ptxt.Height = 24 * flagTest.fEK1;
            EK2_IlSC_dAbsmin.Width = 90 * flagTest.fEK1;
            EK2_IlSC_dAbsmin.Height = 24 * flagTest.fEK1;

            EK2_Iy2_ptxt.Width = 30 * flagTest.fEK1;
            EK2_Iy2_ptxt.Height = 24 * flagTest.fEK1;
            EK2_Iy2.Width = 90 * flagTest.fEK1;
            EK2_Iy2.Height = 24 * flagTest.fEK1;

            EK2_IhSC_dAbsmin_ptxt.Width = 30 * flagTest.fEK1;
            EK2_IhSC_dAbsmin_ptxt.Height = 24 * flagTest.fEK1;
            EK2_IhSC_dAbsmin.Width = 90 * flagTest.fEK1;
            EK2_IhSC_dAbsmin.Height = 24 * flagTest.fEK1;

            EK2_Iy1_ptxt.Width = 30 * flagTest.fEK1;
            EK2_Iy1_ptxt.Height = 24 * flagTest.fEK1;
            EK2_Iy1.Width = 90 * flagTest.fEK1;
            EK2_Iy1.Height = 24 * flagTest.fEK1;

            EK2_BtgAngolo_ptxt.Width = 40 * flagTest.fEK1;
            EK2_BtgAngolo_ptxt.Height = 24 * flagTest.fEK1;
            EK2_BtgAngolo.Width = 90 * flagTest.fEK1;
            EK2_BtgAngolo.Height = 24 * flagTest.fEK1;

            EK2_BreverseVmax_ptxt.Width = 40 * flagTest.fEK1;
            EK2_BreverseVmax_ptxt.Height = 24 * flagTest.fEK1;
            EK2_BreverseVmax.Width = 100 * flagTest.fEK1;
            EK2_BreverseVmax.Height = 24 * flagTest.fEK1;

            EK2_BreverseKm_ptxt.Width = 40 * flagTest.fEK1;
            EK2_BreverseKm_ptxt.Height = 24 * flagTest.fEK1;
            EK2_BreverseKm.Width = 100 * flagTest.fEK1;
            EK2_BreverseKm.Height = 24 * flagTest.fEK1;

            EK2_ItgAngolo_ptxt.Width = 40 * flagTest.fEK1;
            EK2_ItgAngolo_ptxt.Height = 24 * flagTest.fEK1;
            EK2_ItgAngolo.Width = 90 * flagTest.fEK1;
            EK2_ItgAngolo.Height = 24 * flagTest.fEK1;

            EK2_IreverseVmax_ptxt.Width = 40 * flagTest.fEK1;
            EK2_IreverseVmax_ptxt.Height = 24 * flagTest.fEK1;
            EK2_IreverseVmax.Width = 100 * flagTest.fEK1;
            EK2_IreverseVmax.Height = 24 * flagTest.fEK1;

            EK2_IreverseKm_ptxt.Width = 40 * flagTest.fEK1;
            EK2_IreverseKm_ptxt.Height = 24 * flagTest.fEK1;
            EK2_IreverseKm.Width = 100 * flagTest.fEK1;
            EK2_IreverseKm.Height = 24 * flagTest.fEK1;
        }

        /*
           Inhibitor Kinetics analysis: reset of mask, data vector and chart
        */
        private void EK2_Reset_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            HideMsgBox();
            Initialize_EK2();
            ComputingService.Initialize_Chart();
        }

        /*
           Enzymatic Units Assay analysis: effects of parameter "Absorbance Change per Minute of 1st measurement"
        */
        private void EK3_dAbsmin_a_TextChanged(object sender, TextChangedEventArgs e)
        {
            string s_out = ComputingService.NumField(EK3_dAbsmin_a.Text);
            vEK3.dAbsmin_1 = Double.Parse("0" + s_out);
            EK3_dAbsmin_a.Text = s_out;
            EK3_dAbsmin_a.Select(s_out.Length, 0);

            ComputingService.EK3_SC_dAbsmin();
            EK3_dAbsmin_tot.Text = vEK3.dAbsmin.ToString("#0.00000000");
        }

        /*
           Enzymatic Units Assay analysis: effects of parameter "Absorbance Change per Minute of 2nd measurement"
        */
        private void EK3_dAbsmin_b_TextChanged(object sender, TextChangedEventArgs e)
        {
            string s_out = ComputingService.NumField(EK3_dAbsmin_b.Text);
            vEK3.dAbsmin_2 = Double.Parse("0" + s_out);
            EK3_dAbsmin_b.Text = s_out;
            EK3_dAbsmin_b.Select(s_out.Length, 0);

            ComputingService.EK3_SC_dAbsmin();
            EK3_dAbsmin_tot.Text = vEK3.dAbsmin.ToString("#0.00000000");
        }

        /*
           Enzymatic Units Assay analysis: effects of parameter "Absorbance Change per Minute of 3rd measurement"
        */
        private void EK3_dAbsmin_c_TextChanged(object sender, TextChangedEventArgs e)
        {
            string s_out = ComputingService.NumField(EK3_dAbsmin_c.Text);
            vEK3.dAbsmin_3 = Double.Parse("0" + s_out);
            EK3_dAbsmin_c.Text = s_out;
            EK3_dAbsmin_c.Select(s_out.Length, 0);

            ComputingService.EK3_SC_dAbsmin();
            EK3_dAbsmin_tot.Text = vEK3.dAbsmin.ToString("#0.00000000");
        }

        /*
           Enzymatic Units Assay analysis: effects of parameter "average Absorbance Change per Minute"
        */
        private void EK3_dAbsmin_tot_TextChanged(object sender, TextChangedEventArgs e)
        {
            ComputingService.EK3_Unitsml();
            EK3_Unitsml.Text = vEK3.Unitsml.ToString("#0.00000000");
        }

        /*
           Enzymatic Units Assay analysis: effects of parameter "Molar Extinction Coefficient"
        */
        private void EK3_Mec_TextChanged(object sender, TextChangedEventArgs e)
        {
            string s_out = ComputingService.NumField(EK3_Mec.Text);
            vEK3.epsilon0 = Double.Parse("0" + s_out);
            EK3_Mec.Text = s_out;
            EK3_Mec.Select(s_out.Length, 0);

            ComputingService.EK3_Unitsml();
            EK3_Unitsml.Text = vEK3.Unitsml.ToString("#0.00000000");
        }

        /*
           Enzymatic Units Assay analysis: effects of parameter "Optical Path"
        */
        private void EK3_OpticalPath_TextChanged(object sender, TextChangedEventArgs e)
        {
            string s_out = ComputingService.NumField(EK3_OpticalPath.Text);
            vEK3.OpticaltPath = Double.Parse("0" + s_out);
            EK3_OpticalPath.Text = s_out;
            EK3_OpticalPath.Select(s_out.Length, 0);

            ComputingService.EK3_Unitsml();
            EK3_Unitsml.Text = vEK3.Unitsml.ToString("#0.00000000");
        }

        /*
           Enzymatic Units Assay analysis: effects of parameter "Initial Solution Volume"
        */
        private void EK3_InitSolVol_TextChanged(object sender, TextChangedEventArgs e)
        {
            string s_out = ComputingService.NumField(EK3_InitSolVol.Text);
            vEK3.Vi = Double.Parse("0" + s_out);
            EK3_InitSolVol.Text = s_out;
            EK3_InitSolVol.Select(s_out.Length, 0);

            ComputingService.EK3_Unitsml();
            EK3_Unitsml.Text = vEK3.Unitsml.ToString("#0.00000000");
        }

        /*
           Enzymatic Units Assay analysis: effects of parameter "Final Solution Volume"
        */
        private void EK3_FinSolVol_TextChanged(object sender, TextChangedEventArgs e)
        {
            string s_out = ComputingService.NumField(EK3_FinSolVol.Text);
            vEK3.Vf = Double.Parse("0" + s_out);
            EK3_FinSolVol.Text = s_out;
            EK3_FinSolVol.Select(s_out.Length, 0);

            ComputingService.EK3_Unitsml();
            EK3_Unitsml.Text = vEK3.Unitsml.ToString("#0.00000000");
        }

        /*
           Enzymatic Units Assay analysis: procedure to display or to hide hidden parameters to check values correctness
        */
        private void EK3_Test_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (flagTest.fEK3 == 1)
            {
                flagTest.fEK3 = 0;
            }
            else
            {
                flagTest.fEK3 = 1;
            }

            EK3_dAbsmin_tot_text.Width = 30 * flagTest.fEK3;
            EK3_dAbsmin_tot_text.Height = 24 * flagTest.fEK3;
            EK3_dAbsmin_tot.Width = 90 * flagTest.fEK3;
            EK3_dAbsmin_tot.Height = 24 * flagTest.fEK3;
        }

        /*
           Enzymatic Units Assay analysis: reset of data vector
        */
        private void EK3_Reset_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            HideMsgBox();
            Initialize_EK3();
        }

        /*
           Calculation of dAbs/min: effects of parameter "Sample absorbance after 15s"
        */
        private void EK4_Abs_015_TextChanged(object sender, TextChangedEventArgs e)
        {
            string s_out = ComputingService.NumField(EK4_Abs_015.Text);
            vEK4.Abs_015 = Double.Parse("0" + s_out);
            EK4_Abs_015.Text = s_out;
            EK4_Abs_015.Select(s_out.Length, 0);

            ComputingService.EK4_SC_dAbsmin();
            EK4_dAbsmin.Text = vEK4.dAbsmin.ToString("#0.00000000");
        }

        /*
           Calculation of dAbs/min: effects of parameter "Sample absorbance after 1m 15s"
        */
        private void EK4_Abs_115_TextChanged(object sender, TextChangedEventArgs e)
        {
            string s_out = ComputingService.NumField(EK4_Abs_115.Text);
            vEK4.Abs_115 = Double.Parse("0" + s_out);
            EK4_Abs_115.Text = s_out;
            EK4_Abs_115.Select(s_out.Length, 0);

            ComputingService.EK4_SC_dAbsmin();
            EK4_dAbsmin.Text = vEK4.dAbsmin.ToString("#0.00000000");
        }

        /*
           Calculation of dAbs/min: effects of parameter "Sample absorbance after 2m 15s"
        */
        private void EK4_Abs_215_TextChanged(object sender, TextChangedEventArgs e)
        {
            string s_out = ComputingService.NumField(EK4_Abs_215.Text);
            vEK4.Abs_215 = Double.Parse("0" + s_out);
            EK4_Abs_215.Text = s_out;
            EK4_Abs_215.Select(s_out.Length, 0);

            ComputingService.EK4_SC_dAbsmin();
            EK4_dAbsmin.Text = vEK4.dAbsmin.ToString("#0.00000000");
        }

        /*
           Calculation of dAbs/min: effects of parameter "Sample absorbance after 3m 15s"
        */
        private void EK4_Abs_315_TextChanged(object sender, TextChangedEventArgs e)
        {
            string s_out = ComputingService.NumField(EK4_Abs_315.Text);
            vEK4.Abs_315 = Double.Parse("0" + s_out);
            EK4_Abs_315.Text = s_out;
            EK4_Abs_315.Select(s_out.Length, 0);

            ComputingService.EK4_SC_dAbsmin();
            EK4_dAbsmin.Text = vEK4.dAbsmin.ToString("#0.00000000");
        }

        /*
           Calculation of dAbs/min: effects of parameter "Sample absorbance after 4m 15s"
        */
        private void EK4_Abs_415_TextChanged(object sender, TextChangedEventArgs e)
        {
            string s_out = ComputingService.NumField(EK4_Abs_415.Text);
            vEK4.Abs_415 = Double.Parse("0" + s_out);
            EK4_Abs_415.Text = s_out;
            EK4_Abs_415.Select(s_out.Length, 0);

            ComputingService.EK4_SC_dAbsmin();
            EK4_dAbsmin.Text = vEK4.dAbsmin.ToString("#0.00000000");
        }

        /*
           Calculation of dAbs/min: reset of data vector
        */
        private void EK4_Reset_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            HideMsgBox();
            Initialize_EK4();
        }

        /*
           Bradford Assay analysis: effects of parameter "Absorbance Change per Minute of 1st sample of solution with proteins"
        */
        private void EK5_SolProta_TextChanged(object sender, TextChangedEventArgs e)
        {
            string s_out = ComputingService.NumField(EK5_SolProta.Text);
            vEK5.SolProt_1 = Double.Parse("0" + s_out);
            EK5_SolProta.Text = s_out;
            EK5_SolProta.Select(s_out.Length, 0);

            ComputingService.EK5_vetot();
            EK5_vetot.Text = vEK5.vetot.ToString("#0.00000000");
        }

        /*
           Bradford Assay analysis: effects of parameter "Absorbance Change per Minute of 2nd sample of solution with proteins"
        */
        private void EK5_SolProtb_TextChanged(object sender, TextChangedEventArgs e)
        {
            string s_out = ComputingService.NumField(EK5_SolProtb.Text);
            vEK5.SolProt_2 = Double.Parse("0" + s_out);
            EK5_SolProtb.Text = s_out;
            EK5_SolProtb.Select(s_out.Length, 0);

            ComputingService.EK5_vetot();
            EK5_vetot.Text = vEK5.vetot.ToString("#0.00000000");
        }

        /*
           Bradford Assay analysis: effects of parameter "Absorbance Change per Minute of 1st sample of solution without proteins"
        */
        private void EK5_SolBlanka_TextChanged(object sender, TextChangedEventArgs e)
        {
            string s_out = ComputingService.NumField(EK5_SolBlanka.Text);
            vEK5.SolBlank_1 = Double.Parse("0" + s_out);
            EK5_SolBlanka.Text = s_out;
            EK5_SolBlanka.Select(s_out.Length, 0);

            ComputingService.EK5_vbtot();
            EK5_vbtot.Text = vEK5.vbtot.ToString("#0.00000000");
        }

        /*
           Bradford Assay analysis: effects of parameter "Absorbance Change per Minute of 2nd sample of solution without proteins"
        */
        private void EK5_SolBlankb_TextChanged(object sender, TextChangedEventArgs e)
        {
            string s_out = ComputingService.NumField(EK5_SolBlankb.Text);
            vEK5.SolBlank_2 = Double.Parse("0" + s_out);
            EK5_SolBlankb.Text = s_out;
            EK5_SolBlankb.Select(s_out.Length, 0);

            ComputingService.EK5_vbtot();
            EK5_vbtot.Text = vEK5.vbtot.ToString("#0.00000000");
        }

        /*
           Bradford Assay analysis: effects of parameter "average Absorbance Change per Minute of solution with proteins"
        */
        private void EK5_vetot_TextChanged(object sender, TextChangedEventArgs e)
        {
            ComputingService.EK5_ConcProt();
            EK5_ConcProt.Text = vEK5.ConcProt.ToString("#0.00000000");
        }

        /*
           Bradford Assay analysis: effects of parameter "average Absorbance Change per Minute of solution without proteins"
        */
        private void EK5_vbtot_TextChanged(object sender, TextChangedEventArgs e)
        {
            ComputingService.EK5_ConcProt();
            EK5_ConcProt.Text = vEK5.ConcProt.ToString("#0.00000000");
        }

        /*
           Bradford Assay analysis: effects of parameter "Optical Path"
        */
        private void EK5_OpticalPath_TextChanged(object sender, TextChangedEventArgs e)
        {
            string s_out = ComputingService.NumField(EK5_OpticalPath.Text);
            vEK5.OpticaltPath = Double.Parse("0" + s_out);
            EK5_OpticalPath.Text = s_out;
            EK5_OpticalPath.Select(s_out.Length, 0);

            ComputingService.EK5_ConcProt();
            EK5_ConcProt.Text = vEK5.ConcProt.ToString("#0.00000000");
        }

        /*
           Bradford Assay analysis: effects of parameter "Initial Solution Volume"
        */
        private void EK5_InitSolVol_TextChanged(object sender, TextChangedEventArgs e)
        {
            string s_out = ComputingService.NumField(EK5_InitSolVol.Text);
            vEK5.Vi = Double.Parse("0" + s_out);
            EK5_InitSolVol.Text = s_out;
            EK5_InitSolVol.Select(s_out.Length, 0);

            ComputingService.EK5_ConcProt();
            EK5_ConcProt.Text = vEK5.ConcProt.ToString("#0.00000000");
        }

        /*
           Bradford Assay analysis: effects of parameter procedure to display or to hide hidden parameters to check values correctness
        */
        private void EK5_Test_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (flagTest.fEK5 == 1)
            {
                flagTest.fEK5 = 0;
            }
            else
            {
                flagTest.fEK5 = 1;
            }

            EK5_vetot_text.Width = 40 * flagTest.fEK5;
            EK5_vetot_text.Height = 24 * flagTest.fEK5;
            EK5_vetot.Width = 100 * flagTest.fEK5;
            EK5_vetot.Height = 24 * flagTest.fEK5;

            EK5_vbtot_text.Width = 40 * flagTest.fEK5;
            EK5_vbtot_text.Height = 24 * flagTest.fEK5;
            EK5_vbtot.Width = 100 * flagTest.fEK5;
            EK5_vbtot.Height = 24 * flagTest.fEK5;
        }

        /*
            Bradford Assay analysis: reset of data vector
         */
        private void EK5_Reset_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            HideMsgBox();
            Initialize_EK5();
        }

        /*
           Display of pop-up clarifying the meaning of "appropriate"
        */
        private void Appropriate_Pressed(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            Flyout.ShowAttachedFlyout((TextBlock)sender);
        }

        /*
           Simple Enzyme Kinetics analysis: data completion check evaluating parameter "Vmax"
        */
        private void EK1_Vmax_GotFocus(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (vEK1.Vmax > 0)
            {
                EK1_MessageBox.Text = "";
            }
            else
            {
                string _message = "Please set: ";
                if (vEK1.lSC == 0)
                {
                    _message += "Samples lower substrate concentration; ";
                }
                if (vEK1.hSC == 0)
                {
                    _message += "Samples higher substrate concentration; ";
                }
                if (vEK1.lSC_dAbsmin == 0)
                {
                    _message += "\u0394Abs/min for samples with lower substrate concentration; ";
                }
                if (vEK1.hSC_dAbsmin == 0)
                {
                    _message += "\u0394Abs/min for samples with higher substrate concentration; ";
                }

                EK1_MessageBox.Text = _message;
            }
        }

        /*
           Inhibition Kinetics analysis: data completion check evaluating parameter "Vmax in absence of inhibitor" 
        */
        private void EK2_BVmax_GotFocus(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (vEK2.BVmax > 0)
            {
                EK2_MessageBox.Text = "";
            }
            else
            {
                string _message = "Please set: ";
                if (vEK2.BlSC == 0)
                {
                    _message += "Samples lower substrate concentration; ";
                }
                if (vEK2.BhSC == 0)
                {
                    _message += "Samples higher substrate concentration; ";
                }
                if (vEK2.BlSC_dAbsmin == 0)
                {
                    _message += "\u0394Abs/min for samples with lower substrate concentration; ";
                }
                if (vEK2.BhSC_dAbsmin == 0)
                {
                    _message += "\u0394Abs/min for samples with higher substrate concentration; ";
                }

                EK2_MessageBox.Text = _message;
            }
        }

        /*
           Inhibition Kinetics analysis: data completion check evaluating parameter "Vmax in presence of inhibitor" 
        */
        private void EK2_IVmax_GotFocus(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (vEK2.IVmax > 0)
            {
                EK2_MessageBox.Text = "";
            }
            else
            {
                string _message = "Please set: ";
                if (vEK2.IlSC == 0)
                {
                    _message += "Samples lower substrate concentration; ";
                }
                if (vEK2.IhSC == 0)
                {
                    _message += "Samples higher substrate concentration; ";
                }
                if (vEK2.IlSC_dAbsmin == 0)
                {
                    _message += "\u0394Abs/min for samples with lower substrate concentration; ";
                }
                if (vEK2.IhSC_dAbsmin == 0)
                {
                    _message += "\u0394Abs/min for samples with higher substrate concentration; ";
                }

                EK2_MessageBox.Text = _message;
            }
        }

        /*
           Simple Enzyme Kinetics analysis: data completion check evaluating parameter "Km"
        */
        private void EK1_Km_GotFocus(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (vEK1.Km > 0)
            {
                EK1_MessageBox.Text = "";
            }
            else
            {
                string _message = "Please set: ";
                if (vEK1.lSC == 0)
                {
                    _message += "Samples lower substrate concentration; ";
                }
                if (vEK1.hSC == 0)
                {
                    _message += "Samples higher substrate concentration; ";
                }
                if (vEK1.lSC_dAbsmin == 0)
                {
                    _message += "\u0394Abs/min for samples with lower substrate concentration; ";
                }
                if (vEK1.hSC_dAbsmin == 0)
                {
                    _message += "\u0394Abs/min for samples with higher substrate concentration; ";
                }

                EK1_MessageBox.Text = _message;
            }
        }

        /*
           Inhibition Kinetics analysis: data completion check evaluating parameter "Km in absence of inhibitor"
        */
        private void EK2_BKm_GotFocus(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (vEK2.BKm > 0)
            {
                EK2_MessageBox.Text = "";
            }
            else
            {
                string _message = "Please set: ";
                if (vEK2.BlSC == 0)
                {
                    _message += "Samples lower substrate concentration; ";
                }
                if (vEK2.BhSC == 0)
                {
                    _message += "Samples higher substrate concentration; ";
                }
                if (vEK2.BlSC_dAbsmin == 0)
                {
                    _message += "\u0394Abs/min for samples with lower substrate concentration; ";
                }
                if (vEK2.BhSC_dAbsmin == 0)
                {
                    _message += "\u0394Abs/min for samples with higher substrate concentration; ";
                }

                EK2_MessageBox.Text = _message;
            }
        }

        /*
           Inhibition Kinetics analysis: data completion check evaluating parameter "Km in presence of inhibitor"
        */
        private void EK2_IKm_GotFocus(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (vEK2.IKm > 0)
            {
                EK2_MessageBox.Text = "";
            }
            else
            {
                string _message = "Please set: ";
                if (vEK2.IlSC == 0)
                {
                    _message += "Samples lower substrate concentration; ";
                }
                if (vEK2.IhSC == 0)
                {
                    _message += "Samples higher substrate concentration; ";
                }
                if (vEK2.IlSC_dAbsmin == 0)
                {
                    _message += "\u0394Abs/min for samples with lower substrate concentration; ";
                }
                if (vEK2.IhSC_dAbsmin == 0)
                {
                    _message += "\u0394Abs/min for samples with higher substrate concentration; ";
                }

                EK2_MessageBox.Text = _message;
            }
        }

        /*
           Simple Enzyme Kinetics analysis: data completion check evaluating parameter "Substrate Concentration in Substrate Inhibition check sample"
        */
        private void EK1_Absorb_SubstrConc_GotFocus(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (vEK1.Absorbance_SubstrateConcentration > 0)
            {
                EK1_MessageBox.Text = "";
            }
            else
            {
                string _message = "Please set: ";
                if (vEK1.lSC == 0)
                {
                    _message += "Samples lower substrate concentration; ";
                }
                if (vEK1.hSC == 0)
                {
                    _message += "Samples higher substrate concentration; ";
                }
                if (vEK1.lSC_dAbsmin == 0)
                {
                    _message += "\u0394Abs/min for samples with lower substrate concentration; ";
                }
                if (vEK1.hSC_dAbsmin == 0)
                {
                    _message += "\u0394Abs/min for samples with higher substrate concentration; ";
                }

                EK1_MessageBox.Text = _message;
            }
        }

        /*
           Inhibion Kinetics analysis: data completion check evaluating parameter "Substrate Concentration in Substrate Inhibition check sample"
        */
        private void EK2_BAbsor_SubsConc_GotFocus(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (vEK2.BAbsorbance_SubstrateConcentration > 0)
            {
                EK2_MessageBox.Text = "";
            }
            else
            {
                string _message = "Please set: ";
                if (vEK2.BlSC == 0)
                {
                    _message += "Samples lower substrate concentration; ";
                }
                if (vEK2.BhSC == 0)
                {
                    _message += "Samples higher substrate concentration; ";
                }
                if (vEK2.BlSC_dAbsmin == 0)
                {
                    _message += "\u0394Abs/min for samples with lower substrate concentration; ";
                }
                if (vEK2.BhSC_dAbsmin == 0)
                {
                    _message += "\u0394Abs/min for samples with higher substrate concentration; ";
                }

                EK2_MessageBox.Text = _message;
            }
        }

        /*
           Inhibion Kinetics analysis: data completion check evaluating parameter "Percentage of Active Enzyme"
        */
        private void EK2_ActiveEnzymPerc_GotFocus(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (vEK2.ActiveEnzymePerc > 0)
            {
                EK2_MessageBox.Text = "";
            }
            else
            {
                string _message = "Please set: ";
                if (vEK2.BlSC_dAbsmin == 0)
                {
                    _message += "\u0394Abs/min for samples with lower substrate concentration; ";
                }
                if (vEK2.BhSC_dAbsmin == 0)
                {
                    _message += "\u0394Abs/min for samples with higher substrate concentration; ";
                }

                EK2_MessageBox.Text = _message;
            }
        }

        /*
           Simple Enzyme Kinetics analysis: data completion check evaluating parameter "Kcat"
        */
        private void EK1_Kcat_GotFocus(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (vEK1.Kcat > 0)
            {
                EK1_MessageBox.Text = "";
            }
            else
            {
                string _message = "Please set: ";
                if (vEK1.epsilon0 == 0)
                {
                    _message += "Molar extinction coefficient; ";
                }
                if (vEK1.OpticalPath == 0)
                {
                    _message += "Optical path; ";
                }
                if (vEK1.MolecularWeight == 0)
                {
                    _message += "Product molecular weight; ";
                }
                if (vEK1.ConcProt == 0)
                {
                    _message += "Check Proteins/ml; ";
                }
                if (vEK1.Vmax == 0)
                {
                    _message += "Check Vmax; ";
                }

                EK1_MessageBox.Text = _message;
            }
        }

        /*
           Simple Enzyme Kinetics analysis: data completion check evaluating parameter "Units/ml"
        */
        private void EK1_Unitsml_GotFocus(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (vEK1.Unitsml > 0)
            {
                EK1_MessageBox.Text = "";
            }
            else
            {
                string _message = "Please set: ";
                if (vEK1.epsilon0 == 0)
                {
                    _message += "Molar extinction coefficient; ";
                }
                if (vEK1.OpticalPath == 0)
                {
                    _message += "Optical path; ";
                }
                if (vEK1.Absorbance == 0)
                {
                    _message += "Absorbance change per minute; ";
                }
                if (vEK1.Vi == 0)
                {
                    _message += "Initial volume; ";
                }
                if (vEK1.Vf == 0)
                {
                    _message += "Final volume; ";
                }

                EK1_MessageBox.Text = _message;
            }
        }

        /*
           Simple Enzyme Kinetics analysis: data completion check evaluating parameter "Protein Concentration"
        */
        private void EK1_ConcProt_GotFocus(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (vEK1.ConcProt > 0)
            {
                EK1_MessageBox.Text = "";
            }
            else
            {
                string _message = "Please set: ";
                if (vEK1.vetot == 0)
                {
                    _message += "Bradford assay of proteic solution; ";
                }
                if (vEK1.vbtot == 0)
                {
                    _message += "Bradford assay of blank solution; ";
                }
                if (vEK1.OpticalPath == 0)
                {
                    _message += "Optical path; ";
                }
                if (vEK1.Vi == 0)
                {
                    _message += "Initial volume; ";
                }
                if (vEK1.Vf == 0)
                {
                    _message += "Final volume; ";
                }

                EK1_MessageBox.Text = _message;
            }
        }

        /*
           Simple Enzyme Kinetics analysis: data completion check evaluating parameter "Specific Activity"
        */
        private void EK1_AttSpec_GotFocus(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (vEK1.AttSpec > 0)
            {
                EK1_MessageBox.Text = "";
            }
            else
            {
                string _message = "Please check: ";
                if (vEK1.Unitsml == 0)
                {
                    _message += "Units/ml; ";
                }
                if (vEK1.ConcProt == 0)
                {
                    _message += "Proteins/ml; ";
                }

                EK1_MessageBox.Text = _message;
            }
        }

        /*
           Simple Enzyme Kinetics analysis: data completion check evaluating parameter "Computed Reaction Rate"
        */
        private void EK1_V0_GotFocus(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (vEK1.v0 > 0)
            {
                EK1_MessageBox.Text = "";
            }
            else
            {
                string _message = "Please set: ";
                if (vEK1.SubstrateConcentration == 0)
                {
                    _message += "Substrate concentration for assessment; ";
                }
                if (vEK1.Km == 0)
                {
                    _message += "Check Km; ";
                }
                if (vEK1.Vmax == 0)
                {
                    _message += "Check Vmax; ";
                }

                EK1_MessageBox.Text = _message;
            }
        }

        /*
           Inhibition Kinetics analysis: data completion check evaluating parameter "Computed Reaction Rate in absence of inhibitor"
        */
        private void EK2_BV0_GotFocus(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (vEK2.Bv0 > 0)
            {
                EK2_MessageBox.Text = "";
            }
            else
            {
                string _message = "Please set: ";
                if (vEK2.SubstrateConcentration == 0)
                {
                    _message += "Substrate concentration for assessment; ";
                }
                if (vEK2.BKm == 0)
                {
                    _message += "Check Km; ";
                }
                if (vEK2.BVmax == 0)
                {
                    _message += "Check Vmax; ";
                }

                EK2_MessageBox.Text = _message;
            }
        }

        /*
           Inhibition Kinetics analysis: data completion check evaluating parameter "Computed Reaction Rate in presence of inhibitor"
        */
        private void EK2_IV0_GotFocus(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (vEK2.Iv0 > 0)
            {
                EK2_MessageBox.Text = "";
            }
            else
            {
                string _message = "Please set: ";
                if (vEK2.SubstrateConcentration == 0)
                {
                    _message += "Substrate concentration for assessment; ";
                }
                if (vEK2.IKm == 0)
                {
                    _message += "Check Km with inhibitor; ";
                }
                if (vEK2.IVmax == 0)
                {
                    _message += "Check Vmax with inhibitor; ";
                }

                EK2_MessageBox.Text = _message;
            }
        }

        /*
           Simple Enzyme Kinetics analysis: data completion check evaluating parameter "Computed Reaction Rate evaluated in moli/min"
        */
        private void EK1_Vmoli_GotFocus(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (vEK1.vmoli > 0)
            {
                EK1_MessageBox.Text = "";
            }
            else
            {
                string _message = "Please set: ";
                if (vEK1.SubstrateConcentration == 0)
                {
                    _message += "Substrate concentration for assessment; ";
                }
                if (vEK1.epsilon0 == 0)
                {
                    _message += "Molar extinction coefficient; ";
                }
                if (vEK1.OpticalPath == 0)
                {
                    _message += "Optical path; ";
                }
                if (vEK1.Vf == 0)
                {
                    _message += "Final volume; ";
                }
                if (vEK1.Km == 0)
                {
                    _message += "Check Km; ";
                }
                if (vEK1.Vmax == 0)
                {
                    _message += "Check Vmax; ";
                }

                EK1_MessageBox.Text = _message;
            }
        }

        /*
           Inhibition Kinetics analysis: data completion check evaluating parameter "Computed Reaction Rate in absence of inhibitor evaluated in moli/min"
        */
        private void EK2_BVmoli_GotFocus(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (vEK2.Bvmoli > 0)
            {
                EK2_MessageBox.Text = "";
            }
            else
            {
                string _message = "Please set: ";
                if (vEK2.SubstrateConcentration == 0)
                {
                    _message += "Substrate concentration for assessment; ";
                }
                if (vEK2.epsilon0 == 0)
                {
                    _message += "Molar extinction coefficient; ";
                }
                if (vEK2.OpticalPath == 0)
                {
                    _message += "Optical path; ";
                }
                if (vEK2.Vf == 0)
                {
                    _message += "Final volume; ";
                }
                if (vEK2.BKm == 0)
                {
                    _message += "Check Km; ";
                }
                if (vEK2.BVmax == 0)
                {
                    _message += "Check Vmax; ";
                }

                EK1_MessageBox.Text = _message;
            }
        }

        /*
           Inhibition Kinetics analysis: data completion check evaluating parameter "Computed Reaction Rate in presence of inhibitor evaluated in moli/min"
        */
        private void EK2_IVmoli_GotFocus(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (vEK2.Ivmoli > 0)
            {
                EK2_MessageBox.Text = "";
            }
            else
            {
                string _message = "Please set: ";
                if (vEK2.SubstrateConcentration == 0)
                {
                    _message += "Substrate concentration for assessment; ";
                }
                if (vEK2.epsilon0 == 0)
                {
                    _message += "Molar extinction coefficient; ";
                }
                if (vEK2.OpticalPath == 0)
                {
                    _message += "Optical path; ";
                }
                if (vEK2.Vf == 0)
                {
                    _message += "Final volume; ";
                }
                if (vEK2.IKm == 0)
                {
                    _message += "Check Km; ";
                }
                if (vEK2.IVmax == 0)
                {
                    _message += "Check Vmax; ";
                }

                EK1_MessageBox.Text = _message;
            }
        }

        /*
           Simple Enzyme Kinetics analysis: data completion check evaluating parameter "Catalytic Efficiency"
        */
        private void EK1_CatalEff_GotFocus(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (vEK1.CatalEff > 0)
            {
                EK1_MessageBox.Text = "";
            }
            else
            {
                string _message = "Please check: ";
                if (vEK1.Kcat == 0)
                {
                    _message += "Kcat; ";
                }
                if (vEK1.Km == 0)
                {
                    _message += "Km; ";
                }

                EK1_MessageBox.Text = _message;
            }
        }

        /*
           Simple Enzyme Kinetics analysis: consistency check on Absorbance Change per Minute of Lower Substrate Concentration samples
        */
        private void EK1_lSC_LostFocus(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (vEK1.lSC == 0)
            {
                string s_err = "Please insert lower substrate concentration";
                string t_err = "Alert";
                ShowMsgBox(t_err, s_err);
            }
            else if (vEK1.lSC * vEK1.hSC > 0 && vEK1.lSC >= vEK1.hSC)
            {
                string s_err = "Wrong order of substrate concentration values";
                string t_err = "Alert";
                ShowMsgBox(t_err, s_err);
            }
            else if (vEK1.lSC_dAbsmin_1 * vEK1.lSC_dAbsmin_2 == 0)
            {
                vEK1.lSC_dAbsmin = 0;
                EK1_lSC_dAbsmin.Text = vEK1.lSC_dAbsmin.ToString("#0.00000000");
            }
            else if (vEK1.lSC_dAbsmin_1 * vEK1.lSC_dAbsmin_2 > 0)
            {
                if (ComputingService.rely_test(vEK1.lSC_dAbsmin_1, vEK1.lSC_dAbsmin_2) != 1)
                {
                    string s_err = "Values too different for substrate concentration of ";
                    s_err += vEK1.lSC.ToString("#0.00");
                    s_err += " \u03BCM";
                    string t_err = "Error";
                    ShowMsgBox(t_err, s_err);

                    vEK1.lSC_dAbsmin = 0;
                    EK1_lSC_dAbsmin.Text = vEK1.lSC_dAbsmin.ToString("#0.00000000");
                }
            }
            else if (vEK1.lSC_dAbsmin * vEK1.hSC_dAbsmin > 0 && vEK1.lSC_dAbsmin >= vEK1.hSC_dAbsmin)
            {
                string s_err = "Incongruent data of samples absorbance change per minute";
                string t_err = "Error";
                ShowMsgBox(t_err, s_err);
            }
        }

        /*
           Simple Enzyme Kinetics analysis: consistency check on Absorbance Change per Minute of Higher Substrate Concentration samples
        */
        private void EK1_hSC_LostFocus(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (vEK1.hSC == 0)
            {
                string s_err = "Please insert higher substrate concentration";
                string t_err = "Alert";
                ShowMsgBox(t_err, s_err);
            }
            else if (vEK1.lSC * vEK1.hSC > 0 && vEK1.lSC >= vEK1.hSC)
            {
                string s_err = "Wrong order of substrate concentration values";
                string t_err = "Alert";
                ShowMsgBox(t_err, s_err);
            }
            else if (vEK1.hSC_dAbsmin_1 * vEK1.hSC_dAbsmin_2 == 0)
            {
                vEK1.hSC_dAbsmin = 0;
                EK1_hSC_dAbsmin.Text = vEK1.hSC_dAbsmin.ToString("#0.00000000");
            }
            else if (vEK1.hSC_dAbsmin_1 * vEK1.hSC_dAbsmin_2 > 0)
            {
                if (ComputingService.rely_test(vEK1.hSC_dAbsmin_1, vEK1.hSC_dAbsmin_2) != 1)
                {
                    string s_err = "Values too different for substrate concentration of ";
                    s_err += vEK1.hSC.ToString("#0.00");
                    s_err += " \u03BCM";
                    string t_err = "Error";
                    ShowMsgBox(t_err, s_err);

                    vEK1.hSC_dAbsmin = 0;
                    EK1_hSC_dAbsmin.Text = vEK1.hSC_dAbsmin.ToString("#0.00000000");
                }
            }
            else if (vEK1.lSC_dAbsmin * vEK1.hSC_dAbsmin > 0 && vEK1.lSC_dAbsmin >= vEK1.hSC_dAbsmin)
            {
                string s_err = "Incongruent data of samples absorbance change per minute";
                string t_err = "Error";
                ShowMsgBox(t_err, s_err);
            }
        }

        /*
           Inhibition Kinetics analysis: consistency check on Absorbance Change per Minute of Lower Substrate Concentration samples in absence of inhibitor
        */
        private void EK2_BlSC_LostFocus(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (vEK2.BlSC == 0)
            {
                string s_err = "Please insert lower substrate concentration in absence of inhibitor";
                string t_err = "Alert";
                ShowMsgBox(t_err, s_err);
            }
            else if (vEK2.BlSC * vEK2.BhSC > 0 && vEK2.BlSC >= vEK2.BhSC)
            {
                string s_err = "Wrong order of substrate concentration values in absence of inhibitor";
                string t_err = "Alert";
                ShowMsgBox(t_err, s_err);
            }
            else if (vEK2.BlSC_dAbsmin_1 * vEK2.BlSC_dAbsmin_2 == 0)
            {
                vEK2.BlSC_dAbsmin = 0;
                EK2_BlSC_dAbsmin.Text = vEK2.BlSC_dAbsmin.ToString("#0.00000000");
            }
            else if (vEK2.BlSC_dAbsmin_1 * vEK2.BlSC_dAbsmin_2 > 0)
            {
                if (ComputingService.rely_test(vEK2.BlSC_dAbsmin_1, vEK2.BlSC_dAbsmin_2) != 1)
                {
                    string s_err = "Values too different for substrate concentration of ";
                    s_err += vEK2.BlSC.ToString("#0.00");
                    s_err += " \u03BCM in absence of inhibitor";
                    string t_err = "Error";
                    ShowMsgBox(t_err, s_err);

                    vEK2.BlSC_dAbsmin = 0;
                    EK2_BlSC_dAbsmin.Text = vEK2.BlSC_dAbsmin.ToString("#0.00000000");
                }
            }
            else if (vEK2.BlSC_dAbsmin * vEK2.BhSC_dAbsmin > 0 && vEK2.BlSC_dAbsmin >= vEK2.BhSC_dAbsmin)
            {
                string s_err = "Incongruent data of samples absorbance change per minute in absence of inhibitor";
                string t_err = "Error";
                ShowMsgBox(t_err, s_err);
            }
        }

        /*
           Inhibition Kinetics analysis: consistency check on Absorbance Change per Minute of Higher Substrate Concentration samples in absence of inhibitor
        */
        private void EK2_BhSC_LostFocus(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (vEK2.BhSC == 0)
            {
                string s_err = "Please insert higher substrate concentration in absence of inhibitor";
                string t_err = "Alert";
                ShowMsgBox(t_err, s_err);
            }
            else if (vEK2.BlSC * vEK2.BhSC > 0 && vEK2.BlSC >= vEK2.BhSC)
            {
                string s_err = "Wrong order of substrate concentration values in absence of inhibitor";
                string t_err = "Alert";
                ShowMsgBox(t_err, s_err);
            }
            else if (vEK2.BhSC_dAbsmin_1 * vEK2.BhSC_dAbsmin_2 == 0)
            {
                vEK2.BhSC_dAbsmin = 0;
                EK2_BhSC_dAbsmin.Text = vEK2.BhSC_dAbsmin.ToString("#0.00000000");
            }
            else if (vEK2.BhSC_dAbsmin_1 * vEK2.BhSC_dAbsmin_2 > 0)
            {
                if (ComputingService.rely_test(vEK2.BhSC_dAbsmin_1, vEK2.BhSC_dAbsmin_2) != 1)
                {
                    string s_err = "Values too different for substrate concentration of ";
                    s_err += vEK2.BhSC.ToString("#0.00");
                    s_err += " \u03BCM in absence of inhibitor";
                    string t_err = "Error";
                    ShowMsgBox(t_err, s_err);

                    vEK2.BhSC_dAbsmin = 0;
                    EK2_BhSC_dAbsmin.Text = vEK2.BhSC_dAbsmin.ToString("#0.00000000");
                }
            }
            else if (vEK2.BlSC_dAbsmin * vEK2.BhSC_dAbsmin > 0 && vEK2.BlSC_dAbsmin >= vEK2.BhSC_dAbsmin)
            {
                string s_err = "Incongruent data of samples absorbance change per minute in absence of inhibitor";
                string t_err = "Error";
                ShowMsgBox(t_err, s_err);
            }
        }

        /*
           Inhibition Kinetics analysis: consistency check on Absorbance Change per Minute of Lower Substrate Concentration samples in presence of inhibitor
        */
        private void EK2_IlSC_LostFocus(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (vEK2.IlSC == 0)
            {
                string s_err = "Please insert lower substrate concentration in presence of inhibitor";
                string t_err = "Alert";
                ShowMsgBox(t_err, s_err);
            }
            else if (vEK2.IlSC * vEK2.IhSC > 0 && vEK2.IlSC >= vEK2.IhSC)
            {
                string s_err = "Wrong order of substrate concentration values in presence of inhibitor";
                string t_err = "Alert";
                ShowMsgBox(t_err, s_err);
            }
            else if (vEK2.IlSC_dAbsmin_1 * vEK2.IlSC_dAbsmin_2 == 0)
            {
                vEK2.IlSC_dAbsmin = 0;
                EK2_IlSC_dAbsmin.Text = vEK2.IlSC_dAbsmin.ToString("#0.00000000");
            }
            else if (vEK2.IlSC_dAbsmin_1 * vEK2.IlSC_dAbsmin_2 > 0)
            {
                if (ComputingService.rely_test(vEK2.IlSC_dAbsmin_1, vEK2.IlSC_dAbsmin_2) != 1)
                {
                    string s_err = "Values too different for substrate concentration of ";
                    s_err += vEK2.IlSC.ToString("#0.00");
                    s_err += " \u03BCM in presence of inhibitor";
                    string t_err = "Error";
                    ShowMsgBox(t_err, s_err);

                    vEK2.IlSC_dAbsmin = 0;
                    EK2_IlSC_dAbsmin.Text = vEK2.IlSC_dAbsmin.ToString("#0.00000000");
                }
            }
            else if (vEK2.IlSC_dAbsmin * vEK2.IhSC_dAbsmin > 0 && vEK2.IlSC_dAbsmin >= vEK2.IhSC_dAbsmin)
            {
                string s_err = "Incongruent data of samples absorbance change per minute in presence of inhibitor";
                string t_err = "Error";
                ShowMsgBox(t_err, s_err);
            }
        }

        /*
           Inhibition Kinetics analysis: consistency check on Absorbance Change per Minute of Higher Substrate Concentration samples in presence of inhibitor
        */
        private void EK2_IhSC_LostFocus(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (vEK2.IhSC == 0)
            {
                string s_err = "Please insert higher substrate concentration in presence of inhibitor";
                string t_err = "Alert";
                ShowMsgBox(t_err, s_err);
            }
            else if (vEK2.IlSC * vEK2.IhSC > 0 && vEK2.IlSC >= vEK2.IhSC)
            {
                string s_err = "Wrong order of substrate concentration values in presence of inhibitor";
                string t_err = "Alert";
                ShowMsgBox(t_err, s_err);
            }
            else if (vEK2.IhSC_dAbsmin_1 * vEK2.IhSC_dAbsmin_2 == 0)
            {
                vEK2.IhSC_dAbsmin = 0;
                EK2_IhSC_dAbsmin.Text = vEK2.IhSC_dAbsmin.ToString("#0.00000000");
            }
            else if (vEK2.IhSC_dAbsmin_1 * vEK2.IhSC_dAbsmin_2 > 0)
            {
                if (ComputingService.rely_test(vEK2.IhSC_dAbsmin_1, vEK2.IhSC_dAbsmin_2) != 1)
                {
                    string s_err = "Values too different for substrate concentration of ";
                    s_err += vEK2.IhSC.ToString("#0.00");
                    s_err += " \u03BCM in presence of inhibitor";
                    string t_err = "Error";
                    ShowMsgBox(t_err, s_err);

                    vEK2.IhSC_dAbsmin = 0;
                    EK2_IhSC_dAbsmin.Text = vEK2.IhSC_dAbsmin.ToString("#0.00000000");
                }
            }
            else if (vEK2.IlSC_dAbsmin * vEK2.IhSC_dAbsmin > 0 && vEK2.IlSC_dAbsmin >= vEK2.IhSC_dAbsmin)
            {
                string s_err = "Incongruent data of samples absorbance change per minute in presence of inhibitor";
                string t_err = "Error";
                ShowMsgBox(t_err, s_err);
            }
        }

        /*
           Simple Enzyme Kinetics analysis: consistency check on Absorbance Change per Minute of samples of Solution with Proteins
        */
        private void EK1_SolProt_LostFocus(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (vEK1.SolProt_1 * vEK1.SolProt_2 > 0)
            {
                if (ComputingService.rely_test(vEK1.SolProt_1, vEK1.SolProt_2) != 1)
                {
                    vEK1.vetot = 0;
                    string s_err = "In Bradford Assay, values too different for the solution with proteins";
                    string t_err = "Error";
                    ShowMsgBox(t_err, s_err);
                }
            }
            else
            {
                vEK1.vetot = 0;
            }

            EK1_vetot.Text = vEK1.vetot.ToString("#0.00000000");
        }

        /*
           Simple Enzyme Kinetics analysis: consistency check on Absorbance Change per Minute of samples of Solution without Proteins
        */
        private void EK1_SolBlank_LostFocus(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (vEK1.SolBlank_1 * vEK1.SolBlank_2 > 0)
            {
                if (ComputingService.rely_test(vEK1.SolBlank_1, vEK1.SolBlank_2) != 1)
                {
                    vEK1.vbtot = 0;
                    string s_err = "In Bradford Assay, values too different for the solution without proteins";
                    string t_err = "Error";
                    ShowMsgBox(t_err, s_err);
                }
            }
            else
            {
                vEK1.vbtot = 0;
            }
        }

        /*
           Enzymatic Units Assay analysis: consistency check on Absorbance Change per Minute of samples
        */
        private void EK3_dAbsmin_LostFocus(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (vEK3.dAbsmin_1 * vEK3.dAbsmin_2 * vEK3.dAbsmin_3 > 0)
            {
                if (ComputingService.rely3_test(vEK3.dAbsmin_1, vEK3.dAbsmin_2, vEK3.dAbsmin_3) != 1)
                {
                    vEK3.dAbsmin = 0;
                    string s_err = "Values too different for saturant substrate concentration";
                    string t_err = "Error";
                    ShowMsgBox(t_err, s_err);
                }
            }
            else
            {
                vEK3.dAbsmin = 0;
            }

            EK3_dAbsmin_tot.Text = vEK3.dAbsmin.ToString("#0.00000000");
        }

        /*
           Bradford Assay analysis: consistency check on Absorbance Change per Minute of samples of Solution with Proteins
        */
        private void EK5_SolProt_LostFocus(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (vEK5.SolProt_1 * vEK5.SolProt_2 > 0)
            {
                if (ComputingService.rely_test(vEK5.SolProt_1, vEK5.SolProt_2) != 1)
                {
                    vEK5.vetot = 0;
                    string s_err = "In Bradford Assay, values too different for the solution with proteins";
                    string t_err = "Error";
                    ShowMsgBox(t_err, s_err);
                }
            }
            else
            {
                vEK5.vetot = 0;
            }

            EK5_vetot.Text = vEK5.vetot.ToString("#0.00000000");
        }

        /*
           Bradford Assay analysis: consistency check on Absorbance Change per Minute of samples of Solution without Proteins
        */
        private void EK5_SolBlank_LostFocus(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (vEK5.SolBlank_1 * vEK5.SolBlank_2 > 0)
            {
                if (ComputingService.rely_test(vEK5.SolBlank_1, vEK5.SolBlank_2) != 1)
                {
                    vEK5.vetot = 0;
                    string s_err = "In Bradford Assay, values too different for the solution without proteins";
                    string t_err = "Error";
                    ShowMsgBox(t_err, s_err);
                }
            }
            else
            {
                vEK5.vbtot = 0;
            }

            EK5_vbtot.Text = vEK5.vbtot.ToString("#0.00000000");
        }
    }
}
