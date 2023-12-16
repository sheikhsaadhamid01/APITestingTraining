using System.Collections.Generic;

namespace GraphQLProductApp.Data;

public class Manufacturers
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Product Product { get; set; }
    
    public int ComponentsId { get; set; }
    public ICollection<Address> Addresses { get; set; }
}
