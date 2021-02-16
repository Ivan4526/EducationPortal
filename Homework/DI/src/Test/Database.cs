public class Database
{
    public ProductViewModel[] Read()
    {
        return new ProductViewModel[0];
    }
}

public class ProductViewModel
{
    public string Name { get; set; }

    public bool IsVisible { get; set; }

    public bool IsSelected { get; set; }
}