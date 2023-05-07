namespace TheSixteenthProgram
{
    internal class OrderCustomerProduct
    {
        public int CustomerId {get;set;}
        public string FirstName { get;set;}
        public string LastName { get;set;}
        public int ProductId { get; set; }
        public int StockQuantity { get; set; }
        public decimal Price { get; set; }

        public OrderCustomerProduct() { }
    }
}
