using Dapper;
using Npgsql;

namespace TheSixteenthProgram
{
    internal class CustomersRepository
    {
        private readonly string _connectionString;
        public CustomersRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Получение списка покупателей.
        /// </summary>
        public List<Customer> GetCustomers()
        {
            using var con = new NpgsqlConnection(_connectionString);
            {
                var query = "SELECT * FROM Customers";
                con.Open();
                return con.Query<Customer>(query).ToList();
            }
        }

        /// <summary>
        /// Написание запроса, который возвращает список всех пользователей старше 20 лет, у которых есть заказ на продукт с ID=1
        /// </summary>
        public List<dynamic> AllJoin()
        {
            using (var con = new NpgsqlConnection(_connectionString))
            {
                con.Open();
                string query = "SELECT o.CustomerId, c.FirstName, c.LastName, o.ProductId,p.StockQuantity, p.Price FROM Orders AS o JOIN Customers AS c ON o.CustomerId=c.Id JOIN Products AS p ON o.ProductId=p.Id WHERE c.Age>20 AND o.ProductId=1";

                var orders = con.Query(query).ToList();
                return orders;
            }
        }

        /// <summary>
        /// Добавление нового клиента в базу данных.
        /// </summary>
        public void InsertCustomer(Customer customer)
        {
            using var con = new NpgsqlConnection(_connectionString);
            {
                con.Open();
                var query = "INSERT INTO Customers" +
                " (FirstName,LastName,Age)" +
                " VALUES (@FirstName,@LastName,@Age)";
                con.Execute(query, customer);
            }
        }

        /// <summary>
        /// Удаление клиента по имени.
        /// </summary>
        public void DeleteCustomer(string name)
        {
            using var con = new NpgsqlConnection(_connectionString);
            {
                con.Open();
                var query = "DELETE FROM Customers" +
                    " Where FirstName= @name";
                con.Execute(query, new { name });
            }
        }
    }
}
