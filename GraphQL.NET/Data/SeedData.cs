using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphQLProductApp.Data;

public static class SeedData
{
    public static void Seed(this ProductDbContext productDbContext)
    {
        var products = new List<Product>
        {
            new()
            {
                Name = "Keyboard",
                Description = "Gaming Keyboard with lights",
                Price = 150,
                ProductType = ProductType.PERIPHARALS,
                SystemCreatedDate = DateTime.Now,
                UserCreatedDate = DateTime.Now,
                Components = new List<Components>(),
            },
            new()
            {
                Name = "Monitor",
                Description = "HD monitor",
                Price = 400,
                ProductType = ProductType.MONITOR,
                SystemCreatedDate = DateTime.Now,
                UserCreatedDate = DateTime.Now,
                Components = new List<Components>()
            },
            new()
            {
                Name = "Mouse",
                Description = "Gaming Mouse",
                Price = 50,
                ProductType = ProductType.PERIPHARALS,
                SystemCreatedDate = DateTime.Now,
                UserCreatedDate = DateTime.Now,
                Components = new List<Components>(),
            },
            new()
            {
                Name = "CPU",
                Description = "Intel Core i7",
                Price = 500,
                ProductType = ProductType.PROCESSOR,
                SystemCreatedDate = DateTime.Now,
                UserCreatedDate = DateTime.Now,
                Components = new List<Components>(),
            },
            new()
            {
                Name = "RAM",
                Description = "16GB",
                Price = 100,
                ProductType = ProductType.MEMORY,
                SystemCreatedDate = DateTime.Now,
                UserCreatedDate = DateTime.Now,
                Components = new List<Components>(),
            }
        };
        
        productDbContext.Products.AddRange(products);
        productDbContext.SaveChanges();

        var components = new List<Components>
        {
            new()
            {
                Name = "Keys",
                Description = "Glowing Keys",
                Product = products.FirstOrDefault(p => p.ProductId == 1),
                SystemCreatedDate = DateTime.Now,
                UserCreatedDate = DateTime.Now,
                Manufacturers = new List<Manufacturers>()
                {
                    new()
                    {
                        Name = "Foxconn",
                        Description = "supplier of keyboards",
                        Product = products.FirstOrDefault(p => p.ProductId == 1),
                        Addresses = new List<Address>
                        {
                            new()
                            {
                                Country = "Italy",
                                City = "Fr",
                                Street = "New place",
                                State = "LI"
                            },
                            new()
                            {
                                Country = "Germany",
                                City = "Berlin",
                                Street = "Main Street",
                                State = "KI"
                            }
                         
                        }
                    },
                }
            },
            new()
            {
                Name = "Stickers",
                Description = "Key stickers",
                Product = products.FirstOrDefault(p => p.ProductId == 1),
                SystemCreatedDate = DateTime.Now,
                UserCreatedDate = DateTime.Now,
                Manufacturers = new List<Manufacturers>()
                {
                    new()
                    {
                        Name = "Foxconn",
                        Description = "supplier of keyboards",
                        Product = products.FirstOrDefault(p => p.ProductId == 1),
                        Addresses = new List<Address>
                        {
                            new()
                            {
                                Country = "Germany",
                                City = "Berlin",
                                Street = "Main Street",
                                State = "KI"
                            },
                            new()
                            {
                                Country = "Italy",
                                City = "Fr",
                                Street = "New place",
                                State = "LI"
                            }
                        }
                    }
                }
            },
            new()
            {
                Name = "Power cord",
                Description = "Power cables",
                Product = products.FirstOrDefault(p => p.ProductId == 1),
                SystemCreatedDate = DateTime.Now,
                UserCreatedDate = DateTime.Now,
                Manufacturers = new List<Manufacturers>()
                {
                    new()
                    {
                        Name = "Finolex",
                        Description = "supplier of power cables",
                        Product = products.FirstOrDefault(p => p.ProductId == 1),
                        Addresses = new List<Address>
                        {
                            new()
                            {
                                Country = "India",
                                City = "Delhi",
                                Street = "Main Street",
                                State = "UP"
                            },
                            new()
                            {
                                Country = "India",
                                City = "Chennai",
                                Street = "Ritchi street",
                                State = "TN"
                            }
                        }
                    }
                }
            },
            new()
            {
                Name = "Monitor Cover",
                Description = "Monitor Cover",
                Product = products.FirstOrDefault(p => p.ProductId == 2),
                SystemCreatedDate = DateTime.Now,
                UserCreatedDate = DateTime.Now,
                Manufacturers = new List<Manufacturers>()
                {
                    new()
                    {
                        Name = "Foxconn",
                        Description = "supplier of keyboards",
                        Product = products.FirstOrDefault(p => p.ProductId == 2),
                        Addresses = new List<Address>
                        {
                            new()
                            {
                                Country = "Germany",
                                City = "Berlin",
                                Street = "Main Street",
                                State = "KI"
                            },
                            new()
                            {
                                Country = "Italy",
                                City = "Fr",
                                Street = "New place",
                                State = "LI"
                            }
                        }
                    }
                }
            },
            new()
            {
                Name = "Power cord",
                Description = "Power cables",
                Product = products.FirstOrDefault(p => p.ProductId == 2),
                SystemCreatedDate = DateTime.Now,
                UserCreatedDate = DateTime.Now,
                Manufacturers = new List<Manufacturers>()
                {
                    new()
                    {
                        Name = "Finolex",
                        Description = "supplier of power cables",
                        Product = products.FirstOrDefault(p => p.ProductId == 2),
                        Addresses = new List<Address>
                        {
                            new()
                            {
                                Country = "India",
                                City = "Delhi",
                                Street = "Main Street",
                                State = "UP"
                            },
                            new()
                            {
                                Country = "India",
                                City = "Chennai",
                                Street = "Ritchi street",
                                State = "TN"
                            }
                        }
                    }
                }
            },
            new()
            {
                Name = "Mouse Pad",
                Description = "Mouse Pad high quality",
                Product = products.FirstOrDefault(p => p.ProductId == 3),
                SystemCreatedDate = DateTime.Now,
                UserCreatedDate = DateTime.Now,
                Manufacturers = new List<Manufacturers>()
                { 
                    new()
                    {
                        Name = "Flextronics",
                        Description = "supplier of Mouse",
                        Product = products.FirstOrDefault(p => p.ProductId == 3),
                        Addresses = new List<Address>
                        {
                            new()
                            {
                                Country = "India",
                                City = "Chennai",
                                Street = "Sholinganallore",
                                State = "TN"
                            },
                            new()
                            {
                                Country = "China",
                                City = "Beijing",
                                Street = "Xi Lu Streets",
                                State = "CH"
                            }
                        }
                    }
                }
            },
            new()
            {
                Name = "Mouse Dust cover",
                Description = "Mouse dust cover high quality",
                Product = products.FirstOrDefault(p => p.ProductId == 4),
                SystemCreatedDate = DateTime.Now,
                UserCreatedDate = DateTime.Now,
                Manufacturers = new List<Manufacturers>()
                {
                    new()
                    {
                        Name = "Syntel",
                        Description = "supplier of Monitors",
                        Product = products.FirstOrDefault(p => p.ProductId == 4),
                        Addresses = new List<Address>
                        {
                            new()
                            {
                                Country = "Germany",
                                City = "Berlin",
                                Street = "Main Street",
                                State = "KI"
                            },
                            new()
                            {
                                Country = "Italy",
                                City = "Fr",
                                Street = "New place",
                                State = "LI"
                            }
                        }
                    }
                }
            },
            new()
            {
                Name = "Thermal Paste",
                Description = "Thermal",
                Product = products.FirstOrDefault(p => p.ProductId == 4),
                SystemCreatedDate = DateTime.Now,
                UserCreatedDate = DateTime.Now,
            },
            new()
            {
                Name = "Thermal Fan",
                Description = "Thermal Fan",
                Product = products.FirstOrDefault(p => p.ProductId == 4),
                SystemCreatedDate = DateTime.Now,
                UserCreatedDate = DateTime.Now,
            },
            new()
            {
                Name = "RAM Heat Sink",
                Description = "RAM heat sink with fan",
                Product = products.FirstOrDefault(p => p.ProductId == 5),
                SystemCreatedDate = DateTime.Now,
                UserCreatedDate = DateTime.Now,
            }
        };
        
        productDbContext.Components.AddRange(components);
        productDbContext.SaveChanges();
    }
}