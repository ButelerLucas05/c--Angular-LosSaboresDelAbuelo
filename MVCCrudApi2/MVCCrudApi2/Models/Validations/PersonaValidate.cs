using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCCrudApi2.Models
{
    // Asi se relacionan las reglas con la entidad de EF
    [MetadataType(typeof(persona.MetaData))]
    public partial class persona
    {
        
        // Creamos una clase sellada para las validaciones

        sealed class MetaData
        {
            [Required]
            public string name;
            [Required]
            public string surname;

        }
    }
}