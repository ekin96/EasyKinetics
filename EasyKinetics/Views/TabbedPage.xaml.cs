using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Windows.UI.Xaml.Controls;

namespace EasyKinetics.Views
{
    public sealed partial class TabbedPage : Page, INotifyPropertyChanged
    {
        public TabbedPage()
        {
            InitializeComponent();
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

       private void EK1_dAbsmin_15a_KeyDown(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
        {
            bool nonNumberEntered = false;
            if (e.Key < Windows.System.VirtualKey.Number0 || e.Key > Windows.System.VirtualKey.Number9)
            {
                if (e.Key < Windows.System.VirtualKey.NumberPad0 || e.Key > Windows.System.VirtualKey.NumberPad9)
                {
                    if (e.Key != Windows.System.VirtualKey.Back &&
                       e.Key != Windows.System.VirtualKey.Decimal)
                    {
                        nonNumberEntered = true;
                    }
                }
            }
            if (nonNumberEntered)
            {
                e.Handled = true;
            }
        }

        private void EK1_dAbsmin_15b_KeyDown(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
        {
            bool nonNumberEntered = false;
            if (e.Key < Windows.System.VirtualKey.Number0 || e.Key > Windows.System.VirtualKey.Number9)
            {
                if (e.Key < Windows.System.VirtualKey.NumberPad0 || e.Key > Windows.System.VirtualKey.NumberPad9)
                {
                    if (e.Key != Windows.System.VirtualKey.Back &&
                       e.Key != Windows.System.VirtualKey.Decimal)
                    {
                        nonNumberEntered = true;
                    }
                }
            }
            if (nonNumberEntered)
            {
                e.Handled = true;
            }
        }

        private void EK1_dAbsmin_25a_KeyDown(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
        {
            bool nonNumberEntered = false;
            if (e.Key < Windows.System.VirtualKey.Number0 || e.Key > Windows.System.VirtualKey.Number9)
            {
                if (e.Key < Windows.System.VirtualKey.NumberPad0 || e.Key > Windows.System.VirtualKey.NumberPad9)
                {
                    if (e.Key != Windows.System.VirtualKey.Back &&
                       e.Key != Windows.System.VirtualKey.Decimal)
                    {
                        nonNumberEntered = true;
                    }
                }
            }
            if (nonNumberEntered)
            {
                e.Handled = true;
            }
        }

        private void EK1_dAbsmin_25b_KeyDown(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
        {
            bool nonNumberEntered = false;
            if (e.Key < Windows.System.VirtualKey.Number0 || e.Key > Windows.System.VirtualKey.Number9)
            {
                if (e.Key < Windows.System.VirtualKey.NumberPad0 || e.Key > Windows.System.VirtualKey.NumberPad9)
                {
                    if (e.Key != Windows.System.VirtualKey.Back &&
                       e.Key != Windows.System.VirtualKey.Decimal)
                    {
                        nonNumberEntered = true;
                    }
                }
            }
            if (nonNumberEntered)
            {
                e.Handled = true;
            }
        }

        private void EK1_dAbsmin_100a_KeyDown(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
        {
            bool nonNumberEntered = false;
            if (e.Key < Windows.System.VirtualKey.Number0 || e.Key > Windows.System.VirtualKey.Number9)
            {
                if (e.Key < Windows.System.VirtualKey.NumberPad0 || e.Key > Windows.System.VirtualKey.NumberPad9)
                {
                    if (e.Key != Windows.System.VirtualKey.Back &&
                       e.Key != Windows.System.VirtualKey.Decimal)
                    {
                        nonNumberEntered = true;
                    }
                }
            }
            if (nonNumberEntered)
            {
                e.Handled = true;
            }
        }
        private void EK1_dAbsmin_100b_KeyDown(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
        {
            bool nonNumberEntered = false;
            if (e.Key < Windows.System.VirtualKey.Number0 || e.Key > Windows.System.VirtualKey.Number9)
            {
                if (e.Key < Windows.System.VirtualKey.NumberPad0 || e.Key > Windows.System.VirtualKey.NumberPad9)
                {
                    if (e.Key != Windows.System.VirtualKey.Back &&
                       e.Key != Windows.System.VirtualKey.Decimal)
                    {
                        nonNumberEntered = true;
                    }
                }
            }
            if (nonNumberEntered)
            {
                e.Handled = true;
            }
        }

        private void EK1_Mec_KeyDown(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
        {
            bool nonNumberEntered = false;
            if (e.Key < Windows.System.VirtualKey.Number0 || e.Key > Windows.System.VirtualKey.Number9)
            {
                if (e.Key < Windows.System.VirtualKey.NumberPad0 || e.Key > Windows.System.VirtualKey.NumberPad9)
                {
                    if (e.Key != Windows.System.VirtualKey.Back &&
                       e.Key != Windows.System.VirtualKey.Decimal)
                    {
                        nonNumberEntered = true;
                    }
                }
            }
            if (nonNumberEntered)
            {
                e.Handled = true;
            }
        }

        private void EK1_OpticalPath_KeyDown(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
        {
            bool nonNumberEntered = false;
            if (e.Key < Windows.System.VirtualKey.Number0 || e.Key > Windows.System.VirtualKey.Number9)
            {
                if (e.Key < Windows.System.VirtualKey.NumberPad0 || e.Key > Windows.System.VirtualKey.NumberPad9)
                {
                    if (e.Key != Windows.System.VirtualKey.Back &&
                       e.Key != Windows.System.VirtualKey.Decimal)
                    {
                        nonNumberEntered = true;
                    }
                }
            }
            if (nonNumberEntered)
            {
                e.Handled = true;
            }
        }

        private void EK1_InitSolVol_KeyDown(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
        {
            bool nonNumberEntered = false;
            if (e.Key < Windows.System.VirtualKey.Number0 || e.Key > Windows.System.VirtualKey.Number9)
            {
                if (e.Key < Windows.System.VirtualKey.NumberPad0 || e.Key > Windows.System.VirtualKey.NumberPad9)
                {
                    if (e.Key != Windows.System.VirtualKey.Back &&
                       e.Key != Windows.System.VirtualKey.Decimal)
                    {
                        nonNumberEntered = true;
                    }
                }
            }
            if (nonNumberEntered)
            {
                e.Handled = true;
            }
        }

        private void EK1_FinSolVol_KeyDown(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
        {
            bool nonNumberEntered = false;
            if (e.Key < Windows.System.VirtualKey.Number0 || e.Key > Windows.System.VirtualKey.Number9)
            {
                if (e.Key < Windows.System.VirtualKey.NumberPad0 || e.Key > Windows.System.VirtualKey.NumberPad9)
                {
                    if (e.Key != Windows.System.VirtualKey.Back &&
                       e.Key != Windows.System.VirtualKey.Decimal)
                    {
                        nonNumberEntered = true;
                    }
                }
            }
            if (nonNumberEntered)
            {
                e.Handled = true;
            }
        }

        private void EK1_SubstrateConc_KeyDown(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
        {
            bool nonNumberEntered = false;
            if (e.Key < Windows.System.VirtualKey.Number0 || e.Key > Windows.System.VirtualKey.Number9)
            {
                if (e.Key < Windows.System.VirtualKey.NumberPad0 || e.Key > Windows.System.VirtualKey.NumberPad9)
                {
                    if (e.Key != Windows.System.VirtualKey.Back &&
                       e.Key != Windows.System.VirtualKey.Decimal)
                    {
                        nonNumberEntered = true;
                    }
                }
            }
            if (nonNumberEntered)
            {
                e.Handled = true;
            }
        }

        private void EK1_EnzymeSubUnits_KeyDown(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
        {
            bool nonNumberEntered = false;
            if (e.Key < Windows.System.VirtualKey.Number0 || e.Key > Windows.System.VirtualKey.Number9)
            {
                if (e.Key < Windows.System.VirtualKey.NumberPad0 || e.Key > Windows.System.VirtualKey.NumberPad9)
                {
                    if (e.Key != Windows.System.VirtualKey.Back &&
                       e.Key != Windows.System.VirtualKey.Decimal)
                    {
                        nonNumberEntered = true;
                    }
                }
            }
            if (nonNumberEntered)
            {
                e.Handled = true;
            }
        }

        private void EK1_dAbsmin_15a_TextChanged(object sender, TextChangedEventArgs e)
        {
            double a1 = Double.Parse(EK1_dAbsmin_15a.Text);
            double a2 = Double.Parse(EK1_dAbsmin_15b.Text);
            double atot = (a1 + a2) / 2;
            EK1_dAbsmin_15tot.Text = atot.ToString();
        }

        private void EK1_dAbsmin_15b_TextChanged(object sender, TextChangedEventArgs e)
        {
            double a1 = Double.Parse(EK1_dAbsmin_15a.Text);
            double a2 = Double.Parse(EK1_dAbsmin_15b.Text);
            double atot = (a1 + a2) / 2;
            EK1_dAbsmin_15tot.Text = atot.ToString();
        }

        private void EK1_x1_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            double x1 = 1 / 0.000025;
            EK1_x1.Text = x1.ToString();
        }

        private void EK1_x2_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            double x2 = 1 / 0.000015;
            EK1_x2.Text = x2.ToString();
        }

    }
}
