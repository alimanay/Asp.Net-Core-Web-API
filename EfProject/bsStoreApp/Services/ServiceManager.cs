using Repositoires.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IBookService> bookService;
        public ServiceManager(IRepositoryManager repositoryManager)
        {
            bookService = new Lazy<IBookService>(() => new BookManager(repositoryManager));
        }

        public IBookService BookService =>  bookService.Value;
    }
}
