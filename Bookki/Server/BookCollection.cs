using Bookki.Shared;
using System;
using System.Collections.Generic;

namespace Bookki.Server;

public class BookCollection
{
    public List<Book> Books { get; private set; }

    public BookCollection()
    {
        Books = new List<Book>();
        FillWithDummyData(5);
    }

    private void FillWithDummyData(int n)
    {
        for (int i = 0; i < n; i++)
        {
            var book = new Book();
            book.Name = Random.Shared.NextInt64().ToString();
            book.Description = Random.Shared.NextInt64().ToString();
            book.Author = Random.Shared.NextInt64().ToString();
            Books.Add(book);
        }
    }
}

