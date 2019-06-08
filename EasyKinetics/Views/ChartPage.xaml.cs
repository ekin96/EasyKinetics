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

/* CHART PAGE MANAGEMENT MODULE
   This module contains:
   - the starting activities displaying a chart
   - the actions to collect data to draw charts
   - the actions to draw charts
   - the procedure to format data displayed moving the mouse on chart curves
*/

using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;


using EasyKinetics.Models;
using EasyKinetics.Services;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;

namespace EasyKinetics.Views
{
    public sealed partial class ChartPage : Page, INotifyPropertyChanged
    {
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
            Procedure to initialize general components when starting a chart 
        */
        public ChartPage()
        {
            InitializeComponent();
        }

        /*
            Procedure to collect data to draw Simple Enzyme Kinetics chart 
        */
        public ObservableCollection<SeriesItem> SeriesSource1
        {
            get
            {
                return ReactionDataService.GetReactionSeriesItems1
                       (   "Spline",
                            ChartParameters.nH,
                            ChartParameters.Vmax,
                            ChartParameters.Km,
                            ChartParameters.step,
                            ChartParameters.Ki,
                            ChartParameters.SubstrateInhibitionFlag
                       );
            }
        }

        /*
            Procedure to collect data to draw Inhibition Kinetics chart 
        */
        public ObservableCollection<SeriesItem> SeriesSource2
        {
            get
            {
                return ReactionDataService.GetReactionSeriesItems2
                       (    "Spline",
                            ChartParameters.nH,
                            ChartParameters.Vmax,
                            ChartParameters.Km,
                            ChartParameters.inH,
                            ChartParameters.iVmax,
                            ChartParameters.iKm,
                            ChartParameters.step,
                            ChartParameters.Ki,
                            ChartParameters.SubstrateInhibitionFlag
                        );
            }
        }

        /*
            Procedure to draw Simple Enzyme Kinetics chart 
        */
        private void Draw_SEK_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (vEK1.Vmax * vEK1.Km * vEK1.HillCoeff > 0)
            {
                double rifKm = vEK1.Km;
                double stepdim = Math.Floor(Math.Log10(vEK1.Km)) - 2;
                ChartParameters.step = 5.0 * Math.Pow(10, stepdim);
                ChartParameters.Xlimit = 500.0 * ChartParameters.step;
                Chart_Xlimit.Text = ChartParameters.Xlimit.ToString("#0.0000");

                ChartParameters.Mask = "SEK";
                ChartParameters.nH = vEK1.HillCoeff;
                ChartParameters.Vmax = vEK1.Vmax;
                ChartParameters.Km = vEK1.Km;
                ChartParameters.inH = 0;
                ChartParameters.iVmax = 0;
                ChartParameters.iKm = 0;
                ChartParameters.Ki = vEK1.Ki;
                ChartParameters.SubstrateInhibitionFlag = vEK1.SubstrateInhibition;

                ChartName.Text = "Simple Enzyme Kinetics";

                ReactionRateChart.SeriesProvider.Source = SeriesSource1;

                ReactionRateChart.SeriesProvider.RefreshAttachedCharts();
            }
        }

        /*
            Procedure to draw Inhibition Kinetics chart 
        */
        private void Draw_IK_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (vEK2.BVmax * vEK2.BKm * vEK2.IVmax * vEK2.IKm * vEK2.BHillCoeff * vEK2.IHillCoeff > 0)
            {
                double rifKm = Math.Max(ChartParameters.Km, ChartParameters.iKm);
                double stepdim = Math.Floor(Math.Log10(rifKm)) - 2;
                ChartParameters.step = 5.0 * Math.Pow(10, stepdim);
                ChartParameters.Xlimit = 500.0 * ChartParameters.step;
                Chart_Xlimit.Text = ChartParameters.Xlimit.ToString("#0.0000");

                ChartParameters.Mask = "IK";
                ChartParameters.nH = vEK2.BHillCoeff;
                ChartParameters.Vmax = vEK2.BVmax;
                ChartParameters.Km = vEK2.BKm;
                ChartParameters.inH = vEK2.IHillCoeff;
                ChartParameters.iVmax = vEK2.IVmax;
                ChartParameters.iKm = vEK2.IKm;
                ChartParameters.Ki = vEK2.Ki;
                ChartParameters.SubstrateInhibitionFlag = vEK2.BSubstrateInhibition;

                ChartName.Text = "Inhibition Kinetics";

                ReactionRateChart.SeriesProvider.Source = SeriesSource2;

                ReactionRateChart.SeriesProvider.RefreshAttachedCharts();
            }
        }

        /*
            Procedure to manage changes in Substrate Concentration higher limit 
        */
        private void Chart_Xlimit_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Chart_Xlimit.Text != String.Empty)
            {
                string s_out = ComputingService.NumField(Chart_Xlimit.Text);
                ChartParameters.Xlimit = Double.Parse("0" + s_out);
                Chart_Xlimit.Text = s_out;
                Chart_Xlimit.Select(s_out.Length, 0);
            }
        }

        /*
            Procedure to manage a redraw request by the user 
        */
        private void Redraw_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ChartParameters.step=ChartParameters.Xlimit / 500;

            if (ChartParameters.Mask == "SEK")
            {
                ReactionRateChart.SeriesProvider.Source = SeriesSource1;
            }
            else if (ChartParameters.Mask == "IK")
            {
                ReactionRateChart.SeriesProvider.Source = SeriesSource2;
            }

            ReactionRateChart.SeriesProvider.RefreshAttachedCharts();
        }

    }

    /*
        Procedure to format data displayed moving the mouse on chart curves
    */
    public class DataConverter : Windows.UI.Xaml.Data.IValueConverter
    {
        public string Format { get; set; }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string _title;
            if (parameter.ToString() == "SubstrateConc")
            {
                _title = string.Format("{0} = {1}", parameter, value);
                _title += " \u03BCM";
            }
            else
            {
                _title = string.Format("{0} = {1:#0.000000}", parameter, value);
                _title += " \u0394Abs/min";
            }
            return _title;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
