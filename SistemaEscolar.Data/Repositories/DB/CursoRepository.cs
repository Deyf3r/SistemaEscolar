using Sistema_Escolar.Data.Entities;

namespace Sistema_Escolar.Data.Interfaces
{
    public interface CursoRepository
    {
        void Agregar(Cursos curso);
        void Actualizar(Cursos curso);
        void Remover(Cursos curso);
        List<Cursos> TraerTodos();

        Cursos ObtenerPorId(int CursoId);
    }
}
