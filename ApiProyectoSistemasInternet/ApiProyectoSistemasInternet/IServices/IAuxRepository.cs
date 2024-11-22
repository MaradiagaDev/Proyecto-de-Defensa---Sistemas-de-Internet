namespace ApiProyectoSistemasInternet.IServices
{
    public interface IAuxRepository<T>
    {
        public GetOneResponse<T> UpdateCreateObject(T obj);
        public bool DeleteObject(object ID);
        public GetOneResponse<T> GetObjectById(object ID);
        public GetAllResponse<T> GetAllObjects(int offSet, int pageSize);
    }
}
