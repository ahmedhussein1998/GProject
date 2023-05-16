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
                    return new ResponseFileUploaded("xxxxx", true, "Deleted Done.");

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
        public async Task<string> UploadFile(byte[] file, string fileName, bool deleteOldFiles = false)
        {
            if (file != null)
            {
                try
                {
                    Random rnd = new Random();
                    var path = Path.Combine("Uploads", "Test", $"Test_{DateTime.Now.Year}_{DateTime.Now.Month}_{DateTime.Now.Day}_{DateTime.Now.Second}_{rnd.Next(9000)}");

                    if (string.IsNullOrWhiteSpace(_hostingEnvironment.WebRootPath))
                    {
                        _hostingEnvironment.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                    }

                    var fullPath = Path.Combine(_hostingEnvironment.WebRootPath, path);

                    //if (!Directory.Exists($"{_hostingEnvironment.WebRootPath}\\{path}"))
                    //{
                    //    Directory.CreateDirectory($"{_hostingEnvironment.WebRootPath}\\{path}");
                    //}

                    if (!Directory.Exists(fullPath))
                    {
                        Directory.CreateDirectory(fullPath);
                    }
                    else
                    {
                        if (deleteOldFiles)
                        {
                            Array.ForEach(Directory.GetFiles(fullPath),
                                    delegate (string filePath) { File.Delete(filePath); });
                        }
                    }

                    var savedName = $"{Guid.NewGuid()}{DateTime.Now.ToString("dd-MM-yyyy")}{Path.GetExtension(fileName)}";


                    await using var fileStream = File.Create(Path.Combine(fullPath, savedName));
                    await fileStream.WriteAsync(file);

                    return savedName;

                }
                catch (Exception)
                {
                    return null;
                }
            }
            else
            {
                return null;
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
                    return new ResponseFileUploaded("xxxxx",true, "Uploaded All Done.");
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
