using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudySync.Models;
using StudySync.Services;
using StudySync.Views;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace StudySync.ViewModels
{
    public partial class ChecklistViewModel : ObservableObject
    {
        private readonly SQLiteService _dbService;

        [ObservableProperty]
        ObservableCollection<StudyTask> upcomingTasks;

        [ObservableProperty]
        ObservableCollection<StudyTask> completedTasks;

        public ChecklistViewModel(SQLiteService dbService)
        {
            _dbService = dbService;
            UpcomingTasks = new ObservableCollection<StudyTask>();
            CompletedTasks = new ObservableCollection<StudyTask>();
        }

        [RelayCommand]
        public async Task LoadTasksAsync()
        {
            var allTasks = await _dbService.GetTasks();

            UpcomingTasks.Clear();
            foreach (var task in allTasks.Where(t => !t.IsCompleted).OrderBy(t => t.DueDate))
            {
                UpcomingTasks.Add(task);
            }

            CompletedTasks.Clear();
            foreach (var task in allTasks.Where(t => t.IsCompleted).OrderByDescending(t => t.DueDate))
            {
                CompletedTasks.Add(task);
            }
        }

        [RelayCommand]
        private async Task DeleteTaskAsync(StudyTask task)
        {
            if (task == null) return;

            await _dbService.DeleteTask(task);
            await LoadTasksAsync();
        }

        [RelayCommand]
        private async Task GoToEditTaskAsync(StudyTask task)
        {
            if (task == null) return;

            await Shell.Current.GoToAsync($"{nameof(NewTaskPage)}?TaskId={task.Id}");
        }

        [RelayCommand]
        private async Task CompleteTaskAsync(StudyTask task)
        {
            if (task == null) return;

            task.IsCompleted = true;
            await _dbService.UpdateTask(task);
            await LoadTasksAsync();
        }
    }
}
