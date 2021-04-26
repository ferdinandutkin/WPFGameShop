using System;
using System.Globalization;
using System.Reflection;
using System.Windows;
using WpfControlLibrary;

namespace WPFGameShop
{
    /// <summary>
    /// Логика взаимодействия для GameListWindow.xaml
    /// </summary>
    public partial class GameListWindow : Window
    {
         
        public ThemeViewModel ThemeViewModel { get; set; } = new();

        public LanguageViewModel LanguageViewModel { get; set; } = new();
        public GameListViewModel GameListViewModel { get; set; } = new(new GameShopContextOperations());

 
    


        public GameListWindow()
        {

            
          
            LanguageViewModel.Language.Add(
                new Language(new CultureInfo("en-US"),
                new Uri("/Languages/English.xaml", UriKind.Relative))
                  );

            LanguageViewModel.Language.Add(

                new Language(new CultureInfo("ru-RU"),
                new Uri("/Languages/Russian.xaml", UriKind.Relative))


                 );






            ThemeViewModel.Themes.Add(
                   new Theme("Default", new Uri("/Themes/Default.xaml", UriKind.Relative))


                   );

         

            ThemeViewModel.Themes.Add(
                new Theme("Bold", new Uri("/Themes/Bold.xaml", UriKind.Relative))


                );

            ThemeViewModel.Themes.Add(
              new Theme("Italic", new Uri("/Themes/Italic.xaml", UriKind.Relative))


              );

            InitializeComponent();
        }
    }
}
