using DataInfo.Data.Entitys;

namespace HW_Web__1_MVC_.Model
{
    public class CreateAutoModel
    {
        public string Mark { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }
        public int Year { get; set; }
        public IFormFile Image { get; set; }

        public int ColorId { get; set; }


        public CreateAutoModel()
        {

        }
        public CreateAutoModel(string _mark, string _model, double _price, int _year, IFormFile _image, int _idColor)
        {
            Mark = _mark;
            Model = _model;
            Price = _price;
            Year = _year;
            Image = _image;
            ColorId = _idColor;
        }
    }
}
