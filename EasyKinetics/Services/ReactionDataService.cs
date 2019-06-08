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

/* REACTION DATA COLLECTION PROCEDURES MODULE
   This module contains procedures to get data to draw charts
*/

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using EasyKinetics.Models;

namespace EasyKinetics.Services
{
    public static class ReactionDataService
    {
        /*
            Procedure to build dataset to draw charts 
        */
        public static IEnumerable<DataItem> ReactionDataSet(double cn, double cVmax, double cKm, double cstep, double cKi, double csi)
        {
            double cx;
            double cy;

            double steplimit = 501; //Math.Floor(clim / cstep) + 1;

            var ReactionData = new ObservableCollection<DataItem>();

            if (cn > 0)
            {
                for (int i = 0; i < steplimit; i++)
                {
                    cx = i * cstep;
                    cy = ComputingService.V0(cx, cn, cVmax, cKm, cKi, csi);
                    ReactionData.Add(new DataItem() { SubstrateConc = cx, ReactionRate = cy } ) ;
                }
            }

            return ReactionData;

        }

        /*
            Procedure to get dataset to draw charts 
        */
        public static ObservableCollection<DataItem> GetReactionDataItems(double pn, double pVmax, double pKm, double pstep, double pKi, double psi)
        {
            var data = ReactionDataSet(pn, pVmax, pKm, pstep, pKi, psi);

            return new ObservableCollection<DataItem>(data);
        }

        /*
            Procedure to get series to draw Simple Enzyme Kinetics chart 
        */
        public static ObservableCollection<SeriesItem> GetReactionSeriesItems1(string rType, double rn, double rVmax, double rKm, double rstep, double rKi, double rsi)
        {
            var rSeries1 = new ObservableCollection<SeriesItem>
            {
                new SeriesItem
                {
                    Type = rType,
                    Items = GetReactionDataItems(rn, rVmax, rKm, rstep, rKi, rsi)
                }
            };

            return new ObservableCollection<SeriesItem>(rSeries1);
        }

        /*
            Procedure to get series to draw Inhibition Kinetics chart 
        */
        public static ObservableCollection<SeriesItem> GetReactionSeriesItems2(string rType, double rnH, double rVmax, double rKm, double inH, double iVmax, double iKm, double rstep, double rKi, double rsi)
        {
            var rSeries2 = new ObservableCollection<SeriesItem>
            {
                new SeriesItem
                {
                    Type = rType,
                    Items = GetReactionDataItems(rnH, rVmax, rKm, rstep, rKi, rsi)
                },
                new SeriesItem
                {
                    Type = rType,
                    Items = GetReactionDataItems(inH, iVmax, iKm, rstep, rKi, rsi)
                },
            };
            return new ObservableCollection<SeriesItem>(rSeries2);
        }

    }
}
