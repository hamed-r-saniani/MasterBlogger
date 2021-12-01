﻿using Framework.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Framework.Infrastructure
{
    public class BaseRepository<TKey, T> : IRepository<TKey, T> where T : DomainBase<TKey>
    {
        private readonly DbContext _context;

        public BaseRepository(DbContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Add<T>(entity);
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetBy(TKey id)
        {
            return _context.Find<T>(id);
        }

        public bool IsExists(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Any(expression);
        }
    }
}
