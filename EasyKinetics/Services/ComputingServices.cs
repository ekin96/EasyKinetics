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

/* COMPUTING PROCEDURES MODULE
   This module contains:
   - procedures to reset test flags and chart parameters
   - procedures to check consistency and reliability of input fields
   - procedures to compute parameters used in the different masks 
*/

using EasyKinetics.Models;
using System;

namespace EasyKinetics.Services
{
    public static class ComputingService
    {
        /*
            Procedure to reset flags used to show or to hide hidden fields in test mode of different masks
        */
        public static void Reset_Flags()
        {
            flagTest.fEK1 = 0;
            flagTest.fEK2 = 0;
            flagTest.fEK3 = 0;
            flagTest.fEK4 = 0;
            flagTest.fEK5 = 0;
        }

        /*
            Procedure to reset parameters used to draw charts
        */
        public static void Initialize_Chart()
        {
            ChartParameters.Mask = "";
            ChartParameters.nH = 0;
            ChartParameters.Vmax = 0;
            ChartParameters.Km = 0;
            ChartParameters.inH = 0;
            ChartParameters.iVmax = 0;
            ChartParameters.iKm = 0;
        }

        /*
            Procedure to check consistency of numeric fields
        */
        public static string NumField(string s)
        {
            int pointflag = 0;

            string s_out = "";
            int s_len = s.Length;
            for (int i = 0; i < s_len; i++)
            {
                string c = s.Substring(i, 1);
                if (string.Compare(c, "0") >= 0 && string.Compare(c, "9") <= 0)
                {
                    s_out += c;
                }
                else if (c == "." && pointflag == 0)
                {
                    pointflag = 1;
                    s_out += c;
                }
                else 
                {
                    c = "";
                    s_out += c;
                }
            }

            if (s_out.Length > 1 && s_out.StartsWith("0") && s_out.Substring(1, 1) != ".")
            {
                string s_new = s_out.Substring(1, s_out.Length - 1);
                s_out = s_new;
            }

            return s_out;
        }

        /*
            Procedure to check consistency of integer numeric fields
        */
        public static string IntField(string s)
        {
            string s_out = "";
            int s_len = s.Length;
            for (int i = 0; i < s_len; i++)
            {
                string c = s.Substring(i, 1);
                if ((string.Compare(c, "0") >= 0 && string.Compare(c, "9") <= 0))
                {
                    s_out += c;
                }
                else
                {
                    c = "";
                    s_out += c;
                }
            }

            if (s_out.Length > 1 && s_out.StartsWith("0"))
            {
                string s_new = s_out.Substring(1, s_out.Length - 1);
                s_out = s_new;
            }
            return s_out;
        }

        /*
            Procedure to check reliability of input data of Absorbance Change per Minute
        */
        public static int rely_test (double n1, double n2)
        {
            int rely_flag = 0;

            double n_avg = (n1 + n2) / 2.0;
            if ( Math.Abs(n1  - n_avg) / n_avg < 0.1 && Math.Abs(n2 - n_avg) / n_avg < 0.1 )
            {
                rely_flag = 1;
            }

            return rely_flag;
        }

        /*
            Procedure to check reliability of input data in Enzymatic Units Assay
        */
        public static int rely3_test(double n1, double n2, double n3)
        {
            int rely_flag = 0;

            double n_avg = (n1 + n2 + n3) / 3.0;
            if (
                    Math.Abs(n1 - n_avg) / n_avg < 0.1 &&
                    Math.Abs(n2 - n_avg) / n_avg < 0.1 &&
                    Math.Abs(n3 - n_avg) / n_avg < 0.1
               )
            {
                rely_flag = 1;
            }

            return rely_flag;
        }

        /*
            Simple Enzymatic Kinetics analysis: calculation of parameter "Substrate Concentration of sample for Substrate Inhibition check"
        */
        public static void EK1_Absorbance_SubstrateConcentration()
        {
            if (vEK1.Km > 0)
            {
                vEK1.Absorbance_SubstrateConcentration = 100.0 * vEK1.Km;
            }
        }

