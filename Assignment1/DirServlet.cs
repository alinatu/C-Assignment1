using System;
using System.IO;

namespace Assignment1
{
    public class DirServlet : Servlet
    {
        public DirServlet()
        {
        }

        // Written by Alina
        public override void DoGet(HTTPRequest request, HTTPResponse response)
        {
            string output = "<!DOCTYPE html><html><body><ul>" + GetListing("/Users/alinatumaev/") + "</ul></body></html>";
            response.Write(output);
        }

        public override void DoPost(HTTPRequest request, HTTPResponse response) { }


        // Written by Alina
        private String GetListing(string path)
        {
            DirectoryInfo di = new DirectoryInfo(path);

            FileInfo[] fiArr = di.GetFiles();
            string files = "";
            foreach (FileInfo fri in fiArr)
            {
                if (fri.Attributes.HasFlag(FileAttributes.Directory))
                {
                    files += "<li><button type=\"button\">" + fri.DirectoryName + "</button></li>";
                }
                else
                {
                    files += "<li>" + fri + "</li>";
                }
            }
            return files;
        }
    }
}
