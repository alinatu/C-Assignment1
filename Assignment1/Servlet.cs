﻿using System;
namespace Assignment1
{
    public abstract class Servlet
    {
        public abstract void DoGet(HTTPRequest request, HTTPResponse response);
        public abstract void DoPost(HTTPRequest request, HTTPResponse response);

    }
}
