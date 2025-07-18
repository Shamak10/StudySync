using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudySync.Models;
using StudySync.Services;
using StudySync.Views;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace StudySync.ViewModels
{
    public partial class HomeViewModel : ObservableObject // <-- "partial" keyword was added here
    {
        private readonly SQLiteService _dbService;

        [ObservableProperty]
        ObservableCollection<StudyTask> dueTodayTasks;

        [ObservableProperty]
        ObservableCollection<StudyTask> upcomingTasks;

        [ObservableProperty]
        StudyTask focusTask;

        [ObservableProperty]
        string motivationalQuote;

        public HomeViewModel(SQLiteService dbService)
        {
            _dbService = dbService;
            DueTodayTasks = new ObservableCollection<StudyTask>();
            UpcomingTasks = new ObservableCollection<StudyTask>();
        }

        [RelayCommand]
        public async Task LoadTasksAsync()
        {
            var taskList = await _dbService.GetTasks();
            var incompleteTasks = taskList.Where(t => !t.IsCompleted).ToList();

            var today = DateTime.Today;

            var todayTasks = incompleteTasks.Where(t => t.DueDate.Date == today).OrderBy(t => t.DueDate).ToList();
            DueTodayTasks.Clear();
            foreach (var task in todayTasks)
            {
                DueTodayTasks.Add(task);
            }

            var otherTasks = incompleteTasks.Where(t => t.DueDate.Date > today).OrderBy(t => t.DueDate).ToList();
            UpcomingTasks.Clear();
            foreach (var task in otherTasks)
            {
                UpcomingTasks.Add(task);
            }

            // Set the Focus Task
            FocusTask = DueTodayTasks.FirstOrDefault() ?? UpcomingTasks.FirstOrDefault();

            // Load a new quote
            LoadMotivationalQuote();
        }

        private void LoadMotivationalQuote()
        {
            var quotes = new List<string>
            {
                "The secret to getting ahead is getting started.",
                "The expert in anything was once a beginner.",
                "Believe you can and you're halfway there.",
                "Don't watch the clock; do what it does. Keep going.",
                "Success is the sum of small efforts, repeated day in and day out."
            };
            var random = new Random();
            int index = random.Next(quotes.Count);
            MotivationalQuote = quotes[index];
        }

        [RelayCommand]
        private async Task ToggleCompleteAsync(StudyTask task)
        {
            if (task == null) return;
            task.IsCompleted = !task.IsCompleted;
            await _dbService.UpdateTask(task);
            await LoadTasksAsync();
        }

        [RelayCommand]
        private async Task GoToAddTaskAsync()
        {
            await Shell.Current.GoToAsync(nameof(NewTaskPage));
        }

        [RelayCommand]
        private async Task GoToEditTaskAsync(StudyTask task)
        {
            if (task == null) return;
            await Shell.Current.GoToAsync($"{nameof(NewTaskPage)}?TaskId={task.Id}");
        }
    }
}
