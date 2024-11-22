using ApiProyectoSistemasInternet.IServices;
using ApiProyectoSistemasInternet.ModelsFarmaciaBD;

namespace ApiProyectoSistemasInternet.Repositories
{
    public class CompraRepository : IAuxRepository<Compra>
    {
        public bool DeleteObject(object ID)
        {
            try
            {
                using (BaseFarmaciaContext db = new BaseFarmaciaContext())
                {
                    var compra = db.Compras.Find(ID);
                    if (compra != null)
                    {
                        db.Compras.Remove(compra);
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

        public GetAllResponse<Compra> GetAllObjects(int offSet, int pageSize)
        {
            try
            {
                using (BaseFarmaciaContext db = new BaseFarmaciaContext())
                {
                    var compras = db.Compras
                                    .Skip(offSet * pageSize)
                                    .Take(pageSize)
                                    .ToList();

                    return new GetAllResponse<Compra>
                    {
                        statusCode = 200,
                        isExitoso = true,
                        resultado = compras,
                        totalPaginas = (int)Math.Ceiling(db.Compras.Count() / (double)pageSize)
                    };
                }
            }
            catch (Exception ex)
            {
                return new GetAllResponse<Compra>
                {
                    statusCode = 500,
                    isExitoso = false,
                    errorMessages = new List<object> { ex.Message }
                };
            }
        }

        public GetOneResponse<Compra> GetObjectById(object ID)
        {
            try
            {
                using (BaseFarmaciaContext db = new BaseFarmaciaContext())
                {
                    var compra = db.Compras.Find(ID);
                    if (compra != null)
                    {
                        return new GetOneResponse<Compra>
                        {
                            statusCode = 200,
                            isExitoso = true,
                            resultado = compra
                        };
                    }
                    return new GetOneResponse<Compra>
                    {
                        statusCode = 404,
                        isExitoso = false,
                        errorMessages = new List<object> { "Compra no encontrada" }
                    };
                }
            }
            catch (Exception ex)
            {
                return new GetOneResponse<Compra>
                {
                    statusCode = 500,
                    isExitoso = false,
                    errorMessages = new List<object> { ex.Message }
                };
            }
        }

        public GetOneResponse<Compra> UpdateCreateObject(Compra obj)
        {
            try
            {
                using (BaseFarmaciaContext db = new BaseFarmaciaContext())
                {
                    var compra = db.Compras.Find(obj.IdCompra);

                    if (compra == null)
                    {
                        db.Compras.Add(obj);
                        db.SaveChanges();
                        return new GetOneResponse<Compra>
                        {
                            statusCode = 201,
                            isExitoso = true,
                            resultado = obj
                        };
                    }
                    else
                    {
                        compra.Monto = obj.Monto;
                        compra.Fecha = obj.Fecha;
                        compra.IdProveedor = obj.IdProveedor;
                        compra.Nfactura = obj.Nfactura;

                        db.SaveChanges();
                        return new GetOneResponse<Compra>
                        {
                            statusCode = 200,
                            isExitoso = true,
                            resultado = compra
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                return new GetOneResponse<Compra>
                {
                    statusCode = 500,
                    isExitoso = false,
                    errorMessages = new List<object> { ex.Message }
                };
            }
        }
    }

}
