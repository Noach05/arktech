using ArkTech.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ArkTech.Domains.SubProductDomains
{
    public class Motherboard : Product
    {
        private MemoryTypesEnum _memoryType;
        private int _ramSlots;
        private int _m2Slots;
        private int _sata3Ports;
        private bool _isWifiCapable;

        public Motherboard(Product product,
            MemoryTypesEnum memoryType, int ramSlots, int m2Slots, int sata3Ports, bool isWifiCapable)
            : base(product.Id, product.Brand, product.Model, product.Price, product.Stock, product.ReleaseYear, product.Type, product.Image)
        {
            MemoryType = memoryType;
            RamSlots = ramSlots;
            M2Slots = m2Slots;
            Sata3Ports = sata3Ports;
            IsWifiCapable = isWifiCapable;
        }

        public MemoryTypesEnum MemoryType
        {
            get { return _memoryType; }
            private set { _memoryType = value; }
        }
        public int RamSlots
        {
            get { return _ramSlots; }
            private set { _ramSlots = value; }
        }
        public int M2Slots
        {
            get { return _m2Slots; }
            private set { _m2Slots = value; }
        }
        public int Sata3Ports
        {
            get { return _sata3Ports; }
            private set { _sata3Ports = value; }
        }
        public bool IsWifiCapable
        {
            get { return _isWifiCapable; }
            private set { _isWifiCapable = value; }
        }

        public void Update(string nBrand, string nModel, double nPrice, int nStock, int nReleaseYear, ProductTypesEnum nType, byte[] nImage,
            MemoryTypesEnum nMemoryType, int nRamSlots, int nM2Slots, int nSata3Ports, bool nIsWifiCapable)
        {
            base.UpdateProduct(nBrand, nModel, nPrice, nStock, nReleaseYear, nType, nImage);
            MemoryType = nMemoryType;
            RamSlots = nRamSlots;
            M2Slots = nM2Slots;
            Sata3Ports = nSata3Ports;
            IsWifiCapable = nIsWifiCapable;
        }
    }
}
