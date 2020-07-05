namespace BokuNoHeroAcademia.Models
{
    public enum Nota
    {
        A, B, C, D, F
    }

    public class Inscricao
    {
        public int InscricaoId { get; set; }
        public int CursoId { get; set; }
        public int EstudanteId { get; set; }

        public Nota? Nota { get; set; }

        public Curso Curso { get; set; }
        public Estudante Estudante { get; set; }
    }
}