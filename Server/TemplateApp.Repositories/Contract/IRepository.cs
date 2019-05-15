using System;
using System.Collections.Generic;
using System.Text;
using TemplateApp.Data.Models.Base;

namespace TemplateApp.Repositories.Contract
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        void Create(TEntity entity);
        void Delete(TEntity entity);
        void Delete(int id);
        void Edit(TEntity entity);

        TEntity GetById(int id);
        IEnumerable<TEntity> Filter();
        IEnumerable<TEntity> Filter(Func<TEntity, bool> predicate);

        void SaveChanges();
    }
}
