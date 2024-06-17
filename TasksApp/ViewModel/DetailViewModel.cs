using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TasksApp.Model;

namespace TasksApp.ViewModel
{
    [QueryProperty(nameof(Model), "Model")]
    public partial class DetailViewModel : ObservableObject
    {
        [ObservableProperty]
        TaskModel model;

        [RelayCommand]
        async Task Back()
        {
            await Shell.Current.GoToAsync("..");
        }

        
    }
}
