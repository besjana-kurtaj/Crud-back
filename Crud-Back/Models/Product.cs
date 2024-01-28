using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crud_Back.Models
{
    public class Product
    {        
        public string? Id { get; set; }
        public string? Name { get; set; }
        public int? Price { get; set; }
       
    }
}
