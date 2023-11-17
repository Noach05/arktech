using ArkTech.Enumerations;
using ArkTech.Domains;
using static System.Net.Mime.MediaTypeNames;
using System.Security.Cryptography;
using System.Net.NetworkInformation;
using System;
using System.Net.Sockets;
using System.Threading;
using System.Globalization;
using ArkTech.Domains.SubProductDomains;
using System.Reflection;
using System.Drawing;
using Microsoft.AspNetCore.DataProtection;

namespace ArkTechWebApp.DTO
{
    public class ProductDTO
    {
        public ProductDTO() { }

        public ProductDTO(Product product) 
        {
            this.Id = product.Id;
            this.Brand = product.Brand;
            this.Model = product.Model;
            this.Price = product.Price;
            this.Stock = product.Stock;
            this.ReleaseYear = product.ReleaseYear;
            this.Type = product.Type;
            this.Image = product.Image;

            if (product.Type.Equals(ProductTypesEnum.RAM))
            {
                var ram = (RAM)product;
                this.Sticks = ram.Sticks;
                this.Memory = ram.Memory;
                this.MemorySpeed = ram.MemorySpeed;
                this.InternalRam = ram.InternalRam;
                this.RamMemoryType = ram.MemoryType;
                this.Pins = ram.Pins;
            }
            if(product.Type.Equals(ProductTypesEnum.PowerSupply))
            {
                var psu = (PSU)product;
                this.Output = psu.Output;
                this.IsModular = psu.IsModular;
                this.Certificate = psu.Certificate;
            }
            if(product.Type.Equals(ProductTypesEnum.Motherboard))
            {
                var mobo = (Motherboard)product;
                this.MoboMemoryType = mobo.MemoryType;
                this.RamSlots = mobo.RamSlots;
                this.M2Slots = mobo.M2Slots;
                this.Sata3Ports = mobo.Sata3Ports;
                this.IsWifiCapable = mobo.IsWifiCapable;
            }
            if(product.Type.Equals(ProductTypesEnum.GPU))
            {
                var gpu = (GPU)product;
                this.GpuClockSpeed = gpu.ClockSpeed;
                this.DisplayPorts = gpu.DisplayPorts;
                this.VideoRam = gpu.VideoRam;
                this.Fans = gpu.Fans;
                this.BusType = gpu.BusType;
                this.Size = gpu.Size;
            }
            if(product.Type.Equals(ProductTypesEnum.CPU))
            {
                var cpu = (CPU)product;
                this.Cores = cpu.Cores;
                this.CpuClockSpeed = cpu.ClockSpeed;
                this.Socket = cpu.Socket;
                this.Threads = cpu.Threads;
            }
            if(product.Type.Equals(ProductTypesEnum.Case))
            {
                var cas = (Case)product;
                this.FormFactor = cas.FormFactor;
                this.ExpansionSlots = cas.ExpansionSlots;
                this.CaseFans = cas.CaseFans;
                this.DriveBays = cas.DriveBays;
                this.GpuSize = cas.GpuSize;
            }
            
        }

        

        //Product
        public Guid Id { get; private set; }
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public string Name
        {
            get { return String.Format($"{Brand} {Model}"); }
        }
        public double Price { get; private set; }
        public int Stock { get; private set; }
        public int ReleaseYear { get; private set; }
        public ProductTypesEnum Type { get; private set; }
        public byte[] Image { get; private set; }
        //Ram
        public int Sticks { get; private set; }
        public int Memory { get; private set; }
        public int MemorySpeed { get; private set; }
        public int InternalRam { get; private set; }
        public MemoryTypesEnum RamMemoryType { get; private set; }
        public int Pins { get; private set; }
        //Psu
        public int Output { get; private set; }
        public bool IsModular { get; private set; }
        public string Certificate { get; private set; }
        //Mobo
        public MemoryTypesEnum MoboMemoryType { get; private set; }
        public int RamSlots { get; private set; }
        public int M2Slots { get; private set; }
        public int Sata3Ports { get; private set; }
        public bool IsWifiCapable { get; private set; }
        //Gpu
        public int GpuClockSpeed { get; private set; }
        public int DisplayPorts { get; private set; }
        public int VideoRam { get; private set; }
        public int Fans { get; private set; }
        public int Size { get; private set; }
        public BusTypesEnum BusType { get; private set; }
        //Cpu
        public int Cores { get; private set; }
        public double CpuClockSpeed { get; private set; }
        public string Socket { get; private set; }
        public int Threads { get; private set; }
        //Case
        public FormFactorsEnum FormFactor { get; private set; }
        public int ExpansionSlots { get; private set; }
        public int CaseFans { get; private set; }
        public int DriveBays { get; private set; }
        public int GpuSize { get; private set; }
    }
}
