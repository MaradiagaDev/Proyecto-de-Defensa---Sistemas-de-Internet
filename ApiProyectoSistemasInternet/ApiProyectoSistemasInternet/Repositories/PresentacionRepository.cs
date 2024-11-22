using ApiProyectoSistemasInternet.IServices;
using ApiProyectoSistemasInternet.ModelsFarmaciaBD;

namespace ApiProyectoSistemasInternet.Repositories
{
    public class PresentacionRepository : IAuxRepository<Presentacion>
    {
        public bool DeleteObject(object ID)
        {
            try
            {
                using (BaseFarmaciaContext db = new BaseFarmaciaContext())
                {
                    var presentacion = db.Presentacions.Find(ID);
                    if (presentacion != null)
                    {
                        db.Presentacions.Remove(presentacion);
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

        public GetAllResponse<Presentacion> GetAllObjects(int offSet, int pageSize)
        {
            try
            {
                using (BaseFarmaciaContext db = new BaseFarmaciaContext())
                {
                    var presentaciones = db.Presentacions
                                           .Skip(offSet * pageSize)
                                           .Take(pageSize)
                                           .ToList();

                    return new GetAllResponse<Presentacion>
                    {
                        statusCode = 200,
                        isExitoso = true,
                        resultado = presentaciones,
                        totalPaginas = (int)Math.Ceiling(db.Presentacions.Count() / (double)pageSize)
                    };
                }
            }
            catch (Exception ex)
            {
                return new GetAllResponse<Presentacion>
                {
                    statusCode = 500,
                    isExitoso = false,
                    errorMessages = new List<object> { ex.Message }
                };
            }
        }

        public GetOneResponse<Presentacion> GetObjectById(object ID)
        {
            try
            {
                using (BaseFarmaciaContext db = new BaseFarmaciaContext())
                {
                    var presentacion = db.Presentacions.Find(ID);
                    if (presentacion != null)
                    {
                        return new GetOneResponse<Presentacion>
                        {
                            statusCode = 200,
                            isExitoso = true,
                            resultado = presentacion
                        };
                    }
                    return new GetOneResponse<Presentacion>
                    {
                        statusCode = 404,
                        isExitoso = false,
                        errorMessages = new List<object> { "Presentación no encontrada" }
                    };
                }
            }
            catch (Exception ex)
            {
                return new GetOneResponse<Presentacion>
                {
                    statusCode = 500,
                    isExitoso = false,
                    errorMessages = new List<object> { ex.Message }
                };
            }
        }

        public GetOneResponse<Presentacion> UpdateCreateObject(Presentacion obj)
        {
            try
            {
                using (BaseFarmaciaContext db = new BaseFarmaciaContext())
                {
                    var presentacion = db.Presentacions.Find(obj.IdPresentacion);

                    if (presentacion == null)
                    {
                        db.Presentacions.Add(obj);
                        db.SaveChanges();
                        return new GetOneResponse<Presentacion>
                        {
                            statusCode = 201,
                            isExitoso = true,
                            resultado = obj
                        };
                    }
                    else
                    {
                        presentacion.Nombre = obj.Nombre;
                        presentacion.EstadoPresentacion = obj.EstadoPresentacion;

                        db.SaveChanges();
                        return new GetOneResponse<Presentacion>
                        {
                            statusCode = 200,
                            isExitoso = true,
                            resultado = presentacion
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                return new GetOneResponse<Presentacion>
                {
                    statusCode = 500,
                    isExitoso = false,
                    errorMessages = new List<object> { ex.Message }
                };
            }
        }
    }

}
