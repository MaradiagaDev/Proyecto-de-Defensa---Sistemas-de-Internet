using ApiProyectoSistemasInternet.IServices;
using ApiProyectoSistemasInternet.ModelsFarmaciaBD;

namespace ApiProyectoSistemasInternet.Repositories
{
    public class ProveedorTrabajadorRepository : IAuxRepository<ProveedorTrabajador>
    {
        public bool DeleteObject(object ID)
        {
            try
            {
                using (BaseFarmaciaContext db = new BaseFarmaciaContext())
                {
                    var trabajador = db.ProveedorTrabajadors.Find(ID);
                    if (trabajador != null)
                    {
                        db.ProveedorTrabajadors.Remove(trabajador);
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

        public GetAllResponse<ProveedorTrabajador> GetAllObjects(int offSet, int pageSize)
        {
            try
            {
                using (BaseFarmaciaContext db = new BaseFarmaciaContext())
                {
                    var trabajadores = db.ProveedorTrabajadors
                                         .Skip(offSet * pageSize)
                                         .Take(pageSize)
                                         .ToList();

                    return new GetAllResponse<ProveedorTrabajador>
                    {
                        statusCode = 200,
                        isExitoso = true,
                        resultado = trabajadores,
                        totalPaginas = (int)Math.Ceiling(db.ProveedorTrabajadors.Count() / (double)pageSize)
                    };
                }
            }
            catch (Exception ex)
            {
                return new GetAllResponse<ProveedorTrabajador>
                {
                    statusCode = 500,
                    isExitoso = false,
                    errorMessages = new List<object> { ex.Message }
                };
            }
        }

        public GetOneResponse<ProveedorTrabajador> GetObjectById(object ID)
        {
            try
            {
                using (BaseFarmaciaContext db = new BaseFarmaciaContext())
                {
                    var trabajador = db.ProveedorTrabajadors.Find(ID);
                    if (trabajador != null)
                    {
                        return new GetOneResponse<ProveedorTrabajador>
                        {
                            statusCode = 200,
                            isExitoso = true,
                            resultado = trabajador
                        };
                    }
                    return new GetOneResponse<ProveedorTrabajador>
                    {
                        statusCode = 404,
                        isExitoso = false,
                        errorMessages = new List<object> { "ProveedorTrabajador no encontrado" }
                    };
                }
            }
            catch (Exception ex)
            {
                return new GetOneResponse<ProveedorTrabajador>
                {
                    statusCode = 500,
                    isExitoso = false,
                    errorMessages = new List<object> { ex.Message }
                };
            }
        }

        public GetOneResponse<ProveedorTrabajador> UpdateCreateObject(ProveedorTrabajador obj)
        {
            try
            {
                using (BaseFarmaciaContext db = new BaseFarmaciaContext())
                {
                    var trabajador = db.ProveedorTrabajadors.Find(obj.IdTrabajador);

                    if (trabajador == null)
                    {
                        db.ProveedorTrabajadors.Add(obj);
                        db.SaveChanges();
                        return new GetOneResponse<ProveedorTrabajador>
                        {
                            statusCode = 201,
                            isExitoso = true,
                            resultado = obj
                        };
                    }
                    else
                    {
                        trabajador.PrimerNombre = obj.PrimerNombre;
                        trabajador.SegundoNombre = obj.SegundoNombre;
                        trabajador.PrimerApellido = obj.PrimerApellido;
                        trabajador.SegundoApellido = obj.SegundoApellido;
                        trabajador.DireccionTrabajador = obj.DireccionTrabajador;
                        trabajador.Cargo = obj.Cargo;
                        trabajador.Edad = obj.Edad;
                        trabajador.TelefonoTrabajador = obj.TelefonoTrabajador;
                        trabajador.Sexo = obj.Sexo;
                        trabajador.IdProveedor = obj.IdProveedor;

                        db.SaveChanges();
                        return new GetOneResponse<ProveedorTrabajador>
                        {
                            statusCode = 200,
                            isExitoso = true,
                            resultado = trabajador
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                return new GetOneResponse<ProveedorTrabajador>
                {
                    statusCode = 500,
                    isExitoso = false,
                    errorMessages = new List<object> { ex.Message }
                };
            }
        }
    }

}
