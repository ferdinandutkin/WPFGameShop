using System.Collections.ObjectModel;
using WpfControlLibrary;


namespace WPFGameShop
{
    public sealed class ThemeViewModel : BindableBase
    {
        private Theme selectedTheme;

        public ThemeViewModel()
        {
           
            
        }

        public ObservableCollection<Theme> Themes { get; set; } = new();

        public Theme SelectedTheme
        {
            get => selectedTheme;
            set
            {
                if (selectedTheme != value)
                {
                    selectedTheme = value;
                    NotifyPropertyChanged();
                }
              
            }
        }

       

       
    }
}