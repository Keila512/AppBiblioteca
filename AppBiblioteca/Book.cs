using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBiblioteca
{
    internal class Book
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }

        public override string ToString()
        {
            return $"{ID},{Title},{Author},{Year}";
        }

        public static Book FromString(string data)
        {
            var parts = data.Split(',');
            return new Book
            {
                ID = int.Parse(parts[0]),
                Title = parts[1],
                Author = parts[2],
                Year = int.Parse(parts[3])
            };
        }
    }
}
