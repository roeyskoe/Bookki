using Bookki.Shared;
using System;
using System.Collections.Generic;

namespace Bookki.Server;

public class BookCollection : List<Book>
{

    public BookCollection()
    {
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
            Add(book);
        }
    }
}

