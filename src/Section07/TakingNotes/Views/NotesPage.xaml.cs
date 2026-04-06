namespace TakingNotes.Views;

public partial class NotesPage : ContentPage
{
    private readonly string _fileName = Path.Combine(FileSystem.AppDataDirectory, "notes.txt");

    public NotesPage()
    {
        InitializeComponent();

        if (File.Exists(_fileName))
        {
            TextEditor.Text = File.ReadAllText(_fileName);
        }
    }

    private void OnSaveClicked(object? sender, EventArgs e)
    {
        File.WriteAllText(_fileName, TextEditor.Text);
    }

    private void OnDeleteClicked(object? sender, EventArgs e)
    {
        if (File.Exists(_fileName))
        {
            File.Delete(_fileName);
        }

        TextEditor.Text = string.Empty;
    }
}