using ApiProyectoSistemasInternet.IServices;
using ApiProyectoSistemasInternet.ModelsFarmaciaBD;

namespace ApiProyectoSistemasInternet.Repositories
{
    public class EmpleadoRepository : IAuxRepository<Empleado>
    {
        public bool DeleteObject(object ID)
        {
            try
            {
                using (BaseFarmaciaContext db = new BaseFarmaciaContext())
                {
                    var empleado = db.Empleados.Find(ID);
                    if (empleado != null)
                    {
                        db.Empleados.Remove(empleado);
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

        public GetAllResponse<Empleado> GetAllObjects(int offSet, int pageSize)
        {
            try
            {
                using (BaseFarmaciaContext db = new BaseFarmaciaContext())
                {
                    var empleados = db.Empleados
                                     .Skip(offSet * pageSize)
                                     .Take(pageSize)
                                     .ToList();

                    return new GetAllResponse<Empleado>
                    {
                        statusCode = 200,
                        isExitoso = true,
                        resultado = empleados,
                        totalPaginas = (int)Math.Ceiling(db.Usuarios.Count() / (double)pageSize)
                    };
                }
            }
            catch (Exception ex)
            {
                return new GetAllResponse<Empleado>
                {
                    statusCode = 500,
                    isExitoso = false,
                    errorMessages = new List<object> { ex.Message }
                };
            }
        }

        public GetOneResponse<Empleado> GetObjectById(object ID)
        {
            try
            {
                using (BaseFarmaciaContext db = new BaseFarmaciaContext())
                {
                    var empleado = db.Empleados.Find(ID);
                    if (empleado != null)
                    {
                        return new GetOneResponse<Empleado>
                        {
                            statusCode = 200,
                            isExitoso = true,
                            resultado = empleado
                        };
                    }
                    return new GetOneResponse<Empleado>
                    {
                        statusCode = 404,
                        isExitoso = false,
                        errorMessages = new List<object> { "Empleado no encontrado" }
                    };
                }
            }
            catch (Exception ex)
            {
                return new GetOneResponse<Empleado>
                {
                    statusCode = 500,
                    isExitoso = false,
                    errorMessages = new List<object> { ex.Message }
                };
            }
        }

        public GetOneResponse<Empleado> UpdateCreateObject(Empleado obj)
        {
            try
            {
                using (BaseFarmaciaContext db = new BaseFarmaciaContext())
                {
                    var empleado = db.Empleados.Find(obj.IdEmpleado);

                    if (empleado == null)
                    {
                        db.Empleados.Add(obj);
                        db.SaveChanges();
                        return new GetOneResponse<Empleado>
                        {
                            statusCode = 201,
                            isExitoso = true,
                            resultado = obj
                        };
                    }
                    else
                    {
                        empleado.Cargo = obj.Cargo;
                        empleado.CodigoUsuario = obj.CodigoUsuario;
                        empleado.Edad = obj.Edad;
                        empleado.EstadoEmpleado = obj.EstadoEmpleado;
                        empleado.NivelAcceso = obj.NivelAcceso;
                        empleado.LoginUsuario = obj.LoginUsuario;
                        empleado.PasswordUsuario = obj.PasswordUsuario;
                        empleado.Telefono = obj.Telefono;
                        empleado.IdPersona = obj.IdPersona;
   
                        db.SaveChanges();
                        return new GetOneResponse<Empleado>
                        {
                            statusCode = 200,
                            isExitoso = true,
                            resultado = empleado
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                return new GetOneResponse<Empleado>
                {
                    statusCode = 500,
                    isExitoso = false,
                    errorMessages = new List<object> { ex.Message }
                };
            }
        }
    }
}
