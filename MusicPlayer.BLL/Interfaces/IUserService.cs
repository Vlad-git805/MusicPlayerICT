using MusicPlayer.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.BLL.Interfaces
{
    public interface IUserService
    {
        void MakeUser(UserDTO userrDto);
        UserDTO GetUser(int id);
        IEnumerable<UserDTO> GetUsers();
        void Dispose();
    }
}
