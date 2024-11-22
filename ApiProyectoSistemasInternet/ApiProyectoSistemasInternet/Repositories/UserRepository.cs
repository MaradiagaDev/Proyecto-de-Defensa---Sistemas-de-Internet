using ApiProyectoSistemasInternet.IServices;
using ApiProyectoSistemasInternet.ModelsFarmaciaBD;
using Microsoft.AspNetCore.Mvc;

namespace ApiProyectoSistemasInternet.Repositories
{
    public class UserRepository : IAuxRepository<Usuario>
    {
        public bool DeleteObject(object ID)
        {
            try
            {
                using (BaseFarmaciaContext db = new BaseFarmaciaContext())
                {
                    var usuario = db.Usuarios.Find(ID);
                    if (usuario != null)
                    {
                        db.Usuarios.Remove(usuario);
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

        public GetAllResponse<Usuario> GetAllObjects(int offSet, int pageSize)
        {
            try
            {
                using (BaseFarmaciaContext db = new BaseFarmaciaContext())
                {
                    var usuarios = db.Usuarios
                                     .Skip(offSet * pageSize)
                                     .Take(pageSize)
                                     .ToList();

                    return new GetAllResponse<Usuario>
                    {
                        statusCode = 200,
                        isExitoso = true,
                        resultado = usuarios,
                        totalPaginas = (int)Math.Ceiling(db.Usuarios.Count() / (double)pageSize)
                    };
                }
            }
            catch (Exception ex)
            {
                return new GetAllResponse<Usuario>
                {
                    statusCode = 500,
                    isExitoso = false,
                    errorMessages = new List<object> { ex.Message }
                };
            }
        }


        public GetOneResponse<Usuario> GetObjectById(object ID)
        {
            try
            {
                using (BaseFarmaciaContext db = new BaseFarmaciaContext())
                {
                    var usuario = db.Usuarios.Find(ID);
                    if (usuario != null)
                    {
                        return new GetOneResponse<Usuario>
                        {
                            statusCode = 200,
                            isExitoso = true,
                            resultado = usuario
                        };
                    }
                    return new GetOneResponse<Usuario>
                    {
                        statusCode = 404,
                        isExitoso = false,
                        errorMessages = new List<object> { "Usuario no encontrado" }
                    };
                }
            }
            catch (Exception ex)
            {
                return new GetOneResponse<Usuario>
                {
                    statusCode = 500,
                    isExitoso = false,
                    errorMessages = new List<object> { ex.Message }
                };
            }
        }

        public GetOneResponse<Usuario> UpdateCreateObject(Usuario obj)
        {
            try
            {
                using (BaseFarmaciaContext db = new BaseFarmaciaContext())
                {
                    var usuario = db.Usuarios.Find(obj.IdUsuario);

                    if (usuario == null)
                    {
                        db.Usuarios.Add(obj);
                        db.SaveChanges();
                        return new GetOneResponse<Usuario>
                        {
                            statusCode = 201,
                            isExitoso = true,
                            resultado = obj
                        };
                    }
                    else
                    {
                        usuario.Estado = obj.Estado;
                        usuario.Rol = obj.Rol;
                        usuario.IdEmpleado = obj.IdEmpleado;

                        db.SaveChanges();
                        return new GetOneResponse<Usuario>
                        {
                            statusCode = 200,
                            isExitoso = true,
                            resultado = usuario
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                return new GetOneResponse<Usuario>
                {
                    statusCode = 500,
                    isExitoso = false,
                    errorMessages = new List<object> { ex.Message }
                };
            }
        }


        public GetOneResponse<Usuario> Login(string username, string password)
        {
            try
            {
                using (BaseFarmaciaContext db = new BaseFarmaciaContext())
                {
                    var empleado = db.Empleados.FirstOrDefault(u => u.LoginUsuario == username && u.PasswordUsuario == password);


                    if (empleado != null)
                    {
                        var userEmpleado = db.Usuarios.FirstOrDefault(u => u.IdEmpleado == empleado.IdEmpleado);

                        if (userEmpleado != null)
                        {
                            return new GetOneResponse<Usuario>
                            {
                                statusCode = 200,
                                isExitoso = true,
                                resultado = userEmpleado
                            };
                        }
                        else
                        {
                            return new GetOneResponse<Usuario>
                            {
                                statusCode = 401,
                                isExitoso = false,
                                errorMessages = new List<Object> { "No hay usuario asociado al empleado" }
                            };
                        }
                    }
                    else
                    {
                        return new GetOneResponse<Usuario>
                        {
                            statusCode = 401,
                            isExitoso = false,
                            errorMessages = new List<Object> { "Usuario o contraseña incorrectos" }
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                return new GetOneResponse<Usuario>
                {
                    statusCode = 500,
                    isExitoso = false,
                    errorMessages = new List<Object> { ex.Message }
                };
            }
        }

    }
}
