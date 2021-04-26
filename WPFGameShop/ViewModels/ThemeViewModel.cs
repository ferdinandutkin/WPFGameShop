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
            set => Set(ref selectedTheme, value);
        }

       

       
    }





    public sealed class LanguageViewModel : BindableBase
    {
        private Language selectedLanguage;

        public LanguageViewModel()
        {


        }

        public ObservableCollection<Language> Language { get; set; } = new();

        public Language SelectedLanguage
        {
            get => selectedLanguage;
            set => Set(ref selectedLanguage, value);
           
        }




    }
}