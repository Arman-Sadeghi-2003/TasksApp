using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using TasksApp.Model;

namespace TasksApp.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<Model.TaskModel> tasks;

        public MainViewModel()
        {
            tasks = new ObservableCollection<Model.TaskModel>();
            Model = new TaskModel();
            RedRadioButton = true;
        }

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
        void Add()
        {
            if (string.IsNullOrEmpty(Model.Title))
                return;

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

            Model = new TaskModel();
        }

        [RelayCommand]
        void Remove(TaskModel m)
        {
            if (Tasks.Contains(m))
                Tasks.Remove(m);
        }

        [RelayCommand]
        async Task Tap(TaskModel m)
        {
            await Shell.Current.GoToAsync($"{nameof(DetailPage)}? Model={m}");
        }
    }
}
