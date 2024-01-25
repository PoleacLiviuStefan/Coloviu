// AsignareMaterie.cs
namespace Coloviu.Models
{
    public class AsignareMaterie
    {
        public int ProfesorId { get; set; }
        public Profesor Profesor { get; set; }

        public int MaterieId { get; set; }
        public Materie Materie { get; set; }
    }
}
