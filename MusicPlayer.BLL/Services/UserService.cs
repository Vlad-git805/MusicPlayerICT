using MusicPlayer.BLL.DTO;
using MusicPlayer.BLL.Infrastructure;
using MusicPlayer.BLL.Interfaces;
using MusicPlayer.DAL.Entities;
using MusicPlayer.DAL.Interfaces;
using System.Collections.Generic;

namespace MusicPlayer.BLL.Services
{
    public class UserService : IService<UserDTO>
    {
        IUnitOfWork Database { get; set; }

        public UserService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void Make(UserDTO classDTO)
        {
            User user = new User
            {
                Name = classDTO.Name,
                Password = classDTO.Password,
                Picture = classDTO.Picture,
                WayToSongs = classDTO.WayToSongs
            };
            Database.Users.Create(user);
            Database.Save();         
        }
        public UserDTO Get(int id)
        {
            return null;
        }
        public IEnumerable<UserDTO> GetAll()
        {
            return null;
        }
        public void Dispose()
        {

        }
    }
}



