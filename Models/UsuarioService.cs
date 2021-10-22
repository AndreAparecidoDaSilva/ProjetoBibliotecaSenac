using System.Linq;
using System.Collections.Generic;
namespace Biblioteca.Models
{
    public class UsuarioService
    {
        public void Inserir(Usuario u)
        {
            using (BibliotecaContext bc = new BibliotecaContext())
            {
                bc.Usuarios.Add(u);
                bc.SaveChanges();
            }
        }
        public void Atualizar(Usuario u)
        {
            using (BibliotecaContext bc = new BibliotecaContext())
            {
                Usuario usuario = bc.Usuarios.Find(u.Id);
                usuario.Nome = u.Nome;
                usuario.Login = u.Login;
                usuario.Senha = u.Senha;
                bc.SaveChanges();
            }
        }
        public ICollection<Usuario> ListarTodos()
        {
            using (BibliotecaContext bc = new BibliotecaContext())
            {
                IQueryable<Usuario> query;

                query = bc.Usuarios;

                return query.ToList();
            }
        }
        public void Exclui(Usuario u)
        {
            using (BibliotecaContext bc = new BibliotecaContext())
            {
                bc.Usuarios.Remove(u);
                bc.SaveChanges();
            }
        }
        public Usuario ObterPorId(int Id)
        {
            using (BibliotecaContext bc = new BibliotecaContext())
            {
                return bc.Usuarios.Find(Id);
            }
        }
    }
}