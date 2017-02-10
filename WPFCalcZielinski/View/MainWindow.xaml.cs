using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFCalcZielinski.ViewModel;
using System.ComponentModel;

namespace WPFCalcZielinski.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel mainViewModel;
        private SecondaryViewModel secondaryViewModel;
        private SecondaryWindow secondaryWindow;

        public MainWindow(MainViewModel vm)
        {
            InitializeComponent();
            mainViewModel = vm;
            DataContext = vm;
        }

        private void Window_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(secondaryWindow == null || !secondaryWindow.IsVisible)
            {
                secondaryViewModel = new SecondaryViewModel();
                secondaryViewModel.PropertyChanged += SecondaryWindowPropertyChanged;
                secondaryWindow = new SecondaryWindow(secondaryViewModel);
                secondaryWindow.Show();
            }
        }

        private void SecondaryWindowPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "FontFamily")
            {
                mainViewModel.FontFamily = secondaryViewModel.FontFamily;
            }
            else if(e.PropertyName == "Brush")
            {
                mainViewModel.ThemeColor = secondaryViewModel.Brush;
            }
        }
    }
}
