using System;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http.Filters;

namespace GestaoCondominio.Web.Filters
{
    public class ApiExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            Exception exception = actionExecutedContext.Exception;
            if (exception is ApplicationException)
            {
                HttpResponseMessage response = new HttpResponseMessage();

                response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                response.Content = new ObjectContent<Resposta>(
                        new Resposta
                        {                            
                            Mensagem = exception.Message
                        }, new JsonMediaTypeFormatter(), "application/json");

                actionExecutedContext.Response = response;
            }
        }

        private class Resposta
        {
            public Int64 Code;
            public String Mensagem;
        }
    }
}