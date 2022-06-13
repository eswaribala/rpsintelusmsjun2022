using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CQRSNET6Demo.Models
{
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long CustomerId { get; set; }
        public string CustomerName { get; set; }
        public long MobileNo { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public ICollection<Invoice> InvoiceList { get; set; }

    }
}
