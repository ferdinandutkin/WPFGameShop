using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFGameShop
{
    class DatabaseInteraction
    {

        GameshopContext context = new();
        public DatabaseInteraction()
        {

        }

        public IEnumerable<GameModel> GetGames()
        {
            return context.GameView.Select(
                view =>
                new GameModel()
                {
                    Cover = view.Cover,
                    Description = view.Description,
                    Discount = view.Discount,
                    Id = view.Id,
                    Rating= view.Rating,
                    Price = view.Price,
                    Name = view.Name,
                    IsEarlyAccess = (bool)view.IsEarlyAccess
                }
                );
        }
    }
}
