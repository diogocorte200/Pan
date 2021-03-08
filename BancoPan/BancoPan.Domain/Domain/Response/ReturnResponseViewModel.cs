namespace BancoPan.Domain.Domain.Response
{
    public class ReturnResponseViewModel<Response,TObject>
    {
        public Response TResponse { get; set; }
        public TObject Object { get; set; }
    }
}
