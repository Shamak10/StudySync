using SQLite;
using StudySync.Models;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace StudySync.Services
{
    public class SQLiteService
    {
        private SQLiteAsyncConnection _db;

        public async Task Init()
        {
            if (_db != null)
                return;

            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "studysync.db");
            _db = new SQLiteAsyncConnection(dbPath);
            await _db.CreateTableAsync<StudyTask>();
            await _db.CreateTableAsync<StudyGoal>();
        }

        // --- Task Methods ---
        public async Task<List<StudyTask>> GetTasks()
        {
            await Init();
            return await _db.Table<StudyTask>().OrderBy(t => t.DueDate).ToListAsync();
        }

        // This method was empty
        public async Task AddTask(StudyTask task)
        {
            await Init();
            await _db.InsertAsync(task);
        }

        // This method was empty
        public async Task UpdateTask(StudyTask task)
        {
            await Init();
            await _db.UpdateAsync(task);
        }

        // This method was empty
        public async Task DeleteTask(StudyTask task)
        {
            await Init();
            await _db.DeleteAsync(task);
        }


        // --- Goal Methods ---
        public async Task<List<StudyGoal>> GetGoals()
        {
            await Init();
            return await _db.Table<StudyGoal>().ToListAsync();
        }

        public async Task AddGoal(StudyGoal goal)
        {
            await Init();
            await _db.InsertAsync(goal);
        }

        public async Task DeleteGoal(StudyGoal goal)
        {
            await Init();
            await _db.DeleteAsync(goal);
        }
    }
}
