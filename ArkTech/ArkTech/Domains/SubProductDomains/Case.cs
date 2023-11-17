using ArkTech.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkTech.Domains.SubProductDomains
{
    public class Case : Product
    {
        private FormFactorsEnum _formFactor;
        private int _expansionSlots;
        private int _caseFans;
        private int _driveBays;
        private int _gpuSize;

        public Case(Product product, 
            FormFactorsEnum formFactor, int expansionSlots, int caseFans, int driveBays, int gpuSize) 
            : base(product.Id, product.Brand, product.Model, product.Price, product.Stock, product.ReleaseYear, product.Type, product.Image)
        {
            this.FormFactor = formFactor;
            this.ExpansionSlots = expansionSlots;
            this.CaseFans = caseFans;
            this.DriveBays = driveBays;
            this.GpuSize = gpuSize;
        }

        public FormFactorsEnum FormFactor
        {
            get { return _formFactor; }
            private set { _formFactor = value; }
        }
        public int ExpansionSlots
        {
            get { return _expansionSlots; }
            private set { _expansionSlots = value; }
        }
        public int CaseFans
        {
            get { return _caseFans; }
            private set { _caseFans = value; }
        }
        public int DriveBays
        {
            get { return _driveBays; }
            private set { _driveBays = value; }
        }
        public int GpuSize
        {
            get { return _gpuSize; }
            private set { _gpuSize = value; }
        }

        public void Update(string nBrand, string nModel, double nPrice, int nStock, int nReleaseYear, ProductTypesEnum nType, byte[] nImage,
            FormFactorsEnum nFormFactor, int nExpansionSlots, int nCaseFans, int nDriveBays, int nGpuSize)
        {
            base.UpdateProduct(nBrand, nModel, nPrice, nStock, nReleaseYear, nType, nImage);
            this.FormFactor = nFormFactor;
            this.ExpansionSlots = nExpansionSlots;
            this.CaseFans = nCaseFans;
            this.DriveBays = nDriveBays;
            this.GpuSize = nGpuSize;
        }
    }
}
