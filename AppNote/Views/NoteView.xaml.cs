namespace AppNote.Views;

public partial class NoteView : ContentView
{
	public NoteView()
	{
		InitializeComponent();
		BindingContext =new ViewModels.NoteViewModel();
	}

    public object Toast { get; private set; }

   
}