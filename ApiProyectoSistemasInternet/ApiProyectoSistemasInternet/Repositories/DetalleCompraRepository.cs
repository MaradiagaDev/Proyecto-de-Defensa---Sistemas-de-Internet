using ApiProyectoSistemasInternet.IServices;
using ApiProyectoSistemasInternet.ModelsFarmaciaBD;

namespace ApiProyectoSistemasInternet.Repositories
{
    public class DetalleCompraRepository : IAuxRepository<DetalleCompra>
    {
        public bool DeleteObject(object ID)
        {
            try
            {
                using (BaseFarmaciaContext db = new BaseFarmaciaContext())
                {
                    var detalleCompra = db.DetalleCompras.Find(ID);
                    if (detalleCompra != null)
                    {
                        db.DetalleCompras.Remove(detalleCompra);
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

        public GetAllResponse<DetalleCompra> GetAllObjects(int offSet, int pageSize)
        {
            try
            {
                using (BaseFarmaciaContext db = new BaseFarmaciaContext())
                {
                    var detallesCompra = db.DetalleCompras
                                           .Skip(offSet * pageSize)
                                           .Take(pageSize)
                                           .ToList();

                    return new GetAllResponse<DetalleCompra>
                    {
                        statusCode = 200,
                        isExitoso = true,
                        resultado = detallesCompra,
                        totalPaginas = (int)Math.Ceiling(db.DetalleCompras.Count() / (double)pageSize)
                    };
                }
            }
            catch (Exception ex)
            {
                return new GetAllResponse<DetalleCompra>
                {
                    statusCode = 500,
                    isExitoso = false,
                    errorMessages = new List<object> { ex.Message }
                };
            }
        }

        public GetOneResponse<DetalleCompra> GetObjectById(object ID)
        {
            try
            {
                using (BaseFarmaciaContext db = new BaseFarmaciaContext())
                {
                    var detalleCompra = db.DetalleCompras.Find(ID);
                    if (detalleCompra != null)
                    {
                        return new GetOneResponse<DetalleCompra>
                        {
                            statusCode = 200,
                            isExitoso = true,
                            resultado = detalleCompra
                        };
                    }
                    return new GetOneResponse<DetalleCompra>
                    {
                        statusCode = 404,
                        isExitoso = false,
                        errorMessages = new List<object> { "DetalleCompra no encontrada" }
                    };
                }
            }
            catch (Exception ex)
            {
                return new GetOneResponse<DetalleCompra>
                {
                    statusCode = 500,
                    isExitoso = false,
                    errorMessages = new List<object> { ex.Message }
                };
            }
        }

        public GetOneResponse<DetalleCompra> UpdateCreateObject(DetalleCompra obj)
        {
            try
            {
                using (BaseFarmaciaContext db = new BaseFarmaciaContext())
                {
                    var detalleCompra = db.DetalleCompras.Find(obj.IdDetalleCompra);

                    if (detalleCompra == null)
                    {
                        db.DetalleCompras.Add(obj);
                        db.SaveChanges();
                        return new GetOneResponse<DetalleCompra>
                        {
                            statusCode = 201,
                            isExitoso = true,
                            resultado = obj
                        };
                    }
                    else
                    {
                        detalleCompra.Cantidad = obj.Cantidad;
                        detalleCompra.Precio = obj.Precio;
                        detalleCompra.SubTotal = obj.SubTotal;
                        detalleCompra.IdCompra = obj.IdCompra;

                        db.SaveChanges();
                        return new GetOneResponse<DetalleCompra>
                        {
                            statusCode = 200,
                            isExitoso = true,
                            resultado = detalleCompra
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                return new GetOneResponse<DetalleCompra>
                {
                    statusCode = 500,
                    isExitoso = false,
                    errorMessages = new List<object> { ex.Message }
                };
            }
        }
    }

}
