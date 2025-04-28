namespace Parcial_1__Programacion.Models
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public int Edad { get; set; }

        public int IdObrasocial { get; set; }
        public Obrasocial? obra { get; set; }
    }
}
