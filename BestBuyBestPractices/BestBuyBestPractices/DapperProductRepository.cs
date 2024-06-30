using System;
using System.Data;
using Dapper;

namespace BestBuyBestPractices
{
	public class DapperProductRepository: IProductRepository
	{
        private readonly IDbConnection _connection;

        public DapperProductRepository(IDbConnection connection)
		{
			_connection = connection;
		}

		public IEnumerable<Product> GetAllProducts()
		{
			return _connection.Query<Product>("SELECT * FROM Products;");
		}

		public void CreateProduct(string name, double price, int categoryID)
		{
			_connection.Execute("INSERT INTO Products (Name, Price, CategoryID) " +
				"VALUES (@name, @price, @categoryID);",
				new { name = name, price = price, categoryID = categoryID });
		}

    }
}

