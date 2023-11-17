using ArkTech.Domains;
using ArkTech.Domains.SubProductDomains;
using ArkTech.Enumerations;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ArkTechDAL
{
    internal class Mappers
    {
        public User MapUserFromDB(SqlDataReader r)
        {
            int active = (int)r["IsActivated"];
            bool isActivated;
            if (active == 1) { isActivated = true; } else { isActivated = false; }
            return new User(
                (Guid)r["UID"],
                (string)r["FirstName"],
                (string)r["LastName"],
                (string)r["Email"],
                (string)r["Phone"],
                (string)r["Adress"],
                (int)r["AuthorisationLevel"],
                (byte[])r["Salt"],
                (byte[])r["HashedPassword"],
                isActivated
                );
        }
        public Product MapProductFromDB(SqlDataReader r)
        {
            ProductTypesEnum type = ProductTypesEnum.Motherboard;
            switch ((int)r["Type"])
            {
                case 0: type = ProductTypesEnum.Motherboard; break;
                case 1: type = ProductTypesEnum.GPU; break;
                case 2: type = ProductTypesEnum.CPU; break;
                case 3: type = ProductTypesEnum.PowerSupply; break;
                case 4: type = ProductTypesEnum.Case; break;
                case 5: type = ProductTypesEnum.Cooler; break;
                case 6: type = ProductTypesEnum.RAM; break;
                case 7: type = ProductTypesEnum.Drive; break;
                default: type = ProductTypesEnum.Motherboard; break;
            }
            return new Product(
                (Guid)r["ID"],
                (string)r["Brand"],
                (string)r["Model"],
                (double)r["Price"],
                (int)r["Stock"],
                (int)r["ReleaseYear"],
                type,
                (byte[])r["Image"]
                );
        }
        public Motherboard MapMBFromDB(SqlDataReader r, Product product)
        {
            MemoryTypesEnum memType = MemoryTypesEnum.DDR4;
            switch ((int)r["MbMemoryType"])
            {
                case 0: memType = MemoryTypesEnum.DDR3; break;
                case 1: memType = MemoryTypesEnum.DDR4; break;
                case 2: memType = MemoryTypesEnum.DDR5; break;
                default: memType = MemoryTypesEnum.DDR4; break;
            }
            return new Motherboard(
                product,
                memType,
                (int)r["MbRamSlots"],
                (int)r["MbM2Slots"],
                (int)r["MbSata3Slots"],
                (bool)r["MbIsWifiCapable"]
                );
        }
        public CPU MapCPUFromDB(SqlDataReader r, Product product)
        {
            return new CPU(
                product,
                (int)r["CpuCores"],
                (double)r["CpuClockSpeed"],
                (string)r["CpuSocket"],
                (int)r["CpuThreads"]
                );
        }
        public RAM MapRAMFromDB(SqlDataReader r, Product product)
        {
            MemoryTypesEnum memType = MemoryTypesEnum.DDR4;
            switch ((int)r["RamMemoryType"])
            {
                case 0: memType = MemoryTypesEnum.DDR3; break;
                case 1: memType = MemoryTypesEnum.DDR4; break;
                case 2: memType = MemoryTypesEnum.DDR5; break;
                default: memType = MemoryTypesEnum.DDR4; break;
            }
            return new RAM(
                product,
                (int)r["RamSticks"],
                (int)r["RamMemory"],
                (int)r["RamMemorySpeed"],
                (int)r["RamInternal"],
                memType,
                (int)r["RamPins"]
                );
        }
        public GPU MapGPUFromDB(SqlDataReader r, Product product)
        {
            BusTypesEnum busType = BusTypesEnum.PCI;
            switch ((int)r["GpuBusType"])
            {
                case 0: busType = BusTypesEnum.PCI; break;
                case 1: busType = BusTypesEnum.AGP; break;
                case 2: busType = BusTypesEnum.PCIExpress; break;
                default: busType = BusTypesEnum.PCI; break;
            }
            return new GPU(
                product,
                (int)r["GpuClockSpeed"],
                (int)r["GpuDisplayPorts"],
                (int)r["GpuVideoRam"],
                (int)r["GpuFans"],
                busType,
                (int)r["GpuSize"]
                );
        }
        public PSU MapPSUFromDB(SqlDataReader r, Product product)
        {
            return new PSU(
                product,
                (int)r["PsuOutput"],
                (bool)r["PsuModular"],
                (string)r["PsuCertificate"]
                );
        }
        public Case MapCaseFromDB(SqlDataReader r, Product product)
        {
            FormFactorsEnum formFactor = FormFactorsEnum.FullTower;
            switch ((int)r["CaseFormFactor"])
            {
                case 0: formFactor = FormFactorsEnum.FullTower; break;
                case 1: formFactor = FormFactorsEnum.MidTower; break;
                case 2: formFactor = FormFactorsEnum.MiniTower; break;
                case 3: formFactor = FormFactorsEnum.Desktop; break;
                case 4: formFactor = FormFactorsEnum.SFF; break;
                case 5: formFactor = FormFactorsEnum.USFF; break;
                default: formFactor = FormFactorsEnum.FullTower; break;
            }
            return new Case(
                product,
                formFactor,
                (int)r["CaseExpansionSlots"],
                (int)r["CaseFans"],
                (int)r["CaseDriveBays"],
                (int)r["CaseGpuSize"]
                );
        }
    }
}
