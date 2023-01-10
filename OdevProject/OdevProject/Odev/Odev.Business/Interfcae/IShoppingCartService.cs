using Odev.Business.Model;
using Odev.Core.Responses;
using Odev.Entities.Model;

namespace Odev.Business.Interfcae
{
    public interface IShoppingCartService
    {
        ServiceResponse<ShoppingCart> AddCart(ShoppingCartModel model);

        ServiceResponse<object> RemoveCart();

        ServiceResponse<ShoppingCart> GetCart();
    }
}