        /*
            Inhibition Kinetics analysis: calculation of parameter "Substrate Concentration of sample for Substrate Inhibition check"
        */
        public static void EK2_BAbsorbance_SubstrateConcentration()
        {
            if (vEK2.BKm > 0)
            {
                vEK2.BAbsorbance_SubstrateConcentration = 100.0 * vEK2.BKm;
            }
        }

        /*
            Inhibition Kinetics analysis: calculation of parameter "Active Enzyme Percentage after inhibition"
        */
        public static void EK2_ActiveEnzymPerc()
        {
            if (vEK2.BlSC_dAbsmin * vEK2.IlSC_dAbsmin > 0)
            {
                vEK2.ActiveEnzymePerc = (vEK2.IlSC_dAbsmin / vEK2.BlSC_dAbsmin);
            }
            else
            {
                vEK2.ActiveEnzymePerc = 0;
            }
        }

        /*
            Simple Enzymatic Kinetics analysis: calculation of parameter "Specific Activity"
        */
        public static void EK1_AttSpec()
        {
            if (vEK1.ConcProt * vEK1.Unitsml > 0)
            {
                vEK1.AttSpec = vEK1.Unitsml / vEK1.ConcProt;
            }
            else
            {
                vEK1.AttSpec = 0;
            }
        }

        /*
            Simple Enzymatic Kinetics analysis: calculation of parameter "Catalytic Efficiency"
        */
        public static void EK1_CatalEff()
        {
            if (vEK1.Kcat * vEK1.Km > 0)
            {
                vEK1.CatalEff = Math.Log10(vEK1.Kcat / vEK1.Km);
            }
            else
            {
                vEK1.CatalEff = 0;
            }
        }

        /*
            Simple Enzymatic Kinetics analysis: calculation of parameter "Proteins Concentration"
        */
        public static void EK1_ConcProt()
        {
            if (vEK1.vetot * vEK1.vbtot * vEK1.OpticalPath > 0)
            {
                vEK1.ConcProt = ((vEK1.vetot - vEK1.vbtot) / (0.064 * vEK1.OpticalPath)) * 100;
            }
            else
            {
                vEK1.ConcProt = 0;
            }
        }

        /*
            Bradford Assay analysis: calculation of parameter "Proteins Concentration"
        */
        public static void EK5_ConcProt()
        {
            if (vEK5.Vi * vEK5.vetot * vEK5.vbtot * vEK5.OpticaltPath > 0)
            {
                vEK5.ConcProt = ((vEK5.vetot - vEK5.vbtot) / (0.064 * vEK5.OpticaltPath)) * (1000 / vEK5.Vi);
            }
            else
            {
                vEK5.ConcProt = 0;
            }
        }

        /*
            Inhibition Kinetics analysis: evaluation of parameter "Inhibition Type"
        */
        public static void EK2_InhibitionType()
        {
            if (vEK2.BVmax * vEK2.IVmax * vEK2.BKm * vEK2.IKm > 0)
            {
                if (
                        Math.Abs(1 - vEK2.BVmax / vEK2.IVmax) <= 0.02 &&
                        Math.Abs(1 - vEK2.BKm / vEK2.IKm)      > 0.02
                   )
                {
                    vEK2.InhibitionType = "Competitive inhibition";
                }
                else if (
                            Math.Abs(1 - vEK2.BVmax / vEK2.IVmax)  > 0.02 &&
                            Math.Abs(1 - vEK2.BKm / vEK2.IKm)     <= 0.02
                        )
                {
                    vEK2.InhibitionType = "Purely non competitive inhibition";
                }
                else if (
                            Math.Abs(1 - vEK2.BVmax / vEK2.IVmax)  > 0.02 &&
                            Math.Abs(1 - vEK2.BKm / vEK2.IKm)      > 0.02 &&
                            Math.Abs(1 - (vEK2.IKm / vEK2.IVmax) / (vEK2.BKm / vEK2.BVmax)) > 0.02
                        )
                {
                    vEK2.InhibitionType = "Mixed non competitive inhibition";
                }
                else if (
                            Math.Abs(1 - vEK2.BVmax / vEK2.IVmax) > 0.02 &&
                            Math.Abs(1 - vEK2.BKm / vEK2.IKm) > 0.02 &&
                            Math.Abs(1 - (vEK2.IKm / vEK2.IVmax) / (vEK2.BKm / vEK2.BVmax)) <= 0.02
                        )
                {
                    vEK2.InhibitionType = "Uncompetitive inhibition";

                }
                else
                {
                    vEK2.InhibitionType = "Any inhibition detected";
                }
            }
            else
            {
                vEK2.InhibitionType = "";
            }
        }

