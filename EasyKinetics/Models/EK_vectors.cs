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

/* VECTORS STRUCTURE MODULE
   This module defines the structure of vectors:
   - vector of test flags
   - vectors of data for different analysis
   - vector of parameters for chart drawing
*/

namespace EasyKinetics.Models
{
    /*
        Vector of flags used in test mode to display or to hide hidden fields in the masks
    */
    static class flagTest
    {
        public static int fEK1;
        public static int fEK2;
        public static int fEK3;
        public static int fEK4;
        public static int fEK5;
    }

    /*
        Vector of flags used in displaying license
    */
    static class flagLicense
    {
        public static int currPage;
        public static int showPage;
    }

    /*
        Vector of data in Simple Enzyme Kinetics analysis
    */
    static class vEK1
    {
        public static double lSC;
        public static double lSC_dAbsmin_1;
        public static double lSC_dAbsmin_2;
        public static double lSC_dAbsmin;
        public static double hSC;
        public static double hSC_dAbsmin_1;
        public static double hSC_dAbsmin_2;
        public static double hSC_dAbsmin;
        public static double Absorbance;
        public static double Absorbance_SubstrateConcentration;
        public static double ExpectedAbsorbance;
        public static double SubstrateInhibition;
        public static double x1;
        public static double x2;
        public static double y1;
        public static double y2;
        public static double tg_angolo;
        public static double Vmax;
        public static double reverse_Vmax;
        public static double Km;
        public static double reverse_Km;
        public static double Ki;
        public static double epsilon0;
        public static double OpticalPath;
        public static double Vi;
        public static double Vf;
        public static double Unitsml;
        public static double Kcat;
        public static double CatalEff;
        public static double SubstrateConcentration;
        public static double HillCoeff;
        public static double MolecularWeight;
        public static double v0;
        public static double vmoli;
        public static double SolProt_1;
        public static double SolProt_2;
        public static double SolBlank_1;
        public static double SolBlank_2;
        public static double vetot;
        public static double vbtot;
        public static double ConcProt;
        public static double AttSpec;
    }

    /*
        Vector of data in Inhibition Kinetics analysis
    */
    static class vEK2
    {
        public static double BlSC;
        public static double BlSC_dAbsmin_1;
        public static double BlSC_dAbsmin_2;
        public static double BlSC_dAbsmin;
        public static double BhSC;
        public static double BhSC_dAbsmin_1;
        public static double BhSC_dAbsmin_2;
        public static double BhSC_dAbsmin;
        public static double BAbsorbance;
        public static double BAbsorbance_SubstrateConcentration;
        public static double BExpectedAbsorbance;
        public static double BSubstrateInhibition;
        public static double By1;
        public static double By2;
        public static double Btg_angolo;
        public static double BVmax;
        public static double Breverse_Vmax;
        public static double BKm;
        public static double Breverse_Km;
        public static double BHillCoeff;
        public static double Ki;
        public static double InhibitorConcentration;
        public static string InhibitionType;
        public static double IlSC;
        public static double IlSC_dAbsmin_1;
        public static double IlSC_dAbsmin_2;
        public static double IlSC_dAbsmin;
        public static double IhSC;
        public static double IhSC_dAbsmin_1;
        public static double IhSC_dAbsmin_2;
        public static double IhSC_dAbsmin;
        public static double Iy1;
        public static double Iy2;
        public static double Itg_angolo;
        public static double IVmax;
        public static double Ireverse_Vmax;
        public static double IKm;
        public static double Ireverse_Km;
        public static double IHillCoeff;
        public static double x1;
        public static double x2;
        public static double epsilon0;
        public static double OpticalPath;
        public static double Vf;
        public static double SubstrateConcentration;
        public static double Bv0;
        public static double Bvmoli;
        public static double Iv0;
        public static double Ivmoli;
        public static double ActiveEnzymePerc;
    }

    /*
        Vector of data in Enzymatic Units Assay analysis
    */
    static class vEK3
    {
        public static double dAbsmin_1;
        public static double dAbsmin_2;
        public static double dAbsmin_3;
        public static double dAbsmin;
        public static double epsilon0;
        public static double OpticaltPath;
        public static double Vi;
        public static double Vf;
        public static double Unitsml;
    }

    /*
        Vector of data in Calculation of dAbs/min
    */
    static class vEK4
    {
        public static double Abs_015;
        public static double Abs_115;
        public static double Abs_215;
        public static double Abs_315;
        public static double Abs_415;
        public static double dAbsmin;
    }

    /*
        Vector of data in Bradford Assay analysis
    */
    static class vEK5
    {
        public static double SolProt_1;
        public static double SolProt_2;
        public static double SolBlank_1;
        public static double SolBlank_2;
        public static double vetot;
        public static double vbtot;
        public static double OpticaltPath;
        public static double Vi;
        public static double ConcProt;
    }

    /*
        Vector of parameters to draw charts
    */
    static class ChartParameters
    {
        public static string Mask;
        public static double nH;
        public static double Vmax;
        public static double Km;
        public static double inH;
        public static double iVmax;
        public static double iKm;
        public static double step;
        public static double Xlimit;
        public static double Ki;
        public static double SubstrateInhibitionFlag;
    }
}
