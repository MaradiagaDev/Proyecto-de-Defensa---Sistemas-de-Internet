using ApiProyectoSistemasInternet.IServices;
using ApiProyectoSistemasInternet.ModelsFarmaciaBD;

namespace ApiProyectoSistemasInternet.Repositories
{
    public class ClienteNaturalRepository : IAuxRepository<ClienteNatural>
    {
        public bool DeleteObject(object ID)
        {
            try
            {
                using (BaseFarmaciaContext db = new BaseFarmaciaContext())
                {
                    var clienteNatural = db.ClienteNaturals.Find(ID);
                    if (clienteNatural != null)
                    {
                        db.ClienteNaturals.Remove(clienteNatural);
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

        public GetAllResponse<ClienteNatural> GetAllObjects(int offSet, int pageSize)
        {
            try
            {
                using (BaseFarmaciaContext db = new BaseFarmaciaContext())
                {
                    var clientesNaturales = db.ClienteNaturals
                                              .Skip(offSet * pageSize)
                                              .Take(pageSize)
                                              .ToList();

                    return new GetAllResponse<ClienteNatural>
                    {
                        statusCode = 200,
                        isExitoso = true,
                        resultado = clientesNaturales,
                        totalPaginas = (int)Math.Ceiling(db.ClienteNaturals.Count() / (double)pageSize)
                    };
                }
            }
            catch (Exception ex)
            {
                return new GetAllResponse<ClienteNatural>
                {
                    statusCode = 500,
                    isExitoso = false,
                    errorMessages = new List<object> { ex.Message }
                };
            }
        }

        public GetOneResponse<ClienteNatural> GetObjectById(object ID)
        {
            try
            {
                using (BaseFarmaciaContext db = new BaseFarmaciaContext())
                {
                    var clienteNatural = db.ClienteNaturals.Find(ID);
                    if (clienteNatural != null)
                    {
                        return new GetOneResponse<ClienteNatural>
                        {
                            statusCode = 200,
                            isExitoso = true,
                            resultado = clienteNatural
                        };
                    }
                    return new GetOneResponse<ClienteNatural>
                    {
                        statusCode = 404,
                        isExitoso = false,
                        errorMessages = new List<object> { "ClienteNatural no encontrado" }
                    };
                }
            }
            catch (Exception ex)
            {
                return new GetOneResponse<ClienteNatural>
                {
                    statusCode = 500,
                    isExitoso = false,
                    errorMessages = new List<object> { ex.Message }
                };
            }
        }

        public GetOneResponse<ClienteNatural> UpdateCreateObject(ClienteNatural obj)
        {
            try
            {
                using (BaseFarmaciaContext db = new BaseFarmaciaContext())
                {
                    var clienteNatural = db.ClienteNaturals.Find(obj.IdCliente);

                    if (clienteNatural == null)
                    {
                        db.ClienteNaturals.Add(obj);
                        db.SaveChanges();
                        return new GetOneResponse<ClienteNatural>
                        {
                            statusCode = 201,
                            isExitoso = true,
                            resultado = obj
                        };
                    }
                    else
                    {
                        clienteNatural.Edad = obj.Edad;
                        clienteNatural.Estado = obj.Estado;
                        clienteNatural.FechaRegistro = obj.FechaRegistro;
                        clienteNatural.IdPersona = obj.IdPersona;
                        clienteNatural.Telefono = obj.Telefono;

                        db.SaveChanges();
                        return new GetOneResponse<ClienteNatural>
                        {
                            statusCode = 200,
                            isExitoso = true,
                            resultado = clienteNatural
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                return new GetOneResponse<ClienteNatural>
                {
                    statusCode = 500,
                    isExitoso = false,
                    errorMessages = new List<object> { ex.Message }
                };
            }
        }
    }

}
