using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudySync.Models;
using StudySync.Services;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace StudySync.ViewModels
{
    public partial class GoalsViewModel : ObservableObject // <-- "partial" keyword was added here
    {
        private readonly SQLiteService _dbService;

        // --- Weekly Goals Properties ---
        [ObservableProperty]
        ObservableCollection<StudyGoal> goals;

        [ObservableProperty]
        string newGoalSubject;

        [ObservableProperty]
        double newGoalTarget = 5;

        // --- New Major Milestone Properties ---
        [ObservableProperty]
        private bool isMilestoneSet;

        [ObservableProperty]
        private bool isEditingMilestone;

        [ObservableProperty]
        private string milestoneTitle;

        [ObservableProperty]
        private DateTime milestoneDate;

        [ObservableProperty]
        private int daysUntilMilestone;

        [ObservableProperty]
        private double milestoneProgress;

        public GoalsViewModel(SQLiteService dbService)
        {
            _dbService = dbService;
            Goals = new ObservableCollection<StudyGoal>();

            MilestoneDate = Preferences.Get("milestone_date", DateTime.Today.AddMonths(6));
            MilestoneTitle = Preferences.Get("milestone_title", "");
        }

        [RelayCommand]
        public async Task LoadDataAsync()
        {
            // --- Load Weekly Goals ---
            var goalsFromDb = await _dbService.GetGoals();
            var completedTasks = (await _dbService.GetTasks()).Where(t => t.IsCompleted).ToList();
            foreach (var goal in goalsFromDb)
            {
                goal.CompletedTasks = completedTasks.Count(t => t.Subject.Equals(goal.Subject, StringComparison.OrdinalIgnoreCase));
            }
            Goals.Clear();
            foreach (var goal in goalsFromDb.OrderByDescending(g => g.Progress))
            {
                Goals.Add(goal);
            }

            // --- Load Major Milestone ---
            LoadMilestone();
        }

        private void LoadMilestone()
        {
            var savedTitle = Preferences.Get("milestone_title", string.Empty);
            if (!string.IsNullOrEmpty(savedTitle))
            {
                IsMilestoneSet = true;
                MilestoneTitle = savedTitle;
                MilestoneDate = Preferences.Get("milestone_date", DateTime.Today);

                var totalDays = (MilestoneDate - Preferences.Get("milestone_start_date", DateTime.Today)).TotalDays;
                var daysRemaining = (MilestoneDate - DateTime.Today).TotalDays;

                DaysUntilMilestone = (int)Math.Max(0, daysRemaining);
                MilestoneProgress = totalDays > 0 ? 1 - (daysRemaining / totalDays) : 1;
            }
            else
            {
                IsMilestoneSet = false;
            }
        }

        [RelayCommand]
        private void ToggleEditMilestone()
        {
            IsEditingMilestone = !IsEditingMilestone;
        }

        [RelayCommand]
        private void SaveMilestone()
        {
            if (string.IsNullOrWhiteSpace(MilestoneTitle))
            {
                Shell.Current.DisplayAlert("Error", "Please enter a title for your milestone.", "OK");
                return;
            }

            Preferences.Set("milestone_title", MilestoneTitle);
            Preferences.Set("milestone_date", MilestoneDate);
            Preferences.Set("milestone_start_date", DateTime.Today);

            IsEditingMilestone = false;
            LoadMilestone();
        }

        [RelayCommand]
        private void ClearMilestone()
        {
            Preferences.Remove("milestone_title");
            Preferences.Remove("milestone_date");
            Preferences.Remove("milestone_start_date");
            IsEditingMilestone = false;
            LoadMilestone();
        }

        [RelayCommand]
        private async Task AddGoalAsync()
        {
            if (string.IsNullOrWhiteSpace(NewGoalSubject))
            {
                await Shell.Current.DisplayAlert("Error", "Please enter a subject for your goal.", "OK");
                return;
            }

            var newGoal = new StudyGoal
            {
                Subject = NewGoalSubject,
                TargetTasks = (int)NewGoalTarget
            };

            await _dbService.AddGoal(newGoal);
            NewGoalSubject = string.Empty;
            await LoadDataAsync();
        }

        [RelayCommand]
        private async Task DeleteGoalAsync(StudyGoal goal)
        {
            if (goal == null) return;
            await _dbService.DeleteGoal(goal);
            await LoadDataAsync();
        }
    }
}
