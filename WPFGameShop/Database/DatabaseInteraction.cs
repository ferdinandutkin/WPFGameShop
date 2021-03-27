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


        public IEnumerable<GenreModel> GetGenres(int gameId)
        {
            using GameshopContext context = new();
            var ids = context.GameGenre
                  .Where(gameGenre => gameGenre.GameId == gameId)
                  .Select(gameGenre => gameGenre.GenreId).ToList();

            var genres = ids.Select(id => context.Genre.Find(id)).ToList();

            return genres.Select(id => new GenreModel() { Id = id.Id, Name = id.Name });
                
        }


        public IEnumerable<GenreModel> GetGenres()
        {
            using GameshopContext context = new();
            return context.Genre.Select(genre => new GenreModel() { Id = genre.Id, Name = genre.Name }).ToList();
            

        }
        public IEnumerable<GameModel> GetGames()
        {

            using GameshopContext context = new();
            return GetGamesNoGenre().Select(game =>
            {
                game.Genres = new ObservableCollection<GenreModel>(GetGenres(game.Id));
                return game;
            }).ToList();
            /*ленивое вычисление обращается к диспоузнотому контксту*/
        }
    }
}
