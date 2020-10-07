﻿using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Repositorys
{
    public class Repository<T> : IRepository<T> where T : Entidade
    {
        private readonly ConfigureModelsDbContext _context;

        public Repository(ConfigureModelsDbContext ctx)
        {
            _context = ctx;
        }

        //methods
        public T Add(T model)
        {
            _context.Entry(model).State = EntityState.Added;
            _context.SaveChanges();

            return model;
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Remove(T model)
        {
            var ent = _context.Set<T>().Find(model.Id);

            if (ent != null)
            {
                var local = _context.Set<T>().Local.Where(x => x.Id == model.Id).FirstOrDefault();
                if (local != null)
                {
                    _context.Entry(local).State = EntityState.Detached;
                    _context.Remove(model);
                }
            }

            _context.SaveChanges();
        }

        public void Update(T model)
        {
            var ent = _context.Set<T>().Find(model.Id);

            if (ent != null)
            {
                var local = _context.Set<T>().Local.Where(x => x.Id == model.Id).FirstOrDefault();
                if (local != null)
                {
                    _context.Entry(local).State = EntityState.Detached;
                    _context.Update(model);
                }
            }

            _context.SaveChanges();
        }
    }
}
