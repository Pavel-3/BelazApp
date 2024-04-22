using BelazApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Text;
using System.Threading.Tasks;

namespace BelazApp.Services.Interfaces
{
    public interface IVehicleService
    {
        Task<ObservableCollection<BasicVehicleInfo>> GetBasicVehiclesAsync();
        Task<DetailedVehicleInfo> GetDetailedVehicleInfoAsync(string id);
        Task<ObservableCollection<DateTime>> GetAllDatesForVehicleAsync(string id);
        Task<DetailedVehicleInfo> GetDetailedVehicleInfoAsync(string id, DateTime time);
        Task<ObservableCollection<VehicleReport>> GetVehicleReportsAsync(string id);
    }
}
