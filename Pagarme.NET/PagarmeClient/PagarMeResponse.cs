using System;using System.Net;namespace PagarmeClient{    public class PagarMeResponse    {        public HttpStatusCode HttpStatus { get; private set; }        public string Body { get; private set; }        public PagarMeResponse(HttpStatusCode status, string body)        {            HttpStatus = status;            Body = body;        }    }}

