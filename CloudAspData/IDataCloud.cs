using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudAspData.Entity;

namespace CloudAspData
{
    public interface IDataCloud
    {
        void AddClient(Client client);
        Client GetClient(string email);
        Client Authorisation(string username, string password);
        void AddFile(File file);
        File[] GetFiles(Guid idRoom);
        Room RoomById(Guid id);
        void AddRoom(Room room);
        Role RoleByUserEmail(string email);
        News[] GetNews(out int countElement, int pageIndex = 0, int pageSize = 3);
        void UpdateNews(News news);
        void RemoveNews(Guid id);
        News GetNewsById(Guid id);
        void AddNews(News news);
        void RemoveRoom(Func<Room, bool> where);
        File FileById(Guid id);
        void RemoveFile(Guid id);
    }
}
