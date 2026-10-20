using CommunityToolkit.Mvvm.Messaging;
using Nori.Messages;
using System;
using System.Collections.Generic;
using System.Text;

using Nori.Models;
using Nori.ViewModels;

namespace Nori.Views;

public partial class AddTaskPage : ContentPage
{
    public AddTaskPage()
    {
        InitializeComponent();
        PriorityPicker.SelectedIndex = 1;

        // Нельзя выбрать прошедшую дату
        DueDatePicker.MinimumDate = DateTime.Today;
        DueDatePicker.Date = DateTime.Today;
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(TitleEntry.Text))
        {
            await DisplayAlertAsync("Ошибка", "Введите название задачи", "OK");
            return;
        }

        var newTask = new TaskItem
        {
            Title = TitleEntry.Text.Trim(),
            Description = DescriptionEditor.Text,
            DueDate = DueDatePicker.Date,
            Priority = PriorityPicker.SelectedItem?.ToString() ?? "Обычный"
        };

        // Просто добавляем в общую коллекцию
        TasksViewModel.SharedTasks.Add(newTask);

        await Shell.Current.GoToAsync("..");
    }

    private async void OnCancelClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}