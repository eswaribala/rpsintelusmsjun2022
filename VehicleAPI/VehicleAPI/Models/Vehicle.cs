using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleAPI.Models
{
    public enum FuelType { PETROL, DIESEL,GAS}
    [Table("Vehicle")]
    public class Vehicle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Engine_No" )]
        public long EngineNo { get; set; }
        [Column("Rgistration_No")]
        [Required]
        public string? RegistrationNo { get; set; }
        public Maker? Maker { get; set; }
        [DataType(DataType.Date)]
        [Column("DOR")]
        public DateTime DOR { get; set; }
        [Column("Chassis_No")]
        public string? ChassisNo { get; set; }
        
        [Column("Fuel_Type")]
        public FuelType FuelType { get; set; }
        [Column("Color")]
        public string? Color { get; set; }
    }
}
