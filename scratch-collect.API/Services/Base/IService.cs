using System.Collections.Generic;

namespace scratch_collect.API.Services.Base
{
    public interface IService<T, TSearch>
    {
        List<T> Get(TSearch search);

        T GetById(int id);
    }
}