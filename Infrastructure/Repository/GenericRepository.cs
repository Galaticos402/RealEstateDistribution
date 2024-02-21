using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using AppContext = Core.AppContext;
using Infrastructure.Exceptions;

namespace Infrastructure.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private AppContext _context = null;
        //The following Variable is going to hold the DbSet Entity
        private DbSet<T> table = null;
        //Using the Parameterless Constructor, 
        //we are initializing the context object and table variable
        public GenericRepository()
        {
            this._context = new AppContext();
            //Whatever class name we specify while creating the instance of GenericRepository
            //That class name will be stored in the table variable
            table = _context.Set<T>();
        }
        //Using the Parameterized Constructor, 
        //we are initializing the context object and table variable
        public GenericRepository(AppContext _context)
        {
            this._context = _context;
            table = _context.Set<T>();
        }
        //This method will return all the Records from the table
        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }
        //This method will return the specified record from the table
        //based on the ID which it received as an argument
        public T GetById(object id)
        {
            return table.Find(id);
        }
        //This method will Insert one object into the table
        //It will receive the object as an argument which needs to be inserted into the database
        public void Insert(T obj)
        {
            //It will mark the Entity state as Added State
            table.Add(obj);
        }
        //This method is going to update the record in the table
        //It will receive the object as an argument
        public void Update(object id, T obj)
        {
            //First attach the object to the table
            //table.Attach(obj);
            //Then set the state of the Entity as Modified
            T existing = table.Find(id);
            if (existing == null) throw new DBTransactionException("Could not find entity", HttpStatusCode.BadRequest);
            _context.Entry(existing).CurrentValues.SetValues(obj);
        }
        //This method is going to remove the record from the table
        //It will receive the primary key value as an argument whose information needs to be removed from the table
        public void Delete(object id)
        {
            //First, fetch the record from the table
            T existing = table.Find(id);
            if (existing == null) throw new DBTransactionException("Could not find entity", HttpStatusCode.BadRequest);
            //This will mark the Entity State as Deleted
            table.Remove(existing);
        }
        //This method will make the changes permanent in the database
        //That means once we call Insert, Update, and Delete Methods, 
        //Then we need to call the Save method to make the changes permanent in the database
        public void Save()
        {
            _context.SaveChanges();
        }
        public IQueryable<T> Filter(Expression<Func<T, bool>> filter,
                                              int skip = 0,
                                              int take = int.MaxValue,
                                              Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                              Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            var _resetSet = filter != null ? table.AsNoTracking().Where(filter).AsQueryable() : table.AsNoTracking().AsQueryable();

            if (include != null)
            {
                _resetSet = include(_resetSet);
            }
            if (orderBy != null)
            {
                _resetSet = orderBy(_resetSet).AsQueryable();
            }
            _resetSet = skip == 0 ? _resetSet.Take(take) : _resetSet.Skip(skip).Take(take);

            return _resetSet.AsQueryable();
        }
    }
}
