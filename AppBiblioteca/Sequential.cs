using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBiblioteca
{
    internal class Sequential
    {
        private string filePath = "Books.txt";

        public void AddBook(Book book)
        {
            using (StreamWriter sw = File.AppendText(filePath))
            {
                sw.WriteLine(book.ToString());
            }
        }

        public Book FindBook(int id)
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Book book = Book.FromString(line);
                    if (book.ID == id)
                        return book;
                }
            }
            return null;
        }
    }
}
