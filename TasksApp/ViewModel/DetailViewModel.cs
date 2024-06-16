using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksApp.Model;
using Windows.ApplicationModel.VoiceCommands;

namespace TasksApp.ViewModel
{
    [QueryProperty("Model","Model")]
    public partial class DetailViewModel : ObservableObject
    {

        [ObservableProperty]
        TaskModel model;

        async Task Back()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
