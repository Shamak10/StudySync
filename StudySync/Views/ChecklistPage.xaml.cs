using StudySync.ViewModels;

namespace StudySync.Views;

public partial class ChecklistPage : ContentPage
{
    private readonly ChecklistViewModel _viewModel;

    public ChecklistPage(ChecklistViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.LoadTasksAsync();
    }
}
