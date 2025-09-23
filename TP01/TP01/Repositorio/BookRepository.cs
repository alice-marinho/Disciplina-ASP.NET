using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TP01.Negocio;

namespace TP01.Repositorio
{
    internal class BookRepository
    {
        private static readonly string livros = "Repositorio\\livros.csv";
        private readonly List<Negocio.Book> _books;

        public BookRepository()
        {
            var bookList = new List<Negocio.Book>();
            using (var file = File.OpenText(livros))
            {
                file.ReadLine();

                while (!file.EndOfStream)
                {
                    var linha = file.ReadLine();

                    if (string.IsNullOrEmpty(linha))
                    {
                        continue;
                    }

                    string[] values = Regex.Split(linha, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");

                    string name = values[0].Trim('"');
                    string authorName = values[1];
                    double price = double.Parse(values[2], CultureInfo.InvariantCulture);
                    int qty = int.Parse(values[3]);
                    string authorEmail = values[4];
                    char authorGender = char.Parse(values[5]);

                    Author author = new Author(authorName, authorEmail, authorGender);
                    Book book1 = new Book(name, new Author[] { author }, price, qty);

                    bookList.Add(book1);
                }
            }

            _books = bookList;
        }

        public List<Book> GetAllBooks()
        {
            return _books;
        }

        public Book GetBook()
        {
            return _books.FirstOrDefault();
        }
    }
}
