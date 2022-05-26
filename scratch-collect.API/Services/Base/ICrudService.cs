using scratch_collect.API.Services.Base;

namespace scratch_collect.Api.Services
{
    public interface ICrudService<T, TSearch, TInsert, TUpdate> : IService<T, TSearch>
    {
        T Insert(TInsert request);

        T Update(int id, TUpdate request);
    }
}