using Jokes.Core.Entities;
using System.Collections.Generic;

namespace Jokes.Core.Interfaces
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : BaseEntity;
        int Count<T>() where T : BaseEntity;
        void Create<T>(T entity) where T : BaseEntity;
        void Delete<T>(T entity) where T : BaseEntity;
        void DeleteById<T>(int id) where T : BaseEntity;
        T GetById<T>(int id) where T : BaseEntity;
        List<T> List<T>() where T : BaseEntity;
        List<T> List<T>(int start, int step) where T : BaseEntity;
        //void Update<T>(T entity) where T : BaseEntity;
    }
}
