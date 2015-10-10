﻿using System;using System.Net;using System.Runtime.Serialization;using Newtonsoft.Json;namespace PagarmeClient{    public class PagarMeError    {        [JsonIgnore]        public HttpStatusCode HttpStatus { get; private set; }        [JsonProperty("url")]        public string Url { get; private set; }        [JsonProperty("method")]        public string Method { get; private set; }        [JsonProperty("errors")]        public PagarMeErrorDetail[] Errors { get; set; }        internal PagarMeError(HttpStatusCode status, string body)        {            HttpStatus = status;            JsonHelper.DeserializeTo(null, this, body);        }    }}

