using System;
namespace OOP1
{
    class Catalog
    {
        private Dictionary<string, Book> _items = new Dictionary<string, Book>();
        private List<string> _order = new List<string>();
        public IReadOnlyCollection<Book> All => _items.Values;
        public int Count => _items.Count;
        public void Add(Book book)
        {
            if (_items.ContainsKey(book.Isbn))
            {
                throw new ArgumentException($"Книга с таким идентификатором - {book.Isbn}' уже есть");
            }
            _items[book.Isbn] = book;
            _order.Add(book.Isbn);
        }
        public bool Remove(string isbn)
        {
            if (_items.ContainsKey(isbn))
            {
                _items.Remove(isbn);
                _order.Remove(isbn);
                return true;
            }
            return false;
        }
        public bool Contains(string isbn) => _items.ContainsKey(isbn) == true;
        public Book this[string isbn]
        {
            get
            {
                if (!_items.ContainsKey(isbn))
                {
                    throw new KeyNotFoundException($"Книга с таким идентификатором - {isbn} не найдена");
                }
                return _items[isbn];
            }
        }
        public Book this[int index]
        {
            get
            {
                if (index < 0 || index >= _order.Count)
                {
                    throw new IndexOutOfRangeException($"Индекс вышел за границу");
                }
                string isbn = _order[index];
                return _items[isbn];
            }
        }
        public Book this[(string author, int n) key]
        {
            get
            {
                string author = key.author;
                int n = key.n;
                var books = _order.Select(isbn => _items[isbn]).Where(b => b.Author == author).ToList();
                if (n < 0 || n >= books.Count)
                {
                    throw new IndexOutOfRangeException($"Индекс вышел за границу");
                }
                return books[n];
            }
        }
    }
}