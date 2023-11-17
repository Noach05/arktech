using ArkTech.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkTech.Domains.SubProductDomains
{
    public class RAM : Product
    {
        private int _sticks;
        private int _memory;
        private int _memorySpeed;
        private int _internalRam;
        private MemoryTypesEnum _memoryType;
        private int _pins;

        public RAM(Product product,
            int sticks, int memory, int memoryspeed, int internalRam, MemoryTypesEnum memoryType, int pins)
            : base(product.Id, product.Brand, product.Model, product.Price, product.Stock, product.ReleaseYear, product.Type, product.Image)
        {
            this.Sticks = sticks;
            this.Memory = memory;
            this.MemorySpeed = memoryspeed;
            this.InternalRam = internalRam;
            this.MemoryType = memoryType;
            this.Pins = pins;
        }

        public int Sticks
        {
            get { return _sticks; }
            private set { _sticks = value; }
        } 
        public int Memory
        {
            get { return _memory; }
            private set { _memory = value; }
        }
        public int MemorySpeed
        {
            get { return _memorySpeed; }
            private set { _memorySpeed = value; }
        }
        public int InternalRam
        {
            get { return _internalRam; }
            private set { _internalRam = value; }
        }
        public MemoryTypesEnum MemoryType
        {
            get { return _memoryType; }
            private set { _memoryType = value; }
        }
        public int Pins
        {
            get { return _pins; }
            private set { _pins = value; }
        }

        public void Update(string nBrand, string nModel, double nPrice, int nStock, int nReleaseYear, ProductTypesEnum nType, byte[] nImage,
            int nSticks, int nMemory, int nMemoryspeed, int nInternalRam, MemoryTypesEnum nMemoryType, int nPins)
        {
            base.UpdateProduct(nBrand, nModel, nPrice, nStock, nReleaseYear, nType, nImage);
            this.Sticks = nSticks;
            this.Memory = nMemory;
            this.MemorySpeed = nMemoryspeed;
            this.InternalRam = nInternalRam;
            this.MemoryType = nMemoryType;
            this.Pins = nPins;
        }
    }
}
