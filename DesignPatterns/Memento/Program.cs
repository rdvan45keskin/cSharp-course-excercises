using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    //Hafıza oluşturup o hafızaya geri almak için kullanılır faydalı
    internal class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book
            {
                Isbn = "12345",
                Title = "Sefiller",
                Author = "Victor Hugo"
            };
            book.ShowBook();

            CareTaker history = new CareTaker();
            history.Memento = book.CreateUndo();

            book.Isbn = "2003";
            book.Title = "Mein Kampf";
            book.Author = "Adolf";

            book.ShowBook();

            book.RestoreFromUndo(history.Memento);
            book.ShowBook();

        }
    }

    class Book
    {
        private string _title;
        private string _author;
        private string _isbn;
        private DateTime _lastEdited;
        public string Title 
        {
            get { return _title; }
            set 
            { 
                _title = value; 
                SetLastEdited();
            }
        }
        public string Author 
        {
            get { return _author; }
            set 
            { 
                _author = value;
                SetLastEdited();
            }
        }
        public string Isbn 
        {
            get { return _isbn; }
            set 
            { 
                _isbn = value;
                SetLastEdited();
            }
        }

        private void SetLastEdited()
        {
            _lastEdited = DateTime.Now;
        }

        public Memento CreateUndo()
        {
            return new Memento(_isbn,_title,_author,_lastEdited);
        }

        public void RestoreFromUndo(Memento memento)
        {
            _title = memento.Title;
            _author = memento.Author;
            _isbn = memento.Isbn;
            _lastEdited = memento.LastEdited;
        }

        public void ShowBook()
        {
            Console.WriteLine($"{_isbn},{_title},{_author},edited : {_lastEdited}");
        }
    }

    class Memento
    {
        public string  Isbn { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime LastEdited { get; set; }

        public Memento(string isbn, string title, string author, DateTime lastEdited)
        {
            Isbn = isbn;
            Title = title;
            Author = author;
            LastEdited = lastEdited;
        }
    }

    class CareTaker
    {
        public Memento Memento { get; set; }
    }
}
