
using System.Collections.Generic;

namespace Coloviu.Models
{
    public enum TipProfesor
    {
        Standard,
        Laborant
    }

    public class Profesor
    {
        public int ProfesorId { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public TipProfesor Tip { get; set; }

        public virtual ICollection<AsignareMaterie> AsignariMaterii { get; set; }
    }
}
