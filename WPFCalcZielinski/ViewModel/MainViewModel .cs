using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using WPFCalcZielinski.Model;

namespace WPFCalcZielinski.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly ICalculator calculator;
        private string text;
        private bool decimalPointEnabled;
        private bool buttonsEnabled;
        private Brush themeColor;
        private FontFamily fontFamilly;
        private int windowWidth;
        private int windowHeight;
        public event PropertyChangedEventHandler PropertyChanged;

        public RelayCommand RelayCommand { get; private set; }
        
        public string Text
        {
            get { return text; }
            set { text = value; OnPropertyChanged("Text"); }
        }
        public bool DecimalPointEnabled
        {
            get { return decimalPointEnabled; }
            set { decimalPointEnabled = value; OnPropertyChanged("DecimalPointEnabled"); }
        }
        public bool ButtonsEnabled
        {
            get { return buttonsEnabled; }
            set { buttonsEnabled = value; OnPropertyChanged("ButtonsEnabled"); }
        }

        public Brush ThemeColor
        {
            get { return themeColor; }
            set { themeColor = value; OnPropertyChanged("ThemeColor"); }
        }

        public FontFamily FontFamily
        {
            get { return fontFamilly; }
            set { fontFamilly = value; OnPropertyChanged("FontFamily"); }
        }
        
        public int FontSize
        {
            get
            {
                var minDim = Math.Min(windowWidth, windowHeight);
                return minDim / 20;
            }
        }

        public int WindowWidth
        {
            get { return windowWidth; }
            set { windowWidth = value; OnPropertyChanged("FontSize"); }
        }

        public int WindowHeight
        {
            get { return windowHeight; }
            set { windowHeight = value; OnPropertyChanged("FontSize"); }
        }

        public MainViewModel(ICalculator calculator)
        {
            this.calculator = calculator;
            RelayCommand = new RelayCommand(ExecuteRelayCommand);
            SynchronizeWithCalculator();
            ThemeColor = Brushes.White;
            fontFamilly = new FontFamily("Arial");
            WindowWidth = 350;
            windowHeight = 200;
        }

        private void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private void ExecuteRelayCommand(object commandParam)
        {
            calculator.HandleCommand((string)commandParam);
            SynchronizeWithCalculator();
        }

        private void SynchronizeWithCalculator()
        {
            Text = calculator.Text;
            DecimalPointEnabled = calculator.DecimalPointEnabled;
            ButtonsEnabled = !calculator.Error;
        }
    }
}
