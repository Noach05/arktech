using ArkTech.Domains;
using ArkTech.Domains.SubProductDomains;
using ArkTech.Enumerations;
using ArkTech.Interfaces;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArkTechWindowsFormsApp
{
    public partial class ProductRegistrationForm : Form
    {
        private IProductService productService;
        private List<Product> products = new List<Product>();

        public ProductRegistrationForm(IProductService productService)
        {
            InitializeComponent();
            this.productService = productService;
            PopulateListboxes();
            cbxMemoryTypeMobo.DataSource = Enum.GetValues(typeof(MemoryTypesEnum));
            cbMemoryTypeRam.DataSource = Enum.GetValues(typeof(MemoryTypesEnum));
            cbBusGpu.DataSource = Enum.GetValues(typeof(BusTypesEnum));
            cbFormCase.DataSource = Enum.GetValues(typeof(FormFactorsEnum));
        }

        private async void PopulateListboxes()
        {
            lbProducts.Items.Clear();
            lbProducts.Items.Add("Loading...");
            products = await productService.GetProductsAsync();
            lbProducts.Items.RemoveAt(0);
            lbProducts.Items.Add("");
            lbProducts.Items.AddRange(products.ToArray());
        }
        private void ResetBoxes()
        {
            nudSata3Mobo.Value = nudSata3Mobo.Minimum;
            nudM2Mobo.Value = nudM2Mobo.Minimum;
            nudRamMobo.Value = nudRamMobo.Minimum;
            cbxMemoryTypeMobo.SelectedIndex = 0;
            chbWifiMobo.Checked = false;
            nudCPUCores.Value = nudCPUCores.Minimum;
            tbSocketCpu.Clear();
            nudCPUThreads.Value = nudCPUThreads.Minimum;
            nudCPUClockSpeed.Value = nudCPUClockSpeed.Minimum;
            nudPinsRam.Value = nudPinsRam.Minimum;
            nudGHzCompRam.Value = 8;
            nudSticksRam.Value = 2;
            cbMemoryTypeRam.SelectedIndex = 0;
            nudMemorySpeedRam.Value = nudMemorySpeedRam.Minimum;
            nudSizeGpu.Value = nudSizeGpu.Minimum;
            nudVideoRamGpu.Value = nudVideoRamGpu.Minimum;
            nudClockingSpeedGpu.Value = nudClockingSpeedGpu.Minimum;
            nudFansGpu.Value = nudFansGpu.Minimum;
            cbBusGpu.SelectedIndex = 0;
            nudPortsGpu.Value = nudPortsGpu.Minimum;
            cbxModular.Checked = false;
            tbCertificatePsu.Clear();
            nudOutputPsu.Value = nudOutputPsu.Minimum;
            nudGraphCardCase.Value = nudGraphCardCase.Minimum;
            nudBaysCase.Value = nudBaysCase.Minimum;
            nudFansCase.Value = nudFansCase.Minimum;
            cbFormCase.SelectedIndex = 0;
            nudExpansioCase.Value = nudExpansioCase.Minimum;
            pbImage.Controls.Clear();
            nudYear.Value = nudYear.Minimum;
            nudStock.Value = nudStock.Minimum;
            nudPrice.Value = nudPrice.Minimum;
            tbName.Clear();
            tbManuf.Clear();
        }

        private byte[] SavePhoto(PictureBox pictureBox)
        {
            byte[] imageBytes;
            using (MemoryStream ms = new MemoryStream())
            {
                pictureBox.Image.Save(ms, ImageFormat.Png);
                imageBytes = ms.ToArray();
            }
            return imageBytes;
            
        }

        private void chbWifiMobo_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tpRam_Click(object sender, EventArgs e)
        {

        }

        private async void btCreateProduct_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(tbManuf.Text) || String.IsNullOrWhiteSpace(tbName.Text))
            {
                MessageBox.Show("Please fill in all fields", "Invalid Operation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if ((double)nudPrice.Value <= 0) { MessageBox.Show("Price cannot be 0 or less", "Invalid Operation", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            else if ((int)nudStock.Value < 0) { MessageBox.Show("Stock cannot be negative", "Invalid Operation", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            else if ((int)nudYear.Value <= 1970) { MessageBox.Show("Products older than 1970 cannot be sold", "Invalid Operation", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            else
            {
                ProductTypesEnum type = new ProductTypesEnum();
                if (tabControl1.SelectedTab == tpMobo)
                {
                    type = ProductTypesEnum.Motherboard;
                    var product = new Product(Guid.NewGuid(), tbManuf.Text, tbName.Text, (double)nudPrice.Value, (int)nudStock.Value,
                    (int)nudYear.Value, type, SavePhoto(pbImage));
                    var mb = new Motherboard(product, (MemoryTypesEnum)cbxMemoryTypeMobo.SelectedValue,
                        (int)nudRamMobo.Value, (int)nudM2Mobo.Value, (int)nudSata3Mobo.Value, chbWifiMobo.Checked);
                    Result result = await productService.CreateProductAsync(mb);
                    if (result.Success)
                    {
                        lbProducts.Items.Add(mb);
                        MessageBox.Show(result.Message);
                    }
                }
                else if (tabControl1.SelectedTab == tpGpu)
                {
                    type = ProductTypesEnum.GPU;
                    var product = new Product(Guid.NewGuid(), tbManuf.Text, tbName.Text, (double)nudPrice.Value, (int)nudStock.Value,
                    (int)nudYear.Value, type, SavePhoto(pbImage));
                    var gpu = new GPU(product, (int)nudClockingSpeedGpu.Value, (int)nudPortsGpu.Value, (int)nudVideoRamGpu.Value,
                        (int)nudFansGpu.Value, (BusTypesEnum)cbBusGpu.SelectedValue, (int)nudSizeGpu.Value);
                    Result result = await productService.CreateProductAsync(gpu);
                    if (result.Success)
                    {
                        lbProducts.Items.Add(gpu);
                        MessageBox.Show(result.Message);
                    }
                }
                else if (tabControl1.SelectedTab == tpCpu)
                {
                    type = ProductTypesEnum.CPU;
                    var product = new Product(Guid.NewGuid(), tbManuf.Text, tbName.Text, (double)nudPrice.Value, (int)nudStock.Value,
                    (int)nudYear.Value, type, SavePhoto(pbImage));
                    var cpu = new CPU(product, (int)nudCPUCores.Value, (double)nudCPUClockSpeed.Value, tbSocketCpu.Text, (int)nudCPUThreads.Value);
                    Result result = await productService.CreateProductAsync(cpu);
                    if (result.Success)
                    {
                        lbProducts.Items.Add(cpu);
                        MessageBox.Show(result.Message);
                    }
                }
                else if (tabControl1.SelectedTab == tpCase)
                {
                    type = ProductTypesEnum.Case;
                    var product = new Product(Guid.NewGuid(), tbManuf.Text, tbName.Text, (double)nudPrice.Value, (int)nudStock.Value,
                    (int)nudYear.Value, type, SavePhoto(pbImage));
                    var pcase = new Case(product, (FormFactorsEnum)cbFormCase.SelectedValue, (int)nudExpansioCase.Value,
                        (int)nudFansCase.Value, (int)nudBaysCase.Value, (int)nudGraphCardCase.Value);
                    Result result = await productService.CreateProductAsync(pcase);
                    if (result.Success)
                    {
                        lbProducts.Items.Add(pcase);
                        MessageBox.Show(result.Message);
                    }
                }
                else if (tabControl1.SelectedTab == tpDrive)
                {
                    type = ProductTypesEnum.Drive;
                    MessageBox.Show("Drives not implemented");
                }
                else if (tabControl1.SelectedTab == tpRam)
                {
                    type = ProductTypesEnum.RAM;
                    var product = new Product(Guid.NewGuid(), tbManuf.Text, tbName.Text, (double)nudPrice.Value, (int)nudStock.Value,
                    (int)nudYear.Value, type, SavePhoto(pbImage));
                    var ram = new RAM(product, (int)nudSticksRam.Value, (int)nudGHzCompRam.Value, (int)nudMemorySpeedRam.Value,
                        (int)nudInternalRam.Value, (MemoryTypesEnum)cbMemoryTypeRam.SelectedValue, (int)nudPinsRam.Value);
                    Result result = await productService.CreateProductAsync(ram);
                    if (result.Success)
                    {
                        lbProducts.Items.Add(ram);
                        MessageBox.Show(result.Message);
                    }
                }
                else if (tabControl1.SelectedTab == tpCooler)
                {
                    type = ProductTypesEnum.Cooler;
                    MessageBox.Show("Cooler not implemented");
                }
                else if (tabControl1.SelectedTab == tpPsu)
                {
                    type = ProductTypesEnum.PowerSupply;
                    var product = new Product(Guid.NewGuid(), tbManuf.Text, tbName.Text, (double)nudPrice.Value, (int)nudStock.Value,
                    (int)nudYear.Value, type, SavePhoto(pbImage));
                    var psu = new PSU(product, (int)nudOutputPsu.Value, cbxModular.Checked, tbCertificatePsu.Text);
                    Result result = await productService.CreateProductAsync(psu);
                    if (result.Success)
                    {
                        lbProducts.Items.Add(psu);
                        MessageBox.Show(result.Message);
                    }
                }
                ResetBoxes();
            }
        }

        private void btImportImg_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select a File";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp|All Files|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedImagePath = openFileDialog.FileName;
                    pbImage.Image = Image.FromFile(selectedImagePath);
                }
            }
        }

        private void lbProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            var product = (Product)lbProducts.SelectedItem;
            if (product == null)
            {
                PopulateListboxes();
                ResetBoxes();
            }
            else
            {
                tbManuf.Text = product.Brand;
                tbName.Text = product.Model;
                nudStock.Value = product.Stock;
                nudPrice.Value = (decimal)product.Price;
                nudYear.Value = product.ReleaseYear;
                using (MemoryStream ms = new MemoryStream(product.Image))
                {
                    pbImage.Image = Image.FromStream(ms);
                }

                if (product.Type == ProductTypesEnum.Motherboard)
                {
                    tabControl1.SelectedTab = tpMobo;
                    var mb = (Motherboard)product;
                    cbxMemoryTypeMobo.SelectedItem = mb.MemoryType;
                    nudRamMobo.Value = mb.RamSlots;
                    nudM2Mobo.Value = mb.M2Slots;
                    nudSata3Mobo.Value = mb.Sata3Ports;
                    chbWifiMobo.Checked = mb.IsWifiCapable;
                }
                else if (product.Type == ProductTypesEnum.CPU)
                {
                    tabControl1.SelectedTab = tpCpu;
                    var cpu = (CPU)product;
                    nudCPUCores.Value = cpu.Cores;
                    nudCPUClockSpeed.Value = (decimal)cpu.ClockSpeed;
                    nudCPUThreads.Value = cpu.Threads;
                    tbSocketCpu.Text = cpu.Socket;
                }
                else if (product.Type == ProductTypesEnum.RAM)
                {
                    tabControl1.SelectedTab = tpRam;
                    var ram = (RAM)product;
                    nudSticksRam.Value = ram.Sticks;
                    nudGHzCompRam.Value = ram.Memory;
                    nudMemorySpeedRam.Value = ram.MemorySpeed;
                    nudPinsRam.Value = ram.Pins;
                    cbMemoryTypeRam.SelectedItem = ram.MemoryType;
                    nudInternalRam.Value = ram.InternalRam;
                }
                else if (product.Type == ProductTypesEnum.GPU)
                {
                    tabControl1.SelectedTab = tpGpu;
                    var gpu = (GPU)product;
                    nudClockingSpeedGpu.Value = gpu.ClockSpeed;
                    nudPortsGpu.Value = gpu.DisplayPorts;
                    nudVideoRamGpu.Value = gpu.VideoRam;
                    nudFansGpu.Value = gpu.Fans;
                    nudSizeGpu.Value = gpu.Size;
                    cbBusGpu.SelectedItem = gpu.BusType;
                    //cbBusGpu.SelectedIndex = (int)gpu.BusType;
                }
                else if (product.Type == ProductTypesEnum.PowerSupply)
                {
                    tabControl1.SelectedTab = tpPsu;
                    var psu = (PSU)product;
                    nudOutputPsu.Value = psu.Output;
                    tbCertificatePsu.Text = psu.Certificate;
                    cbxModular.Checked = psu.IsModular;
                }
                else if (product.Type == ProductTypesEnum.Case)
                {
                    tabControl1.SelectedTab = tpCase;
                    var pcase = (Case)product;
                    cbFormCase.SelectedItem = pcase.FormFactor;
                    nudExpansioCase.Value = pcase.ExpansionSlots;
                    nudFansCase.Value = pcase.CaseFans;
                    nudBaysCase.Value = pcase.DriveBays;
                    nudGraphCardCase.Value = pcase.GpuSize;
                }
                else if (product.Type == ProductTypesEnum.Cooler)
                {
                    MessageBox.Show("You didn't implement cooler");
                }
                else if (product.Type == ProductTypesEnum.Drive)
                {
                    MessageBox.Show("You didn't implement drive");
                }
                else
                {
                    MessageBox.Show("Unknown error occured in loading data.");
                }
            }
        }

        private void nudGHzCompRam_ValueChanged(object sender, EventArgs e)
        {
            nudInternalRam.Value = nudGHzCompRam.Value * nudSticksRam.Value;
        }

        private void nudSticksRam_ValueChanged(object sender, EventArgs e)
        {
            nudInternalRam.Value = nudGHzCompRam.Value * nudSticksRam.Value;
        }

        private async void btUpdate_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(tbManuf.Text) || String.IsNullOrWhiteSpace(tbName.Text))
            {
                MessageBox.Show("Please fill in all fields", "Invalid Operation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if ((double)nudPrice.Value <= 0) { MessageBox.Show("Price cannot be 0 or less", "Invalid Operation", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            else if ((int)nudStock.Value < 0) { MessageBox.Show("Stock cannot be negative", "Invalid Operation", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            else if ((int)nudYear.Value <= 1970) { MessageBox.Show("Products older than 1970 cannot be sold", "Invalid Operation", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            else
            {
                var uProduct = (Product)lbProducts.SelectedItem;
                if (uProduct != null)
                {
                    Result result;
                    switch ((int)uProduct.Type)
                    {
                        case 0:
                            var mb = (Motherboard)uProduct;
                            mb.Update(tbManuf.Text, tbName.Text, (double)nudPrice.Value, (int)nudStock.Value, (int)nudYear.Value, ProductTypesEnum.Motherboard, SavePhoto(pbImage),
                        (MemoryTypesEnum)cbxMemoryTypeMobo.SelectedItem, (int)nudRamMobo.Value, (int)nudM2Mobo.Value, (int)nudSata3Mobo.Value, chbWifiMobo.Checked);
                            result = await productService.UpdateProductAsync(mb);
                            MessageBox.Show(result.Message, "Operation", MessageBoxButtons.OK, MessageBoxIcon.Information); break;
                        case 1:
                            var gpu = (GPU)uProduct;
                            gpu.Update(tbManuf.Text, tbName.Text, (double)nudPrice.Value, (int)nudStock.Value, (int)nudYear.Value, ProductTypesEnum.GPU, SavePhoto(pbImage),
                                (int)nudClockingSpeedGpu.Value, (int)nudPortsGpu.Value, (int)nudVideoRamGpu.Value, (int)nudFansGpu.Value, (BusTypesEnum)cbBusGpu.SelectedItem, (int)nudSizeGpu.Value);
                            result = await productService.UpdateProductAsync(gpu);
                            MessageBox.Show(result.Message, "Operation", MessageBoxButtons.OK, MessageBoxIcon.Information); break;
                        case 2:
                            var cpu = (CPU)uProduct;
                            cpu.Update(tbManuf.Text, tbName.Text, (double)nudPrice.Value, (int)nudStock.Value, (int)nudYear.Value, ProductTypesEnum.CPU, SavePhoto(pbImage),
                                (int)nudCPUCores.Value, (double)nudCPUClockSpeed.Value, tbSocketCpu.Text, (int)nudCPUThreads.Value);
                            result = await productService.UpdateProductAsync(cpu);
                            MessageBox.Show(result.Message, "Operation", MessageBoxButtons.OK, MessageBoxIcon.Information); break;
                        case 3:
                            var psu = (PSU)uProduct;
                            psu.Update(tbManuf.Text, tbName.Text, (double)nudPrice.Value, (int)nudStock.Value, (int)nudYear.Value, ProductTypesEnum.PowerSupply, SavePhoto(pbImage),
                                (int)nudOutputPsu.Value, cbxModular.Checked, tbCertificatePsu.Text);
                            result = await productService.UpdateProductAsync(psu);
                            MessageBox.Show(result.Message, "Operation", MessageBoxButtons.OK, MessageBoxIcon.Information); break;
                        case 4:
                            var pcase = (Case)uProduct;
                            pcase.Update(tbManuf.Text, tbName.Text, (double)nudPrice.Value, (int)nudStock.Value, (int)nudYear.Value, ProductTypesEnum.Case, SavePhoto(pbImage),
                                (FormFactorsEnum)cbFormCase.SelectedItem, (int)nudExpansioCase.Value, (int)nudFansCase.Value, (int)nudBaysCase.Value, (int)nudGraphCardCase.Value);
                            result = await productService.UpdateProductAsync(pcase);
                            MessageBox.Show(result.Message, "Operation", MessageBoxButtons.OK, MessageBoxIcon.Information); break;
                        case 5: MessageBox.Show("Cooler not implemented"); break;
                        case 6:
                            var ram = (RAM)uProduct;
                            ram.Update(tbManuf.Text, tbName.Text, (double)nudPrice.Value, (int)nudStock.Value, (int)nudYear.Value, ProductTypesEnum.RAM, SavePhoto(pbImage),
                                (int)nudSticksRam.Value, (int)nudGHzCompRam.Value, (int)nudMemorySpeedRam.Value, (int)nudInternalRam.Value, (MemoryTypesEnum)cbMemoryTypeRam.SelectedItem, (int)nudPinsRam.Value);
                            result = await productService.UpdateProductAsync(ram);
                            MessageBox.Show(result.Message, "Operation", MessageBoxButtons.OK, MessageBoxIcon.Information); break;
                        case 7: MessageBox.Show("Drives not implemented"); break;
                        default: MessageBox.Show("Not valid"); break;
                    }
                }
                PopulateListboxes();
                ResetBoxes();
            }
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            PopulateListboxes();
            ResetBoxes();
        }

        private async void btDelete_Click(object sender, EventArgs e)
        {
            var product = (Product)lbProducts.SelectedItem;
            if (product != null)
            {
                var result = await productService.DeleteProductAsync(product.Id);
                MessageBox.Show(result.Message, "Operation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please select a product", "Operation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PopulateListboxes();
                ResetBoxes();
            }
        }
    }
}
