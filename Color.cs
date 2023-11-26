using System;
using System.Collections.Generic;

public class Color
{
    public int Id { get; set; }
    public string ColorName { get; set; }
    public ICollection<Auto> Autos { get; set; }
    public Color()
    {

    }
    public Color(int _id, string _colorName)
    {
        Id = _id;
        ColorName = _colorName;
    }

}
