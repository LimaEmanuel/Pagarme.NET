using System;namespace PagarmeClient{    public class PagarMeException : Exception    {        public PagarMeError Error { get; private set; }        public PagarMeException(PagarMeError error)        {            Error = error;        }    }}

