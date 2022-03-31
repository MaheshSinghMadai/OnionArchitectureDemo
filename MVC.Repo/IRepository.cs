using System;
using System.Collections.Generic;
using System.Text;

namespace MVC.Repo
{
    public interface IRepository<T> where T : class
    {
        //Get all records
        IEnumerable<T> GetAll();

        //Get by particular ID
        T GetById(int id);

        //Creating/inserting record into database
        void Insert(T entity);

        //Editing the record
        void Update(T entity);

        ////Deleting the record
        //void Delete(T entity);

        //Removing the record
        void Remove(T entity);

        //Saving the record/changes to database
        void SaveChanges();
    }
}
