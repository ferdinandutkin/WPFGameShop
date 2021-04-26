using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace WPFGameShop
{




    public class GameListViewModel : BindableBase
    {
        ObservableCollection<GameModel> gameModelList;

        SelectedGameViewModel selectedGameViewModel;
        readonly IGameShopRepository IGameShopRepository;

        public SelectedGameViewModel SelectedGameViewModel
        {
            get => selectedGameViewModel;
            set => Set(ref selectedGameViewModel, value);
        }


        public ICommand SearchCommand => new DelegateCommand(
                   param => Search(param.ToString())
               );


       
        public ICommand DeleteCommand => new DelegateCommand(
            param => Delete(),
            param => SelectedGameViewModel.SelectedGame is not null
        );


        public ICommand NewCommand => new DelegateCommand(
      param => New()
  );

        private void New()
        {
            gameModelList.Add(new GameModel());
        }

        public ICommand SaveChangesCommand => new DelegateCommand(
                  param => SaveChanges()
              );

        void SaveChanges() => IGameShopRepository.SaveChanges(gameModelList);


      

        public GameListViewModel(IGameShopRepository IGameShopRepository)
        {
            this.IGameShopRepository = IGameShopRepository;
            this.selectedGameViewModel = new();

            this.selectedGameViewModel.AllGenres = new ObservableCollection<GenreModel>(IGameShopRepository.GetGenres());
            this.GameModelList = new ObservableCollection<GameModel>(IGameShopRepository.GetGames());
 

        }

        void Search(string search)
        {
         
            GameModelListView.Filter = item =>
            {
                string searchLower = search.ToLower().Trim();
                if (searchLower == string.Empty)
                {
                    return true;
                }
                GameModel gameModel = item as GameModel;
                return gameModel.Name.ToLower().Contains(searchLower) ||
                gameModel.Price.ToString().ToLower().Contains(searchLower) ||
                gameModel.Genres.Any(genre => genre.Name.ToLower().Contains(searchLower)) ||
                gameModel.Rating.ToString().ToLower().Contains(searchLower);



            };
        }

        void Delete()
        {
            IGameShopRepository.RemoveGame(selectedGameViewModel.SelectedGame);
            GameModelList.Remove(selectedGameViewModel.SelectedGame);

        }

        public ICollectionView GameModelListView { get; set; }


        public ObservableCollection<GameModel> GameModelList
        {
            get => gameModelList;
            set
            {
                gameModelList = value;
                GameModelListView = CollectionViewSource.GetDefaultView(GameModelList);
                NotifyPropertyChanged();

            }
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



        public ICommand DropCommand => new DelegateCommand(
                     param => DropEvent(param as DragEventArgs),
                     param => (SelectedGame is not null)
                 );

        public ICommand DragEnterCommand => new DelegateCommand(
                     param => DragEnterEvent(),
                     param => (SelectedGame is not null)
                 );
        public ICommand DragLeaveCommand => new DelegateCommand(
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
            OpenFileDialog openFileDialog = new()
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



