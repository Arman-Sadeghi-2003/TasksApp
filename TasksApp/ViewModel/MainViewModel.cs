using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using TasksApp.Model;

namespace TasksApp.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        PathWorker pathWorker = new PathWorker();

        [ObservableProperty]
        ObservableCollection<Model.TaskModel> tasks;

        public MainViewModel()
        {
            Model = new TaskModel();
            RedRadioButton = true;
            Shell.Current.Navigated += Current_Navigated; ;
        }

        private async void Current_Navigated(object? sender, ShellNavigatedEventArgs e)
            => await load();

        [ObservableProperty]
        TaskModel model;

        // Radio Buttons
        [ObservableProperty]
        bool redRadioButton;
        [ObservableProperty]
        bool yellowRadioButton;
        [ObservableProperty]
        bool greenRadioButton;
        [ObservableProperty]
        bool orangeRadioButton;


        [RelayCommand]
        async Task Add()
        {
            if (string.IsNullOrEmpty(Model.Title))
                return;

            foreach (var task in Tasks)
                if(task.Title.Contains(Model.Title))
                {
                    await Shell.Current.DisplayAlert("Repeated!", $"{Model.Title} is exists in the repository.\nplease set diffrent title", "OK");
                    return;
                }

            if (!(RedRadioButton || YellowRadioButton || GreenRadioButton || OrangeRadioButton))
                RedRadioButton = true;
            else if (RedRadioButton)
                Model.taskColor = new SolidColorBrush(new Color(112, 28, 26, 255));
            else if (YellowRadioButton)
                Model.taskColor = new SolidColorBrush(new Color(244, 179, 21, 255));
            else if (GreenRadioButton)
                Model.taskColor = new SolidColorBrush(new Color(98, 221, 57, 255));
            else if (OrangeRadioButton)
                Model.taskColor = new SolidColorBrush(new Color(255, 79, 0, 255));
            else
                return;

            Tasks.Add(Model);

            await save();

            Model = new TaskModel();
        }

        [RelayCommand]
        async Task Remove(TaskModel m)
        {
            if (Tasks.Contains(m))
            {
                Tasks.Remove(m);
                await save();
            }
        }

        [RelayCommand]
        async Task Tap(TaskModel m)
        {
            await Shell.Current.GoToAsync($"{nameof(DetailPage)}", new Dictionary<string, Object>
            {
                { nameof(Model), m }
            });
        }


        async Task save()
        {
            await ObjectSerializer.SerializeToFile(pathWorker.GetTastsFilePath, Tasks);
        }

        async Task load()
        {
            if (pathWorker.IsTasksFileExists)
                Tasks = await ObjectSerializer.DeserializeFromFile<ObservableCollection<Model.TaskModel>>(pathWorker.GetTastsFilePath);
            else
                Tasks = new ObservableCollection<Model.TaskModel>();

        }
    }
}
