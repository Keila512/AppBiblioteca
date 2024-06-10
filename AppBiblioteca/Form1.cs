using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppBiblioteca
{
    public partial class Form1 : Form
    {
        private Sequential fileSequence = new Sequential();
        private Index fileIndex = new Index();
        private Direct fileDirect = new Direct();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Book book = new Book
            {
                ID = int.Parse(txtID.Text),
                Title = txtTitle.Text,
                Author = txtAuthor.Text,
                Year = int.Parse(txtYear.Text)
            };

            fileSequence.AddBook(book);
            fileIndex.AddBook(book);
            fileDirect.AddBook(book);
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtIDFind.Text);

            // Seleccionar el tipo de archivo según necesidad
            Book book = fileSequence.FindBook(id);
            // o
            //Book book = fileIndex.FindBook(id);
            // o
            //Book book = fileDirect.FindBook(id);

            if (book != null)
            {
                MessageBox.Show($"Book Found: {book.Title}");
            }
            else
            {
                MessageBox.Show("Book not found");
            }
        }
    }
}
