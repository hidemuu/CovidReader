using CovidReader.Models;
using CovidReader.Models.Api;
using System;
using System.Collections.Generic;

namespace CovidReader.Plugins.Charts
{
    public class ChartItemBuilder
    {
        public static IEnumerable<ChartItem> GetChartItems(IEnumerable<Virus> viruses)
        {
            List<ChartItem> result = new List<ChartItem>();
            foreach (var item in viruses)
            {
                result.Add(new ChartItem
                {
                    Id = item.Id,
                    Date = item.Date,
                    Data = item.DeathNumber.ToString() + Formats.Delimiter +
                           item.HospitalizationNumber.ToString() + Formats.Delimiter +
                           item.PositiveNumber.ToString() + Formats.Delimiter +
                           item.RecoveryNumber.ToString() + Formats.Delimiter +
                           item.SevereNumber.ToString() + Formats.Delimiter +
                           item.TestNumber.ToString() + Formats.Delimiter +
                           item.NationalTestNumber.ToString() + Formats.Delimiter +
                           item.QuarantineTestNumber.ToString() + Formats.Delimiter +
                           item.CareCenterTestNumber.ToString() + Formats.Delimiter +
                           item.CivilCenterTestNumber.ToString() + Formats.Delimiter +
                           item.CollegeTestNumber.ToString() + Formats.Delimiter +
                           item.MedicalTestNumber.ToString(),
                });
            }
            return result;
        }

        public static IEnumerable<ChartConfig> GetChartConfigs()
        {
            List<ChartConfig> result = new List<ChartConfig>();
            var date = DateTime.MinValue;

            result.Add(new ChartConfig
            {
                Id = 0,
                Date = date.ToString(),
                Name = "Death",
                ChartType = "line",
                BackgroundColor = "rgba(0, 0, 0, 0)",
                BorderColor = "rgba(255,0,0,1)",
                BorderWidth = 1,
            });

            result.Add(new ChartConfig
            {
                Id = 1,
                Date = date.AddSeconds(1).ToString(),
                Name = "Hospitalization",
                ChartType = "line",
                BackgroundColor = "rgba(0, 0, 0, 0)",
                BorderColor = "rgba(0,255,0,1)",
                BorderWidth = 1,
            });

            result.Add(new ChartConfig
            {
                Id = 2,
                Date = date.AddSeconds(2).ToString(),
                Name = "Positive",
                ChartType = "line",
                BackgroundColor = "rgba(0, 0, 0, 0)",
                BorderColor = "rgba(0,0,255,1)",
                BorderWidth = 1,
            });

            result.Add(new ChartConfig
            {
                Id = 3,
                Date = date.AddSeconds(3).ToString(),
                Name = "Recovery",
                ChartType = "line",
                BackgroundColor = "rgba(0, 0, 0, 0)",
                BorderColor = "rgba(128,128,0,1)",
                BorderWidth = 1,
            });

            result.Add(new ChartConfig
            {
                Id = 4,
                Date = date.AddSeconds(4).ToString(),
                Name = "Severe",
                ChartType = "line",
                BackgroundColor = "rgba(0, 0, 0, 0)",
                BorderColor = "rgba(128,128,0,1)",
                BorderWidth = 1,
            });

            result.Add(new ChartConfig
            {
                Id = 5,
                Date = date.AddSeconds(5).ToString(),
                Name = "Test",
                ChartType = "line",
                BackgroundColor = "rgba(0, 0, 0, 0)",
                BorderColor = "rgba(128,128,0,1)",
                BorderWidth = 1,
            });

            result.Add(new ChartConfig
            {
                Id = 6,
                Date = date.AddSeconds(6).ToString(),
                Name = "NationalTest",
                ChartType = "line",
                BackgroundColor = "rgba(0, 0, 0, 0)",
                BorderColor = "rgba(128,128,0,1)",
                BorderWidth = 1,
            });

            result.Add(new ChartConfig
            {
                Id = 7,
                Date = date.AddSeconds(7).ToString(),
                Name = "QuarantineTest",
                ChartType = "line",
                BackgroundColor = "rgba(0, 0, 0, 0)",
                BorderColor = "rgba(128,128,0,1)",
                BorderWidth = 1,
            });

            result.Add(new ChartConfig
            {
                Id = 8,
                Date = date.AddSeconds(8).ToString(),
                Name = "CareCenterTest",
                ChartType = "line",
                BackgroundColor = "rgba(0, 0, 0, 0)",
                BorderColor = "rgba(128,128,0,1)",
                BorderWidth = 1,
            });

            result.Add(new ChartConfig
            {
                Id = 9,
                Date = date.AddSeconds(9).ToString(),
                Name = "CivilCenterTest",
                ChartType = "line",
                BackgroundColor = "rgba(0, 0, 0, 0)",
                BorderColor = "rgba(128,128,0,1)",
                BorderWidth = 1,
            });

            result.Add(new ChartConfig
            {
                Id = 10,
                Date = date.AddSeconds(10).ToString(),
                Name = "CollegeTestNumber",
                ChartType = "line",
                BackgroundColor = "rgba(0, 0, 0, 0)",
                BorderColor = "rgba(128,128,0,1)",
                BorderWidth = 1,
            });

            result.Add(new ChartConfig
            {
                Id = 11,
                Date = date.AddSeconds(11).ToString(),
                Name = "MedicalTestNumber",
                ChartType = "line",
                BackgroundColor = "rgba(0, 0, 0, 0)",
                BorderColor = "rgba(128,128,0,1)",
                BorderWidth = 1,
            });

            return result;
        }

    }
}
