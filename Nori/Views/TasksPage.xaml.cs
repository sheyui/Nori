using System;
using System.Collections.Generic;
using System.Text;

using CommunityToolkit.Mvvm.Messaging;
using Nori.Messages;
using Nori.ViewModels;

namespace Nori.Views;

public partial class TasksPage : ContentPage
{
    public TasksPage()
    {
        InitializeComponent();
        BindingContext = new TasksViewModel();
    }

    private async void OnAddTaskClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(AddTaskPage));
    }

    private async void OnAboutClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(AboutPage));
    }

    private void OnTaskCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        // Пока ничего дополнительно делать не нужно.
        // IsCompleted уже меняется через биндинг.
    }

    private async void OnTaskTapped(object sender, TappedEventArgs e)
    {
        if (e.Parameter is Models.TaskItem task)
        {
            await Navigation.PushAsync(new EditTaskPage(task));
        }
    }
}