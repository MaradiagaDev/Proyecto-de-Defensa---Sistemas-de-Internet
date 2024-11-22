using ApiProyectoSistemasInternet.IServices;
using ApiProyectoSistemasInternet.ModelsFarmaciaBD;

namespace ApiProyectoSistemasInternet.Repositories
{
    public class VentumRepository : IAuxRepository<Ventum>
    {
        public bool DeleteObject(object ID)
        {
            try
            {
                using (BaseFarmaciaContext db = new BaseFarmaciaContext())
                {
                    var venta = db.Venta.Find(ID);
                    if (venta != null)
                    {
                        db.Venta.Remove(venta);
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

        public GetAllResponse<Ventum> GetAllObjects(int offSet, int pageSize)
        {
            try
            {
                using (BaseFarmaciaContext db = new BaseFarmaciaContext())
                {
                    var ventas = db.Venta
                                   .Skip(offSet * pageSize)
                                   .Take(pageSize)
                                   .ToList();

                    return new GetAllResponse<Ventum>
                    {
                        statusCode = 200,
                        isExitoso = true,
                        resultado = ventas,
                        totalPaginas = (int)Math.Ceiling(db.Venta.Count() / (double)pageSize)
                    };
                }
            }
            catch (Exception ex)
            {
                return new GetAllResponse<Ventum>
                {
                    statusCode = 500,
                    isExitoso = false,
                    errorMessages = new List<object> { ex.Message }
                };
            }
        }

        public GetOneResponse<Ventum> GetObjectById(object ID)
        {
            try
            {
                using (BaseFarmaciaContext db = new BaseFarmaciaContext())
                {
                    var venta = db.Venta.Find(ID);
                    if (venta != null)
                    {
                        return new GetOneResponse<Ventum>
                        {
                            statusCode = 200,
                            isExitoso = true,
                            resultado = venta
                        };
                    }
                    return new GetOneResponse<Ventum>
                    {
                        statusCode = 404,
                        isExitoso = false,
                        errorMessages = new List<object> { "Venta no encontrada" }
                    };
                }
            }
            catch (Exception ex)
            {
                return new GetOneResponse<Ventum>
                {
                    statusCode = 500,
                    isExitoso = false,
                    errorMessages = new List<object> { ex.Message }
                };
            }
        }

        public GetOneResponse<Ventum> UpdateCreateObject(Ventum obj)
        {
            try
            {
                using (BaseFarmaciaContext db = new BaseFarmaciaContext())
                {
                    var venta = db.Venta.Find(obj.IdVenta);

                    if (venta == null)
                    {
                        db.Venta.Add(obj);
                        db.SaveChanges();
                        return new GetOneResponse<Ventum>
                        {
                            statusCode = 201,
                            isExitoso = true,
                            resultado = obj
                        };
                    }
                    else
                    {
                        venta.Monto = obj.Monto;
                        venta.Nrecibo = obj.Nrecibo;
                        venta.Fecha = obj.Fecha;
                        venta.IdCliente = obj.IdCliente;

                        db.SaveChanges();
                        return new GetOneResponse<Ventum>
                        {
                            statusCode = 200,
                            isExitoso = true,
                            resultado = venta
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                return new GetOneResponse<Ventum>
                {
                    statusCode = 500,
                    isExitoso = false,
                    errorMessages = new List<object> { ex.Message }
                };
            }
        }

        public List<Ventum> GetVentasByFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            using (BaseFarmaciaContext db = new BaseFarmaciaContext())
            {
                return db.Venta
                         .Where(v => v.Fecha >= fechaInicio && v.Fecha <= fechaFin)
                         .ToList();
            }
        }

        public List<DevolucionVentum> GetDevolucionesByCliente(int idCliente)
        {
            using (BaseFarmaciaContext db = new BaseFarmaciaContext())
            {
                return db.DevolucionVenta
                         .Where(d => d.Nrecibo == db.Venta
                                                .Where(v => v.IdCliente == idCliente)
                                                .Select(v => v.Nrecibo)
                                                .FirstOrDefault())
                         .ToList();
            }
        }


    }

}
