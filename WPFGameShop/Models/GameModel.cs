using System.Collections.ObjectModel;

namespace WPFGameShop
{

    public class GenreNameModel : BindableBase
    {

    }


    public class GameModel : TrackableBindableBase
    {


        private byte[] cover;
        private int id;
        private string description;
        private string name;
        private decimal price;
        private int rating;
        private int discount;
        private bool isEarlyAccess;


        public GameModel()
        {
           
        }
        private ObservableCollection<GenreModel> genres = new();


        public int Discount
        {
            get => discount;
            set => Set(ref discount, value);
        }

        public ObservableCollection<GenreModel> Genres
        {
            get => genres;
            set => Set(ref genres, value);
        }

        public bool IsEarlyAccess
        {
            get => isEarlyAccess;
            set => Set(ref isEarlyAccess, value);
        }

        public int Id
        {
            get => id;
            set => Set(ref id, value);
        }

        public byte[] Cover
        {
            get => cover;
            set => Set(ref cover, value);
        }

        public string Name
        {
            get => name;
            set => Set(ref name, value);
        }


        public string Description
        {
            get => description;
            set => Set(ref description, value);
        }

        public int Rating
        {
            get => rating;
            set => Set(ref rating, value);
        }

        public decimal Price
        {
            get => price;
            set => Set(ref price, value);
        }


    }


}
