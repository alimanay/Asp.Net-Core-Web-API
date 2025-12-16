using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositoires.Contracts
{
    public interface IRepositoryManager
    {
        IBooksRepository Books { get; }
        void Save();
    }
}
