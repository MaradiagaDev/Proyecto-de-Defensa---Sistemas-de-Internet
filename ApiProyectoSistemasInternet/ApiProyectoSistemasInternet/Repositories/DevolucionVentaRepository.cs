using ApiProyectoSistemasInternet.IServices;
using ApiProyectoSistemasInternet.ModelsFarmaciaBD;

namespace ApiProyectoSistemasInternet.Repositories
{
    public class DevolucionVentaRepository : IAuxRepository<DevolucionVentum>
    {
        public bool DeleteObject(object ID)
        {
            try
            {
                using (BaseFarmaciaContext db = new BaseFarmaciaContext())
                {
                    var devolucionVenta = db.DevolucionVenta.Find(ID);
                    if (devolucionVenta != null)
                    {
                        db.DevolucionVenta.Remove(devolucionVenta);
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

        public GetAllResponse<DevolucionVentum> GetAllObjects(int offSet, int pageSize)
        {
            try
            {
                using (BaseFarmaciaContext db = new BaseFarmaciaContext())
                {
                    var devolucionesVenta = db.DevolucionVenta
                                               .Skip(offSet * pageSize)
                                               .Take(pageSize)
                                               .ToList();

                    return new GetAllResponse<DevolucionVentum>
                    {
                        statusCode = 200,
                        isExitoso = true,
                        resultado = devolucionesVenta,
                        totalPaginas = (int)Math.Ceiling(db.DevolucionVenta.Count() / (double)pageSize)
                    };
                }
            }
            catch (Exception ex)
            {
                return new GetAllResponse<DevolucionVentum>
                {
                    statusCode = 500,
                    isExitoso = false,
                    errorMessages = new List<object> { ex.Message }
                };
            }
        }

        public GetOneResponse<DevolucionVentum> GetObjectById(object ID)
        {
            try
            {
                using (BaseFarmaciaContext db = new BaseFarmaciaContext())
                {
                    var devolucionVenta = db.DevolucionVenta.Find(ID);
                    if (devolucionVenta != null)
                    {
                        return new GetOneResponse<DevolucionVentum>
                        {
                            statusCode = 200,
                            isExitoso = true,
                            resultado = devolucionVenta
                        };
                    }
                    return new GetOneResponse<DevolucionVentum>
                    {
                        statusCode = 404,
                        isExitoso = false,
                        errorMessages = new List<object> { "Devolución de venta no encontrada" }
                    };
                }
            }
            catch (Exception ex)
            {
                return new GetOneResponse<DevolucionVentum>
                {
                    statusCode = 500,
                    isExitoso = false,
                    errorMessages = new List<object> { ex.Message }
                };
            }
        }

        public GetOneResponse<DevolucionVentum> UpdateCreateObject(DevolucionVentum obj)
        {
            try
            {
                using (BaseFarmaciaContext db = new BaseFarmaciaContext())
                {
                    var devolucionVenta = db.DevolucionVenta.Find(obj.IdDevolucionVenta);

                    if (devolucionVenta == null)
                    {
                        db.DevolucionVenta.Add(obj);
                        db.SaveChanges();
                        return new GetOneResponse<DevolucionVentum>
                        {
                            statusCode = 201,
                            isExitoso = true,
                            resultado = obj
                        };
                    }
                    else
                    {
                        devolucionVenta.Fecha = obj.Fecha;
                        devolucionVenta.Monto = obj.Monto;
                        devolucionVenta.MotivoDevolucion = obj.MotivoDevolucion;
                        devolucionVenta.Ndevolucion = obj.Ndevolucion;
                        devolucionVenta.Nrecibo = obj.Nrecibo;

                        db.SaveChanges();
                        return new GetOneResponse<DevolucionVentum>
                        {
                            statusCode = 200,
                            isExitoso = true,
                            resultado = devolucionVenta
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                return new GetOneResponse<DevolucionVentum>
                {
                    statusCode = 500,
                    isExitoso = false,
                    errorMessages = new List<object> { ex.Message }
                };
            }
        }
    }

}
