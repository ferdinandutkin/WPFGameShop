using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WPFGameShop
{
    /// <summary>
    /// Логика взаимодействия для ToolbarContol.xaml
    /// </summary>
    public partial class ToolbarContol : UserControl
    {


        public static readonly DependencyProperty SearchCommandProperty =
            DependencyProperty.Register(nameof(SearchCommand), typeof(ICommand), typeof(ToolbarContol));


        public ICommand SearchCommand
        {
            get => (ICommand)GetValue(SearchCommandProperty);
            set => SetValue(SearchCommandProperty, value);
        }

        public static readonly DependencyProperty SaveChangesCommandProperty =
          DependencyProperty.Register(nameof(SaveChangesCommand), typeof(ICommand), typeof(ToolbarContol));





        public ICommand NewCommand
        {
            get => GetValue(NewCommandProperty) as ICommand;
            set => SetValue(NewCommandProperty, value);
        }

        public static readonly DependencyProperty NewCommandProperty =
          DependencyProperty.Register(nameof(NewCommand), typeof(ICommand), typeof(ToolbarContol));

        public ICommand DeleteCommand
        {
            get => GetValue(DeleteCommandProperty) as ICommand;
            set => SetValue(DeleteCommandProperty, value);
        }

        public static readonly DependencyProperty DeleteCommandProperty =
          DependencyProperty.Register(nameof(DeleteCommand), typeof(ICommand), typeof(ToolbarContol));


        public ICommand SaveChangesCommand
        {
            get => GetValue(SaveChangesCommandProperty) as ICommand;
            set => SetValue(SaveChangesCommandProperty, value);
        }


        public ToolbarContol()
        {
            InitializeComponent();





        }


    }
}
