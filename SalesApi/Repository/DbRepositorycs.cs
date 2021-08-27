using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using Npgsql;
using SalesApi.Entities;
using SalesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using static SalesApi.IRepository;

namespace SalesApi.Repository
{
    public class DbRepositorycs
    {
        private static readonly string connectionString = @"";

        public DbRepositorycs()
        {
            
        }

        
        public async Task<List<Product>> Get()
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            List<Product> itemList = new List<Product>();
            SqlConnection connection = new SqlConnection(connectionString);
            await connection.OpenAsync();
            string query = "SELECT Id,Name,UnitPrice FROM Product ";
            
            using (SqlCommand command = new SqlCommand(query.ToString(), connection))
            {
                using (SqlDataReader dataReader = await command.ExecuteReaderAsync())
                {
                    while (dataReader.Read())
                    {
                        Product item = new Product();
                        item.Id = int.Parse(dataReader[0].ToString());
                        item.Name = dataReader[1].ToString();
                        item.UnitPrice = dataReader[2].ToString();
                        itemList.Add(item);
                    }
                }
            }
            return itemList;
        }
        public async Task<List<Customer>> GetCustomers()
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            List<Customer> itemList = new List<Customer>();
            SqlConnection connection = new SqlConnection(connectionString);
            await connection.OpenAsync();
            string query = "SELECT Id,Name,LastName,Identification,Phone FROM Customer ";

