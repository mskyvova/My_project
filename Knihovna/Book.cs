using System;

public class Book
{
    public required string Title{ get; set; }
    public required string Author{ get; set; }

    private DateTime publishedDate;
    public DateTime PublishedDate
    {
        get => publishedDate;
        set => publishedDate = value;
    }

    private int pages;
    public int Pages
    {
        get => pages;
        set
        {
            if (value <= 0)
                throw new ArgumentException("Počet stran musí být kladný.");
            pages = value;
        }
    }

    public override string ToString()
    {
        return $"Kniha: {Title}, autor: {Author}, vydáno {PublishedDate:d.M.yyyy}, stran: {Pages}";
    }
}