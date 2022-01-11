using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Bookki.Shared;

public class Book
{
    public Guid Guid { get; set; } = Guid.NewGuid();

    [Required]
    public string Name { get; set; }

    [Required]
    public string Author { get; set; }

    [Required]
    public string Description { get; set; }

    public static Book Empty
    {
        get
        {
            return new Book { Guid = Guid.Empty };
        }
    }

    public void Clear()
    {
        Guid = Guid.Empty;
        Name = string.Empty;
        Author = string.Empty;
        Description = string.Empty;
    }

    public Book Clone()
    {
        var book = new Book
        {
            Guid = Guid,
            Name = Name,
            Author = Author,
            Description = Description
        };
        return book;
    }
}

