using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Likhachev.Pgas.Services
{
    using Core.Activities;
    public static class FileManagerExtensions
    {
        public static FileStreamResult GetFileStream(this File file)
        {
            using (MemoryStream pdfStream = new MemoryStream())
            {
                pdfStream.Write(file.FileByte, 0, file.FileByte.Length);
                pdfStream.Position = 0;
                return new FileStreamResult(pdfStream, file.FileName);
            }
        }

        public static IFormFile ReturnFormFile(this FileStreamResult result)
        {
            var ms = new MemoryStream();
            try
            {
                result.FileStream.CopyTo(ms);
                return new FormFile(ms, 0, ms.Length, result.FileDownloadName, result.FileDownloadName);
            }
            catch (Exception e)
            {
                ms.Dispose();
                throw;
            }
            finally
            {
                ms.Dispose();
            }
        }
    }
}
