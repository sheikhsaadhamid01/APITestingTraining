using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace GraphQLProductApp.Data;

public class Product
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    
    public int Price { get; set; }
    
    [System.ComponentModel.DefaultValue(typeof(DateTime), "")]
    public DateTime UserCreatedDate { get; set; }
    
    [System.ComponentModel.DefaultValue(typeof(DateTime), "")]
    public DateTime SystemCreatedDate { get; set; }
    
    public ICollection<Components> Components { get; set; }

    public ProductType ProductType { get; set; }
}

public enum ProductType
{
    CPU,
    MONITOR,
    PERIPHARALS,
    EXTERNAL,
    PROCESSOR,
    MEMORY
}