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

using System.Threading.Tasks;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace EasyKinetics.Views
{
    public sealed partial class PivotPage : Page
    {
        public PivotPage()
        {
             NavigationCacheMode = NavigationCacheMode.Required;
             InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            await Task.CompletedTask;
        }
    }
}
