namespace BokuNoHeroAcademia.Models
{
    public class CursoAtribuido
    {
        public int ProfessorID { get; set; }
        public int CursoID { get; set; }
        public Professor Professor { get; set; }
        public Curso Curso { get; set; }
    }
}