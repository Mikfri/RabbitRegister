using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RabbitRegister.Model
{
    public class TrimmDTO
    {

        public int RabbitRegNo { get; set; }
        public int OriginRegNo { get; set; }

        [Required(ErrorMessage = "Der skal angives en Dato")]
        public DateTime Date { get; set; }

        [Display(Name = "Klippetid/min")]
        [Range(1, 300, ErrorMessage = "Tid skal være mellem 1 og 300 minutter")]
        public int? TimeUsed { get; set; }

        [Display(Name = "Hårlængde (dag:90)")]
        [Range(1, 15, ErrorMessage = "Hårlængden skal være mellem 1 og 15")]
        public float? HairLengthByDayNinety { get; set; }

        [Display(Name = "Uldtæthed")]
        [Range(1, 20, ErrorMessage = "Uld tætheden skal være mellem 1 og 20")]
        public float? WoolDensity { get; set; }

        [Display(Name = "1'ste sortering/g")]
        [Required(ErrorMessage = "Angiv mængde i gram")]
        [Range(0, 1000, ErrorMessage = "Vægten skal være mellem 0 og 1000g")]
        public int FirstSortmentWeight { get; set; }

        [Display(Name = "2'den sortering/g")]
        [Required(ErrorMessage = "Vægten skal være mellem 0 og 1000")]
        [Range(0, 1000, ErrorMessage = "Vægten skal være mellem 0 og 1000")]
        public int SecondSortmentWeight { get; set; }

        [Display(Name = "Spild-uld/g")]
        [Required(ErrorMessage = "Angiv mængde i gram")]
        [Range(0, 1000, ErrorMessage = "Vægten skal være mellem 0 og 1000g")]
        public int DisposableWoolWeight { get; set; }

    }
}
