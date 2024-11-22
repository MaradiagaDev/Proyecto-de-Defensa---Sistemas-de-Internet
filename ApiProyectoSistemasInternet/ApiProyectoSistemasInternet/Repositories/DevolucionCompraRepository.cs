using ApiProyectoSistemasInternet.IServices;
using ApiProyectoSistemasInternet.ModelsFarmaciaBD;

namespace ApiProyectoSistemasInternet.Repositories
{
    public class DevolucionCompraRepository : IAuxRepository<DevolucionCompra>
    {
        public bool DeleteObject(object ID)
        {
            try
            {
                using (BaseFarmaciaContext db = new BaseFarmaciaContext())
                {
                    var devolucionCompra = db.DevolucionCompras.Find(ID);
                    if (devolucionCompra != null)
                    {
                        db.DevolucionCompras.Remove(devolucionCompra);
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

        public GetAllResponse<DevolucionCompra> GetAllObjects(int offSet, int pageSize)
        {
            try
            {
                using (BaseFarmaciaContext db = new BaseFarmaciaContext())
                {
                    var devolucionesCompra = db.DevolucionCompras
                                               .Skip(offSet * pageSize)
                                               .Take(pageSize)
                                               .ToList();

                    return new GetAllResponse<DevolucionCompra>
                    {
                        statusCode = 200,
                        isExitoso = true,
                        resultado = devolucionesCompra,
                        totalPaginas = (int)Math.Ceiling(db.DevolucionCompras.Count() / (double)pageSize)
                    };
                }
            }
            catch (Exception ex)
            {
                return new GetAllResponse<DevolucionCompra>
                {
                    statusCode = 500,
                    isExitoso = false,
                    errorMessages = new List<object> { ex.Message }
                };
            }
        }

        public GetOneResponse<DevolucionCompra> GetObjectById(object ID)
        {
            try
            {
                using (BaseFarmaciaContext db = new BaseFarmaciaContext())
                {
                    var devolucionCompra = db.DevolucionCompras.Find(ID);
                    if (devolucionCompra != null)
                    {
                        return new GetOneResponse<DevolucionCompra>
                        {
                            statusCode = 200,
                            isExitoso = true,
                            resultado = devolucionCompra
                        };
                    }
                    return new GetOneResponse<DevolucionCompra>
                    {
                        statusCode = 404,
                        isExitoso = false,
                        errorMessages = new List<object> { "Devolución de compra no encontrada" }
                    };
                }
            }
            catch (Exception ex)
            {
                return new GetOneResponse<DevolucionCompra>
                {
                    statusCode = 500,
                    isExitoso = false,
                    errorMessages = new List<object> { ex.Message }
                };
            }
        }

        public GetOneResponse<DevolucionCompra> UpdateCreateObject(DevolucionCompra obj)
        {
            try
            {
                using (BaseFarmaciaContext db = new BaseFarmaciaContext())
                {
                    var devolucionCompra = db.DevolucionCompras.Find(obj.IdDevolucionCompra);

                    if (devolucionCompra == null)
                    {
                        db.DevolucionCompras.Add(obj);
                        db.SaveChanges();
                        return new GetOneResponse<DevolucionCompra>
                        {
                            statusCode = 201,
                            isExitoso = true,
                            resultado = obj
                        };
                    }
                    else
                    {
                        devolucionCompra.Fecha = obj.Fecha;
                        devolucionCompra.Monto = obj.Monto;
                        devolucionCompra.MotivoDevolucion = obj.MotivoDevolucion;
                        devolucionCompra.Ndevolucion = obj.Ndevolucion;
                        devolucionCompra.IdCompra = obj.IdCompra;

                        db.SaveChanges();
                        return new GetOneResponse<DevolucionCompra>
                        {
                            statusCode = 200,
                            isExitoso = true,
                            resultado = devolucionCompra
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                return new GetOneResponse<DevolucionCompra>
                {
                    statusCode = 500,
                    isExitoso = false,
                    errorMessages = new List<object> { ex.Message }
                };
            }
        }
    }

}
