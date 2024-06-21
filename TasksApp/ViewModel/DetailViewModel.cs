using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using TasksApp.Model;

namespace TasksApp.ViewModel
{
    [QueryProperty(nameof(Model), "Model")]
    public partial class DetailViewModel : ObservableObject
    {
        List<TaskModel> tasks;
        PathWorker pathWorker = PathWorker.Instance;

        public DetailViewModel()
        {
            load();
        }

        [ObservableProperty]
        TaskModel model;

        [RelayCommand]
        async Task Back()
        {
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        async Task Edit(TaskModel m)
        {
            tasks[indexOf(m)] = m;

            await Save();

            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        async Task Delete(TaskModel m)
        {
            tasks.RemoveAt(indexOf(m));

            await Save();

            await Shell.Current.GoToAsync("..");
        }

        int indexOf(TaskModel m) =>
            tasks.FindIndex(_model => _model.Title.Contains(m.Title));

        async Task Save()
        {
            await ObjectSerializer.SerializeToFile(pathWorker.GetTastsFilePath, new ObservableCollection<TaskModel>(tasks));
        }

        async Task load()
        {
            if (pathWorker.IsTasksFileExists)
                tasks = (await ObjectSerializer.DeserializeFromFile<ObservableCollection<Model.TaskModel>>(pathWorker.GetTastsFilePath)).ToList();
        }

    }
}
