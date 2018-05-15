using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using CloudAsp.Models.Cloud;
using CloudAspData;
using CloudAspData.Entity;
using File = CloudAspData.Entity.File;

namespace CloudAsp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDataCloud _data;
        public static Timer Timer { get; set; }

        public HomeController(IDataCloud data)
        {
            _data = data;
            if (Timer == null)
            {
                Timer = new Timer(state =>
                {
                    _data.RemoveRoom(room => (room.DataCreated.AddDays((int)room.DaysRemove) > DateTime.Now));
                }, null, 0, (int)TimeSpan.FromMinutes(5).TotalMilliseconds); ;
            }
        }
        public ActionResult Index(string id)
        {
            Guid roomId = Guid.NewGuid();
            if (id != null)
            {
                roomId = Guid.Parse(id);
                return View(new CloudModel() { Id = roomId,Files = _data.GetFiles(roomId).ToList() });
            }
            return View(new CloudModel(){Id = roomId} );
        }

        public ActionResult Files()
        {
            return View("Files");
        }
        [HttpPost]
        public ActionResult UploadFile(string roomId)
        {
            var id = Guid.Parse(roomId);
            var room = _data.RoomById(id);
            if (room == null)
                _data.AddRoom(new Room { Id = id, DataCreated = DateTime.Now });
            foreach (string file in Request.Files)
            {
                HttpPostedFileBase upload = Request.Files[file];
                if (upload != null)
                {
                    string fileName = Path.GetFileName(upload.FileName);

                    byte[] data;
                    using (Stream inputStream = upload.InputStream)
                    {
                        MemoryStream memoryStream = inputStream as MemoryStream;
                        if (memoryStream == null)
                        {
                            memoryStream = new MemoryStream();
                            inputStream.CopyTo(memoryStream);
                        }
                        data = memoryStream.ToArray();
                    }
                    
                    File filedb = new File();
                    filedb.RoomId = id;
                    filedb.Id = Guid.NewGuid();
                    filedb.Name = fileName;
                    filedb.FileType = GetFileType(fileName);
                    filedb.FileBytes = data;
                    _data.AddFile(filedb);
                }
            }
            return View("Files", _data.GetFiles(id).ToArray());
        }

        public ActionResult RemoveFile(Guid id, Guid roomId)
        {
            _data.RemoveFile(id);
            return View("Files", _data.GetFiles(roomId).ToArray());
        }
        public ActionResult DownloadFile(Guid id)
        {
            var file = _data.FileById(id);
            return File(
                file.FileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, file.Name);
        }

        public ActionResult PlayFile(Guid id, string format)
        {
            var file = _data.FileById(id);
            return File(
                file.FileBytes, format);
        }
        FileType GetFileType(string name)
        {
            var nameToLower = name.ToLower();
            if (nameToLower.EndsWith(".png") || nameToLower.EndsWith(".jpg") || nameToLower.EndsWith(".jpeg"))
            {
                return FileType.Image;
            }
            if (nameToLower.EndsWith(".rar") || nameToLower.EndsWith(".zip"))
            {
                return FileType.Rar;
            }
            if (nameToLower.EndsWith(".doc") || nameToLower.EndsWith(".docx"))
            {
                return FileType.Doc;
            }
            if (nameToLower.EndsWith(".mp3"))
            {
                return FileType.Mp3;
            }
            if (nameToLower.EndsWith(".mp4"))
            {
                return FileType.Mp4;
            }
            return FileType.Other;
        }
    }
}