using Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.DataTransferObjects
{
    public record BookDtoForUpdate 
    {
        public BookDtoForUpdate(int ıd, string title, decimal price)
        {
            Id = ıd;
            Title = title;
            Price = price;
        }

        public int Id {  get; init; }
        public string? Title { get; init; }
        public decimal Price { get; init; }
    }
}
