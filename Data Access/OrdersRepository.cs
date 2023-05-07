using Npgsql;
using Dapper;

namespace TheSixteenthProgram
{
    internal class OrdersRepository
    {
        private readonly string _connectionString;
        public OrdersRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Получение списка заказов.
        /// </summary>
        public List<Order> GetOrders()
        {
            using var con = new NpgsqlConnection(_connectionString);
            {
                var query = "SELECT * FROM Orders";
                con.Open();
                return con.Query<Order>(query).ToList();
            }
        }

        /// <summary>
        /// Добавление нового заказа в базу данных.
        /// </summary>
        public void InsertOrder(Order order)
        {
            using var con = new NpgsqlConnection(_connectionString);
            {
                con.Open();
                var query = "INSERT INTO Orders" +
                " (CustomerId,ProductId,Quantity)" +
                " VALUES (@CustomerId,@ProductId,@Quantity)";
                con.Execute(query, order);
            }
        }

        /// <summary>
        /// Удаление заказа по id.
        /// </summary>
        public void DeleteOrder(int id)
        {
            using var con = new NpgsqlConnection(_connectionString);
            {
                con.Open();
                var query = "DELETE FROM Orders" +
                    " Where Id= @id";
                con.Execute(query, new { id });
            }
        }
    }
}

