using System;
using System.Collections.Generic;
using System.Text;
using EstacoesDaCidade.Dominio.Interfaces;
using EstacoesDaCidade.Infra.Dados.Config;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EstacoesDaCidade.Infra.Dados.Repositorio
{
    public class RepositorioBase<T> : IBase<T>, IDisposable where T : class
    {
        private readonly DbContextOptions<EstacoesDaCidadeDbContext> _optionsBuilder;

        public RepositorioBase()
        {
            _optionsBuilder = new DbContextOptions<EstacoesDaCidadeDbContext>();
        }

        public void Adicionar(T obj)
        {
            using (var db = new EstacoesDaCidadeDbContext(_optionsBuilder))
            {
                db.Set<T>().Add(obj);
                db.SaveChanges();
            }
        }

        public T RecuperarPorId(Guid id)
        {
            using (var db = new EstacoesDaCidadeDbContext(_optionsBuilder))
            {
                return db.Set<T>().Find(id);
            }
        }

        public void Atualizar(T obj)
        {
            using (var db = new EstacoesDaCidadeDbContext(_optionsBuilder))
            {
                db.Set<T>().Update(obj);
                db.SaveChanges();
            }
        }

        public void Excluir(T obj)
        {
            using (var db = new EstacoesDaCidadeDbContext(_optionsBuilder))
            {
                db.Set<T>().Remove(obj);
                db.SaveChanges();
            }
        }

        public IList<T> Listar()
        {
            using (var db = new EstacoesDaCidadeDbContext(_optionsBuilder))
            {
                return db.Set<T>().AsNoTracking().ToList();
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
