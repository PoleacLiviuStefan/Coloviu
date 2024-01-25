// Materie.cs
using System.Collections.Generic;

namespace Coloviu.Models
{
    public class Materie
    {
        public int MaterieId { get; set; }
        public string Nume { get; set; }
        public string Descriere { get; set; }

        public virtual ICollection<AsignareMaterie> AsignariMaterii { get; set; }
    }
}
