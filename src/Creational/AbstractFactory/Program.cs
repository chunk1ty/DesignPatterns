using AbstractFactory;

var shoppingCartForBulgaria = new ShoppingCart(new BulgarianShoppingCartPurchaseFactory());
shoppingCartForBulgaria.CalculateCosts();

var shoppingCartForAmerica = new ShoppingCart(new AmericanShoppingCartPurchaseFactory());
shoppingCartForAmerica.CalculateCosts();