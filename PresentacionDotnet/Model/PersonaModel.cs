using Entidad;



    public class PersonaInputModel
    {
        public int Identificacion { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
    }

    public class PersonaViewModel : PersonaInputModel
    {
       
        public PersonaViewModel(Persona persona)
        {
            Identificacion = persona.Identificacion;
            Nombre = persona.Nombre;
            Edad = persona.Edad;
        }
      
    }
