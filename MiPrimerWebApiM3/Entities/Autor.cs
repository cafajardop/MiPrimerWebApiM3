using MiPrimerWebApiM3.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiPrimerWebApiM3.Entities
{
    public class Autor
    {
        public int Id { get; set; }
        [Required]
        [PrimeraLetraMayuscula]
        [StringLength(10, MinimumLength = (1), ErrorMessage = "El campo Nombre debe tener {1} caracteres no menos")]
        public string Nombre { get; set; }
        //[Range(18, 120)]//La edad debe ser entre 18 y 120
        //public int Edad { get; set; }
        //[CreditCard]
        //public string CreditCard { get; set; }
        ////[Url]
        //public string Url { get; set; }

        //Validacion por modelo
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!string.IsNullOrEmpty(Nombre))
            {
                var primeraLetra = Nombre[0].ToString();
                if (primeraLetra != primeraLetra.ToUpper())
                    yield return new ValidationResult("La primera letra debe ser mayúscula", new string[] { nameof(Nombre) });
            }

        }

        public List<Libro> Libros { get; set; }

    }
}
