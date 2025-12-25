using AutoMapper;
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
        public ServiceManager(IRepositoryManager repositoryManager,ILoggerService loggerService,IMapper mapper)
        {
            bookService = new Lazy<IBookService>(() => new BookManager(repositoryManager,loggerService,mapper));
        }

        public IBookService BookService =>  bookService.Value;
    }
}
