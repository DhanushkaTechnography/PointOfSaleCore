
namespace PizzaCore.Entity.Payload
{
    public class StatusCode
    {
        private int _statusCode;
        private Response _response;

        public StatusCode(int _statusCode,Response response)
        {
            this._response = response;
            this._statusCode = _statusCode;
        }
    }
}