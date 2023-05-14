using ErrorOr;
using Gproject.Application.Common.Interfaces.Services;
using Gproject.Application.Common.Interfaces.Services.Common;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gproject.Infrastruct.Services
{
    public class UploadFilesService : IUploadFilesService
    {
        [Obsolete]
        private readonly IHostingEnvironment _hostingEnvironment;
        [Obsolete]
        public UploadFilesService(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        [Obsolete]
        public async Task<ErrorOr<ResponseFileUploaded>> DeleteFile(string path)
        {
            await Task.CompletedTask;
            if (path != null)
            {
                try
                {
                    var fullPath = $"{_hostingEnvironment.WebRootPath}{path}";
                    File.Delete(fullPath);
                    return new ResponseFileUploaded(true, "Deleted Done.");

                }
                catch (Exception)
                {
                    return Error.Failure(code: "Failure", description: "Failure TO Delete File");
                }
            }
            else
            {
                return Error.NotFound(code: "Not.Found", description: "Not Found Any File");
            }
        }

        [Obsolete]
        public async Task<ErrorOr<ResponseFileUploaded>> UploadFile(string path, IFormFile file, bool deleteOldFiles = false)
        {
            if (file != null)
            {
                try
                {
                    if (!Directory.Exists($"{_hostingEnvironment.WebRootPath}\\{path}"))
                    {
                        Directory.CreateDirectory($"{_hostingEnvironment.WebRootPath}\\{path}");
                    }
                    else
                    {
                        if (deleteOldFiles)
                        {
                            Array.ForEach(Directory.GetFiles($"{_hostingEnvironment.WebRootPath}\\{path}"),
                                    delegate (string filePath) { File.Delete(filePath); });
                        }
                    }
                    using (FileStream filestream = File.Create($"{_hostingEnvironment.WebRootPath}\\{path}\\{file.FileName}"))
                    {
                        await file.CopyToAsync(filestream);
                        await filestream.FlushAsync();
                        var newFullPath = $"\\{path}\\{file.FileName}";
                        return new ResponseFileUploaded(true, "Uploaded Done.");
                    }
                }
                catch (Exception)
                {
                    return Error.Failure(code: "Failure", description: "Failure TO Upload File");
                }
            }
            else
            {
                return Error.NotFound(code: "Not.Found", description: "Not Found Any File");
            }
        }
        [Obsolete]
        public async Task<ErrorOr<ResponseFileUploaded>> UploadFiles(string path, List<IFormFile> files, bool deleteOldFiles = false)
        {
            if (files != null && files.Count() > 0)
            {
                try
                {
                    if (!Directory.Exists($"{_hostingEnvironment.WebRootPath}\\{path}"))
                    {
                        Directory.CreateDirectory($"{_hostingEnvironment.WebRootPath}\\{path}");
                    }
                    else
                    {
                        if (deleteOldFiles)
                        {
                            Array.ForEach(Directory.GetFiles($"{_hostingEnvironment.WebRootPath}\\{path}"),
                                    delegate (string filePath) { File.Delete(filePath); });
                        }

                    }
                    List<string> newFullPaths = new List<string>();
                    foreach (var file in files)
                    {

                        using (FileStream filestream = File.Create($"{_hostingEnvironment.WebRootPath}\\{path}\\{file.FileName}"))
                        {
                            await file.CopyToAsync(filestream);
                            await filestream.FlushAsync();
                            var newFullPath = $"\\{path}\\{file.FileName}";
                            newFullPaths.Add(newFullPath);
                        }
                    }
                    return new ResponseFileUploaded(true, "Uploaded All Done.");
                }
                catch (Exception)
                {
                    return Error.Failure(code: "Failure", description: "Failure To Upload Files");
                }
            }
            else
            {
                return Error.NotFound(code: "Not.Found", description: "Not Found Any Files");
            }
        }
    }
}