        /*
            Simple Enzyme Kinetics analysis: calculation of parameter "Expected Absorbance Change per Minute of sample for Substrate Inhibition check"
        */
        public static void EK1_ExpectedAbsorbance()
        {
            double n = vEK1.HillCoeff;
            double si_sc = vEK1.Absorbance_SubstrateConcentration;
            if (n * si_sc * vEK1.Km * vEK1.Vmax > 0)
            {
                vEK1.ExpectedAbsorbance = vEK1.Vmax * Math.Pow(si_sc, n) / (Math.Pow(si_sc, n) + Math.Pow(vEK1.Km, n));
            }
            else
            {
                vEK1.ExpectedAbsorbance = 0;
            }
        }

        /*
            Inhibition Kinetics analysis: calculation of parameter "Expected Absorbance Change per Minute of sample for Substrate Inhibition check"
        */
        public static void EK2_BExpectedAbsorbance()
        {
            double n = vEK2.BHillCoeff;
            double si_sc = vEK2.BAbsorbance_SubstrateConcentration;
            if (n * si_sc * vEK2.BKm * vEK2.BVmax > 0)
            {
                vEK2.BExpectedAbsorbance = vEK2.BVmax * Math.Pow(si_sc, n) / (Math.Pow(si_sc, n) + Math.Pow(vEK2.BKm, n));
            }
            else
            {
                vEK2.BExpectedAbsorbance = 0;
            }
        }

        /*
            Inhibition Kinetics analysis: calculation of parameter "Lower Substrate Concentration of samples in presence of inhibitor"
        */
        public static void EK2_IlSC()
        {
            vEK2.IlSC = vEK2.BlSC;
        }

        /*
            Inhibition Kinetics analysis: calculation of parameter "Higher Substrate Concentration of samples in presence of inhibitor"
        */
        public static void EK2_IhSC()
        {
            vEK2.IhSC = vEK2.BhSC;
        }

        /*
            Simple Enzyme Kinetics analysis: calculation of parameter "average Absorbance Change per Minute of Lower Substrate Concentration samples"
        */
        public static void EK1_lSC_dAbsmin()
        {
            vEK1.lSC_dAbsmin = (vEK1.lSC_dAbsmin_1 + vEK1.lSC_dAbsmin_2) / 2.0;
        }

        /*
            Inhibition Kinetics analysis: calculation of parameter "average Absorbance Change per Minute of Lower Substrate Concentration samples in absence of inhibitor"
        */
        public static void EK2_BlSC_dAbsmin()
        {
            vEK2.BlSC_dAbsmin = (vEK2.BlSC_dAbsmin_1 + vEK2.BlSC_dAbsmin_2) / 2.0;
        }

        /*
            Inhibition Kinetics analysis: calculation of parameter "average Absorbance Change per Minute of Lower Substrate Concentration samples in presence of inhibitor"
        */
        public static void EK2_IlSC_dAbsmin()
        {
            vEK2.IlSC_dAbsmin = (vEK2.IlSC_dAbsmin_1 + vEK2.IlSC_dAbsmin_2) / 2.0;
        }

        /*
            Enzymatic Units Assay analysis: calculation of parameter "average Absorbance Change per Minute of samples"
        */
        public static void EK3_SC_dAbsmin()
        {
            vEK3.dAbsmin = (vEK3.dAbsmin_1 + vEK3.dAbsmin_2 + vEK3.dAbsmin_3) / 3.0;
        }

        /*
            Calculation of dAbs/min: calculation of parameter "average Absorbance Change per Minute of samples"
        */
        public static void EK4_SC_dAbsmin()
        {
            vEK4.dAbsmin = ((vEK4.Abs_115 - vEK4.Abs_015) + (vEK4.Abs_215 - vEK4.Abs_115) + (vEK4.Abs_315 - vEK4.Abs_215) + (vEK4.Abs_415 - vEK4.Abs_315)) / 4;
        }

