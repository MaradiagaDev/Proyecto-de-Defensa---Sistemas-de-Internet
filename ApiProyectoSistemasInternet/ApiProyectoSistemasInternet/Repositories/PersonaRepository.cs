using ApiProyectoSistemasInternet.IServices;
using ApiProyectoSistemasInternet.ModelsFarmaciaBD;

namespace ApiProyectoSistemasInternet.Repositories
{
    public class PersonaRepository : IAuxRepository<Persona>
    {
        public bool DeleteObject(object ID)
        {
            try
            {
                using (BaseFarmaciaContext db = new BaseFarmaciaContext())
                {
                    var persona = db.Personas.Find(ID);
                    if (persona != null)
                    {
                        db.Personas.Remove(persona);
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

        public GetAllResponse<Persona> GetAllObjects(int offSet, int pageSize)
        {
            try
            {
                using (BaseFarmaciaContext db = new BaseFarmaciaContext())
                {
                    var personas = db.Personas
                                     .Skip(offSet * pageSize)
                                     .Take(pageSize)
                                     .ToList();

                    return new GetAllResponse<Persona>
                    {
                        statusCode = 200,
                        isExitoso = true,
                        resultado = personas,
                        totalPaginas = (int)Math.Ceiling(db.Usuarios.Count() / (double)pageSize)
                    };
                }
            }
            catch (Exception ex)
            {
                return new GetAllResponse<Persona>
                {
                    statusCode = 500,
                    isExitoso = false,
                    errorMessages = new List<object> { ex.Message }
                };
            }
        }

        public GetOneResponse<Persona> GetObjectById(object ID)
        {
            try
            {
                using (BaseFarmaciaContext db = new BaseFarmaciaContext())
                {
                    var persona = db.Personas.Find(ID);
                    if (persona != null)
                    {
                        return new GetOneResponse<Persona>
                        {
                            statusCode = 200,
                            isExitoso = true,
                            resultado = persona
                        };
                    }
                    return new GetOneResponse<Persona>
                    {
                        statusCode = 404,
                        isExitoso = false,
                        errorMessages = new List<object> { "Persona no encontrada" }
                    };
                }
            }
            catch (Exception ex)
            {
                return new GetOneResponse<Persona>
                {
                    statusCode = 500,
                    isExitoso = false,
                    errorMessages = new List<object> { ex.Message }
                };
            }
        }

        public GetOneResponse<Persona> UpdateCreateObject(Persona obj)
        {
            try
            {
                using (BaseFarmaciaContext db = new BaseFarmaciaContext())
                {
                    var persona = db.Personas.Find(obj.IdPersona);

                    if (persona == null)
                    {
                        db.Personas.Add(obj);
                        db.SaveChanges();
                        return new GetOneResponse<Persona>
                        {
                            statusCode = 201,
                            isExitoso = true,
                            resultado = obj
                        };
                    }
                    else
                    {
 
                        persona.PrimerNombre = obj.PrimerNombre;
                        persona.SegundoNombre = obj.SegundoNombre;
                        persona.PrimerApellido = obj.PrimerApellido;
                        persona.SegundoApellido = obj.SegundoApellido;
                        persona.Direccion = obj.Direccion;
                        persona.Correo = obj.Correo;
                        persona.Sexo = obj.Sexo;

                        db.SaveChanges();
                        return new GetOneResponse<Persona>
                        {
                            statusCode = 200,
                            isExitoso = true,
                            resultado = persona
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                return new GetOneResponse<Persona>
                {
                    statusCode = 500,
                    isExitoso = false,
                    errorMessages = new List<object> { ex.Message }
                };
            }
        }
    }
}
