using System;
using System.Collections.Generic;
using System.Text;

using Nori.Models;

namespace Nori.Views;

public partial class EditTaskPage : ContentPage
{
    private TaskItem _task;

    public EditTaskPage(TaskItem task)
    {
        InitializeComponent();
        _task = task;

        // Заполняем поля текущими значениями
        TitleEntry.Text = _task.Title;
        DescriptionEditor.Text = _task.Description;
        DueDatePicker.Date = _task.DueDate ?? DateTime.Today;
        PriorityPicker.SelectedItem = _task.Priority;

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

        // Обновляем существующую задачу
        _task.Title = TitleEntry.Text.Trim();
        _task.Description = DescriptionEditor.Text;
        _task.DueDate = DueDatePicker.Date;
        _task.Priority = PriorityPicker.SelectedItem?.ToString() ?? "Обычный";

        await Shell.Current.GoToAsync("..");
    }

    private async void OnCancelClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }


}