        /*
            Simple Enzyme Kinetics analysis: calculation of parameter "average Absorbance Change per Minute of Higher Substrate Concentration samples"
        */
        public static void EK1_hSC_dAbsmin()
        {
            vEK1.hSC_dAbsmin = (vEK1.hSC_dAbsmin_1 + vEK1.hSC_dAbsmin_2) / 2.0;
        }

        /*
            Inhibition Kinetics analysis: calculation of parameter "average Absorbance Change per Minute of Higher Substrate Concentration samples in absence of inhibitor"
        */
        public static void EK2_BhSC_dAbsmin()
        {
            vEK2.BhSC_dAbsmin = (vEK2.BhSC_dAbsmin_1 + vEK2.BhSC_dAbsmin_2) / 2.0;
        }

        /*
            Inhibition Kinetics analysis: calculation of parameter "average Absorbance Change per Minute of Higher Substrate Concentration samples in presence of inhibitor"
        */
        public static void EK2_IhSC_dAbsmin()
        {
            vEK2.IhSC_dAbsmin = (vEK2.IhSC_dAbsmin_1 + vEK2.IhSC_dAbsmin_2) / 2.0;
        }

        /*
            Simple Enzyme Kinetics analysis: calculation of parameter "Kcat"
        */
        public static void EK1_Kcat()
        {
            if (vEK1.Vmax * vEK1.epsilon0 * vEK1.OpticalPath * vEK1.MolecularWeight * vEK1.ConcProt > 0)
            {
                vEK1.Kcat = 1000000 * vEK1.Vmax * vEK1.MolecularWeight / (vEK1.epsilon0 * vEK1.OpticalPath * vEK1.ConcProt);
            }
            else
            {
                vEK1.Kcat = 0;
            }
        }

        /*
            Simple Enzyme Kinetics analysis: calculation of parameter "Km"
        */
        public static void EK1_Km()
        {
            if (vEK1.reverse_Km > 0)
            {
                vEK1.Km = (1 / vEK1.reverse_Km) * 1000000.0;
            }
            else
            {
                vEK1.Km = 0;
            }
        }

        /*
            Inhibition Kinetics analysis: calculation of parameter "Km in absence of inhibitor"
        */
        public static void EK2_BKm()
        {
            if (vEK2.Breverse_Km > 0)
            {
                vEK2.BKm = (1 / vEK2.Breverse_Km) * 1000000.0;
            }
            else
            {
                vEK2.BKm = 0;
            }
        }

        /*
            Inhibition Kinetics analysis: calculation of parameter "Km in presence of inhibitor"
        */
        public static void EK2_IKm()
        {
            if (vEK2.Ireverse_Km > 0)
            {
                vEK2.IKm = (1 / vEK2.Ireverse_Km) * 1000000.0;
            }
            else
            {
                vEK2.IKm = 0;
            }
        }

        /*
            Simple Enzyme Kinetics analysis: calculation of parameter "Reverse of Km"
        */
        public static void EK1_ReverseKm()
        {
            if (vEK1.reverse_Vmax * vEK1.tg_angolo > 0)
            {
                vEK1.reverse_Km = vEK1.reverse_Vmax / vEK1.tg_angolo;
            }
            else
            {
                vEK1.reverse_Km = 0;
            }
        }

        /*
            Inhibition Kinetics analysis: calculation of parameter "Reverse of Km in absence of inhibitor"
        */
        public static void EK2_BReverseKm()
        {
            if (vEK2.Breverse_Vmax * vEK2.Btg_angolo > 0)
            {
                vEK2.Breverse_Km = vEK2.Breverse_Vmax / vEK2.Btg_angolo;
            }
            else
            {
                vEK2.Breverse_Km = 0;
            }
        }

        /*
            Inhibition Kinetics analysis: calculation of parameter "Reverse of Km in presence of inhibitor"
        */
        public static void EK2_IReverseKm()
        {
            if (vEK2.Ireverse_Vmax * vEK2.Itg_angolo > 0)
            {
                vEK2.Ireverse_Km = vEK2.Ireverse_Vmax / vEK2.Itg_angolo;
            }
            else
            {
                vEK2.Ireverse_Km = 0;
            }
        }

