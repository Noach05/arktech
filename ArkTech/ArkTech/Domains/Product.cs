using ArkTech.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;


namespace ArkTech.Domains
{
    public class Product
    {
        private Guid _id;
        private string _brand;
        private string _model;
        private double _price;
        private int _stock;
        private int _releaseYear;
        private ProductTypesEnum _type;
        private byte[] _image;

        public Product(Guid id, string brand, string model, double price, int stock, int releaseYear, ProductTypesEnum type, byte[] image)
        {
            this.Id = id;
            this.Brand = brand;
            this.Model = model;
            this.Price = price;
            this.Stock = stock;
            this.ReleaseYear = releaseYear;
            this.Type = type;
            this.Image = image;
        }

        public Guid Id 
        {
            get { return _id; } 
            private set { _id = value; } 
        }
        public string Brand
        {
            get { return _brand; }
            private set { _brand = value; }
        } 
        public string Model
        {
            get { return _model; }
            private set { _model = value; }
        }
        public string Name
        {
            get { return String.Format($"{Brand} {Model}"); }
        }
        public double Price
        {
            get { return _price; }
            private set { _price = value; }
        }
        public int Stock
        {
            get { return _stock; }
            private set { _stock = value; }
        }
        public int ReleaseYear
        {
            get { return _releaseYear; }
            private set { _releaseYear = value; }
        }
        public ProductTypesEnum Type
        {
            get { return _type; }
            private set { _type = value; }
        }
        public byte[] Image
        {
            get { return _image; }
            private set { _image = value; }
        }

        public void UpdateProduct(string nBrand, string nModel, double nPrice, int nStock, int nReleaseYear, ProductTypesEnum nType, byte[] nImage)
        {
            this.Brand = nBrand;
            this.Model = nModel;
            this.Price = nPrice;
            this.Stock = nStock;
            this.ReleaseYear = nReleaseYear;
            this.Type = nType;
            this.Image = nImage;
        }

        public override string ToString()
        {
            return String.Format($"{Name}");
        }

        public void ChangeStock(int nStock)
        {
            this.Stock = nStock;
        }
        public void ChangePrice(double nPrice)
        {
            this.Price = nPrice;
        }

    }
}
