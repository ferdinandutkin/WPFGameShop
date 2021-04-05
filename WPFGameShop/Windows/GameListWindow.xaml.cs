using System;
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

        public ThemeViewModel LanguageViewModel { get; set; } = new();
        public GameListViewModel GameListViewModel { get; set; } = new(new IShopRepository());

    


        public GameListWindow()
        {



            LanguageViewModel.Themes.Add(
                  new Theme("English", new Uri("/Languages/English.xaml", UriKind.Relative))


                  );

            LanguageViewModel.Themes.Add(
                 new Theme("Русский", new Uri("/Languages/Russian.xaml", UriKind.Relative))


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
