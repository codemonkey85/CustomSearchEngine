namespace CustomSearchEngine.Pages;

public partial class Configuration
{
    private string? AppendedArgs { get; set; }

    private bool ChangesSaved { get; set; } = false;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            AppendedArgs = await localStorage.GetItemAsync<string>(nameof(AppendedArgs));
            StateHasChanged();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.Message}{Environment.NewLine}{ex.StackTrace}");
        }
    }

    private async Task SaveConfig()
    {
        await localStorage.SetItemAsync(nameof(AppendedArgs), AppendedArgs);
        ChangesSaved = true;
    }
}
