using MusicPlayer.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.BLL.Interfaces
{

    public interface IService<T> where T : class
    {
        void Make(T classDTO);
        T Get(int id);
        IEnumerable<T> GetAll();
        void Dispose();
    }
}
   
