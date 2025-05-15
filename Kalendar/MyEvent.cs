using System;

public class MyEvent
{
    public string Name { get; set; }
    public DateTime Date { get; set; }

    public MyEvent(string name, DateTime date)
    {
        Name = name;
        Date = date;
    }

    public string GetInfo()
    {
        var today = DateTime.Today;
        int diff = (Date - today).Days;

        if (diff > 0)
            return $"Event {Name} with date {Date:yyyy-MM-dd} will happen in {diff} days";
        else if (diff < 0)
            return $"Event {Name} with date {Date:yyyy-MM-dd} happened {-diff} days ago";
        else
            return $"Event {Name} with date {Date:yyyy-MM-dd} is happening today";
    }
}