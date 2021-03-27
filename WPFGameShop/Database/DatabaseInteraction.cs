using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFGameShop
{
    class DatabaseInteraction
    {

    
        public DatabaseInteraction()
        {

        }


        private IEnumerable<GameModel> GetGamesNoGenre()
        {

            using GameshopContext context = new();
            return context.GameView.Select(
               view =>
               new GameModel()
               {
                   Cover = view.Cover,
                   Description = view.Description,
                   Discount = view.Discount,
                   Id = view.Id,
                   Rating = view.Rating,
                   Price = view.Price,
                   Name = view.Name,
                   IsEarlyAccess = (bool)view.IsEarlyAccess,
               }
               ).ToList();
        }


        public IEnumerable<string> GetGenres(int gameId)
        {
            using GameshopContext context = new();
            var ids = context.GameGenre
                  .Where(gameGenre => gameGenre.GameId == gameId)
                  .Select(gameGenre => gameGenre.GenreId).ToList();
            return ids.Select(id => context.Genre.Find(id).Name).ToList();
                
        }
        public IEnumerable<GameModel> GetGames()
        {

            using GameshopContext context = new();
            return GetGamesNoGenre().Select(game =>
            {
                game.Genres = new ObservableCollection<Prop<string>>(GetGenres(game.Id).Select(genre => new Prop<string>(genre)));
                return game;
            }).ToList();
            /*ленивое вычисление обращается к диспоузнотому контксту*/
        }
    }
}
