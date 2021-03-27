using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

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
          
            this.SourceUpdated += GameModelControl_SourceUpdated;
            
           
          


        }
      

        private void GameModelControl_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            if (Source is not null)
            {
                MessageBox.Show("not null");
                Source.PropertyChanged += (source, name) =>
                {
                    MessageBox.Show(name.PropertyName);
                };
            }
        }

      
    }
}
