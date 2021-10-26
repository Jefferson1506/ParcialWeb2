using System.ComponentModel.DataAnnotations;
using Entidad;



    public class PersonaInputModel
    {
        [Key]
        public int Identificacion { get; set; }
        public string tipoIdentificacion { get; set; }
        
        
    }

    public class PersonaViewModel : PersonaInputModel
    {
       
        public PersonaViewModel(Persona persona)
        {
            Identificacion = persona.Identificacion;
            tipoIdentificacion  = persona.tipoIdentificacion ;
        }
      
    }
