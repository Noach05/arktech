using ArkTech.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkTech.Domains.SubProductDomains
{
    public class GPU : Product
    {
        private int _clockSpeed;
        private int _displayPorts;
        private int _videoRam;
        private int _fans;
        private int _size;
        private BusTypesEnum _busType;

        public GPU(Product product,
            int clockSpeed, int displayPorts, int videoRam, int fans, BusTypesEnum busType, int size)
            : base(product.Id, product.Brand, product.Model, product.Price, product.Stock, product.ReleaseYear, product.Type, product.Image)
        {
            this.ClockSpeed = clockSpeed;
            this.DisplayPorts = displayPorts;
            this.VideoRam = videoRam;
            this.Fans = fans;
            this.BusType = busType;
            this.Size = size;
        }

        public int ClockSpeed
        {
            get { return _clockSpeed; }
            private set { _clockSpeed = value; }
        }
        public int DisplayPorts
        {
            get { return _displayPorts; }
            private set { _displayPorts = value; }
        }
        public int VideoRam
        {
            get { return _videoRam; }
            private set { _videoRam = value; }
        }
        public int Fans
        {
            get { return _fans; }
            private set { _fans = value; }
        }
        public int Size
        {
            get { return _size; }
            private set { _size = value; }
        }
        public BusTypesEnum BusType
        {
            get { return _busType; }
            private set { _busType = value; }
        }

        public void Update(string nBrand, string nModel, double nPrice, int nStock, int nReleaseYear, ProductTypesEnum nType, byte[] nImage,
            int nClockSpeed, int nDisplayPorts, int nVideoRam, int nFans, BusTypesEnum nBusType, int nSize)
        {
            base.UpdateProduct(nBrand, nModel, nPrice, nStock, nReleaseYear, nType, nImage);
            this.ClockSpeed = nClockSpeed;
            this.DisplayPorts = nDisplayPorts;
            this.VideoRam = nVideoRam;
            this.Fans = nFans;
            this.BusType = nBusType;
            this.Size = nSize;
        }
    }
}
