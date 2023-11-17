using ArkTech.Domains;
using ArkTech.Domains.SubProductDomains;
using ArkTech.Enumerations;
using ArkTech.Interfaces;
using ArkTechDAL.Queries;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ArkTechDAL.Repositories
{
    public class ProductRepository : ProductQuery, IProductRepo
    {
        private SqlConnection _con;
        private BaseConnection _baseCon = new BaseConnection();
        private List<Product> _products = new List<Product>();
        private readonly Mappers _mappers = new Mappers();
        private readonly AddParametersWithValues _addParameters = new AddParametersWithValues();
        private SqlExceptionLogger logger = new SqlExceptionLogger();

        public ProductRepository()
        {
            _con = _baseCon.GetSqlConnection();
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            _products.Clear();
            try
            {
                await _con.OpenAsync();
                SqlCommand cmd = new SqlCommand(GetAll, _con);
                SqlDataReader r = await cmd.ExecuteReaderAsync();
                while (await r.ReadAsync().ConfigureAwait(false))
                {
                    if (r.HasRows)
                    {
                        Product product = _mappers.MapProductFromDB(r);
                        switch ((int)product.Type)
                        {
                            case 0: _products.Add(_mappers.MapMBFromDB(r, product)); break;
                            case 1: _products.Add(_mappers.MapGPUFromDB(r, product)); break;
                            case 2: _products.Add(_mappers.MapCPUFromDB(r, product)); break;
                            case 3: _products.Add(_mappers.MapPSUFromDB(r, product)); break;
                            case 4: _products.Add(_mappers.MapCaseFromDB(r, product)); break;
                            case 5: throw new NotImplementedException("Coolers not implemented");
                            case 6: _products.Add(_mappers.MapRAMFromDB(r, product)); break;
                            case 7: throw new NotImplementedException("Drives not implemented");
                            default: throw new InvalidOperationException("No valid data found; Product type invalid; Switch statement defaulted.");
                        }
                    }
                    else
                    {
                        return new List<Product>();
                    }
                }
                return _products;
            }
            catch (SqlException ex)
            {
                logger.LogSqlException(ex);
                return new List<Product>();
            }
            finally { _con.Close(); }
        }

        public async Task<Result> CreateProductAsync(Product nProduct)
        {
            try
            {
                await _con.OpenAsync();
                SqlCommand cmd;
                string query = Create;
                string replaceColumn = @"\bColumnNames\b";
                string replaceValues = @"\bValueNames\b";
                string endQuery = string.Empty;
                if (nProduct.Type == ProductTypesEnum.Motherboard)
                {
                    endQuery = Regex.Replace(query, replaceColumn, MotherboardColumnNames);
                    endQuery = Regex.Replace(endQuery, replaceValues, MotherboardValueNames);

                    if (string.IsNullOrWhiteSpace(endQuery)) { return new Result(false, "Failed to create query for Motherboard"); }

                    cmd = new SqlCommand(endQuery, _con);
                    _addParameters.AddWithValueProduct(nProduct, cmd);
                    _addParameters.AddWithValueMb(nProduct, cmd);
                }
                else if (nProduct.Type == ProductTypesEnum.GPU)
                {
                    endQuery = Regex.Replace(query, replaceColumn, GpuColumnNames);
                    endQuery = Regex.Replace(endQuery, replaceValues, GpuValueNames);

                    if (string.IsNullOrWhiteSpace(endQuery)) { return new Result(false, "Failed to create query for Gpu"); }

                    cmd = new SqlCommand(endQuery, _con);
                    _addParameters.AddWithValueProduct(nProduct, cmd);
                    _addParameters.AddWithValueGpu(nProduct, cmd);
                }
                else if (nProduct.Type == ProductTypesEnum.CPU)
                {
                    endQuery = Regex.Replace(query, replaceColumn, CpuColumnNames);
                    endQuery = Regex.Replace(endQuery, replaceValues, CpuValueNames);

                    if (string.IsNullOrWhiteSpace(endQuery)) { return new Result(false, "Failed to create query for Cpu"); }

                    cmd = new SqlCommand(endQuery, _con);
                    _addParameters.AddWithValueProduct(nProduct, cmd);
                    _addParameters.AddWithValueCpu(nProduct, cmd);
                }
                else if (nProduct.Type == ProductTypesEnum.PowerSupply)
                {
                    endQuery = Regex.Replace(query, replaceColumn, PsuColumnNames);
                    endQuery = Regex.Replace(endQuery, replaceValues, PsuValueNames);

                    if (string.IsNullOrWhiteSpace(endQuery)) { return new Result(false, "Failed to create query for Psu"); }

                    cmd = new SqlCommand(endQuery, _con);
                    _addParameters.AddWithValueProduct(nProduct, cmd);
                    _addParameters.AddWithValuePsu(nProduct, cmd);
                }
                else if (nProduct.Type == ProductTypesEnum.Case)
                {
                    endQuery = Regex.Replace(query, replaceColumn, CaseColumnNames);
                    endQuery = Regex.Replace(endQuery, replaceValues, CaseValueNames);

                    if (string.IsNullOrWhiteSpace(endQuery)) { return new Result(false, "Failed to create query for Case"); }

                    cmd = new SqlCommand(endQuery, _con);
                    _addParameters.AddWithValueProduct(nProduct, cmd);
                    _addParameters.AddWithValueCase(nProduct, cmd);
                }
                else if (nProduct.Type == ProductTypesEnum.RAM)
                {
                    endQuery = Regex.Replace(query, replaceColumn, RamColumnNames);
                    endQuery = Regex.Replace(endQuery, replaceValues, RamValueNames);

                    if (string.IsNullOrWhiteSpace(endQuery)) { return new Result(false, "Failed to create query for Ram"); }

                    cmd = new SqlCommand(endQuery, _con);
                    _addParameters.AddWithValueProduct(nProduct, cmd);
                    _addParameters.AddWithValueRam(nProduct, cmd);
                }
                else if (nProduct.Type == ProductTypesEnum.Cooler)
                {
                    throw new NotImplementedException("Create Cooler is not implemented");
                }
                else if (nProduct.Type == ProductTypesEnum.Drive)
                {
                    throw new NotImplementedException("Create Drive is not implemented");
                }
                else { throw new InvalidDataException("Provided data is invalid for creating products"); }

                await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
                return new Result(true, $"Successfully added {nProduct.Name} to database");
            }
            catch (SqlException ex)
            {
                logger.LogSqlException(ex);
                return new Result(false, $"Something went wrong creating a product, {ex.Message}");
            }
            finally { _con.Close(); }
        }
        public async Task<Result> UpdateProductAsync(Product product)
        {
            try
            {
                _con.Open();
                string query = String.Concat(UpdateProductBrandAndModel, UpdateProductStock, UpdateProductPrice, UpdateProductReleaseYear, UpdateProductImage);
                SqlCommand cmd;
                switch ((int)product.Type)
                {
                    case 0: query += UpdateMotherboard;
                        if (string.IsNullOrWhiteSpace(query)) { return new Result(false, "Failed to create query for Motherboard; Query empty or null"); }
                        if (!query.Contains(UpdateProductBrandAndModel) || !query.Contains(UpdateProductStock) || !query.Contains(UpdateProductPrice) 
                            || !query.Contains(UpdateProductReleaseYear) || !query.Contains(UpdateProductImage) || !query.Contains(UpdateMotherboard)) 
                        { return new Result(false, "Failed to create query for Motherboard; Query does not contain all required queries"); }
                        cmd = new SqlCommand(query, _con);
                        _addParameters.AddWithValueProduct(product, cmd);
                        _addParameters.AddWithValueMb(product, cmd);
                        break;
                    case 1: query += UpdateGpu;
                        if (string.IsNullOrWhiteSpace(query)) { return new Result(false, "Failed to create query for Gpu"); }
                        if (!query.Contains(UpdateProductBrandAndModel) || !query.Contains(UpdateProductStock) || !query.Contains(UpdateProductPrice)
                            || !query.Contains(UpdateProductReleaseYear) || !query.Contains(UpdateProductImage) || !query.Contains(UpdateGpu))
                        { return new Result(false, "Failed to create query for Gpu; Query does not contain all required queries"); }
                        cmd = new SqlCommand(query, _con);
                        _addParameters.AddWithValueProduct(product, cmd);
                        _addParameters.AddWithValueGpu(product, cmd);
                        break;
                    case 2: query += UpdateCpu;
                        if (string.IsNullOrWhiteSpace(query)) { return new Result(false, "Failed to create query for Cpu"); }
                        if (!query.Contains(UpdateProductBrandAndModel) || !query.Contains(UpdateProductStock) || !query.Contains(UpdateProductPrice)
                            || !query.Contains(UpdateProductReleaseYear) || !query.Contains(UpdateProductImage) || !query.Contains(UpdateCpu))
                        { return new Result(false, "Failed to create query for Cpu; Query does not contain all required queries"); }
                        cmd = new SqlCommand(query, _con);
                        _addParameters.AddWithValueProduct(product, cmd);
                        _addParameters.AddWithValueCpu(product, cmd);
                        break;
                    case 3: query += UpdatePsu;
                        if (string.IsNullOrWhiteSpace(query)) { return new Result(false, "Failed to create query for Psu"); }
                        if (!query.Contains(UpdateProductBrandAndModel) || !query.Contains(UpdateProductStock) || !query.Contains(UpdateProductPrice)
                            || !query.Contains(UpdateProductReleaseYear) || !query.Contains(UpdateProductImage) || !query.Contains(UpdatePsu))
                        { return new Result(false, "Failed to create query for Psu; Query does not contain all required queries"); }
                        cmd = new SqlCommand(query, _con);
                        _addParameters.AddWithValueProduct(product, cmd);
                        _addParameters.AddWithValuePsu(product, cmd);
                        break;
                    case 4: query += UpdateCase;
                        if (string.IsNullOrWhiteSpace(query)) { return new Result(false, "Failed to create query for Case"); }
                        if (!query.Contains(UpdateProductBrandAndModel) || !query.Contains(UpdateProductStock) || !query.Contains(UpdateProductPrice)
                            || !query.Contains(UpdateProductReleaseYear) || !query.Contains(UpdateProductImage) || !query.Contains(UpdateCase))
                        { return new Result(false, "Failed to create query for Case; Query does not contain all required queries"); }
                        cmd = new SqlCommand(query, _con);
                        _addParameters.AddWithValueProduct(product, cmd);
                        _addParameters.AddWithValueCase(product, cmd);
                        break;
                    case 5: throw new NotImplementedException("Updating coolers is not implemented");
                    case 6: query += UpdateRam;
                        if (string.IsNullOrWhiteSpace(query)) { return new Result(false, "Failed to create query for Ram"); }
                        if (!query.Contains(UpdateProductBrandAndModel) || !query.Contains(UpdateProductStock) || !query.Contains(UpdateProductPrice)
                            || !query.Contains(UpdateProductReleaseYear) || !query.Contains(UpdateProductImage) || !query.Contains(UpdateRam))
                        { return new Result(false, "Failed to create query for Ram; Query does not contain all required queries"); }
                        cmd = new SqlCommand(query, _con);
                        _addParameters.AddWithValueProduct(product, cmd);
                        _addParameters.AddWithValueRam(product, cmd);
                        break;
                    case 7: throw new NotImplementedException("Updating drives is not implemented");
                    default: cmd = new SqlCommand(query, _con); _addParameters.AddWithValueProduct(product, cmd); break;
                }
                await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
                return new Result(true, $"Successfully updated {product.Name} in database");
            }
            catch (SqlException ex)
            {
                logger.LogSqlException(ex);
                return new Result(false, $"Something went wrong updating a product, {ex.Message}");
            }
            finally { _con.Close(); }
        }
        public async Task<Result> DeleteProductAsync(Guid id)
        {
            try
            {
                await _con.OpenAsync();
                SqlCommand cmd = new SqlCommand(ProductDelete, _con);
                cmd.Parameters.AddWithValue("@id", id);
                await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
                return new Result(true, "Successfully deleted product");
            } 
            catch (SqlException ex) 
            {
                logger.LogSqlException(ex);
                return new Result(false, $"Something went wrong deleting a product, {ex.Message}");
            }
            finally { _con.Close(); }
        }
        public async Task<Product> GetProductById(Guid id)
        {
            try
            {
                await _con.OpenAsync();
                SqlCommand cmd = new SqlCommand(GetById, _con);
                cmd.Parameters.AddWithValue("@id", id);
                await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);

                SqlDataReader r = await cmd.ExecuteReaderAsync();
                await r.ReadAsync().ConfigureAwait(false);
                if (r.HasRows)
                {
                    Product product = _mappers.MapProductFromDB(r);
                    switch ((int)product.Type)
                    {
                        case 0: return _mappers.MapMBFromDB(r, product);
                        case 1: return _mappers.MapGPUFromDB(r, product);
                        case 2: return _mappers.MapCPUFromDB(r, product);
                        case 3: return _mappers.MapPSUFromDB(r, product);
                        case 4: return _mappers.MapCaseFromDB(r, product);
                        case 5: throw new NotImplementedException("Coolers not implemented");
                        case 6: return _mappers.MapRAMFromDB(r, product);
                        case 7: throw new NotImplementedException("Drives not implemented");
                        default: throw new InvalidOperationException("No valid data found; Product type invalid; Switch statement defaulted.");
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException ex)
            {
                logger.LogSqlException(ex);
                return null;
            }
            finally { _con.Close(); }
        }
    }
}
