namespace ApiProyectoSistemasInternet.IServices
{
    public class GetOneResponse<T>
    {
        public int statusCode { get; set; }
        public bool isExitoso { get; set; }
        public List<object> errorMessages { get; set; }
        public T resultado { get; set; }
        public int totalPaginas { get; set; }
    }

    public class GetAllResponse<T>
    {
        public int statusCode { get; set; }
        public bool isExitoso { get; set; }
        public List<object> errorMessages { get; set; }
        public List<T> resultado { get; set; }
        public int totalPaginas { get; set; }
    }
}
