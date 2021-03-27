using Microsoft.Win32;
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
                if (selectedItem != value)
                {
                    selectedItem = value;
                    NotifyPropertyChanged();
                }
               
            }
        }

        public GameListViewModel(IEnumerable<GameModel> models) => gameModelList = new ObservableCollection<GameModel>(models);


        public GameListViewModel(ObservableCollection<GameModel> models) => gameModelList = new ObservableCollection<GameModel>(models);
        public ICommand SeeMoreCommand => new DelegateCommand(
                     param => SeeMore(),
                     param => (SelectedItem is not null)
                 );



        void SeeMore()
        {
            MessageBox.Show("More");

        }

    }


    public class SelectedGameViewModel : BindableBase
    {


        ObservableCollection<GenreModel> allGenres;






        public ObservableCollection<GenreModel> AllGenres
        {
            get => allGenres;
            set
            {
                if (allGenres != value)
                {
                    allGenres = value;
                    NotifyPropertyChanged();
                }
            

            }
        }

        GameModel selectedGame;



        public GameModel SelectedGame
        {
            get => selectedGame;

            set
            {
                if (selectedGame != value)
                {
                    
                    selectedGame = value;
                    NotifyPropertyChanged();
                }
               
            }
        }

       
    
        public ICommand DropCommand =>   new DelegateCommand(
                     param => DropEvent(param as DragEventArgs),
                     param => (SelectedGame is not null)
                 );

        public ICommand DragEnterCommand =>   new DelegateCommand(
                     param => DragEnterEvent(),
                     param => (SelectedGame is not null)
                 );
        public ICommand DragLeaveCommand =>  new DelegateCommand(
                     param => DragLeaveEvent(),
                     param => (SelectedGame is not null)
                 );

        public ICommand BrowseImageCommand => new DelegateCommand(
                     param => BrowseImageEvent(),
                     param => (SelectedGame is not null)
                 );




        bool entered = false;
        public bool Entered
        {
            get => entered;
            set
            {
                if (entered != value)
                {
                    entered = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private void BrowseImageEvent()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.png;*.bmp;*.tiff;"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                SelectedGame.Cover = File.ReadAllBytes(openFileDialog.FileName);
            }
        }

        private void DragLeaveEvent() => Entered = false;

        private void DragEnterEvent() => Entered = true;

        private void DropEvent(DragEventArgs obj)
        {
            try
            {
                
                Entered = false;

                if (obj.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    var files = obj.Data.GetData(DataFormats.FileDrop, true) as string[];
                    SelectedGame.Cover = File.ReadAllBytes(files.Last());
                    //NotifyPropertyChanged(nameof(SelectedGame));
                }
              
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.Source);
            }
        }

      

    }
}



