using Entites.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositoires.EFCore.Config
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {

            builder.HasData(
                new Book
                {
                    Id = 1,
                    Title = "Karagöz ve hacivat",
                    Price = 234

                },
                new Book
                {
                    Id = 2,
                    Title = "Kuyucaklı Yusuf",
                    Price = 189

                },

                new Book
                {
                    Id = 3,
                    Title = "Suç ve Ceza",
                    Price = 275
                }
                );
        }
    }
}
