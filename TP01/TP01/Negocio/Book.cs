using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP01.Negocio
{
    internal class Book
    {
        private String name;
        private Author[] authors;
        private double price;
        private int qty = 0;

        public string GetName() { return name; }

        public Author[] GetAuthors() { return authors; }

        public double GetPrice() { return price;}

        public void SetPrice(double price){ this.price = price; }

        public int GetQty() {return qty;}

        public void SetQty(int qty) { this.qty = qty; }

        public Book(String name, Author [] authors, double price)
        {
            this.name = name;
            this.authors = authors;
            this.price = price;
        }
        public Book(string name, Author[] authors, double price, int qty)
        {
            this.name = name;
            this.authors = authors;
            this.price = price;
            this.qty = qty;
        }

        public override string ToString()
        {
            StringBuilder authorsStr = new StringBuilder();
            authorsStr.Append('{');
            for (int i = 0; i < authors.Length; i++)
            {
                authorsStr.Append(authors[i].ToString());
                if (i < authors.Length - 1)
                {
                    authorsStr.Append(", ");
                }
            }
            authorsStr.Append('}');
            return $"Book[name={name}, authors={authorsStr}, price={price}, qty={qty}]";
        }

        public string GetAuthorNames()
        {
            string[] authorNames = new string[authors.Length];
            for (int i = 0; i < authors.Length; i++)
            {
                authorNames[i] = authors[i].GetName();
            }
            return string.Join(", ", authorNames);
        }
    }
}

