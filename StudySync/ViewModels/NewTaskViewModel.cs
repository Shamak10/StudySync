using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudySync.Models;
using StudySync.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace StudySync.ViewModels
{
    [QueryProperty(nameof(TaskId), "TaskId")]
    public partial class NewTaskViewModel : ObservableObject
    {
        private readonly SQLiteService _dbService;

        [ObservableProperty]
        private StudyTask currentTask;

        [ObservableProperty]
        private bool isEditing;

        [ObservableProperty]
        private int taskId;

        [ObservableProperty]
        string title;

        [ObservableProperty]
        string subject;

        [ObservableProperty]
        DateTime dueDate;

        public NewTaskViewModel(SQLiteService dbService)
        {
            _dbService = dbService;
            CurrentTask = new StudyTask();
            DueDate = DateTime.Now;
        }

        partial void OnTaskIdChanged(int value)
        {
            IsEditing = true;
            LoadTaskAsync(value);
        }

        private async void LoadTaskAsync(int taskId)
        {
            var task = (await _dbService.GetTasks()).FirstOrDefault(t => t.Id == taskId);
            if (task != null)
            {
                CurrentTask = task;
                Title = task.Title;
                Subject = task.Subject;
                DueDate = task.DueDate;
            }
        }

        [RelayCommand]
        private async Task SaveTaskAsync()
        {
            if (string.IsNullOrWhiteSpace(Title) || string.IsNullOrWhiteSpace(Subject))
            {
                await Shell.Current.DisplayAlert("Error", "Please fill in all fields.", "OK");
                return;
            }

            CurrentTask.Title = this.Title;
            CurrentTask.Subject = this.Subject;
            CurrentTask.DueDate = this.DueDate;

            if (IsEditing)
            {
                await _dbService.UpdateTask(CurrentTask);
            }
            else
            {
                await _dbService.AddTask(CurrentTask);
            }

            await Shell.Current.GoToAsync("..");
        }
    }
}