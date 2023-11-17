using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkTechDAL.Queries
{
    public class ProductQuery
    {
        public const string GetAll = "SELECT * FROM PRODUCTS;";
        public const string Create = "USE dbi511127_arktech " +
            "INSERT INTO PRODUCTS (ID, Brand, Model, Price, Stock, ReleaseYear, Type, Image, ColumnNames) " +
            "values (@id, @brand, @model, @price, @stock, @releaseyear, @type, @image, ValueNames);";

        public const string MotherboardColumnNames = "MbMemoryType, MbRamSlots, MbM2Slots, MbSata3Slots, MbIsWifiCapable";
        public const string MotherboardValueNames = "@mbmemtype, @mbram, @mbm2, @mbsata3, @mbwifi";

        public const string CpuColumnNames = "CpuCores, CpuClockSpeed, CpuSocket, CpuThreads";
        public const string CpuValueNames = "@cpucores, @cpuclock, @cpusocket, @cputhreads";

        public const string RamColumnNames = "RamSticks, RamMemory, RamMemorySpeed, RamInternal, RamMemoryType, RamPins";
        public const string RamValueNames = "@ramsticks, @rammem, @ramspeed, @raminternal, @rammemtype, @rampins";

        public const string GpuColumnNames = "GpuClockSpeed, GpuDisplayPorts, GpuVideoRam, GpuFans, GpuBusType, GpuSize";
        public const string GpuValueNames = "@gpuclock, @gpudisplay, @gpuram, @gpufans, @gpubus, @gpusize";

        public const string PsuColumnNames = "PsuOutput, PsuModular, PsuCertificate";
        public const string PsuValueNames = "@psuout, @psumodular, @psucertificate";

        public const string CaseColumnNames = "CaseFormFactor, CaseExpansionSlots, CaseFans, CaseDriveBays, CaseGpuSize";
        public const string CaseValueNames = "@caseform, @caseexpansion, @casefans, @casedrives, @casegpusize";

        public const string UpdateProductBrandAndModel = "UPDATE PRODUCTS SET Brand = @brand, Model = @model, " +
            "Price = @price WHERE ID = @id;";
        public const string UpdateProductStock = "UPDATE PRODUCTS SET Stock = @stock WHERE ID = @id;";
        public const string UpdateProductPrice = "UPDATE PRODUCTS SET Price = @price WHERE ID = @id;";
        public const string UpdateProductReleaseYear = "UPDATE PRODUCTS SET ReleaseYear = @releaseyear WHERE ID = @id;";
        public const string UpdateProductImage = "UPDATE PRODUCTS SET Image = @image WHERE ID = @id;";
        public const string UpdateMotherboard = "UPDATE PRODUCTS SET MbMemoryType = @mbmemtype, MbRamSlots = @mbram, " +
            "MbM2Slots = @mbm2, MbSata3Slots = @mbsata3, MbIsWifiCapable = @mbwifi WHERE ID = @id;";
        public const string UpdateCpu = "UPDATE PRODUCTS SET CpuCores = @cpucores, CpuClockSpeed = @cpuclock, " +
            "CpuSocket = @cpusocket, CpuThreads = @cputhreads WHERE ID = @id;";
        public const string UpdateRam = "UPDATE PRODUCTS SET RamSticks = @ramsticks, RamMemory = @rammem, RamMemorySpeed = @ramspeed, " +
            "RamInternal = @raminternal, RamMemoryType = @rammemtype, RamPins = @rampins WHERE ID = @id;";
        public const string UpdateGpu = "UPDATE PRODUCTS SET GpuClockSpeed = @gpuclock, GpuDisplayPorts = @gpudisplay, " +
            "GpuVideoRam = @gpuram, GpuFans = @gpufans, GpuBusType = @gpubus, GpuSize = @gpusize WHERE ID = @id;";
        public const string UpdatePsu = "UPDATE PRODUCTS SET PsuOutput = @psuout, PsuModular = @psumodular, PsuCertificate = @psucertificate " +
            "WHERE ID = @id;";
        public const string UpdateCase = "UPDATE PRODUCTS SET CaseFormFactor = @caseform, CaseExpansionSlots = @caseexpansion, " +
            "CaseFans = @casefans, CaseDriveBays = @casedrives, CaseGpuSize = @casegpusize WHERE ID = @id;";

        public const string ProductDelete = "DELETE FROM PRODUCTS * WHERE ID = @id;"; 
        public const string GetById = "SELECT * FROM PRODUCTS WHERE ID = @id;";
    }
}
