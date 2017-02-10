using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace WPFCalcZielinski.ViewModel
{
    public class SecondaryViewModel : INotifyPropertyChanged
    {
        private FontFamily fontFamily;
        private Brush brush;

        public event PropertyChangedEventHandler PropertyChanged;

        public FontFamily FontFamily
        {
            get { return fontFamily; }
            set { fontFamily = value; OnPropertyChanged("FontFamily"); }
        }

        public Brush Brush
        {
            get { return brush; }
            set { brush = value; OnPropertyChanged("Brush"); }
        }

        public CollectionView AvailableFontFamilies { get; } =
            new CollectionView(new List<FontFamilyComboboxItem>()
            {
                new FontFamilyComboboxItem() { Name = "Arial", FontFamily = new FontFamily("Arial") },
                new FontFamilyComboboxItem() { Name = "Consolas", FontFamily = new FontFamily("Consolas") },
                new FontFamilyComboboxItem() { Name = "Algerian", FontFamily = new FontFamily("Algerian") },
            });

        public CollectionView AvailableBrushes { get; } =
            new CollectionView(new List<BrushComboboxItem>()
            {
                new BrushComboboxItem() { Name = "White", Brush = Brushes.White },
                new BrushComboboxItem() { Name = "Black", Brush = Brushes.Black },
                new BrushComboboxItem() { Name = "Red", Brush = Brushes.Red  },
            });


        private void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public class FontFamilyComboboxItem
    {
        public string Name { get; set; }
        public FontFamily FontFamily { get; set; }
    }

    public class BrushComboboxItem
    {
        public string Name { get; set; }
        public Brush Brush { get; set; }
    }
}
