using AutoMapper;
using Entites.DataTransferObjects;
using Entites.Exceptions;
using Entites.Models;
using Repositoires.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BookManager : IBookService
    {
        private readonly IRepositoryManager _manager;
        private readonly ILoggerService _loggerService;
        private readonly IMapper _mapper;

       

        public BookManager(IRepositoryManager manager, ILoggerService loggerService, IMapper mapper)
        {
            _manager = manager;
            _loggerService = loggerService;
            _mapper = mapper;
        }

        public Book CreateOneBook(Book book) { 
 
            _manager.Books.CreateOneBook(book);
            _manager.Save();
            return book;
        }
        
       

        public void DeleteOneBook(int id, bool trackChanges)
        {
            var entity = _manager.Books.GetOneBookById(id , trackChanges);
            if (entity== null) 
                throw new BookNotFoundException(id);
            _manager.Books.DeleteOneBook(entity);
            _manager.Save();
        }

        public IEnumerable<Book> GetAllBook(bool trackChanges)
        {
            return _manager.Books.GetAllBooks(trackChanges);
        }
        public Book GetOneBookById(int id, bool trackChanges)
        {
            var books = _manager.Books.GetOneBookById(id, trackChanges);
            if (books is null) throw new BookNotFoundException(id);
            return books;
        }
        public void  UpdateOneBook(int id, BookDtoForUpdate bookDto, bool trackChanges)
        {
            var entity = _manager.Books.GetOneBookById(id, trackChanges);
            if (entity == null) throw new BookNotFoundException(id);
            //Mapping
            entity = _mapper.Map<Book>(bookDto);
            _manager.Books.Update (entity);
            _manager.Save();
        }
    }
}
