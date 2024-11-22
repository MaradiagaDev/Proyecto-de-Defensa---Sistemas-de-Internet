using ApiProyectoSistemasInternet.IServices;
using ApiProyectoSistemasInternet.ModelsFarmaciaBD;

namespace ApiProyectoSistemasInternet.Repositories
{
    public class TransaccionRepository : IAuxRepository<Transaccion>
    {
        public bool DeleteObject(object ID)
        {
            try
            {
                using (BaseFarmaciaContext db = new BaseFarmaciaContext())
                {
                    var transaccion = db.Transaccions.Find(ID);
                    if (transaccion != null)
                    {
                        db.Transaccions.Remove(transaccion);
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

        public GetAllResponse<Transaccion> GetAllObjects(int offSet, int pageSize)
        {
            try
            {
                using (BaseFarmaciaContext db = new BaseFarmaciaContext())
                {
                    var transacciones = db.Transaccions
                                         .Skip(offSet * pageSize)
                                         .Take(pageSize)
                                         .ToList();

                    return new GetAllResponse<Transaccion>
                    {
                        statusCode = 200,
                        isExitoso = true,
                        resultado = transacciones,
                        totalPaginas = (int)Math.Ceiling(db.Transaccions.Count() / (double)pageSize)
                    };
                }
            }
            catch (Exception ex)
            {
                return new GetAllResponse<Transaccion>
                {
                    statusCode = 500,
                    isExitoso = false,
                    errorMessages = new List<object> { ex.Message }
                };
            }
        }

        public GetOneResponse<Transaccion> GetObjectById(object ID)
        {
            try
            {
                using (BaseFarmaciaContext db = new BaseFarmaciaContext())
                {
                    var transaccion = db.Transaccions.Find(ID);
                    if (transaccion != null)
                    {
                        return new GetOneResponse<Transaccion>
                        {
                            statusCode = 200,
                            isExitoso = true,
                            resultado = transaccion
                        };
                    }
                    return new GetOneResponse<Transaccion>
                    {
                        statusCode = 404,
                        isExitoso = false,
                        errorMessages = new List<object> { "Transacción no encontrada" }
                    };
                }
            }
            catch (Exception ex)
            {
                return new GetOneResponse<Transaccion>
                {
                    statusCode = 500,
                    isExitoso = false,
                    errorMessages = new List<object> { ex.Message }
                };
            }
        }

        public GetOneResponse<Transaccion> UpdateCreateObject(Transaccion obj)
        {
            try
            {
                using (BaseFarmaciaContext db = new BaseFarmaciaContext())
                {
                    var transaccion = db.Transaccions.Find(obj.IdTransaccion);

                    if (transaccion == null)
                    {
                        db.Transaccions.Add(obj);
                        db.SaveChanges();
                        return new GetOneResponse<Transaccion>
                        {
                            statusCode = 201,
                            isExitoso = true,
                            resultado = obj
                        };
                    }
                    else
                    {
                        transaccion.Descuento = obj.Descuento;
                        transaccion.Estado = obj.Estado;
                        transaccion.Fecha = obj.Fecha;
                        transaccion.Iva = obj.Iva;
                        transaccion.SubTotal = obj.SubTotal;
                        transaccion.Tipo = obj.Tipo;
                        transaccion.Total = obj.Total;

                        db.SaveChanges();
                        return new GetOneResponse<Transaccion>
                        {
                            statusCode = 200,
                            isExitoso = true,
                            resultado = transaccion
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                return new GetOneResponse<Transaccion>
                {
                    statusCode = 500,
                    isExitoso = false,
                    errorMessages = new List<object> { ex.Message }
                };
            }
        }
    }

}
