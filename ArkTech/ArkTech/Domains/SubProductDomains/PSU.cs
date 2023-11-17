using ArkTech.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkTech.Domains.SubProductDomains
{
    public class PSU : Product
    {
        private int _output;
        private bool _isModular;
        private string _certificate;

        public PSU(Product product, 
            int output, bool modular, string certificate) 
            : base(product.Id, product.Brand, product.Model, product.Price, product.Stock, product.ReleaseYear, product.Type, product.Image)
        {
            this.Output = output;
            this.IsModular = modular;
            this.Certificate = certificate;
        }

        public int Output
        {
            get { return _output; }
            private set { _output = value; }
        }
        public bool IsModular
        {
            get { return _isModular; }
            private set { _isModular = value; }
        }
        public string Certificate
        {
            get { return _certificate; }
            private set { _certificate = value; }
        }

        public void Update(string nBrand, string nModel, double nPrice, int nStock, int nReleaseYear, ProductTypesEnum nType, byte[] nImage,
            int nOutput, bool nModular, string nCertificate)
        {
            base.UpdateProduct(nBrand, nModel, nPrice, nStock, nReleaseYear, nType, nImage);
            this.Output = nOutput;
            this.IsModular = nModular;
            this.Certificate = nCertificate;
        }
    }
}
