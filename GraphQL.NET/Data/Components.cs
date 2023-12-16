using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQLProductApp.Data;

public class Components
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int? ProductId { get; set; }
    public Product Product { get; set; }
    
    [System.ComponentModel.DefaultValue(typeof(DateTime), "")]
    public DateTime UserCreatedDate { get; set; }
    
    [System.ComponentModel.DefaultValue(typeof(DateTime), "")]
    public DateTime SystemCreatedDate { get; set; }
    
    public ICollection<Manufacturers> Manufacturers { get; set; }
}