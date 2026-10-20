using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Nori.Models;
using System.Collections.ObjectModel;

namespace Nori.ViewModels;

public partial class TasksViewModel : ObservableObject
{
    // Статическая коллекция — общая для всего приложения
    public static ObservableCollection<TaskItem> SharedTasks { get; } = new();

    public ObservableCollection<TaskItem> Tasks => SharedTasks;

    [ObservableProperty]
    private string newTaskTitle = string.Empty;

    [RelayCommand]
    private void AddTask()
    {
        if (string.IsNullOrWhiteSpace(NewTaskTitle))
            return;

        SharedTasks.Add(new TaskItem
        {
            Title = NewTaskTitle.Trim()
        });

        NewTaskTitle = string.Empty;
    }

    [RelayCommand]
    private void RemoveTask(TaskItem? task)
    {
        if (task is null) return;

        if (SharedTasks.Contains(task))
            SharedTasks.Remove(task);
    }

    [RelayCommand]
    private void ToggleComplete(TaskItem? task)
    {
        if (task is null) return;

        task.IsCompleted = !task.IsCompleted;
    }
}