        /*
            Simple Enzyme Kinetics analysis: calculation of parameter "Reverse of Vmax"
        */
        public static void EK1_ReverseVmax()
        {
            if (vEK1.tg_angolo * vEK1.y2 * vEK1.x2 > 0)
            {
                vEK1.reverse_Vmax = vEK1.y2 - vEK1.tg_angolo * vEK1.x2;
            }
            else
            {
                vEK1.reverse_Vmax = 0;
            }
        }

        /*
            Inhibition Kinetics analysis: calculation of parameter "Reverse of Vmax in absence of inhibitor"
        */
        public static void EK2_BReverseVmax()
        {
            if (vEK2.Btg_angolo * vEK2.By2 * vEK2.x2 > 0)
            {
                vEK2.Breverse_Vmax = vEK2.By2 - vEK2.Btg_angolo * vEK2.x2;
            }
            else
            {
                vEK2.Breverse_Vmax = 0;
            }
        }

        /*
            Inhibition Kinetics analysis: calculation of parameter "Reverse of Vmax in presence of inhibitor"
        */
        public static void EK2_IReverseVmax()
        {
            if (vEK2.Itg_angolo * vEK2.Iy2 * vEK2.x2 > 0)
            {
                vEK2.Ireverse_Vmax = vEK2.Iy2 - vEK2.Itg_angolo * vEK2.x2;
            }
            else
            {
                vEK2.Ireverse_Vmax = 0;
            }
        }

        /*
            Simple Enzyme Kinetics analysis: calculation of parameter "Flag of Substrate Inhibition"
        */
        public static void EK1_SubstrateInhibition()
        {
            double si_sc = vEK1.Absorbance_SubstrateConcentration;
            if (vEK1.Absorbance_SubstrateConcentration * vEK1.Absorbance * vEK1.ExpectedAbsorbance * vEK1.Vmax * vEK1.Km > 0)
            {
                if (vEK1.Absorbance < vEK1.ExpectedAbsorbance * 0.5)
                {
                    vEK1.SubstrateInhibition = 1;
                    vEK1.Ki = Math.Pow(si_sc, 2) / (si_sc * vEK1.Vmax / vEK1.Absorbance - vEK1.Km - si_sc);
                }
                else
                {
                    vEK1.SubstrateInhibition = 0;
                    vEK1.Ki = 1;
                }
            }
        }

        /*
            Inhibition Kinetics analysis: calculation of parameter "Flag of Substrate Inhibition"
        */
        public static void EK2_BSubstrateInhibition()
        {
            double si_sc = vEK2.BAbsorbance_SubstrateConcentration;
            if (vEK2.BAbsorbance_SubstrateConcentration * vEK2.BAbsorbance * vEK2.BExpectedAbsorbance * vEK2.BVmax * vEK2.BKm > 0)
            {
                if (vEK2.BAbsorbance < vEK2.BExpectedAbsorbance * 0.5)
                {
                    vEK2.BSubstrateInhibition = 1;
                    vEK2.Ki = Math.Pow(si_sc, 2.0) / (si_sc * vEK2.BVmax / vEK2.BAbsorbance - vEK2.BKm - si_sc);
                }
                else
                {
                    vEK2.BSubstrateInhibition = 0;
                    vEK2.Ki = 1;
                }
            }
        }

        /*
            Simple Enzyme Kinetics analysis: calculation of parameter "Tangent of Angle"
        */
        public static void EK1_tgAngolo()
        {
            if ((vEK1.y1 * vEK1.y2 * vEK1.x1 * vEK1.x2 > 0) && (vEK1.x2 > vEK1.x1))
            {
                vEK1.tg_angolo = (vEK1.y2 - vEK1.y1) / (vEK1.x2 - vEK1.x1);
            }
            else
            {
                vEK1.tg_angolo = 0;
            }
        }

        /*
            inhibition Kinetics analysis: calculation of parameter "Tangent of Angle in absence of inhibitor"
        */
        public static void EK2_BtgAngolo()
        {
            if (vEK2.By1 * vEK2.By2 * vEK2.x1 * vEK2.x2 > 0)
            {
                vEK2.Btg_angolo = (vEK2.By2 - vEK2.By1) / (vEK2.x2 - vEK2.x1);
            }
            else
            {
                vEK2.Btg_angolo = 0;
            }
        }

