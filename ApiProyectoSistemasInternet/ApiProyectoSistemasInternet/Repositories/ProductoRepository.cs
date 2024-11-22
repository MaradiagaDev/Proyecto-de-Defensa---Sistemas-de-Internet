using ApiProyectoSistemasInternet.IServices;
using ApiProyectoSistemasInternet.ModelsFarmaciaBD;

namespace ApiProyectoSistemasInternet.Repositories
{
    public class ProductoRepository : IAuxRepository<Producto>
    {
        public bool DeleteObject(object ID)
        {
            try
            {
                using (BaseFarmaciaContext db = new BaseFarmaciaContext())
                {
                    var producto = db.Productos.Find(ID);
                    if (producto != null)
                    {
                        db.Productos.Remove(producto);
                        db.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public GetAllResponse<Producto> GetAllObjects(int offSet, int pageSize)
        {
            try
            {
                using (BaseFarmaciaContext db = new BaseFarmaciaContext())
                {
                    var productos = db.Productos
                                      .Skip(offSet * pageSize)
                                      .Take(pageSize)
                                      .ToList();

                    return new GetAllResponse<Producto>
                    {
                        statusCode = 200,
                        isExitoso = true,
                        resultado = productos,
                        totalPaginas = (int)Math.Ceiling(db.Productos.Count() / (double)pageSize)
                    };
                }
            }
            catch (Exception ex)
            {
                return new GetAllResponse<Producto>
                {
                    statusCode = 500,
                    isExitoso = false,
                    errorMessages = new List<object> { ex.Message }
                };
            }
        }

        public GetOneResponse<Producto> GetObjectById(object ID)
        {
            try
            {
                using (BaseFarmaciaContext db = new BaseFarmaciaContext())
                {
                    var producto = db.Productos.Find(ID);
                    if (producto != null)
                    {
                        return new GetOneResponse<Producto>
                        {
                            statusCode = 200,
                            isExitoso = true,
                            resultado = producto
                        };
                    }
                    return new GetOneResponse<Producto>
                    {
                        statusCode = 404,
                        isExitoso = false,
                        errorMessages = new List<object> { "Producto no encontrado" }
                    };
                }
            }
            catch (Exception ex)
            {
                return new GetOneResponse<Producto>
                {
                    statusCode = 500,
                    isExitoso = false,
                    errorMessages = new List<object> { ex.Message }
                };
            }
        }

        public GetOneResponse<Producto> UpdateCreateObject(Producto obj)
        {
            try
            {
                using (BaseFarmaciaContext db = new BaseFarmaciaContext())
                {
                    var producto = db.Productos.Find(obj.IdProducto);

                    if (producto == null)
                    {
                        db.Productos.Add(obj);
                        db.SaveChanges();
                        return new GetOneResponse<Producto>
                        {
                            statusCode = 201,
                            isExitoso = true,
                            resultado = obj
                        };
                    }
                    else
                    {
                        producto.Concentracion = obj.Concentracion;
                        producto.UnidadMedida = obj.UnidadMedida;
                        producto.DescripcionProducto = obj.DescripcionProducto;
                        producto.EstadoProducto = obj.EstadoProducto;
                        producto.FechaFabricacion = obj.FechaFabricacion;
                        producto.FechaVencimiento = obj.FechaVencimiento;
                        producto.IdCategoria = obj.IdCategoria;
                        producto.IdProveedor = obj.IdProveedor;
                        producto.IdPresentacion = obj.IdPresentacion;
                        producto.IdRubro = obj.IdRubro;
                        producto.IdTipoProducto = obj.IdTipoProducto;
                        producto.MargenGanancias = obj.MargenGanancias;
                        producto.NombreProducto = obj.NombreProducto;
                        producto.PrecioCompra = obj.PrecioCompra;
                        producto.PrecioVenta = obj.PrecioVenta;
                        producto.StockMinimo = obj.StockMinimo;
                        producto.StockMaximo = obj.StockMaximo;
                        producto.StockMedio = obj.StockMedio;
                        producto.FechaRegistro = obj.FechaRegistro;

                        db.SaveChanges();
                        return new GetOneResponse<Producto>
                        {
                            statusCode = 200,
                            isExitoso = true,
                            resultado = producto
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                return new GetOneResponse<Producto>
                {
                    statusCode = 500,
                    isExitoso = false,
                    errorMessages = new List<object> { ex.Message }
                };
            }
        }

        public bool UpdateEstadoProducto(int idProducto, bool nuevoEstado)
        {
            using (BaseFarmaciaContext db = new BaseFarmaciaContext())
            {
                var producto = db.Productos.Find(idProducto);
                if (producto != null)
                {
                    producto.EstadoProducto = nuevoEstado;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }

    }
}
