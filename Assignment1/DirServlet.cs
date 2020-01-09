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
<<<<<<< HEAD
            string output = "<!DOCTYPE html><html><body><ul>" + GetListing("/") + "</ul></body></html>";
=======
            string output = "<!DOCTYPE html><html><body><ul>" + GetListing("c:/Users/tlrla/") + "</ul></body></html>";
>>>>>>> Taylor's commit
            response.Write(output);
        }

        public override void DoPost(HTTPRequest request, HTTPResponse response) { }


        // Written by Alina
        private String GetListing(string path)
        {
            string[] allfiles = Directory.GetFileSystemEntries(path);

            string files = "";
            foreach (var file in allfiles)
            {
                FileInfo info = new FileInfo(file);
                if (info.Attributes.HasFlag(FileAttributes.Directory))
                {
                    files += "<li><button type=\"button\">" + info.Name + "</button></li>";
                }
                else
                {
                    files += "<li>" + info.Name + "</li>";
                }
            }
            return files;
        }
    }
}
