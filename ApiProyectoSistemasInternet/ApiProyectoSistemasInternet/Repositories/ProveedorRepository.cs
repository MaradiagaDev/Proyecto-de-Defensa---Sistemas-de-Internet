using ApiProyectoSistemasInternet.IServices;
using ApiProyectoSistemasInternet.ModelsFarmaciaBD;

namespace ApiProyectoSistemasInternet.Repositories
{
    public class ProveedorRepository : IAuxRepository<Proveedor>
    {
        public bool DeleteObject(object ID)
        {
            try
            {
                using (BaseFarmaciaContext db = new BaseFarmaciaContext())
                {
                    var proveedor = db.Proveedors.Find(ID);
                    if (proveedor != null)
                    {
                        db.Proveedors.Remove(proveedor);
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

        public GetAllResponse<Proveedor> GetAllObjects(int offSet, int pageSize)
        {
            try
            {
                using (BaseFarmaciaContext db = new BaseFarmaciaContext())
                {
                    var proveedores = db.Proveedors
                                        .Skip(offSet * pageSize)
                                        .Take(pageSize)
                                        .ToList();

                    return new GetAllResponse<Proveedor>
                    {
                        statusCode = 200,
                        isExitoso = true,
                        resultado = proveedores,
                        totalPaginas = (int)Math.Ceiling(db.Proveedors.Count() / (double)pageSize)
                    };
                }
            }
            catch (Exception ex)
            {
                return new GetAllResponse<Proveedor>
                {
                    statusCode = 500,
                    isExitoso = false,
                    errorMessages = new List<object> { ex.Message }
                };
            }
        }

        public GetOneResponse<Proveedor> GetObjectById(object ID)
        {
            try
            {
                using (BaseFarmaciaContext db = new BaseFarmaciaContext())
                {
                    var proveedor = db.Proveedors.Find(ID);
                    if (proveedor != null)
                    {
                        return new GetOneResponse<Proveedor>
                        {
                            statusCode = 200,
                            isExitoso = true,
                            resultado = proveedor
                        };
                    }
                    return new GetOneResponse<Proveedor>
                    {
                        statusCode = 404,
                        isExitoso = false,
                        errorMessages = new List<object> { "Proveedor no encontrado" }
                    };
                }
            }
            catch (Exception ex)
            {
                return new GetOneResponse<Proveedor>
                {
                    statusCode = 500,
                    isExitoso = false,
                    errorMessages = new List<object> { ex.Message }
                };
            }
        }

        public GetOneResponse<Proveedor> UpdateCreateObject(Proveedor obj)
        {
            try
            {
                using (BaseFarmaciaContext db = new BaseFarmaciaContext())
                {
                    var proveedor = db.Proveedors.Find(obj.IdProveedor);

                    if (proveedor == null)
                    {
                        db.Proveedors.Add(obj);
                        db.SaveChanges();
                        return new GetOneResponse<Proveedor>
                        {
                            statusCode = 201,
                            isExitoso = true,
                            resultado = obj
                        };
                    }
                    else
                    {
                        proveedor.Estado = obj.Estado;
                        proveedor.FechaRegistro = obj.FechaRegistro;
                        proveedor.FechaUltimoPedido = obj.FechaUltimoPedido;
                        proveedor.NombreCompania = obj.NombreCompania;
                        proveedor.IdPersona = obj.IdPersona;
                        proveedor.Telefono = obj.Telefono;

                        db.SaveChanges();
                        return new GetOneResponse<Proveedor>
                        {
                            statusCode = 200,
                            isExitoso = true,
                            resultado = proveedor
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                return new GetOneResponse<Proveedor>
                {
                    statusCode = 500,
                    isExitoso = false,
                    errorMessages = new List<object> { ex.Message }
                };
            }
        }
    }

}