            using (SqlCommand command = new SqlCommand(query.ToString(), connection))
            {
                using (SqlDataReader dataReader = await command.ExecuteReaderAsync())
                {
                    while (dataReader.Read())
                    {
                        Customer item = new Customer();
                        item.Id = int.Parse(dataReader[0].ToString());
                        item.Name = dataReader[1].ToString();
                        item.LastName = dataReader[2].ToString();
                        item.Identification = dataReader[3].ToString();
                        item.Phone = dataReader[4].ToString();
                        itemList.Add(item);
                    }
                }
            }
            return itemList;
        }
        public async Task<List<InvoiceDto>> GetInvoices()
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            List<InvoiceDto> itemList = new List<InvoiceDto>();
            SqlConnection connection = new SqlConnection(connectionString);
            await connection.OpenAsync();
            string query = "SELECT Inv.Id,C.Name,C.LastName FROM SalesHeader Inv INNER JOIN Customer C ON Inv.CustomerId=C.Id  ";

            using (SqlCommand command = new SqlCommand(query.ToString(), connection))
            {
                using (SqlDataReader dataReader = await command.ExecuteReaderAsync())
                {
                    while (dataReader.Read())
                    {
                        InvoiceDto item = new InvoiceDto();
                        item.id = Int32.Parse(dataReader[0].ToString());
                        item.customerName = dataReader[1].ToString()+" "+ dataReader[2].ToString();
                        itemList.Add(item);
                    }
                }
            }
            return itemList;
        }
        public async Task<List<SalesDetailDto>> GetDetails(int invoiceId)
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            List<SalesDetailDto> itemList = new List<SalesDetailDto>();
            SqlConnection connection = new SqlConnection(connectionString);
            await connection.OpenAsync();
            string query = "SELECT P.Name,SD.Quantity,SD.UnitPrice,SD.TotalPrice FROM SalesDetails SD INNER JOIN SalesHeader SH ON SD.SalesHeaderId=SH.Id INNER JOIN Product P ON SD.ProductId=P.Id "
                           +"WHERE SH.Id=@Id";

            using (SqlCommand command = new SqlCommand(query.ToString(), connection))
            {
                command.Parameters.AddWithValue("Id", invoiceId);
                using (SqlDataReader dataReader = await command.ExecuteReaderAsync())
                {
                    while (dataReader.Read())
                    {
                        SalesDetailDto item = new SalesDetailDto();
                        item.Quantity = Int32.Parse(dataReader[1].ToString());
                        item.ProductName = dataReader[0].ToString();
                        item.UnitPrice = Double.Parse(dataReader[1].ToString());
                        item.TotalPrice = Double.Parse(dataReader[2].ToString());
                        itemList.Add(item);
                    }
                }
            }
            return itemList;
        }
        public async Task<int> CreateProduct(Product product)
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            SqlConnection connection = new SqlConnection(connectionString);
           
            await connection.OpenAsync();
            string query = "INSERT  INTO Product (Name,UnitPrice) OUTPUT Inserted.Id VALUES(@Name,@UnitPrice) ";
            int id = 0;
            using (SqlCommand command = new SqlCommand(query.ToString(), connection))
            {
                command.Parameters.AddWithValue("Name", product.Name);
                command.Parameters.AddWithValue("UnitPrice", product.UnitPrice);
                using (SqlDataReader dataReader = await command.ExecuteReaderAsync())
                {
                    while (dataReader.Read())
                    {
                        id = int.Parse(dataReader[0].ToString());
                    }
                }
            }
            return id;
        }
        public async Task<int> CreateCustomer(Customer customer)
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            SqlConnection connection = new SqlConnection(connectionString);

            await connection.OpenAsync();
            string query = "INSERT  INTO Customer (Name,LastName,Identification,Phone) OUTPUT Inserted.Id VALUES(@Name,@LastName,@Identification,@Phone) ";
            int id = 0;
            using (SqlCommand command = new SqlCommand(query.ToString(), connection))
            {
                command.Parameters.AddWithValue("Name", customer.Name);
                command.Parameters.AddWithValue("LastName", customer.LastName);
                command.Parameters.AddWithValue("Identification", customer.Identification);
                command.Parameters.AddWithValue("Phone", customer.Phone);
                using (SqlDataReader dataReader = await command.ExecuteReaderAsync())
                {
                    while (dataReader.Read())
                    {
                        id = int.Parse(dataReader[0].ToString());
                    }
                }
            }
            return id;
        }
        public async Task<int> CreateSalesHeader(InvoiceDto invoice)
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            SqlConnection connection = new SqlConnection(connectionString);

            await connection.OpenAsync();

            string query = "INSERT INTO SalesHeader (CustomerId) OUTPUT Inserted.Id   VALUES (@CustomerId) ";
            int id = 0;
            using (SqlCommand command = new SqlCommand(query.ToString(), connection))
            {
                command.Parameters.AddWithValue("CustomerId", invoice.customerId);
                using (SqlDataReader dataReader = await command.ExecuteReaderAsync())
                {
                    while (dataReader.Read())
                    {
                        id = int.Parse(dataReader[0].ToString());
                    }
                }
            }
            return id;
        }
        public async Task<int> CreateSalesDetails(List<SalesDetail> details,int invoiceId)
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            SqlConnection connection = new SqlConnection(connectionString);
            int id = 0;
            await connection.OpenAsync();
            try
            {
                for (int i = 0; i < details.Count(); i++)
                {
                    string query = "INSERT INTO SalesDetails (ProductId,Quantity,UnitPrice,TotalPrice,SalesHeaderId) OUTPUT Inserted.Id" +
                                   " VALUES (@ProductId,@Quantity,@UnitPrice,@TotalPrice,@SalesHeaderId) ";

                    using (SqlCommand command = new SqlCommand(query.ToString(), connection))
                    {
                        command.Parameters.AddWithValue("ProductId", details.ElementAt(i).ProductId);
                        command.Parameters.AddWithValue("Quantity", details.ElementAt(i).Quantity);
                        command.Parameters.AddWithValue("UnitPrice", details.ElementAt(i).UnitPrice);
                        command.Parameters.AddWithValue("TotalPrice", details.ElementAt(i).TotalPrice);
                        command.Parameters.AddWithValue("SalesHeaderId", invoiceId);
                        using (SqlDataReader dataReader = await command.ExecuteReaderAsync())
                        {
                            while (dataReader.Read())
                            {
                                id = int.Parse(dataReader[0].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {

            }


            return id;
        }
        public async Task<int> UpdateProduct(Product product)
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            SqlConnection connection = new SqlConnection(connectionString);

            await connection.OpenAsync();
            string query = "Update Product SET Name=@Name,UnitPrice=@UnitPrice WHERE Id=@Id";
            int id = 0;
            using (SqlCommand command = new SqlCommand(query.ToString(), connection))
            {
                command.Parameters.AddWithValue("Name", product.Name);
                command.Parameters.AddWithValue("UnitPrice", product.UnitPrice);
                command.Parameters.AddWithValue("Id", product.Id);
                using (SqlDataReader dataReader = await command.ExecuteReaderAsync())
                {
                    while (dataReader.Read())
                    {
                        id = int.Parse(dataReader[0].ToString());
                    }
                }
            }
            return id;
        }
        public async Task<int> UpdateCustomer(Customer customer)
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            SqlConnection connection = new SqlConnection(connectionString);

            await connection.OpenAsync();
            string query = "Update Customer SET Name=@Name,LastName=@LastName,Identification=@Identification,Phone=@Phone WHERE Id=@Id";
            int id = 0;
            using (SqlCommand command = new SqlCommand(query.ToString(), connection))
            {
                command.Parameters.AddWithValue("Id", customer.Id);
                command.Parameters.AddWithValue("Name", customer.Name);
                command.Parameters.AddWithValue("LastName", customer.LastName);
                command.Parameters.AddWithValue("Identification", customer.Identification);
                command.Parameters.AddWithValue("Phone", customer.Phone);
                using (SqlDataReader dataReader = await command.ExecuteReaderAsync())
                {
                    while (dataReader.Read())
                    {
                        id = int.Parse(dataReader[0].ToString());
                    }
                }
            }
            return id;
        }
        public async Task<int> DeleteProduct(int idProduct)
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            SqlConnection connection = new SqlConnection(connectionString);

            await connection.OpenAsync();
            string query = "Delete Product WHERE Id=@Id;                    ";
            int id = 0;
            using (SqlCommand command = new SqlCommand(query.ToString(), connection))
            {
                command.Parameters.AddWithValue("Id", idProduct);
                using (SqlDataReader dataReader = await command.ExecuteReaderAsync())
                {
                    while (dataReader.Read())
                    {
                        id = int.Parse(dataReader[0].ToString());
                    }
                }
            }
            return id;
        }
        public async Task<int> DeleteCustomer(int idCustomer)
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            SqlConnection connection = new SqlConnection(connectionString);

            await connection.OpenAsync();
            string query = "Delete Customer WHERE Id=@Id;                    ";
            int id = 0;
            using (SqlCommand command = new SqlCommand(query.ToString(), connection))
            {
                command.Parameters.AddWithValue("Id", idCustomer);
                using (SqlDataReader dataReader = await command.ExecuteReaderAsync())
                {
                    while (dataReader.Read())
                    {
                        id = int.Parse(dataReader[0].ToString());
                    }
                }
            }
            return id;
        }

    }
}
