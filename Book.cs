using System;
namespace OOP1
{
    class Book
    {
        private double _price;
        private int _stock;
        public string Isbn { get; }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public double Price {
            get { return _price; }
            private set {
                if (value < 0) {
                    throw new ArgumentOutOfRangeException(nameof(Price), "Price must be >= 0");
                } 
                _price = value;
            }
        }
        public int Stock
        {
            get { return _stock; }
            private set {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(Stock), "Stock must be >= 0");
                }
                _stock = value;
            }
        }
        public bool IsAvailable
        {
            get { return _stock > 0; }
        }
        public Book(string isbn, string title, string author, double price, int stock)
        {
            Isbn = isbn;
            Title = title;
            Author = author;
            Price = price;
            Stock = stock;
        }
        public void Rent()
        {
            Stock -= 1;
        }
        public void Return()
        {
            Stock += 1;
        }
        public void Reprice(double newPrice)
        {
            Price = newPrice;
        }
        public void Rename(string newTitle)
        {
            Title = newTitle;
        }
        public  override string ToString()
        {
            return $"Isbn: {Isbn}, Title: {Title}, Author: {Author}, Price: {Price:C}, Stock: {Stock}";
        }
    }
}