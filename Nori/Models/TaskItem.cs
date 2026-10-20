using System;
using System.Collections.Generic;
using System.Text;

using CommunityToolkit.Mvvm.ComponentModel;

namespace Nori.Models;

public partial class TaskItem : ObservableObject
{
    [ObservableProperty]
    private string title = string.Empty;

    [ObservableProperty]
    private string? description;

    [ObservableProperty]
    private DateTime? dueDate;

    [ObservableProperty]
    private string priority = "Обычный";

    [ObservableProperty]
    private bool isCompleted;
}