﻿using Domain.IRepository;
using Microsoft.EntityFrameworkCore;
using Migration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace Repository.implementation
{
    public class Repositroy<T> : IRepository<T> where T : class
    {
        private readonly StoreContext _db;
        internal DbSet<T> dbSet;

        public Repositroy(StoreContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();


        }
        public void Add(T entity)
        {
            entity.GetType().GetProperty("CreateDate").SetValue(entity, DateTime.Now);
            entity.GetType().GetProperty("IsActive").SetValue(entity, (byte)1);
            dbSet.Add(entity);

        }

        public void Update(T entity)
        {
            dbSet.Update(entity);
        }


        public T Get(int id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null)
        {

            IQueryable<T> query = dbSet;

            if(filter !=null)
            {
                query = query.Where(filter);

            }
            if(includeProperties !=null)
            {
                foreach(var includeProp in includeProperties.Split(new char[] { ','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);

                }
            }

            if(orderBy !=null)
            {
                return orderBy(query).ToList();
            }

            return query.ToList();

        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);

            }
            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);

                }
            }

          

            return query.FirstOrDefault();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void Remove(int id)
        {
            T entity = dbSet.Find(id);
            Remove(entity);

        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }
    }
}
