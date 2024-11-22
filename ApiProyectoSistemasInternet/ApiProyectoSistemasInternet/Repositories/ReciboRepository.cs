using ApiProyectoSistemasInternet.IServices;
using ApiProyectoSistemasInternet.ModelsFarmaciaBD;

namespace ApiProyectoSistemasInternet.Repositories
{
    public class ReciboRepository : IAuxRepository<Recibo>
    {
        public bool DeleteObject(object ID)
        {
            try
            {
                using (BaseFarmaciaContext db = new BaseFarmaciaContext())
                {
                    var recibo = db.Recibos.Find(ID);
                    if (recibo != null)
                    {
                        db.Recibos.Remove(recibo);
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

        public GetAllResponse<Recibo> GetAllObjects(int offSet, int pageSize)
        {
            try
            {
                using (BaseFarmaciaContext db = new BaseFarmaciaContext())
                {
                    var recibos = db.Recibos
                                    .Skip(offSet * pageSize)
                                    .Take(pageSize)
                                    .ToList();

                    return new GetAllResponse<Recibo>
                    {
                        statusCode = 200,
                        isExitoso = true,
                        resultado = recibos,
                        totalPaginas = (int)Math.Ceiling(db.Recibos.Count() / (double)pageSize)
                    };
                }
            }
            catch (Exception ex)
            {
                return new GetAllResponse<Recibo>
                {
                    statusCode = 500,
                    isExitoso = false,
                    errorMessages = new List<object> { ex.Message }
                };
            }
        }

        public GetOneResponse<Recibo> GetObjectById(object ID)
        {
            try
            {
                using (BaseFarmaciaContext db = new BaseFarmaciaContext())
                {
                    var recibo = db.Recibos.Find(ID);
                    if (recibo != null)
                    {
                        return new GetOneResponse<Recibo>
                        {
                            statusCode = 200,
                            isExitoso = true,
                            resultado = recibo
                        };
                    }
                    return new GetOneResponse<Recibo>
                    {
                        statusCode = 404,
                        isExitoso = false,
                        errorMessages = new List<object> { "Recibo no encontrado" }
                    };
                }
            }
            catch (Exception ex)
            {
                return new GetOneResponse<Recibo>
                {
                    statusCode = 500,
                    isExitoso = false,
                    errorMessages = new List<object> { ex.Message }
                };
            }
        }

        public GetOneResponse<Recibo> UpdateCreateObject(Recibo obj)
        {
            try
            {
                using (BaseFarmaciaContext db = new BaseFarmaciaContext())
                {
                    var recibo = db.Recibos.Find(obj.Nrecibo);

                    if (recibo == null)
                    {
                        db.Recibos.Add(obj);
                        db.SaveChanges();
                        return new GetOneResponse<Recibo>
                        {
                            statusCode = 201,
                            isExitoso = true,
                            resultado = obj
                        };
                    }
                    else
                    {
                        recibo.CostoProducto = obj.CostoProducto;
                        recibo.IdTransaccion = obj.IdTransaccion;

                        db.SaveChanges();
                        return new GetOneResponse<Recibo>
                        {
                            statusCode = 200,
                            isExitoso = true,
                            resultado = recibo
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                return new GetOneResponse<Recibo>
                {
                    statusCode = 500,
                    isExitoso = false,
                    errorMessages = new List<object> { ex.Message }
                };
            }
        }
    }

}
