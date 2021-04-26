using System.Collections.ObjectModel;

namespace WPFGameShop
{
    public class GenreModel : BindableBase
    {
        private string name;
        private int id;


        public int Id
        {
            get => id;
            set => Set(ref id, value);
        }


        public string Name
        {
            get => name;
            set => Set(ref name, value);
        }


        ObservableCollection<GameModel> games;
        public ObservableCollection<GameModel> Games
        {
            get => games;
            set => Set(ref games, value);

        }
        public override bool Equals(object obj) => obj is GenreModel gm && (gm.Id, gm.Name) == (Id, Name);



    }


}
