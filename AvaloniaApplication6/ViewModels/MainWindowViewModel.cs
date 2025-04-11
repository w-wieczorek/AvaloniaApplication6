using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using Avalonia.Controls;
using AvaloniaApplication6.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace AvaloniaApplication6.ViewModels;

public partial class MainWindowViewModel : ObservableObject, IRecipient<DateChangedMessage>
{
    public ObservableCollection<Person> People { get; }
    private IAccessToPeople _accessToPeople;
    private bool _isConnected;
    
    public MainWindowViewModel(IAccessToPeople accessToPeople)
    {
        People = new(new Person[] {}); 
        StrongReferenceMessenger.Default.Register<DateChangedMessage>(this);
        _accessToPeople = accessToPeople;
        _isConnected = false;
    }

    ~MainWindowViewModel() {
        StrongReferenceMessenger.Default.UnregisterAll(this);
    }

    [RelayCommand]
    public void OnConnect()
    {
        if (_accessToPeople.Connect())
        {
            _isConnected = true;
        }
        else
        {
            _isConnected = false;
        }
    }

    [RelayCommand]
    public void OnDisconnect()
    {
        if (_isConnected)
        {
            _accessToPeople.Disconnect();
            _isConnected = false;
        }
    }

    public async void Receive(DateChangedMessage message)
    {
        if (_isConnected)
        {
            int count = await _accessToPeople.FillTheCollectionAsync(People, message.Date);
        }
    }
}