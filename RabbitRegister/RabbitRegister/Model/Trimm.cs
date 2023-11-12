using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RabbitRegister.Model
{
    public class Trimm
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TrimmingId { get; set; }

        [ForeignKey("Rabbit")]
        [Column(Order = 0)]
        public int RabbitRegNo { get; set; }
        [ForeignKey("Rabbit")]
        [Column(Order = 1)]
        public int OriginRegNo { get; set; }

        public Rabbit Rabbit { get; set; }

        [Required(ErrorMessage = "Der skal angives en Dato")]
        public DateTime Date { get; set; }

        [Range(1, 300, ErrorMessage = "Tid skal være mellem 1 og 300 minutter")]
        public int? TimeUsed { get; set; }

        [Range(1, 15, ErrorMessage = "Hårlængden skal være mellem 1 og 15")]
        public float? HairLengthByDayNinety { get; set; }

        [Range(1, 20, ErrorMessage = "Uld tætheden skal være mellem 1 og 20")]
        public float? WoolDensity { get; set; }

        [Required(ErrorMessage = "Vægten skal være mellem 0 og 1000")]
        [Range(0, 1000, ErrorMessage = "Vægten skal være mellem 0 og 1000")]
        public int FirstSortmentWeight { get; set; }

        [Required(ErrorMessage = "Vægten skal være mellem 0 og 1000")]
        [Range(0, 1000, ErrorMessage = "Vægten skal være mellem 0 og 1000")]
        public int SecondSortmentWeight { get; set; }

        [Required(ErrorMessage = "Vægten skal være mellem 0 og 1000")]
        [Range(0, 1000, ErrorMessage = "Vægten skal være mellem 0 og 1000")]
        public int DisposableWoolWeight { get; set; }
    }
}
