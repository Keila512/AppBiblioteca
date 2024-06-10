using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBiblioteca
{
    internal class Index
    {
        private string filePath = "Index_books.txt";
        private Dictionary<int, long> index = new Dictionary<int, long>();

        public Index()
        {
            if (File.Exists("index.txt"))
            {
                var indexLines = File.ReadAllLines("index.txt");
                foreach (var line in indexLines)
                {
                    var parts = line.Split(',');
                    index[int.Parse(parts[0])] = long.Parse(parts[1]);
                }
            }
        }

        public void AddBook(Book book)
        {
            using (StreamWriter sw = File.AppendText(filePath))
            {
                long position = sw.BaseStream.Length;
                sw.WriteLine(book.ToString());
                index[book.ID] = position;
                File.AppendAllText("index.txt", $"{book.ID},{position}\n");
            }
        }

        public Book FindBook(int id)
        {
            if (index.TryGetValue(id, out long position))
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    sr.BaseStream.Seek(position, SeekOrigin.Begin);
                    string line = sr.ReadLine();
                    return Book.FromString(line);
                }
            }
            return null;
        }
    }
}
