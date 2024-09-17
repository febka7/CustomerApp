using Microsoft.EntityFrameworkCore;

namespace CustomerAPI.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
               new Customer { Id = 1, FirstName = "John", LastName="Test", Email="John.Test@abc.com", Phone="07771111111", Address="1 New Lane, Birmingham" },
               new Customer { Id = 2, FirstName = "Laura", LastName = "Test", Email = "Laura.Test@abc.com", Phone = "07772222222", Address = "2 New Lane, Birmingham" },
               new Customer { Id = 3, FirstName = "James", LastName = "Test", Email = "James.Test@abc.com", Phone = "07773333333", Address = "3 New Lane, Birmingham" },
               new Customer { Id = 4, FirstName = "Tony", LastName = "Test", Email = "Tony.Test@abc.com", Phone = "07774444444", Address = "4 New Lane, Birmingham" },
               new Customer { Id = 5, FirstName = "Becky", LastName = "Test", Email = "Becky.Test@abc.com", Phone = "07775555555" ,Address = "5 New Lane, Birmingham" });
        }
        }
}
