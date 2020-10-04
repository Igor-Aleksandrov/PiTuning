using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using PItuning.Models;
using PItuning.Views;

namespace PItuning.ViewModels
{
    public class ObjectModelsViewModel : BaseViewModel
    {
        public ObservableCollection<ObjectModel> ObjectModels { get; set; }

        public Command SaveObjectModelCommand { get; set; }
        public Command CancelCommand { get; set; }
        public Command CreateObjectModelCommand { get; set; }
        public Command LoadObjectModelsCommand { get; set; }

        public INavigation Navigation { get; set; }

        public ObjectModelsViewModel()
        {
            Title = "Controllers";
            ObjectModels = new ObservableCollection<ObjectModel>();

            //SaveObjectModelCommand = new Command(async (ref ObjectModel om) => await SaveObjectModel(om));
            SaveObjectModelCommand = new Command(SaveObjectModel);
            CancelCommand = new Command(Cancel);
            CreateObjectModelCommand = new Command(async () => await CreateObjectModel());
            LoadObjectModelsCommand = new Command(async () => await ExecuteLoadObjectModelsCommand());

            MessagingCenter.Subscribe<NewObjectModelPage, ObjectModel>(this, "AddObjectModel", async (obj, objectModel) =>
            {
                var newObjectModel = objectModel as ObjectModel;
                ObjectModels.Add(newObjectModel);
                await DataStore.AddObjectModelAsync(newObjectModel);
            });
        }

        async void Cancel()
        {
            await Navigation.PopModalAsync();
        }

        async void SaveObjectModel(object controller)
        {
            var newObjectModel = controller as ObjectModel;
            ObjectModels.Add(newObjectModel);
            await DataStore.AddObjectModelAsync(newObjectModel);
        }

        async Task CreateObjectModel()
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewObjectModelPage(new NewObjectModelViewModel() { ListViewModel = this })));
        }

        async Task ExecuteLoadObjectModelsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                ObjectModels.Clear();
                var objectmodels = await DataStore.GetObjectModelsAsync(true);
                foreach (var objectModel in objectmodels)
                {
                    ObjectModels.Add(objectModel);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}