        /*
            inhibition Kinetics analysis: calculation of parameter "Tangent of Angle in presence of inhibitor"
        */
        public static void EK2_ItgAngolo()
        {
            if (vEK2.Iy1 * vEK2.Iy2 * vEK2.x1 * vEK2.x2 > 0)
            {
                vEK2.Itg_angolo = (vEK2.Iy2 - vEK2.Iy1) / (vEK2.x2 - vEK2.x1);
            }
            else
            {
                vEK2.Itg_angolo = 0;
            }
        }

        /*
            Simple Enzyme Kinetics analysis: calculation of parameter "Units/ml"
        */
        public static void EK1_Unitsml()
        {
            if (vEK1.Absorbance * vEK1.Vi * vEK1.Vf * vEK1.epsilon0 * vEK1.OpticalPath > 0)
            {
                vEK1.Unitsml = vEK1.Absorbance / (vEK1.epsilon0 * vEK1.OpticalPath) * (vEK1.Vf / vEK1.Vi);
            }
            else
            {
                vEK1.Unitsml = 0;
            }
        }

        /*
            Enzymatic Units Assay analysis: calculation of parameter "Units/ml"
        */
        public static void EK3_Unitsml()
        {
            if (vEK3.dAbsmin * vEK3.Vi * vEK3.Vf * vEK3.epsilon0 * vEK3.OpticaltPath > 0)
            {
                vEK3.Unitsml = (vEK3.dAbsmin / (vEK3.epsilon0 * vEK3.OpticaltPath)) * (vEK3.Vf / vEK3.Vi);
            }
            else
            {
                vEK3.Unitsml = 0;
            }
        }

        /*
            Simple Enzyme Kinetics analysis: calculation of parameter "average Absorbance Change per Minute in samples of Solution without Proteins in Bradford Assay"
        */
        public static void EK1_vbtot()
        {
            vEK1.vbtot = (vEK1.SolBlank_1 + vEK1.SolBlank_2) / 2.0;
        }

        /*
            Bradford Assay analysis: calculation of parameter "average Absorbance Change per Minute in samples of Solution without Proteins"
        */
        public static void EK5_vbtot()
        {
            vEK5.vbtot = (vEK5.SolBlank_1 + vEK5.SolBlank_2) / 2.0;
        }

        /*
            Simple Enzyme Kinetics analysis: calculation of parameter "average Absorbance Change per Minute in samples of Solution with proteins in Bradford Assay"
        */
        public static void EK1_vetot()
        {
            vEK1.vetot = (vEK1.SolProt_1 + vEK1.SolProt_2) / 2.0;
        }

        /*
            Bradford Assay analysis: calculation of parameter "average Absorbance Change per Minute in samples of Solution with Proteins"
        */
        public static void EK5_vetot()
        {
            vEK5.vetot = (vEK5.SolProt_1 + vEK5.SolProt_2) / 2.0;
        }

        /*
            Simple Enzyme Kinetics analysis: calculation of parameter "Vmax"
        */
        public static void EK1_Vmax()
        {
            if (vEK1.reverse_Vmax > 0)
            {
                vEK1.Vmax = 1 / vEK1.reverse_Vmax;
            }
            else
            {
                vEK1.Vmax = 0;
            }
        }

        /*
            Inhibition Kinetics analysis: calculation of parameter "Vmax in absence of inhibitor"
        */
        public static void EK2_BVmax()
        {
            if (vEK2.Breverse_Vmax > 0)
            {
                vEK2.BVmax = 1 / vEK2.Breverse_Vmax;
            }
            else
            {
                vEK2.BVmax = 0;
            }
        }

        /*
            Inhibition Kinetics analysis: calculation of parameter "Vmax in presence of inhibitor"
        */
        public static void EK2_IVmax()
        {
            if (vEK2.Ireverse_Vmax > 0)
            {
                vEK2.IVmax = 1 / vEK2.Ireverse_Vmax;
            }
            else
            {
                vEK2.IVmax = 0;
            }
        }

