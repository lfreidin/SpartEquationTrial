using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SparkEquation.Trial.WebAPI.Data.Models;

namespace SparkEquation.Trial.WebAPI.Data
{
    public partial class MainDbContext
    {
        protected void SeedData(ModelBuilder modelBuilder)
        {
            SeedBrands(modelBuilder);
            SeedCategories(modelBuilder);
            SeedProducts(modelBuilder);
            SeedProductCategories(modelBuilder);
        }

        protected void SeedProductCategories(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryProduct>().HasData(new[]
            {
                new CategoryProduct
                {
                    CategoryId = 1,
                    ProductId = 1
                },
                new CategoryProduct
                {
                    CategoryId = 1,
                    ProductId = 2
                },
                new CategoryProduct
                {
                    CategoryId = 1,
                    ProductId = 3
                },
                new CategoryProduct
                {
                    CategoryId = 1,
                    ProductId = 4
                },
                new CategoryProduct
                {
                    CategoryId = 1,
                    ProductId = 5
                },
                new CategoryProduct
                {
                    CategoryId = 1,
                    ProductId = 6
                },
                new CategoryProduct
                {
                    CategoryId = 1,
                    ProductId = 7
                },
                new CategoryProduct
                {
                    CategoryId = 1,
                    ProductId = 8
                },
                new CategoryProduct
                {
                    CategoryId = 1,
                    ProductId = 9
                },
                new CategoryProduct
                {
                    CategoryId = 1,
                    ProductId = 10
                },
                new CategoryProduct
                {
                    CategoryId = 1,
                    ProductId = 11
                },
                new CategoryProduct
                {
                    CategoryId = 1,
                    ProductId = 12
                },
                new CategoryProduct
                {
                    CategoryId = 1,
                    ProductId = 13
                },
                
                new CategoryProduct
                {
                    CategoryId = 2,
                    ProductId = 1
                },
                new CategoryProduct
                {
                    CategoryId = 2,
                    ProductId = 2
                },
                new CategoryProduct
                {
                    CategoryId = 2,
                    ProductId = 9
                },
                new CategoryProduct
                {
                    CategoryId = 2,
                    ProductId = 10
                },
                
                new CategoryProduct
                {
                    CategoryId = 3,
                    ProductId = 3
                },
                new CategoryProduct
                {
                    CategoryId = 3,
                    ProductId = 4
                },
                new CategoryProduct
                {
                    CategoryId = 3,
                    ProductId = 5
                },
                new CategoryProduct
                {
                    CategoryId = 3,
                    ProductId = 6
                },
                new CategoryProduct
                {
                    CategoryId = 3,
                    ProductId = 7
                },
                new CategoryProduct
                {
                    CategoryId = 3,
                    ProductId = 8
                },
                new CategoryProduct
                {
                    CategoryId = 3,
                    ProductId = 9
                },
                new CategoryProduct
                {
                    CategoryId = 3,
                    ProductId = 10
                },
                new CategoryProduct
                {
                    CategoryId = 3,
                    ProductId = 12
                },
                
                new CategoryProduct
                {
                    CategoryId = 4,
                    ProductId = 14
                },
                new CategoryProduct
                {
                    CategoryId = 4,
                    ProductId = 15
                },
                new CategoryProduct
                {
                    CategoryId = 4,
                    ProductId = 16
                },
                new CategoryProduct
                {
                    CategoryId = 4,
                    ProductId = 17
                },
                new CategoryProduct
                {
                    CategoryId = 4,
                    ProductId = 18
                },
                new CategoryProduct
                {
                    CategoryId = 4,
                    ProductId = 19
                },
                new CategoryProduct
                {
                    CategoryId = 4,
                    ProductId = 20
                },
                new CategoryProduct
                {
                    CategoryId = 4,
                    ProductId = 21
                },
                new CategoryProduct
                {
                    CategoryId = 4,
                    ProductId = 22
                },
                new CategoryProduct
                {
                    CategoryId = 4,
                    ProductId = 23
                },
                new CategoryProduct
                {
                    CategoryId = 4,
                    ProductId = 24
                },
                new CategoryProduct
                {
                    CategoryId = 4,
                    ProductId = 25
                },
                new CategoryProduct
                {
                    CategoryId = 4,
                    ProductId = 26
                },
                new CategoryProduct
                {
                    CategoryId = 4,
                    ProductId = 27
                },
                new CategoryProduct
                {
                    CategoryId = 4,
                    ProductId = 28
                },
                
                new CategoryProduct
                {
                    CategoryId = 5,
                    ProductId = 14
                },
                new CategoryProduct
                {
                    CategoryId = 5,
                    ProductId = 21
                },
                new CategoryProduct
                {
                    CategoryId = 5,
                    ProductId = 23
                },
                new CategoryProduct
                {
                    CategoryId = 5,
                    ProductId = 26
                }
            });
        }

