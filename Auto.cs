using System;

public class Auto
{
    public int Id { get; set; }
    public string Mark { get; set; }
    public string Model { get; set; }
    public double Price { get; set; }
    public int Year { get; set; }
    public string Image { get; set; }

    public Order Order { get; set; }
    public int? OrderId { get; set; }
    public int ColorId { get; set; }

    public Color Color { get; set; }

    public Auto()
    {

    }
    public Auto(int _id, string _mark, string _model, double _price, int _year, string _image, int _idColor)
    {
        Id = _id;
        Mark = _mark;
        Model = _model;
        Price = _price;
        Year = _year;
        Image = _image;
        ColorId = _idColor;
    }

}
