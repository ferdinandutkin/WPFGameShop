using System;
using System.Windows;
using System.Windows.Controls;

namespace WPFGameShop
{
    /// <summary>
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    public partial class GameModelControl : UserControl
    {

        public static readonly DependencyProperty SourceProperty = DependencyProperty.Register(nameof(Source), typeof(SelectedGameViewModel), typeof(GameModelControl), new PropertyMetadata(null, propertyChangedCallback));

        private static void propertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is SelectedGameViewModel selectedGameViewModel)
            {

                selectedGameViewModel.PropertyChanged += (sender, args) =>
                {
                    if (sender is SelectedGameViewModel { SelectedGame: not null } sgvm)
                    {
                        sgvm.SelectedGame.PropertyChanged += (_, args1) =>
                        {
                            var tmp = (d as GameModelControl).DataContext;
                            (d as GameModelControl).DataContext = null;
                            (d as GameModelControl).DataContext = tmp;
                        
                        };
                    };
                };
          
            }
        }

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
