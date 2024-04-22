using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using BelazApp.Models;

//namespace BelazApp.Models
//{
//    public static class Data
//    {
//        public static List<DetailedVehicleInfo> Vehicles = new List<DetailedVehicleInfo>();
//        //public static List<DetailedVehicleInfo> GetVehicles()
//        //{
//        //    for (int i = 0; i < 20; i++)
//        //    {
//        //        Vehicles.Add(
//        //            new DetailedVehicleInfo()
//        //            {
//        //                ImagePath = "BasePicture.png",
//        //                Id = i.ToString(),
//        //                Name = $"Vehicle {i}",
//        //                Model = $"Model {i % 4}",
//        //                Description = $"Name: Vehicle {i}, Model: Model {i % 4}",
//        //                Sections = new()
//        //                {
//        //                    new Section()
//        //                    {
//        //                        Name = "ЭПП",
//        //                        Parameters = new ObservableCollection<Parameter>()
//        //                        {
//        //                            new Parameter()
//        //                            {
//        //                                ParameterName = "Скрость движения",
//        //                                ParameterValue = new Random(DateTime.Now.Minute * i).Next(0,293) / 3,
//        //                                IsValid = true
//        //                            },
//        //                            new Parameter()
//        //                            {
//        //                                ParameterName = "Пробег",
//        //                                ParameterValue = new Random(DateTime.Now.Minute * i).Next(0,124322) / 423,
//        //                                IsValid = false
//        //                            },
//        //                            new Parameter()
//        //                            {
//        //                                ParameterName = "Давление в рулевом управлении",
//        //                                ParameterValue = new Random(DateTime.Now.Minute * i).Next(0,432) / 43,
//        //                                IsValid = true
//        //                            },
//        //                            new Parameter()
//        //                            {
//        //                                ParameterName = "Аварийная температура масла в гидросистеме",
//        //                                ParameterValue = new Random(DateTime.Now.Minute * i).Next(0,6534) /656,
//        //                                IsValid = true
//        //                            },
//        //                            new Parameter()
//        //                            {
//        //                                ParameterName = "Температура масла в гидросистеме",
//        //                                ParameterValue = new Random(DateTime.Now.Minute * i).Next(0,234) / 326,
//        //                                IsValid = true
//        //                            },
//        //                        }
//        //                    },
//        //                    new Section()
//        //                    {
//        //                        Name = "СКТ",
//        //                        Parameters = new ObservableCollection<Parameter>()
//        //                        {
//        //                            new Parameter()
//        //                            {
//        //                                ParameterName = "Давление шин",
//        //                                ParameterValue = new Random(DateTime.Now.Minute*i).Next(0,293) / 3,
//        //                                IsValid = true
//        //                            },
//        //                            new Parameter()
//        //                            {
//        //                                ParameterName = "Положение внешних шин",
//        //                                ParameterValue = new Random(DateTime.Now.Minute*i).Next(43,124322) / 423,
//        //                                IsValid = false
//        //                            },
//        //                            new Parameter()
//        //                            {
//        //                                ParameterName = "Положение внутренних шин",
//        //                                ParameterValue = new Random(DateTime.Now.Minute * i).Next(53,432) / 43,
//        //                                IsValid = true
//        //                            }
//        //                        }
//        //                    }
//        //                }
//        //            }) ;
//        //    }
//        //    return Vehicles;
//        //}
//        //public static List<DetailedVehicleInfo> GetVehicles(int minute)
//        //{
//        //    for (int i = 0; i < 20; i++)
//        //    {
//        //        Vehicles.Add(
//        //            new DetailedVehicleInfo()
//        //            {
//        //                ImagePath = "BasePicture.png",
//        //                Id = i.ToString(),
//        //                Name = $"Vehicle {i}",
//        //                Model = $"Model {i % 4}",
//        //                Description = $"Name: Vehicle {i}, Model: Model {i % 4}",
//        //                Sections = new ObservableCollection<Section>()
//        //                {
//        //                    new Section()
//        //                    {
//        //                        Name = "ЭПП",
//        //                        Parameters = new ObservableCollection<Parameter>()
//        //                        {
//        //                            new Parameter()
//        //                            {
//        //                                ParameterName = "Скрость движения",
//        //                                ParameterValue = new Random(minute * i).Next(0,293) / 3,
//        //                                IsValid = true
//        //                            },
//        //                            new Parameter()
//        //                            {
//        //                                ParameterName = "Пробег",
//        //                                ParameterValue = new Random(minute * i).Next(0,124322) / 423,
//        //                                IsValid = false
//        //                            },
//        //                            new Parameter()
//        //                            {
//        //                                ParameterName = "Давление в рулевом управлении",
//        //                                ParameterValue = new Random(minute * i).Next(0,432) / 43,
//        //                                IsValid = true
//        //                            },
//        //                            new Parameter()
//        //                            {
//        //                                ParameterName = "Аварийная температура масла в гидросистеме",
//        //                                ParameterValue = new Random(minute * i).Next(0,6534) /656,
//        //                                IsValid = true
//        //                            },
//        //                            new Parameter()
//        //                            {
//        //                                ParameterName = "Температура масла в гидросистеме",
//        //                                ParameterValue = new Random(minute * i).Next(0,234) / 326,
//        //                                IsValid = true
//        //                            },
//        //                        }
//        //                    },
//        //                    new Section()
//        //                    {
//        //                        Name = "СКТ",
//        //                        Parameters = new ObservableCollection<Parameter>()
//        //                        {
//        //                            new Parameter()
//        //                            {
//        //                                ParameterName = "Давление шин",
//        //                                ParameterValue = new Random(minute*i).Next(0,293) / 3,
//        //                                IsValid = true
//        //                            },
//        //                            new Parameter()
//        //                            {
//        //                                ParameterName = "Положение внешних шин",
//        //                                ParameterValue = new Random(minute*i).Next(43,124322) / 423,
//        //                                IsValid = false
//        //                            },
//        //                            new Parameter()
//        //                            {
//        //                                ParameterName = "Положение внутренних шин",
//        //                                ParameterValue = new Random(minute * i).Next(53,432) / 43,
//        //                                IsValid = true
//        //                            }
//        //                        }
//        //                    }
//        //                }
//        //            });
//        //    }
//        //    return Vehicles;
//        //}
//        public static  GetReports(string vehicleId)
//        {
//            var report = new VehicleReport();
//            report.vehicleReporDatas = new List<VehicleReportData>();
//            report.VehicleId = vehicleId;
//            Random random = new Random(DateTime.Now.Minute);
//            for (int i = 0; i < random.Next(2, 5); i++)
//            {
//                int length = random.Next(20, 51);
//                const string chars = "йцукенгшщзхъфывапролджэячсмитьбю               ";
//                string randomString = new string(Enumerable.Repeat(chars, length)
//                    .Select(s => s[random.Next(s.Length)]).ToArray());
//                DateTime start = new DateTime(1995, 1, 1);
//                int range = (DateTime.Today - start).Days;
//                DateTime randomDate = start.AddDays(random.Next(range));
//                report.vehicleReporDatas.Add(new VehicleReportData()
//                {
//                    ReportDate = randomDate.ToString("MM/dd/yyyy HH:mm"),
//                    Text = randomString
//                });
//            }
//            return report;
//        }
//        public static List<Point> GetPoints(Parameter parameter)
//        {
//            DateTime time = DateTime.Now;
//            Random random = new Random(time.Millisecond);
//            List<Point> points = new List<Point>();
//            time = time - new TimeSpan(0, 10, 0);
//            for (int i = 0; i < 10; i++)
//            {
//                points.Add(new Point()
//                {
//                    value = random.Next(10,100),
//                    time = time
//                });
//                time = time + new TimeSpan(0, 1, 0);
//            }
//            return points;
//        }
//    }
//}
