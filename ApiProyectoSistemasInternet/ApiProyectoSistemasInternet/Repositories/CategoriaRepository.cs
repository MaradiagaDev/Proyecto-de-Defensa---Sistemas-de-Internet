using ApiProyectoSistemasInternet.IServices;
using ApiProyectoSistemasInternet.ModelsFarmaciaBD;

namespace ApiProyectoSistemasInternet.Repositories
{
    public class CategoriaRepository : IAuxRepository<Categorium>
    {
        public bool DeleteObject(object ID)
        {
            try
            {
                using (BaseFarmaciaContext db = new BaseFarmaciaContext())
                {
                    var categoria = db.Categoria.Find(ID);
                    if (categoria != null)
                    {
                        db.Categoria.Remove(categoria);
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

        public GetAllResponse<Categorium> GetAllObjects(int offSet, int pageSize)
        {
            try
            {
                using (BaseFarmaciaContext db = new BaseFarmaciaContext())
                {
                    var categorias = db.Categoria
                                       .Skip(offSet * pageSize)
                                       .Take(pageSize)
                                       .ToList();

                    return new GetAllResponse<Categorium>
                    {
                        statusCode = 200,
                        isExitoso = true,
                        resultado = categorias,
                        totalPaginas = (int)Math.Ceiling(db.Categoria.Count() / (double)pageSize)
                    };
                }
            }
            catch (Exception ex)
            {
                return new GetAllResponse<Categorium>
                {
                    statusCode = 500,
                    isExitoso = false,
                    errorMessages = new List<object> { ex.Message }
                };
            }
        }

        public GetOneResponse<Categorium> GetObjectById(object ID)
        {
            try
            {
                using (BaseFarmaciaContext db = new BaseFarmaciaContext())
                {
                    var categoria = db.Categoria.Find(ID);
                    if (categoria != null)
                    {
                        return new GetOneResponse<Categorium>
                        {
                            statusCode = 200,
                            isExitoso = true,
                            resultado = categoria
                        };
                    }
                    return new GetOneResponse<Categorium>
                    {
                        statusCode = 404,
                        isExitoso = false,
                        errorMessages = new List<object> { "Categoría no encontrada" }
                    };
                }
            }
            catch (Exception ex)
            {
                return new GetOneResponse<Categorium>
                {
                    statusCode = 500,
                    isExitoso = false,
                    errorMessages = new List<object> { ex.Message }
                };
            }
        }

        public GetOneResponse<Categorium> UpdateCreateObject(Categorium obj)
        {
            try
            {
                using (BaseFarmaciaContext db = new BaseFarmaciaContext())
                {
                    var categoria = db.Categoria.Find(obj.IdCategoria);

                    if (categoria == null)
                    {
                        db.Categoria.Add(obj);
                        db.SaveChanges();
                        return new GetOneResponse<Categorium>
                        {
                            statusCode = 201,
                            isExitoso = true,
                            resultado = obj
                        };
                    }
                    else
                    {
                        categoria.NombreCategoria = obj.NombreCategoria;
                        db.SaveChanges();

                        return new GetOneResponse<Categorium>
                        {
                            statusCode = 200,
                            isExitoso = true,
                            resultado = categoria
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                return new GetOneResponse<Categorium>
                {
                    statusCode = 500,
                    isExitoso = false,
                    errorMessages = new List<object> { ex.Message }
                };
            }
        }
    }

}
