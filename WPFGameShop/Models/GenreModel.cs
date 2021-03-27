﻿namespace WPFGameShop
{
    public class GenreModel : BindableBase
    {
        private string name;
        private int id;


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
        public override bool Equals(object obj) => obj is GenreModel gm && (gm.Id, gm.Name) == (Id, Name);
  


    }


}