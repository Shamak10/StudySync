using StudySync.ViewModels;

namespace StudySync.Views;

public partial class NewTaskPage : ContentPage
{
    public NewTaskPage(NewTaskViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}