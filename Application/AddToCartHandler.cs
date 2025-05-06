namespace OnlineShopApp.Application
{
    public class AddToCartHandler
    {
        private List<ShoppingCartItem> _items;

        public AddToCartHandler()
        {
            _items = new List<ShoppingCartItem>();
        }

        public AddToCartResponseModel AddToCart(AddToCartCommand command)
        {
            _items.Add(command.ItemToAdd);

            var response = new AddToCartResponseModel()
            {
                Items = _items,
            };

            return response;
        }
    }
}