        /*
            Simple Enzyme Kinetics analysis: calculation of parameter "Computed Reaction Rate evaluated in moli/min"
        */
        public static void EK1_Vmoli()
        {
            if (vEK1.v0 * vEK1.Vf * vEK1.epsilon0 * vEK1.OpticalPath > 0)
            {
                vEK1.vmoli = vEK1.v0 * vEK1.Vf / (vEK1.epsilon0 * vEK1.OpticalPath);
            }
            else
            {
                vEK1.vmoli = 0;
            }
        }

        /*
            Inhibition Kinetics analysis: calculation of parameter "Computed Reaction Rate in absence of inhibitor evaluated in moli/min"
        */
        public static void EK2_BVmoli()
        {
            if (vEK2.Bv0 * vEK2.Vf * vEK2.epsilon0 * vEK2.OpticalPath > 0)
            {
                vEK2.Bvmoli = vEK2.Bv0 * vEK2.Vf / (vEK2.epsilon0 * vEK2.OpticalPath);
            }
            else
            {
                vEK2.Bvmoli = 0;
            }
        }

        /*
            Inhibition Kinetics analysis: calculation of parameter "Computed Reaction Rate in presence of inhibitor evaluated in moli/min"
        */
        public static void EK2_IVmoli()
        {
            if (vEK2.Iv0 * vEK2.Vf * vEK2.epsilon0 * vEK2.OpticalPath > 0)
            {
                vEK2.Ivmoli = vEK2.Iv0 * vEK2.Vf / (vEK2.epsilon0 * vEK2.OpticalPath);
            }
            else
            {
                vEK2.Ivmoli = 0;
            }
        }

        /*
            Simple Enzyme Kinetics analysis: calculation of parameter "Hill Coefficient"
        */
        public static void EK1_HillCoeff()
        {
            if (vEK1.hSC * vEK1.hSC_dAbsmin * vEK1.Vmax * vEK1.Km > 0)
            {
                vEK1.HillCoeff = Math.Log(vEK1.Km / (vEK1.Vmax / vEK1.hSC_dAbsmin - 1 )) / Math.Log(vEK1.hSC);
            }
            else
            {
                vEK1.HillCoeff = 0;
            }
        }

        /*
            Inhibition Kinetics analysis: calculation of parameter "Hill Coefficient in absence of inhibitor"
        */
        public static void EK2_BHillCoeff()
        {
            if (vEK2.BhSC * vEK2.BhSC_dAbsmin * vEK2.BVmax * vEK2.BKm > 0)
            {
                vEK2.BHillCoeff = Math.Log(vEK2.BKm / (vEK2.BVmax / vEK2.BhSC_dAbsmin - 1)) / Math.Log(vEK2.BhSC);
            }
            else
            {
                vEK2.BHillCoeff = 0;
            }
        }

        /*
            Inhibition Kinetics analysis: calculation of parameter "Hill Coefficient in presence of inhibitor"
        */
        public static void EK2_IHillCoeff()
        {
            if (vEK2.IhSC * vEK2.IhSC_dAbsmin * vEK2.IVmax * vEK2.IKm > 0)
            {
                vEK2.IHillCoeff = Math.Log(vEK2.IKm / (vEK2.IVmax / vEK2.IhSC_dAbsmin - 1)) / Math.Log(vEK2.IhSC);
            }
            else
            {
                vEK2.IHillCoeff = 0;
            }
        }

        /*
            Formula of Computed Reaction Rate
        */
        public static double V0(double x, double n, double Vmax, double Km, double ki, double flag)
        {
            double v0;
            return v0 = Vmax * Math.Pow(x, n) / (Math.Pow(x, n) * (1 + flag * Math.Pow(x / ki, n)) + Math.Pow(Km, n));
        }

        /*
            Simple Enzyme Kinetics analysis: calculation of parameter "Computed Reaction Rate"
        */
        public static void EK1_V0()
        {
            if (vEK1.HillCoeff * vEK1.SubstrateConcentration * vEK1.Vmax * vEK1.Km * vEK1.Ki > 0)
            {
                vEK1.v0 = V0(vEK1.SubstrateConcentration, vEK1.HillCoeff, vEK1.Vmax, vEK1.Km, vEK1.Ki, vEK1.SubstrateInhibition);
            }
            else
            {
                vEK1.v0 = 0;
            }
        }

