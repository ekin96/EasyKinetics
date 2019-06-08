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

/* DATA STRUCTURE MODULE
   This module defines the structure of items used to draw charts:
   - data items
   - series item
*/

using System.Collections.ObjectModel;

namespace EasyKinetics.Models
{
    /*
        Structure of chart data items
    */
    public class DataItem
    {
        public double SubstrateConc { get; set; }

        public double ReactionRate { get; set; }

        public override string ToString()
        {
            return $"{SubstrateConc} {ReactionRate}";
        }
    }

    /*
        Structure of chart data series
    */
    public class SeriesItem
    {
        public string Type { get; set; }

        public ObservableCollection<DataItem> Items { get; set; }
    }

}
