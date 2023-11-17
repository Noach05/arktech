using ArkTech.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkTech.Domains.SubProductDomains
{
    public class CPU : Product
    {
        private int _cores;
        private double _clockSpeed;
        private string _socket;
        private int _threads;
        public CPU(Product product,
            int cores, double clockSpeed, string socket, int threads)
            : base(product.Id, product.Brand, product.Model, product.Price, product.Stock, product.ReleaseYear, product.Type, product.Image)
        {
            this.Cores = cores;
            this.ClockSpeed = clockSpeed;
            this.Socket = socket;
            this.Threads = threads;
        }

        public int Cores
        {
            get { return _cores; }
            private set { _cores = value; }
        }
        public double ClockSpeed
        {
            get { return _clockSpeed; }
            private set { _clockSpeed = value; }
        }
        public string Socket
        {
            get { return _socket; }
            private set { _socket = value; }
        }
        public int Threads
        {
            get { return _threads; }
            private set { _threads = value; }
        }

        public void Update(string nBrand, string nModel, double nPrice, int nStock, int nReleaseYear, ProductTypesEnum nType, byte[] nImage,
            int nCores, double nClockSpeed, string nSocket, int nThreads)
        {
            base.UpdateProduct(nBrand, nModel, nPrice, nStock, nReleaseYear, nType, nImage);
            this.Cores = nCores;
            this.ClockSpeed = nClockSpeed;
            this.Socket = nSocket;
            this.Threads = nThreads;
        }
    }
}
