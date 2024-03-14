using System;
using formula1;
using System.Collections.Generic;

public class Driver
{
    public string Name { get; set; }
    public Team Team { get; set; }
    public int Points { get; set; } = 0;
    public double Rating { get; set; }

    public Driver(string name, double rating)
    {
        Name = name;
        Rating = rating;    }
}