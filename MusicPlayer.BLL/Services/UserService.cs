using MusicPlayer.BLL.DTO;
using MusicPlayer.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.BLL.Services
{
    public class UserService : IUserService
    {
        public void MakeUser(UserDTO userrDto)
        {

        }
        public UserDTO GetUser(int id)
        {
            return null;
        }
        public IEnumerable<UserDTO> GetUsers()
        {
            return null;
        }
        public void Dispose()
        {

        }
    }
}
