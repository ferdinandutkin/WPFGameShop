using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WPFGameShop
{
    public class GameListViewModel : BindableBase
    {
        ObservableCollection<GameModel> gameModelList;

        ICommand seeMoreCommand;
        ICommand editImageCommand;

        public ObservableCollection<GameModel> GameModelList
        {
            get => gameModelList;
            set
            {
                gameModelList = value;
                NotifyPropertyChanged();

            }
        }


        GameModel selectedItem;
        public GameModel SelectedItem
        {
            get => selectedItem;

            set
            {
                selectedItem = value;
                NotifyPropertyChanged();
            }
        }

        public GameListViewModel(IEnumerable<GameModel> models) => gameModelList = new ObservableCollection<GameModel>(models);


        public GameListViewModel(ObservableCollection<GameModel> models) => gameModelList = new ObservableCollection<GameModel>(models);
        public ICommand SeeMoreCommand => seeMoreCommand ??= new DelegateCommand(
                     param => SeeMore(),
                     param => (SelectedItem is not null)
                 );


        public ICommand EditImageCommand =>  editImageCommand ??= new DelegateCommand(
                     param => EditImage(),
                     param => (SelectedItem is not null)
                 );


        void EditImage()
        {

            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            dlg.DefaultExt = ".jpg";
            dlg.Filter = "Image Files| *.jpg; *.jpeg; *.png; *.gif; *.tif; ...";



            var result = dlg.ShowDialog();


            if (result == true)
            {

                SelectedItem.Cover = File.ReadAllBytes(dlg.FileName);
            }

        }

        void SeeMore()
        {
            MessageBox.Show("More");

        }

    }
}
