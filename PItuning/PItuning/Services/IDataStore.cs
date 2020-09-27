using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PItuning.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddObjectModelAsync(T ObjectModel);
        Task<bool> UpdateObjectModelAsync(T ObjectModel);
        Task<bool> DeleteObjectModelAsync(string id);
        Task<T> GetObjectModelAsync(string id);
        Task<IEnumerable<T>> GetObjectModelsAsync(bool forceRefresh = false);
    }
}
