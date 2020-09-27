using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PItuning.Models;

namespace PItuning.Services
{
    public class MockDataStore : IDataStore<ObjectModel>
    {
        List<ObjectModel> objectModels;

        public MockDataStore()
        {
            objectModels = new List<ObjectModel>();
            var mockObjectModels = new List<ObjectModel>
            {
                new ObjectModel { Id = Guid.NewGuid().ToString(), TagName = "PIC001", Description="Liquefied natural gas pressure", Gp=0.1, Dt=3, Tau1=20, Tau2=0, Beta=0},
                new ObjectModel { Id = Guid.NewGuid().ToString(), TagName = "FIC001", Description="Liquefied natural gas flow", Gp=1, Dt=10, Tau1=60, Tau2=0, Beta=0},
                new ObjectModel { Id = Guid.NewGuid().ToString(), TagName = "TIC001", Description="Liquefied natural gas temperature", Gp=10, Dt=20, Tau1=120, Tau2=0, Beta=0},
                new ObjectModel { Id = Guid.NewGuid().ToString(), TagName = "PIC002", Description="Liquefied natural gas pressure", Gp=0.2, Dt=3, Tau1=20, Tau2=0, Beta=0},
                new ObjectModel { Id = Guid.NewGuid().ToString(), TagName = "FIC002", Description="Liquefied natural gas flow", Gp=2, Dt=10, Tau1=60, Tau2=0, Beta=0},
                new ObjectModel { Id = Guid.NewGuid().ToString(), TagName = "TIC002", Description="Liquefied natural gas temperature", Gp=20, Dt=20, Tau1=120, Tau2=0, Beta=0}
            };

            foreach (var ObjectModel in mockObjectModels)
            {
                objectModels.Add(ObjectModel);
            }
        }

        public async Task<bool> AddObjectModelAsync(ObjectModel ObjectModel)
        {
            objectModels.Add(ObjectModel);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateObjectModelAsync(ObjectModel ObjectModel)
        {
            var oldObjectModel = objectModels.Where((ObjectModel arg) => arg.Id == ObjectModel.Id).FirstOrDefault();
            objectModels.Remove(oldObjectModel);
            objectModels.Add(ObjectModel);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteObjectModelAsync(string id)
        {
            var oldObjectModel = objectModels.Where((ObjectModel arg) => arg.Id == id).FirstOrDefault();
            objectModels.Remove(oldObjectModel);

            return await Task.FromResult(true);
        }

        public async Task<ObjectModel> GetObjectModelAsync(string id)
        {
            return await Task.FromResult(objectModels.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<ObjectModel>> GetObjectModelsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(objectModels);
        }
    }
}