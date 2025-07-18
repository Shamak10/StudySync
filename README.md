# StudySync

StudySync is a comprehensive cross-platform study management application built with .NET MAUI. It helps students organize their study tasks, track progress, and achieve their academic goals with an intuitive and motivational interface.

## 🚀 Features

- **📋 Task Management**: Create, update, and manage study tasks with due dates and subjects
- **🎯 Goal Setting**: Set study goals with target tasks and track your progress
- **📊 Progress Tracking**: Visualize your study progress with charts and statistics
- **💡 Daily Motivation**: Get inspired with motivational quotes to keep you focused
- **✅ Smart Checklist**: Organize tasks by due dates (today vs. upcoming)
- **🎨 Modern UI**: Clean, intuitive interface with light/dark theme support
- **💾 Local Storage**: All data stored locally using SQLite for privacy and offline access

## 🛠️ Technology Stack

- **.NET 9.0** - Latest .NET framework
- **.NET MAUI** - Cross-platform UI framework
- **SQLite** - Local database for data persistence
- **MVVM Pattern** - Clean architecture with CommunityToolkit.Mvvm
- **Microcharts** - Beautiful charts for progress visualization

## 📱 Supported Platforms

- **Android** (API 21+)
- **iOS** (15.0+)
- **macOS** (Catalyst 15.0+)
- **Windows** (10.0.17763.0+)
- **Tizen** (6.5+)

## 🏗️ Project Structure

```
StudySync/
├── Models/
│   ├── StudyTask.cs          # Task data model
│   ├── StudyGoal.cs          # Goal data model
│   └── LegendItem.cs         # Chart legend model
├── ViewModels/
│   ├── HomeViewModel.cs      # Home page logic
│   ├── ChecklistViewModel.cs # Checklist page logic
│   ├── GoalsViewModel.cs     # Goals page logic
│   ├── ProgressViewModel.cs  # Progress page logic
│   └── NewTaskViewModel.cs   # New task page logic
├── Views/
│   ├── HomePage.xaml         # Home page UI
│   ├── ChecklistPage.xaml    # Checklist page UI
│   ├── GoalsPage.xaml        # Goals page UI
│   ├── ProgressPage.xaml     # Progress page UI
│   └── NewTaskPage.xaml      # New task page UI
├── Services/
│   └── SQLiteService.cs      # Database service
├── Converters/
│   └── *.cs                  # Value converters for UI binding
└── Resources/
    ├── Styles/               # App themes and styles
    ├── Fonts/                # Custom fonts
    └── Images/               # App icons and images
```

## 🚀 Getting Started

### Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) or [Visual Studio Code](https://code.visualstudio.com/)
- Platform-specific SDKs (Android SDK, Xcode for iOS/macOS, etc.)

### Installation

1. **Clone the repository**:
   ```bash
   git clone https://github.com/yourusername/StudySync.git
   cd StudySync
   ```

2. **Restore NuGet packages**:
   ```bash
   dotnet restore
   ```

3. **Build the solution**:
   ```bash
   dotnet build
   ```

4. **Run the application**:
   ```bash
   # For Android
   dotnet build -f net9.0-android
   
   # For iOS (macOS only)
   dotnet build -f net9.0-ios
   
   # For Windows
   dotnet build -f net9.0-windows10.0.19041.0
   ```

### Using Visual Studio

1. Open `StudySync.sln` in Visual Studio 2022
2. Select your target platform from the dropdown
3. Press F5 to build and run

## 📖 Usage

### Home Page
- View your focus task for the day
- See tasks due today and upcoming tasks
- Mark tasks as complete with checkboxes
- Get daily motivational quotes

### Checklist Page
- View all your study tasks
- Filter and organize tasks by completion status
- Quick task completion toggle

### Goals Page
- Set study goals with target task counts
- Track progress towards your goals
- Visualize goal completion

### Progress Page
- View charts and statistics of your study progress
- Track completion rates over time
- Analyze your productivity patterns

### New Task Page
- Add new study tasks with subjects and due dates
- Edit existing tasks
- Set task priorities and categories

## 🎨 Customization

The app supports both light and dark themes that automatically adapt to your system preferences. You can customize colors and styles in the `Resources/Styles/` directory.

## 🔧 Configuration

The app uses SQLite for local data storage. The database file is automatically created in the app's data directory. No additional configuration is required.

## 📦 Dependencies

- **CommunityToolkit.Maui** (12.1.0) - Enhanced MAUI controls and behaviors
- **CommunityToolkit.Mvvm** (8.4.0) - MVVM helpers and source generators
- **Microcharts.Maui** (1.0.1) - Beautiful charts for progress visualization
- **sqlite-net-pcl** (1.9.172) - SQLite database access
- **Microsoft.Maui.Controls** (9.0.90) - MAUI UI controls

## 🤝 Contributing

We welcome contributions! Please follow these steps:

1. Fork the repository
2. Create a feature branch: `git checkout -b feature/amazing-feature`
3. Make your changes and commit: `git commit -m 'Add amazing feature'`
4. Push to your branch: `git push origin feature/amazing-feature`
5. Submit a pull request

### Development Guidelines

- Follow C# coding conventions
- Use MVVM pattern for new features
- Add appropriate comments for complex logic
- Test on multiple platforms when possible
- Update documentation for new features

## 📝 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 🙏 Acknowledgments

- Icons from [FontAwesome](https://fontawesome.com/)
- Motivational quotes curated from various sources
- Built with the amazing [.NET MAUI](https://github.com/dotnet/maui) framework

## 📧 Contact

For questions, suggestions, or support, please open an issue on GitHub or contact the development team.

---

**Happy Studying! 📚✨**
 
