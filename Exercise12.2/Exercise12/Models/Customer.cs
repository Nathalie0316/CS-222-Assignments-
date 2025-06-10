using System.ComponentModel.DataAnnotations;

namespace Exercise02.Models;

public class Customer
{
    [Key]
    public string CustomerID { get; set; }
    public string CompanyName { get; set; }
    public string City { get; set; }
}
