using System;
using System.Collections.Generic;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Nori.ViewModels;   // ← замени Nori на имя своего проекта, если другое

public partial class CounterViewModel : ObservableObject
{
    [ObservableProperty]
    private int count;

    [RelayCommand]
    private void Increment()
    {
        Count++;
    }

    [RelayCommand]
    private void Reset()
    {
        Count = 0;
    }
}
