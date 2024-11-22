using ApiProyectoSistemasInternet.IServices;
using ApiProyectoSistemasInternet.ModelsFarmaciaBD;

namespace ApiProyectoSistemasInternet.Repositories
{
    public class RubroRepository : IAuxRepository<Rubro>
    {
        public bool DeleteObject(object ID)
        {
            try
            {
                using (BaseFarmaciaContext db = new BaseFarmaciaContext())
                {
                    var rubro = db.Rubros.Find(ID);
                    if (rubro != null)
                    {
                        db.Rubros.Remove(rubro);
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

        public GetAllResponse<Rubro> GetAllObjects(int offSet, int pageSize)
        {
            try
            {
                using (BaseFarmaciaContext db = new BaseFarmaciaContext())
                {
                    var rubros = db.Rubros
                                   .Skip(offSet * pageSize)
                                   .Take(pageSize)
                                   .ToList();

                    return new GetAllResponse<Rubro>
                    {
                        statusCode = 200,
                        isExitoso = true,
                        resultado = rubros,
                        totalPaginas = (int)Math.Ceiling(db.Rubros.Count() / (double)pageSize)
                    };
                }
            }
            catch (Exception ex)
            {
                return new GetAllResponse<Rubro>
                {
                    statusCode = 500,
                    isExitoso = false,
                    errorMessages = new List<object> { ex.Message }
                };
            }
        }

        public GetOneResponse<Rubro> GetObjectById(object ID)
        {
            try
            {
                using (BaseFarmaciaContext db = new BaseFarmaciaContext())
                {
                    var rubro = db.Rubros.Find(ID);
                    if (rubro != null)
                    {
                        return new GetOneResponse<Rubro>
                        {
                            statusCode = 200,
                            isExitoso = true,
                            resultado = rubro
                        };
                    }
                    return new GetOneResponse<Rubro>
                    {
                        statusCode = 404,
                        isExitoso = false,
                        errorMessages = new List<object> { "Rubro no encontrado" }
                    };
                }
            }
            catch (Exception ex)
            {
                return new GetOneResponse<Rubro>
                {
                    statusCode = 500,
                    isExitoso = false,
                    errorMessages = new List<object> { ex.Message }
                };
            }
        }

        public GetOneResponse<Rubro> UpdateCreateObject(Rubro obj)
        {
            try
            {
                using (BaseFarmaciaContext db = new BaseFarmaciaContext())
                {
                    var rubro = db.Rubros.Find(obj.IdRubro);

                    if (rubro == null)
                    {
                        db.Rubros.Add(obj);
                        db.SaveChanges();
                        return new GetOneResponse<Rubro>
                        {
                            statusCode = 201,
                            isExitoso = true,
                            resultado = obj
                        };
                    }
                    else
                    {
                        rubro.Nombre = obj.Nombre;
                        rubro.Estado = obj.Estado;

                        db.SaveChanges();
                        return new GetOneResponse<Rubro>
                        {
                            statusCode = 200,
                            isExitoso = true,
                            resultado = rubro
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                return new GetOneResponse<Rubro>
                {
                    statusCode = 500,
                    isExitoso = false,
                    errorMessages = new List<object> { ex.Message }
                };
            }
        }
    }

}
