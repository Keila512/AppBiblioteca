using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBiblioteca
{
    internal class Direct
    {
        private string filePath = "Direct_books.dat";
        private int recordSize = 256;

        public void AddBook(Book book)
        {
            int hash = book.ID % 100;
            long position = hash * recordSize;

            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write))
            {
                fs.Seek(position, SeekOrigin.Begin);
                byte[] buffer = new byte[recordSize];
                byte[] data = System.Text.Encoding.UTF8.GetBytes(book.ToString());
                Array.Copy(data, buffer, data.Length);
                fs.Write(buffer, 0, buffer.Length);
            }
        }

        public Book FindBook(int id)
        {
            int hash = id % 100;
            long position = hash * recordSize;

            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                fs.Seek(position, SeekOrigin.Begin);
                byte[] buffer = new byte[recordSize];
                fs.Read(buffer, 0, buffer.Length);
                string data = System.Text.Encoding.UTF8.GetString(buffer).TrimEnd('\0');
                return Book.FromString(data);
            }
        }
    }
}
