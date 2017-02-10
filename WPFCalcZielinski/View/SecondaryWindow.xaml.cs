﻿using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using WPFCalcZielinski.ViewModel;

namespace WPFCalcZielinski.View
{
    /// <summary>
    /// Interaction logic for SecondaryWindow.xaml
    /// </summary>
    public partial class SecondaryWindow : Window
    {
        public SecondaryWindow(SecondaryViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
        }
    }
}
