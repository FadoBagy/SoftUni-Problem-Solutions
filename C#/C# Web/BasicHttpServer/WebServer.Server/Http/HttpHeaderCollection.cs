﻿namespace WebServer.Server.Http
{
    using System.Collections.Generic;

    public class HttpHeaderCollection
    {
        private readonly Dictionary<string, HttpHeader> headers;

        public HttpHeaderCollection()
        {
            this.headers = new Dictionary<string, HttpHeader>();
        }

        public int Count() => headers.Count;

        public void Add(HttpHeader header) 
        {
            headers.Add(header.Name, header);
        }
    }
}