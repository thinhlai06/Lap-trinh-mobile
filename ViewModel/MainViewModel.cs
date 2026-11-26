using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
namespace MauiApp1.ViewModel;
public partial class MainViewModel:ObservableObject
{
    IConnectivity connectivity;

    public MainViewModel(IConnectivity connectivity)
    {
        Items = new ObservableCollection<string>();
        this.connectivity = connectivity;
    }
    [ObservableProperty]
    ObservableCollection<string> items;
    [ObservableProperty]
    string text;
    [RelayCommand]
    async Task Add()
    {
        if (string.IsNullOrWhiteSpace(Text))
            return;

        if (connectivity.NetworkAccess != NetworkAccess.Internet)
        {
            await Shell.Current.DisplayAlert("Uh Oh","No Internet","OK");
            return;
        }

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
