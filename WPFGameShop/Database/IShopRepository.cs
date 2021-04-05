using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WPFGameShop
{

    public interface IGameShopRepository
    {


        IEnumerable<GameModel> GetGames();

        IEnumerable<GenreModel> GetGenres();


        void RemoveGame(GameModel model);

        void SaveChanges(IEnumerable<GameModel> gameModels);

      
    }





    public class IShopRepository : IDisposable, IGameShopRepository
    {
        readonly ShopContext context = new();

        public IShopRepository()
        {

        }

        public void Dispose()
        {
            context.Dispose();
            GC.SuppressFinalize(this);
        }


        ~IShopRepository() => Dispose();


        public void SaveChanges(IEnumerable<GameModel> gameModels)
        {



          //  context.Games.UpdateRange(gameModels);
            context.UpdateRange(gameModels);

            
            //context.Genres.UpdateRange(gameModels.SelectMany(gameModels => gameModels.Genres));

            // context.Game.Update()
            context.SaveChanges();

        }





        public IEnumerable<GenreModel> GetGenres() => context.Genres.ToList();
    
        public void RemoveGame(GameModel model)
        {


            context.Games.Remove(context.Games.Find(model.Id));

        }
        public IEnumerable<GameModel> GetGames() => context.Games.Include(game => game.Genres);
       
    }
}
