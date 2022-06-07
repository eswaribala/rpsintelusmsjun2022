using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleAPI.Models
{
    [Owned]
    public class Maker
    {
        [Column("Brand_Name")]
        public string? BrandName { get; set; }
        [Column("Model_No")]
        public string? ModelNo { get; set; }
    }
}
