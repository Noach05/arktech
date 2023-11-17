using ArkTech.Domains;
using ArkTech.Domains.SubProductDomains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkTechDAL
{
    public class AddParametersWithValues
    {
        public void AddWithValueProduct(Product nProduct, SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@id", nProduct.Id);
            cmd.Parameters.AddWithValue("@brand", nProduct.Brand);
            cmd.Parameters.AddWithValue("@model", nProduct.Model);
            cmd.Parameters.AddWithValue("@price", nProduct.Price);
            cmd.Parameters.AddWithValue("@stock", nProduct.Stock);
            cmd.Parameters.AddWithValue("@releaseyear", nProduct.ReleaseYear);
            cmd.Parameters.AddWithValue("@type", ((int)nProduct.Type));
            cmd.Parameters.AddWithValue("@image", nProduct.Image);
        }
        public void AddWithValueMb(Product nProduct, SqlCommand cmd)
        {
            var mb = (Motherboard)nProduct;
            cmd.Parameters.AddWithValue("@mbmemtype", (int)mb.MemoryType);
            cmd.Parameters.AddWithValue("@mbram", mb.RamSlots);
            cmd.Parameters.AddWithValue("@mbm2", mb.M2Slots);
            cmd.Parameters.AddWithValue("@mbsata3", mb.Sata3Ports);
            cmd.Parameters.AddWithValue("@mbwifi", mb.IsWifiCapable);
        }
        public void AddWithValueGpu(Product nProduct, SqlCommand cmd)
        {
            var gpu = (GPU)nProduct;
            cmd.Parameters.AddWithValue("@gpuclock", gpu.ClockSpeed);
            cmd.Parameters.AddWithValue("@gpudisplay", gpu.DisplayPorts);
            cmd.Parameters.AddWithValue("@gpuram", gpu.VideoRam);
            cmd.Parameters.AddWithValue("@gpufans", gpu.Fans);
            cmd.Parameters.AddWithValue("@gpubus", ((int)gpu.BusType));
            cmd.Parameters.AddWithValue("@gpusize", gpu.Size);
        }
        public void AddWithValueCpu(Product nProduct, SqlCommand cmd)
        {
            var cpu = (CPU)nProduct;
            cmd.Parameters.AddWithValue("@cpucores", cpu.Cores);
            cmd.Parameters.AddWithValue("@cpuclock", cpu.ClockSpeed);
            cmd.Parameters.AddWithValue("@cpusocket", cpu.Socket);
            cmd.Parameters.AddWithValue("@cputhreads", cpu.Threads);
        }
        public void AddWithValuePsu(Product nProduct, SqlCommand cmd)
        {
            var psu = (PSU)nProduct;
            cmd.Parameters.AddWithValue("@psuout", psu.Output);
            cmd.Parameters.AddWithValue("@psumodular", psu.IsModular);
            cmd.Parameters.AddWithValue("@psucertificate", psu.Certificate);
        }
        public void AddWithValueCase(Product nProduct, SqlCommand cmd)
        {
            var pcase = (Case)nProduct;
            cmd.Parameters.AddWithValue("@caseform", pcase.FormFactor);
            cmd.Parameters.AddWithValue("@caseexpansion", pcase.ExpansionSlots);
            cmd.Parameters.AddWithValue("@casefans", pcase.CaseFans);
            cmd.Parameters.AddWithValue("@casedrives", pcase.DriveBays);
            cmd.Parameters.AddWithValue("@casegpusize", pcase.GpuSize);
        }
        public void AddWithValueRam(Product nProduct, SqlCommand cmd)
        {
            var ram = (RAM)nProduct;
            cmd.Parameters.AddWithValue("@ramsticks", ram.Sticks);
            cmd.Parameters.AddWithValue("@rammem", ram.Memory);
            cmd.Parameters.AddWithValue("@ramspeed", ram.MemorySpeed);
            cmd.Parameters.AddWithValue("@raminternal", ram.InternalRam);
            cmd.Parameters.AddWithValue("@rammemtype", ((int)ram.MemoryType));
            cmd.Parameters.AddWithValue("@rampins", ram.Pins);
        }
    }
}
