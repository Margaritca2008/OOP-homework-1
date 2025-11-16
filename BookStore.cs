using System;
namespace OOP1
{
    class BookStore
    {
        private Catalog _catalog;
        public Catalog Catalog => _catalog;
        public BookStore(Catalog catalog)
        {
            _catalog = catalog;
        }
        public void Rent(string isbn)
        {
            _catalog[isbn].Rent();
        }
        public void Return(string isbn)
        {
            _catalog[isbn].Return();
        }
        public void SetPrice(string isbn, double price)
        {
            _catalog[isbn].Reprice(price);
        }
        public void PrintCatalog()
        {
            for (int i = 0; i < _catalog.Count; i++)
            {
                Book b = _catalog[i];
                Console.WriteLine(b.ToString());
            }
        }
    }
}