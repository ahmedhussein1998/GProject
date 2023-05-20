using ErrorOr;
using Gproject.Application.Common.Interfaces.Services;
using Gproject.Application.Common.Interfaces.Services.Common;
using Gproject.Domain.AttachmentAggregate;
using Gproject.Infrastruct.Persistance;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gproject.Infrastruct.Services
{
    public class UploadFilesService : IUploadFilesService
    {
        [Obsolete]
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly GProjectDbContext _context;

        [Obsolete]
        public UploadFilesService(IHostingEnvironment hostingEnvironment, GProjectDbContext context)
        {
            _hostingEnvironment = hostingEnvironment;
            _context = context;
        }
        private static byte[] GetFileBytes(IFormFile file)
        {
            using var ms = new MemoryStream();
            file.CopyTo(ms);
            return ms.ToArray();
        }

        public async Task InsertAttachmentInTable(Attachment attachment)
        {
            _context.Attachments.Add(attachment);
            await _context.SaveEntitiesAsync();
        }
        public async Task RemoveFileFormTable(Guid Id)
        {
            var File = _context.Attachments.FirstOrDefault(x => x.Id == Id);
            _context.Attachments.Remove(File);
            await _context.SaveEntitiesAsync();
        }

        public async Task<Attachment> GetFileAttachment(Guid Id)
        {
            await Task.CompletedTask;
            var File = _context.Attachments.FirstOrDefault(x => x.Id == Id);
            return File;
        }

        [Obsolete]
        public async Task<bool> DeleteFilePhysical(string path)
        {
            await Task.CompletedTask;
            if (path != null)
            {
                try
                {
                    var fullPath = $"{_hostingEnvironment.WebRootPath}{path}";
                    File.Delete(fullPath);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        [Obsolete]
        public async Task<string> UploadFile(IFormFile file, bool deleteOldFiles = false)
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

                    //var savedName = $"{Guid.NewGuid()}{DateTime.Now.ToString("dd-MM-yyyy")}{Path.GetExtension(file.FileName)}";

                    var fileByte = GetFileBytes(file);
                    var newFullPath = $"\\{path}\\{file.FileName}";
                    await using var fileStream = File.Create(Path.Combine(fullPath, file.FileName));
                    await fileStream.WriteAsync(fileByte);

                    return newFullPath;

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
        public async Task<string[]> UploadFiles(IList<IFormFile> files, bool deleteOldFiles = false)
        {
            if (files != null && files.Count() > 0)
            {
                try
                {
                    Random rnd = new Random();
                    var path = Path.Combine("Uploads", "Test", $"Test_{DateTime.Now.Year}_{DateTime.Now.Month}_{DateTime.Now.Day}_{DateTime.Now.Second}_{rnd.Next(9000)}");
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
                    string[] myStringArray = new string[0];
                    for (int i = 0; i < files.Count; i++)
                    {
                        using (FileStream filestream = File.Create($"{_hostingEnvironment.WebRootPath}\\{path}\\{files[i].FileName}"))
                        {
                            var file = GetFileBytes(files[i]);
                            await filestream.WriteAsync(file);
                            var newFullPath = $"\\{path}\\{files[i].FileName}";
                            Array.Resize(ref myStringArray, myStringArray.Length + 1);
                            myStringArray[myStringArray.Length - 1] = newFullPath;
                        }
                    }
                    return myStringArray;
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
    }
}
