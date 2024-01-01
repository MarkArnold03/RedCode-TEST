using System;
using Microsoft.EntityFrameworkCore;
using RedCode_Test.Models;

namespace RedCode_Test.Data
{
    public class DataInitializer
    {
        private readonly ApplicationDbContext _dbContext;

        public DataInitializer(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void MigrateData()
        {
            _dbContext.Database.Migrate();
            SeedData();
            _dbContext.SaveChanges();

        }
        private void SeedData()
        {
            if (!_dbContext.Books
            .Any(e => e.Title == "Harry Potter"))
            {
                _dbContext.Add(new Book
                {
                    Title = "Harry Potter",
                    Writer = "J.K. Rowling",
                    PublishDate = new DateTime(1997, 6, 26)

                });
            }
            if (!_dbContext.Books
            .Any(e => e.Title == "The Lord of the Rings"))
            {
                _dbContext.Add(new Book
                {
                    Title = "The Lord of the Rings",
                    Writer = "J.R.R. Tolkien",
                    PublishDate = new DateTime(1954, 7, 29)

                });
            }

            if (!_dbContext.Books
            .Any(e => e.Title == "The Autobiography of Malcolm X"))
            {
                _dbContext.Add(new Book
                {
                    Title = "The Autobiography of Malcolm X",
                    Writer = "Malcolm X",
                    PublishDate = new DateTime(1965, 10, 29)

                });
            }
        }
    }
}