        /*
            Inhibition Kinetics analysis: calculation of parameter "Computed Reaction Rate in absence of inhibitor"
        */
        public static void EK2_BV0()
        {
            if (vEK2.BHillCoeff * vEK2.SubstrateConcentration * vEK2.BVmax * vEK2.BKm * vEK2.Ki > 0)
            {
                vEK2.Bv0 = V0(vEK2.SubstrateConcentration, vEK2.BHillCoeff, vEK2.BVmax, vEK2.BKm, vEK2.Ki, vEK2.BSubstrateInhibition);
            }
            else
            {
                vEK2.Bv0 = 0;
            }
        }

        /*
            Inhibition Kinetics analysis: calculation of parameter "Computed Reaction Rate in presence of inhibitor"
        */
        public static void EK2_IV0()
        {
            if (vEK2.IHillCoeff * vEK2.SubstrateConcentration * vEK2.IVmax * vEK2.IKm * vEK2.Ki > 0)
            {
                vEK2.Iv0 = V0(vEK2.SubstrateConcentration, vEK2.IHillCoeff, vEK2.IVmax, vEK2.IKm, vEK2.Ki, vEK2.BSubstrateInhibition);
            }
            else
            {
                vEK2.Iv0 = 0;
            }
        }

        /*
            Simple Enzyme Kinetics analysis: calculation of parameter "x1"
        */
        public static void EK1_x1()
        {
            vEK1.x1 = 1000000 / vEK1.hSC;
        }

        /*
            Inhibition Kinetics analysis: calculation of parameter "x1"
        */
        public static void EK2_x1()
        {
            vEK2.x1 = 1000000 / vEK2.BhSC;
        }

        /*
            Simple Enzyme Kinetics analysis: calculation of parameter "x2"
        */
        public static void EK1_x2()
        {
            vEK1.x2 = 1000000 / vEK1.lSC;
        }

        /*
            Inhibition Kinetics analysis: calculation of parameter "x2"
        */
        public static void EK2_x2()
        {
            vEK2.x2 = 1000000 / vEK2.BlSC;
        }

        /*
            Simple Enzyme Kinetics analysis: calculation of parameter "y1"
        */
        public static void EK1_y1()
        {
            if (vEK1.hSC_dAbsmin > 0)
            {
                vEK1.y1 = 1 / vEK1.hSC_dAbsmin;
            }
            else
            {
                vEK1.y1 = 0;
            }
        }

        /*
            Inhibition Kinetics analysis: calculation of parameter "y1 in absence of inhibitor"
        */
        public static void EK2_By1()
        {
            if (vEK2.BhSC_dAbsmin > 0)
            {
                vEK2.By1 = 1 / vEK2.BhSC_dAbsmin;
            }
            else
            {
                vEK2.By1 = 0;
            }
        }

        /*
            Inhibition Kinetics analysis: calculation of parameter "y1 in presence of inhibitor"
        */
        public static void EK2_Iy1()
        {
            if (vEK2.IhSC_dAbsmin > 0)
            {
                vEK2.Iy1 = 1 / vEK2.IhSC_dAbsmin;
            }
            else
            {
                vEK2.Iy1 = 0;
            }
        }

        /*
            Simple Enzyme Kinetics analysis: calculation of parameter "y2"
        */
        public static void EK1_y2()
        {
            if (vEK1.lSC_dAbsmin > 0)
            {
                vEK1.y2 = 1 / vEK1.lSC_dAbsmin;
            }
            else
            {
                vEK1.y2 = 0;
            }
        }

        /*
            Inhibition Kinetics analysis: calculation of parameter "y2 in absence of inhibitor"
        */
        public static void EK2_By2()
        {
            if (vEK2.BlSC_dAbsmin > 0)
            {
                vEK2.By2 = 1 / vEK2.BlSC_dAbsmin;
            }
            else
            {
                vEK2.By2 = 0;
            }

        }

        /*
            Inhibition Kinetics analysis: calculation of parameter "y2 in presence of inhibitor"
        */
        public static void EK2_Iy2()
        {
            if (vEK2.IlSC_dAbsmin > 0)
            {
                vEK2.Iy2 = 1 / vEK2.IlSC_dAbsmin;
            }
            else
            {
                vEK2.Iy2 = 0;
            }

        }
    }
}

