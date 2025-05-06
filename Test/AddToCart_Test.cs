using OnlineShopApp.Application;

namespace OnlineShopApp.Test
{
    public class AddToCart_Test
    {
        public AddToCart_Test()
        {

        }

        [Fact]
        public void AddToCart_ShouldReturnItemAdded()
        {
            // Arrange
            var item = new ShoppingCartItem
            {
                ArticleId = 42,
                Quantity = 1
            };

            var command = new AddToCartCommand
            {
                ItemToAdd = item
            };

            var handler = new AddToCartHandler();

            // Act
            AddToCartResponseModel result = handler.AddToCart(command);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result.Items);
            Assert.Contains(item, result.Items);
        }

        [Fact]
        public void AddToCart_ShouldReturnItemsAdded()
        {
            // Arrange
            var item1 = new ShoppingCartItem
            {
                ArticleId = 42,
                Quantity = 1
            };

            var command1 = new AddToCartCommand
            {
                ItemToAdd = item1
            };

            var handler = new AddToCartHandler();

            handler.AddToCart(command1);

            var item2 = new ShoppingCartItem
            {
                ArticleId = 39,
                Quantity = 5
            };

            var command2 = new AddToCartCommand
            {
                ItemToAdd = item2
            };

            // Act
            AddToCartResponseModel result = handler.AddToCart(command2);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Items.Count);
            Assert.Contains(item1, result.Items);
            Assert.Contains(item2, result.Items);
        }
    }
};