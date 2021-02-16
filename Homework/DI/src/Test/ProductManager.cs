public class ProducManager
{
    public void SaveToDb(Product product) { }

    public Product[] GetProducts() { return new Product[0]; }

    public Product[] FindProductsByName(string searchPattern) { return new Product[0]; }

    public void LoadAllProductsFromDb() {}

    public Product[] GetUserProducts(User user) { return new Product[0]; }
}