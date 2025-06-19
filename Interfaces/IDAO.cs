using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_cinema.Interfaces
{
    public interface IDAO<T>
    {
        public T GetById(int id);
    }
}