using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFGameShop
{
    public class GameModel : BindableBase
    {
      

        private byte[] cover;
        private int id;
        private string description;
        private string name;
        private decimal price;
        private int rating;
        private int discount;
        private bool isEarlyAccess;

        private List<string> genres;

    
        public int Discount
        {
            get => discount;
            set
            {
                if (value != discount)
                {
                    discount = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public List<string> Genres
        {
            get => genres;
            set
            {
                if (value != genres)
                {
                    genres = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public bool IsEarlyAccess
        {
            get => isEarlyAccess;
            set
            {
                if (value != isEarlyAccess)
                {
                    isEarlyAccess = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public int Id
        {
            get => id;
            set
            {
                if (value != id)
                {
                    id = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public byte[] Cover
        {
            get => cover;
            set
            {
                if (value != cover)
                {
                    cover = value;
                    NotifyPropertyChanged();
                }

            }
        }
        public string Name
        {
            get => name;
            set
            {
                if (value != name)
                {
                    name = value;
                    NotifyPropertyChanged();
                }
            }
        }


        public string Description
        {
            get => description;
            set
            {
                if (value != description)
                {
                    description = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public int Rating
        {
            get => rating;
            set
            {
                if (value != rating)
                {
                    rating = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public decimal Price
        {
            get => price;
            set
            {
                if (value != price)
                {
                    price = value;
                    NotifyPropertyChanged();
                }
            }
        }

       
    }


}
