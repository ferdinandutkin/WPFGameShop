using System.Windows;
using System.Windows.Controls;

namespace WPFGameShop
{
    /// <summary>
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    public partial class GameModelControl : UserControl
    {

        public static readonly DependencyProperty SourceProperty = DependencyProperty.Register(nameof(Source), typeof(SelectedGameViewModel), typeof(GameModelControl));



        public SelectedGameViewModel Source
        {
            get => (SelectedGameViewModel)GetValue(SourceProperty);
            set => SetValue(SourceProperty, value);
        }



        public static readonly DependencyProperty IsEditableProperty = DependencyProperty.Register(nameof(IsEditable), typeof(bool), typeof(GameModelControl));


        public bool IsEditable
        {
            get => (bool)GetValue(IsEditableProperty);
            set => SetValue(IsEditableProperty, value);
        }




        public GameModelControl()
        {

            InitializeComponent();







        }





    }
}
