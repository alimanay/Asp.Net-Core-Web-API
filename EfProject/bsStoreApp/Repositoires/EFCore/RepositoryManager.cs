using Entites.Models;
using Repositoires.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositoires.EFCore
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly Lazy<IBooksRepository> _booksRepository;
        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _context = repositoryContext;
            _booksRepository = new Lazy<IBooksRepository>(()=> new BookRepository(_context));
        }
        public IBooksRepository Books => _booksRepository.Value;

        public void Save()
        {
          _context.SaveChanges();
        }
    }
}
