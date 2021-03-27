using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository</*class*/> /*class*/ { get; }
        IRepository</*class*/> /*class*/ { get; }
        void Save();
    }
}
