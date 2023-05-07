namespace TheSixteenthProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomersRepository customerRepository = new(ConstantsForConnectionToDB.ConnectionString);

            // Получение списка покупателей старше 20 лет, у которых есть заказ на продукт с ID=1.
            var result = customerRepository.AllJoin();
            foreach (var res in result)
            {
                Console.WriteLine($"{res.customerid}, {res.firstname}, {res.lastname}, {res.productid}, {res.stockquantity}, {res.price}");
            }

            // Добавление нового покупателя в базу данных.
            Customer newCustomer = new("Алия", "Талалова", 22);
            customerRepository.InsertCustomer(newCustomer);

            // Удаление покупателя с именем 'Бердимырат'.
            customerRepository.DeleteCustomer("Бердимырат");

            // Получение списка всех покупателей.
            var customers = customerRepository.GetCustomers();
            foreach (var customer in customers)
            {
                Console.WriteLine($"{customer.Id}, {customer.FirstName}, {customer.LastName}, {customer.Age}");
            }

            // Работа с таблицей Products.
            ProductsRepository productsRepository = new(ConstantsForConnectionToDB.ConnectionString);
            productsRepository.DeleteProduct(8);
            var products = productsRepository.GetProducts();
            string separator = new('-', 50);
            Console.WriteLine(separator);

            // Получение списка товаров из базы данных.
            foreach (var product in products)
            {
                Console.WriteLine($"{product.Id}, {product.NameOfProdact}, {product.StockQuantity},  {product.Price}");
            }

            // Работа с таблицей Orders.
            OrdersRepository ordersRepository = new(ConstantsForConnectionToDB.ConnectionString);
            ordersRepository.DeleteOrder(10);

            // Вставка нового заказа.
            ordersRepository.InsertOrder(new Order(8, 9, 1));
        }
    }
}
