using System;
using System.Data.Entity;
using System.Linq;
using CloudAspData.Entity;
using CloudAspData.EntityFramework;

namespace CloudAspData
{
    public class DataCloud: IDataCloud
    {
        private CloudContext Context { get; set; } = new CloudContext();
        public void AddClient(Client client)
        {
            Context.Clients.Add(client);
            Context.SaveChanges();
        }

        public Client GetClient(string email)
        {
            return Context.Clients.FirstOrDefault(client => client.Email == email);
        }

        public Client Authorisation(string emeil, string password)
        {
            return Context.Clients.FirstOrDefault(client => client.Email == emeil || client.Password == password);
        }

        public void AddFile(File file)
        {
            Context.Files.Add(file);
            Context.SaveChanges();
        }

        public File[] GetFiles(Guid idRoom)
        {
            return Context.Files.Where(file => file.RoomId == idRoom).AsNoTracking().ToArray();
        }

        public Room RoomById(Guid id)
        {
            return Context.Rooms.FirstOrDefault(room => room.Id == id);
        }

        public void AddRoom(Room room)
        {
            Context.Rooms.Add(room);
            Context.SaveChanges();
        }

        public Role RoleByUserEmail(string email)
        {
            return Context.Clients.Where(client => client.Email == email).Include(client => client.Role).FirstOrDefault()?.Role;
        }
        public void AddNews(News news)
        {
            Context.News.Add(news);
            Context.SaveChanges();
        }

        public News[] GetNews(out int countElement, int pageIndex = 0, int pageSize = 3)
        {
            countElement = Context.News.Count();
            return Context.News.OrderBy(news => news.DateCreate).Skip(pageIndex * pageSize).Take(pageSize).AsNoTracking().ToArray(); ;
        }

        public void UpdateNews(News news)
        {
            var elem = Context.News.FirstOrDefault(news1 => news1.Id == news.Id);
            if (elem == null)
                throw new Exception("");
            elem.Text = news.Text;
            elem.Caption = news.Caption;
            elem.Image = news.Image;
            Context.SaveChanges();
        }

        public void RemoveNews(Guid id)
        {
            Context.News.Remove(Context.News.FirstOrDefault(news => news.Id == id));
            Context.SaveChanges();
        }

        public News GetNewsById(Guid id)
        {
            return Context.News.Where(news => news.Id == id).Include(news => news.Image).FirstOrDefault();
        }

        public void RemoveRoom(Func<Room, bool> where)
        {
           Context.Rooms.RemoveRange(Context.Rooms.Where(where));
        }

        public File FileById(Guid id)
        {
            return Context.Files.FirstOrDefault(file => file.Id == id);
        }

        public void RemoveFile(Guid id)
        {
            var fileDb = Context.Files.FirstOrDefault(file => file.Id == id);
            if (fileDb != null) Context.Files.Remove(fileDb);
        }
    }
}
