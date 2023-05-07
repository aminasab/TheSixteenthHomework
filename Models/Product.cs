namespace TheSixteenthProgram
{
    public class Product
    {
        public int Id { get; set; }
        public string? NameOfProdact { get; set; }
        public string? Description { get; set; }
        public int StockQuantity { get; set; }
        public decimal Price { get; set; }

        public Product() { }
        public Product(string nameOfProduct, string description, int quantity, decimal price)
        {
            NameOfProdact = nameOfProduct;
            Description = description;
            StockQuantity = quantity;
            Price = price;
        }
    }
}
