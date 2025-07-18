using CommunityToolkit.Mvvm.ComponentModel;
using Microcharts;
using Microsoft.Maui.Graphics;
using SkiaSharp;
using StudySync.Models;
using StudySync.Services;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace StudySync.ViewModels
{
    public partial class ProgressViewModel : ObservableObject
    {
        private readonly SQLiteService _dbService;

        [ObservableProperty]
        private Chart completedTasksChart;

        [ObservableProperty]
        private Chart upcomingTasksChart;

        [ObservableProperty]
        private ObservableCollection<LegendItem> completedLegend;

        [ObservableProperty]
        private ObservableCollection<LegendItem> upcomingLegend;

        public ProgressViewModel(SQLiteService dbService)
        {
            _dbService = dbService;
            CompletedLegend = new ObservableCollection<LegendItem>();
            UpcomingLegend = new ObservableCollection<LegendItem>();
        }

        public async Task LoadDataAsync()
        {
            var allTasks = await _dbService.GetTasks();

            var colors = new[]
            {
                "#007AFF", "#28A745", "#FFC107", "#DC3545",
                "#17A2B8", "#6F42C1", "#FD7E14"
            };

            // --- Chart 1: Completed Tasks ---
            var completedGroups = allTasks
                .Where(t => t.IsCompleted)
                .GroupBy(t => t.Subject)
                .Select((group, index) => new
                {
                    SubjectName = group.Key,
                    Count = group.Count(),
                    Color = Color.FromArgb(colors[index % colors.Length])
                })
                .ToList();

            if (!completedGroups.Any())
            {
                CompletedTasksChart = null;
                CompletedLegend.Clear();
            }
            else
            {
                var completedEntries = completedGroups.Select(g => new ChartEntry(g.Count)
                {
                    Color = SKColor.Parse(g.Color.ToHex())
                }).ToArray();

                CompletedTasksChart = new PieChart // Changed from DonutChart
                {
                    Entries = completedEntries,
                    IsAnimated = true,
                    BackgroundColor = SKColors.Transparent,
                    LabelMode = LabelMode.None // Use our custom legend instead
                };

                CompletedLegend.Clear();
                foreach (var group in completedGroups)
                {
                    CompletedLegend.Add(new LegendItem { Label = group.SubjectName, Value = group.Count.ToString(), Color = group.Color });
                }
            }

            // --- Chart 2: Upcoming Tasks ---
            var upcomingGroups = allTasks
                .Where(t => !t.IsCompleted)
                .GroupBy(t => t.Subject)
                .Select((group, index) => new
                {
                    SubjectName = group.Key,
                    Count = group.Count(),
                    Color = Color.FromArgb(colors[index % colors.Length])
                })
                .ToList();

            if (!upcomingGroups.Any())
            {
                UpcomingTasksChart = null;
                UpcomingLegend.Clear();
            }
            else
            {
                var upcomingEntries = upcomingGroups.Select(g => new ChartEntry(g.Count)
                {
                    Color = SKColor.Parse(g.Color.ToHex())
                }).ToArray();

                UpcomingTasksChart = new PieChart // Changed from DonutChart
                {
                    Entries = upcomingEntries,
                    IsAnimated = true,
                    BackgroundColor = SKColors.Transparent,
                    LabelMode = LabelMode.None // Use our custom legend instead
                };

                UpcomingLegend.Clear();
                foreach (var group in upcomingGroups)
                {
                    UpcomingLegend.Add(new LegendItem { Label = group.SubjectName, Value = group.Count.ToString(), Color = group.Color });
                }
            }
        }
    }
}