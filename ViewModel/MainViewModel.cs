using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
namespace MauiApp1.ViewModel;
public partial class MainViewModel:ObservableObject
{
    public MainViewModel()
    {
        Items = new ObservableCollection<string>();
    }
    [ObservableProperty]
    ObservableCollection<string> items;
    [ObservableProperty]
    string text;
    [RelayCommand]
    void Add()
    {
        if (string.IsNullOrWhiteSpace(Text))
            return;
        Items.Add(Text);
        Text = string.Empty;
    }

    [RelayCommand]
    async Task Tap(string s)
    {
        if (string.IsNullOrWhiteSpace(s))
            return;

        await Shell.Current.GoToAsync($"{nameof(DetailPage)}?Text={Uri.EscapeDataString(s)}");
    }
}
