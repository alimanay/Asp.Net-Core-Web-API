using Entites.Models;
using Microsoft.EntityFrameworkCore;
using Repositoires.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositoires.EFCore
{
    public class BookRepository : RepositoryBase<Book>, IBooksRepository
    {
        public BookRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            
        }
        public void CreateOneBook(Book book) => Create(book);

        public void DeleteOneBook(Book book) => Delete(book);

        public IQueryable<Book> GetAllBooks(bool trackChanges) =>
            FindAll(trackChanges);

         

        public void UpdateOneBook(Book book)=>Update(book);

         public  Book  GetOneBookById(int id, bool trackChanges)=>
        FindByCondition(a => a.Equals(id), trackChanges).SingleOrDefault();
        
    }
}
