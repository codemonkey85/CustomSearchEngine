namespace CustomSearchEngine.Pages;

public partial class Index
{
    private string? InputSearchString { get; set; }

    private string? AppendedArgs { get; set; }

    private string FullSearchString => $"{InputSearchString}{AppendedArgs}";

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

    private void DoSearch() =>
        NavManager.NavigateTo($"https://www.google.com/search?q={HttpUtility.UrlEncode(FullSearchString)}");
}
