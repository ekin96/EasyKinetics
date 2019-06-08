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

using System.Linq;

using EasyKinetics.Helpers;

using Microsoft.Xaml.Interactivity;

using Windows.UI.Xaml.Controls;

namespace EasyKinetics.Behaviors
{
    public class PivotBehavior : Behavior<Pivot>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.SelectionChanged += OnSelectionChanged;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.SelectionChanged -= OnSelectionChanged;
        }

        private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var removedItem = e.RemovedItems.Cast<PivotItem>()
                .Select(i => i.GetPage<IPivotPage>()).FirstOrDefault();

            var addedItem = e.AddedItems.Cast<PivotItem>()
                .Select(i => i.GetPage<IPivotPage>()).FirstOrDefault();

            if (removedItem != null)
            {
                await removedItem.OnPivotUnselectedAsync();
            }

            if (addedItem != null)
            {
                await addedItem?.OnPivotSelectedAsync();
            }
        }
    }
}