        protected void SeedProducts(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new[]
            {
                new Product
                {
                    Id = 1,
                    Name = "La Vieille Ferme Rouge",
                    Rating = 5,
                    BrandId = 4,
                    ExpirationDate = DateTime.Now.AddYears(10)
                },
                new Product
                {
                    Id = 2,
                    Name = "J.P. Chenet Pays D'Oc Cabernet - Syrah",
                    Rating = 4.9,
                    BrandId = 4,
                    ExpirationDate = DateTime.Now.AddYears(10)
                },
                new Product
                {
                    Id = 3,
                    Name = "Essentuki 4",
                    Rating = 4.5,
                    BrandId = 5,
                    ExpirationDate = DateTime.Now.AddYears(1)
                },
                new Product
                {
                    Id = 4,
                    Name = "Essentuki 17",
                    Rating = 4.5,
                    BrandId = 5,
                    ExpirationDate = DateTime.Now.AddYears(1)
                },
                new Product
                {
                    Id = 5,
                    Name = "Fanta",
                    Rating = 4.0,
                    BrandId = 2,
                    ExpirationDate = DateTime.Now.AddYears(4)
                },
                new Product
                {
                    Id = 6,
                    Name = "Coca Cola",
                    Rating = 4.0,
                    BrandId = 2,
                    ExpirationDate = DateTime.Now.AddYears(4)
                },
                new Product
                {
                    Id = 7,
                    Name = "Sprite",
                    Rating = 4.0,
                    BrandId = 2,
                    ExpirationDate = DateTime.Now.AddYears(4)
                },
                new Product
                {
                    Id = 8,
                    Name = "Pepsi",
                    Rating = 4.0,
                    BrandId = 1,
                    ExpirationDate = DateTime.Now.AddYears(4)
                },
                new Product
                {
                    Id = 9,
                    Name = "Budweiser",
                    Rating = 4.0,
                    BrandId = 3
                },
                new Product
                {
                    Id = 10,
                    Name = "Budweiser 66",
                    Rating = 4.0,
                    BrandId = 3
                },
                new Product
                {
                    Id = 11,
                    Name = "Simply",
                    Rating = 3.0,
                    BrandId = 2
                },
                new Product
                {
                    Id = 12,
                    Name = "Surge",
                    Rating = 3.6,
                    BrandId = 2
                },
                new Product
                {
                    Id = 13,
                    Name = "Zico",
                    Rating = 4.6,
                    BrandId = 2
                },
                new Product
                {
                    Id = 14,
                    Name = "Niva",
                    Rating = 3.5,
                    BrandId = 6
                },
                new Product
                {
                    Id = 15,
                    Name = "1200/1300",
                    Rating = 1.5,
                    BrandId = 6
                },
                new Product
                {
                    Id = 16,
                    Name = "1500",
                    Rating = 1.8,
                    BrandId = 6
                },
                new Product
                {
                    Id = 17,
                    Name = "1600",
                    Rating = 2,
                    BrandId = 6
                },
                new Product
                {
                    Id = 18,
                    Name = "Oka",
                    Rating = 1,
                    BrandId = 6
                },
                new Product
                {
                    Id = 19,
                    Name = "Kalina",
                    Rating = 3,
                    BrandId = 6
                },
                new Product
                {
                    Id = 20,
                    Name = "Granta",
                    Rating = 3.2,
                    BrandId = 6
                },
                new Product
                {
                    Id = 21,
                    Name = "Taiga",
                    Rating = 3.8,
                    BrandId = 6
                },
                new Product
                {
                    Id = 22,
                    Name = "Priora",
                    Rating = 3.2,
                    BrandId = 6
                },
                new Product
                {
                    Id = 23,
                    Name = "Tahoe",
                    Rating = 4.2,
                    BrandId = 7
                },
                new Product
                {
                    Id = 24,
                    Name = "Camaro",
                    Rating = 4.9,
                    BrandId = 7
                },
                new Product
                {
                    Id = 25,
                    Name = "Corvette",
                    Rating = 4.9,
                    BrandId = 7
                },
                new Product
                {
                    Id = 26,
                    Name = "Land Cruiser",
                    Rating = 4.9,
                    BrandId = 8
                },
                new Product
                {
                    Id = 27,
                    Name = "Prius",
                    Rating = 4,
                    BrandId = 8
                },
                new Product
                {
                    Id = 28,
                    Name = "Maxima",
                    Rating = 4,
                    BrandId = 9
                },
                new Product
                {
                    Id = 29,
                    Name = "Cube",
                    Rating = 4.5,
                    BrandId = 9
                }
            });
        }

        protected void SeedCategories(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(new[]
            {
                new Category
                {
                    Id = 1,
                    Name = "Drinks"
                },
                new Category
                {
                    Id = 2,
                    Name = "Alcohol"
                },
                new Category
                {
                    Id = 3,
                    Name = "Sparkling"
                },
                new Category
                {
                    Id = 4,
                    Name = "Cars"
                },
                new Category
                {
                    Id = 5,
                    Name = "4x4"
                },
            });
        }

        protected void SeedBrands(ModelBuilder modelBuilder)
        {       
            modelBuilder.Entity<Brand>().HasData(new[]
            {
                new Brand
                {
                    Id = 1,
                    Country = "USA",
                    Name = "Pepsi"
                },
                new Brand
                {
                    Id = 2,
                    Country = "USA",
                    Name = "Coca Cola"
                },
                new Brand
                {
                    Id = 3,
                    Country = "USA",
                    Name = "Bud"
                },
                new Brand
                {
                    Id = 4,
                    Country = "France",
                    Name = "Bordeaux"
                },
                new Brand
                {
                    Id = 5,
                    Country = "Russia",
                    Name = "Essentuki"
                },
                new Brand
                {
                    Id = 6,
                    Country = "Russia",
                    Name = "Lada"
                },
                new Brand
                {
                    Id = 7,
                    Country = "USA",
                    Name = "Chevrolet"
                },
                new Brand
                {
                    Id = 8,
                    Country = "Japan",
                    Name = "Toyota"
                },
                new Brand
                {
                    Id = 9,
                    Country = "Japan",
                    Name = "Nissan"
                }
            });
        }
    }
}