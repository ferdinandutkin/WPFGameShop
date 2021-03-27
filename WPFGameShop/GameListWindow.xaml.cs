using System;
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

namespace WPFGameShop
{
    /// <summary>
    /// Логика взаимодействия для GameListWindow.xaml
    /// </summary>
    public partial class GameListWindow : Window
    {
        DatabaseInteraction databaseInteraction = new();
        public GameListViewModel GameListViewModel { get; set; }

        public SelectedGameViewModel SelectedGameViewModel { get; set; } = new();
        public GameListWindow()
        {
            GameListViewModel = new(databaseInteraction.GetGames());
            InitializeComponent();
        }
    }
}
