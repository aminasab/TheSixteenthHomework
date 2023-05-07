using Dapper;
using Npgsql;

namespace TheSixteenthProgram
{
    internal class ProductsRepository
    {
        private readonly string _connectionString;
        public ProductsRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Получение списка товаров.
        /// </summary>
        public List<Product> GetProducts()
        {
            using var con = new NpgsqlConnection(_connectionString);
            {
                var query = "SELECT * FROM Products";
                con.Open();
                return con.Query<Product>(query).ToList();
            }
        }

        /// <summary>
        /// Добавление нового товара в базу данных.
        /// </summary>
        public void InsertProduct(Product product)
        {
            using var con = new NpgsqlConnection(_connectionString);
            {
                con.Open();
                var query = "INSERT INTO Products" +
                " (NameOfProduct,Description,Quantity,Price)" +
                " VALUES (@NameOfProduct,@Description,@Quantity,@Price)";
                con.Execute(query, product);
            }
        }

        /// <summary>
        /// Удаление товара по id.
        /// </summary>
        public void DeleteProduct(int id)
        {
            using var con = new NpgsqlConnection(_connectionString);
            {
                con.Open();
                var query = "DELETE FROM Products" +
                    " Where Id= @id";
                con.Execute(query, new { id });
            }
        }
    }
}
