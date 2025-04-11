using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace AvaloniaApplication6.Models;

public interface IAccessToPeople
{
    public bool Connect();
    public void Disconnect();
    public Task<int> FillTheCollectionAsync(ObservableCollection<Person> people, DateTime date);
}
