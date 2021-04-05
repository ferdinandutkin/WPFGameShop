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
            get => (ICommand)GetValue(NewCommandProperty);
            set => SetValue(NewCommandProperty, value);
        }

        public static readonly DependencyProperty NewCommandProperty =
          DependencyProperty.Register(nameof(NewCommand), typeof(ICommand), typeof(ToolbarContol));

        public ICommand DeleteCommand
        {
            get => (ICommand)GetValue(DeleteCommandProperty);
            set => SetValue(DeleteCommandProperty, value);
        }

        public static readonly DependencyProperty DeleteCommandProperty =
          DependencyProperty.Register(nameof(DeleteCommand), typeof(ICommand), typeof(ToolbarContol));


        public ICommand SaveChangesCommand
        {
            get => (ICommand)GetValue(SaveChangesCommandProperty);
            set => SetValue(SaveChangesCommandProperty, value);
        }
 

     


        //public static readonly DependencyProperty CommandProperty =
        //  DependencyProperty.Register(nameof(Command), typeof(ICommand), typeof(ToolbarContol));


        //public ICommand Command
        //{
        //    get => (ICommand)GetValue(CommandProperty);
        //    set => SetValue(CommandProperty, value);
        //}



        public ToolbarContol()
        {
            InitializeComponent();





        }


    }
}
