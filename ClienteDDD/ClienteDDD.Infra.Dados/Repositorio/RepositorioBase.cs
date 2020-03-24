using ClienteDDD.Dominio.Interfaces;
using ClienteDDD.Infra.Dados.Config;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClienteDDD.Infra.Dados.Repositorio
{
    public class RepositorioBase<T> : IBase<T> where T : class
    {

        private readonly DbContextOptions<ClienteDbContext> _optionsBuilder;

        public RepositorioBase()
        {
            _optionsBuilder = new DbContextOptions<ClienteDbContext>();
        }
        public void Adicionar(T obj)
        {
            using (var db = new ClienteDbContext(_optionsBuilder))
            {
                db.Set<T>().Add(obj);
                db.SaveChanges();
            }
        }


        public void Atualizar(T obj)
        {
            using (var db = new ClienteDbContext(_optionsBuilder))
            {
                db.Set<T>().Update(obj);
                db.SaveChanges();
            }
        }

        public void Excluir(T obj)
        {
            using (var db = new ClienteDbContext(_optionsBuilder))
            {
                db.Set<T>().Remove(obj);
                db.SaveChanges();
            }

        }

        public T RecuperarPorId(Guid id)
        {
            using (var db = new ClienteDbContext(_optionsBuilder))
            {
                return db.Set<T>().Find(id);
            }
        }

        public IList<T> Listar()
        {
            using (var db = new ClienteDbContext(_optionsBuilder))
            {
                return db.Set<T>().AsNoTracking().ToList();
            }
        }
    }
}


