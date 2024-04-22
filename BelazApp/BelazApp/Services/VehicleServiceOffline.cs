using BelazApp.Models;
using BelazApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace BelazApp.Services
{
    public class VehicleServiceOffline : IVehicleService
    {
        public async Task<ObservableCollection<DateTime>> GetAllDatesForVehicleAsync(string id)
        {
            return new ObservableCollection<DateTime>() { DateTime.Now};
        }

        public async Task<ObservableCollection<BasicVehicleInfo>> GetBasicVehiclesAsync()
        {
            var detailedVehicle = Data.GetVehicles();
            var vehicle = detailedVehicle.Select(x => new BasicVehicleInfo()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Model = x.Model,
                ImagePath = x.ImagePath,
            });
            return new ObservableCollection<BasicVehicleInfo>(vehicle);
        }

        public async Task<DetailedVehicleInfo> GetDetailedVehicleInfoAsync(string id)
        {
            var vehicles = Data.GetVehicles();
            var vehicle = vehicles.Where(x => x.Id == id).FirstOrDefault();
            return vehicle;
        }

        public async Task<DetailedVehicleInfo> GetDetailedVehicleInfoAsync(string id, DateTime time)
        {
            var vehicles = Data.GetVehicles();
            var vehicle = vehicles.Where(x => x.Id == id).FirstOrDefault();
            return vehicle;
        }

        public async Task<ObservableCollection<VehicleReport>> GetVehicleReportsAsync(string id)
        {
            return Data.GetReports(id);
        }
    }
    public static class Data
    {
        public static List<DetailedVehicleInfo> Vehicles = new List<DetailedVehicleInfo>();
        public static List<DetailedVehicleInfo> GetVehicles()
        {
            for (int i = 0; i < 20; i++)
            {
                Vehicles.Add(
                    new DetailedVehicleInfo()
                    {
                        ImagePath = "BasePicture.png",
                        Id = i.ToString(),
                        Name = $"Vehicle {i}",
                        Model = $"Model {i % 4}",
                        Description = $"Name: Vehicle {i}, Model: Model {i % 4}",
                        Sections = new Dictionary<string, Dictionary<string, Parameter>>()
                        {
                            {
                                "ЭПП", new Dictionary<string, Parameter>()
                                {
                                    {
                                        "Скрость движения", new Parameter()
                                        {
                                            Value = new Random(DateTime.Now.Minute * i).Next(0,293) / 3,
                                            IsValid = true
                                        }
                                    },
                                    {
                                        "Пробег",new Parameter()
                                        {
                                            Value = new Random(DateTime.Now.Minute * i).Next(0,124322) / 423,
                                            IsValid = false
                                        }
                                    },
                                    {
                                        "Давление в рулевом управлении", new Parameter()
                                        {
                                            Value = new Random(DateTime.Now.Minute * i).Next(0,432) / 43,
                                            IsValid = true
                                        }
                                    },
                                    {
                                        "Аварийная температура масла в гидросистеме", new Parameter()
                                        {
                                            Value = new Random(DateTime.Now.Minute * i).Next(0,432) / 43,
                                            IsValid = true
                                        }
                                    },
                                    {
                                        "Температура масла в гидросистеме", new Parameter()
                                        {
                                            Value = new Random(DateTime.Now.Minute * i).Next(0, 234) / 326,
                                            IsValid = true
                                        }
                                    }

                                }

                            },
                            {
                                "СКТ", new Dictionary<string, Parameter>()
                                {
                                    {
                                        "Давление шин", new Parameter()
                                        {
                                            Value = new Random(DateTime.Now.Minute*i).Next(0,293) / 3,
                                            IsValid = true
                                        }
                                    },
                                    {
                                        "Положение внешних шин", new Parameter()
                                        {
                                            Value = new Random(DateTime.Now.Minute*i).Next(43,124322) / 423,
                                            IsValid = false
                                        }
                                    }
                                }

                            }
                        }
                    });
            }
            return Vehicles;
        }
        //public static List<DetailedVehicleInfo> GetVehicles(int minute)
        //{
        //    for (int i = 0; i < 20; i++)
        //    {
        //        Vehicles.Add(
        //            new DetailedVehicleInfo()
        //            {
        //                ImagePath = "BasePicture.png",
        //                Id = i.ToString(),
        //                Name = $"Vehicle {i}",
        //                Model = $"Model {i % 4}",
        //                Description = $"Name: Vehicle {i}, Model: Model {i % 4}",
        //                Sections = new ObservableCollection<Section>()
        //                {
        //                    new Section()
        //                    {
        //                        Name = "ЭПП",
        //                        Parameters = new ObservableCollection<Parameter>()
        //                        {
        //                            new Parameter()
        //                            {
        //                                ParameterName = "Скрость движения",
        //                                ParameterValue = new Random(minute * i).Next(0,293) / 3,
        //                                IsValid = true
        //                            },
        //                            new Parameter()
        //                            {
        //                                ParameterName = "Пробег",
        //                                ParameterValue = new Random(minute * i).Next(0,124322) / 423,
        //                                IsValid = false
        //                            },
        //                            new Parameter()
        //                            {
        //                                ParameterName = "Давление в рулевом управлении",
        //                                ParameterValue = new Random(minute * i).Next(0,432) / 43,
        //                                IsValid = true
        //                            },
        //                            new Parameter()
        //                            {
        //                                ParameterName = "Аварийная температура масла в гидросистеме",
        //                                ParameterValue = new Random(minute * i).Next(0,6534) /656,
        //                                IsValid = true
        //                            },
        //                            new Parameter()
        //                            {
        //                                ParameterName = "Температура масла в гидросистеме",
        //                                ParameterValue = new Random(minute * i).Next(0,234) / 326,
        //                                IsValid = true
        //                            },
        //                        }
        //                    },
        //                    new Section()
        //                    {
        //                        Name = "СКТ",
        //                        Parameters = new ObservableCollection<Parameter>()
        //                        {
        //                            new Parameter()
        //                            {
        //                                ParameterName = "Давление шин",
        //                                ParameterValue = new Random(minute*i).Next(0,293) / 3,
        //                                IsValid = true
        //                            },
        //                            new Parameter()
        //                            {
        //                                ParameterName = "Положение внешних шин",
        //                                ParameterValue = new Random(minute*i).Next(43,124322) / 423,
        //                                IsValid = false
        //                            },
        //                            new Parameter()
        //                            {
        //                                ParameterName = "Положение внутренних шин",
        //                                ParameterValue = new Random(minute * i).Next(53,432) / 43,
        //                                IsValid = true
        //                            }
        //                        }
        //                    }
        //                }
        //            });
        //    }
        //    return Vehicles;
        //}
        public static ObservableCollection<VehicleReport> GetReports(string vehicleId)
        {
            var reports = new ObservableCollection<VehicleReport>();
            Random random = new Random(DateTime.Now.Minute);
            for (int i = 0; i < random.Next(2, 5); i++)
            {
                var report = new VehicleReport();
                report.VehicleId = vehicleId;
                int length = random.Next(20, 51);
                const string chars = "йцукенгшщзхъфывапролджэячсмитьбю               ";
                string randomString = new string(Enumerable.Repeat(chars, length)
                    .Select(s => s[random.Next(s.Length)]).ToArray());
                DateTime start = new DateTime(1995, 1, 1);
                int range = (DateTime.Today - start).Days;
                DateTime randomDate = start.AddDays(random.Next(range));
                report.RecordingTime = randomDate;
                report.Description = randomString;
                reports.Add(report);
            }
            return reports;
        }
        public static List<Point> GetPoints(Parameter parameter)
        {
            DateTime time = DateTime.Now;
            Random random = new Random(time.Millisecond);
            List<Point> points = new List<Point>();
            time = time - new TimeSpan(0, 10, 0);
            for (int i = 0; i < 10; i++)
            {
                points.Add(new Point()
                {
                    value = random.Next(10, 100),
                    time = time
                });
                time = time + new TimeSpan(0, 1, 0);
            }
            return points;
        }
    }
}
