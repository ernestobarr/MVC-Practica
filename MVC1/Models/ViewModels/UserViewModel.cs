using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//Necesitamos anotaciones agregamos
using System.ComponentModel.DataAnnotations;

namespace MVC1.Models.ViewModels
{
    public class UserViewModel
    {
        [Required]
        [EmailAddress]
        [StringLength(100, ErrorMessage = "El {0} debe tener al menos {1}", MinimumLength =1 )]
        [Display(Name = "Correo Electrónico")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirmar contraseña")]
        [Compare("Password", ErrorMessage ="Las contraseñas no son iguales")]
        public string ConfirmPassword { get; set; }
        [Required]
        public int Edad { get; set; }
        //Telefonos, fechas son tipos de anotaciones 



    }

    public class EditUserViewModel
    {
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100, ErrorMessage = "El {0} debe tener al menos {1}", MinimumLength = 1)]
        [Display(Name = "Correo Electrónico")]
        public string Email { get; set; }
        
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirmar contraseña")]
        [Compare("Password", ErrorMessage = "Las contraseñas no son iguales")]
        public string ConfirmPassword { get; set; }
        [Required]
        public int Edad { get; set; }
        //Telefonos, fechas son tipos de anotaciones 



    }

}