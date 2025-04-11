using System;
using Avalonia.Controls;
using AvaloniaApplication6.ViewModels;
using CommunityToolkit.Mvvm.Messaging;

namespace AvaloniaApplication6.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void CalendarDatePicker_OnSelectedDateChanged(object? sender, SelectionChangedEventArgs e)
    {
        CalendarDatePicker? calendarDatePicker = sender as CalendarDatePicker;
        DateTime? date = calendarDatePicker!.SelectedDate;
        StrongReferenceMessenger.Default.Send<DateChangedMessage>(new DateChangedMessage(date!.Value));
    }
}