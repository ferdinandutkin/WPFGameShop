using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class GenreControl : UserControl
    {

        public static readonly DependencyProperty IsEditableProperty = DependencyProperty.Register(nameof(IsEditable),
      typeof(bool), typeof(GenreControl)
      );

        //private void propertyChangedCallback(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        //{

        //    var control = sender as GenreControl;
           
        //   if ((bool)e.NewValue)
        //    {
        //        control.popup.IsOpen = false;
        //    }
        //   else
        //    {
        //        control.popup.IsOpen = true;
        //    }

        //}

        public bool IsEditable
        {
            get => (bool)GetValue(IsEditableProperty);
            set => SetValue(IsEditableProperty, value);
        }
        public static readonly DependencyProperty CurrentGenresSourceProperty = DependencyProperty.Register(nameof(CurrentGenresSource),
       typeof(ObservableCollection<GenreModel>), typeof(GenreControl)
       );

       
        public ObservableCollection<GenreModel> CurrentGenresSource
        {
            get => GetValue(CurrentGenresSourceProperty) as ObservableCollection<GenreModel>;
            set => SetValue(CurrentGenresSourceProperty, value);
        }

         
 
        public static readonly DependencyProperty AllGenresSourceProperty = DependencyProperty.Register(nameof(AllGenresSource),
    typeof(ObservableCollection<GenreModel>), typeof(GenreControl)
    );


        public ObservableCollection<GenreModel> AllGenresSource
        {
            get => GetValue(AllGenresSourceProperty) as ObservableCollection<GenreModel>;
            set => SetValue(AllGenresSourceProperty, value);
        }

       

        private void ListBox_Drop(object sender, DragEventArgs e)
        {
           
            object data = e.Data.GetData(typeof(GenreModel));
            AddToCurrent(data);
      
        }
        private void ListBox_PreviewMouseLeftButtonDown(object sender, MouseEventArgs e)
        {

            if (sender is ListBoxItem && e.LeftButton == MouseButtonState.Pressed)
            {
                ListBoxItem draggedItem = sender as ListBoxItem;
                DragDrop.DoDragDrop(draggedItem, draggedItem.DataContext, DragDropEffects.Move);
                draggedItem.IsSelected = true;
            }
        }
      

        void AddToCurrent(object element)
        {
            if (!(CurrentListBox.ItemsSource as IList).Contains(element))
            {
                (CurrentListBox.ItemsSource as IList).Add(element);
            }
        }

        private void PopupOpened(object sender, EventArgs e)
        {
            var wnd = Window.GetWindow(this);
            if (wnd is not null)
            {
                var mi = popup.GetType().GetMethod("Reposition", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                wnd.LocationChanged += (_, _) => mi.Invoke(popup, null);
                wnd.SizeChanged += (_, _) => mi.Invoke(popup, null);
            }
            else
            {
                popup.IsOpen = false;
            }
        
        }
      
        public GenreControl()
        {
           
            InitializeComponent();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
             if (CurrentListBox.SelectedItem is not null)
            {
                (CurrentListBox.ItemsSource as IList).Remove(CurrentListBox.SelectedItem);
            }
                 
 
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (TotalListBox.SelectedItem is not null)
            {
                AddToCurrent(TotalListBox.SelectedItem);
            }
        }

       
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
