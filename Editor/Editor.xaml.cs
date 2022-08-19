namespace Editor;

public partial class Editor : ContentPage
{

    string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PLP_LightWriter");
	bool isedit = false;
    public Editor()
	{
		InitializeComponent();
		isedit = false;
	}

    public Editor(string title)
    {
        InitializeComponent();
		this.Title = "Edit " + title;
		this.title.Text = title;

		string filepath = Path.Combine(path, title + ".txt");

		StreamReader sr = new StreamReader(filepath);
		editor.Text = sr.ReadToEnd();
		sr.Close();

		isedit = true;

    }

	private void save_btn_Clicked(object sender, EventArgs e)
	{
		if (!title.Text.Contains('/') && !title.Text.Contains('\\') && !title.Text.Contains('"') && title.Text != "" && title.Text != null)
		{
			if (!isedit)
			{
				bool enable = true;
				for (int i = 0; i < Vars.list_1.Count; i++)
				{
					if (Vars.list_1[i].title.ToLower() == title.Text.ToLower())
					{
						enable = false;
						break;
					}
				}

				if (enable)
				{
					DataHandler.Save(title.Text, editor.Text);
					messager.Text = "Erfolgreich gespeichert";
					bdr_msg.IsVisible = true;
					DataHandler.LoadList();
				}
				else
				{
					messager.Text = "Der Name ist bereits vergeben.";
					bdr_msg.IsVisible = true;
				} 
			}
			else
			{
                DataHandler.Save(title.Text, editor.Text);
                messager.Text = "Erfolgreich gespeichert";
                bdr_msg.IsVisible = true;
				DataHandler.LoadList();
            }
		}
		else
		{
            messager.Text = "Diese Zeichen sind nicht gestattet: /, \\, \". Achten Sie darauf, dass alles ausgefüllt ist!  ";
            bdr_msg.IsVisible = true;
        }
	}

	private void title_Completed(object sender, EventArgs e)
	{
        DataHandler.CreateFile(title.Text);
    }

	private void close_btn_Clicked(object sender, EventArgs e)
	{
		messager.Text = "";
		bdr_msg.IsVisible = false;
	}
}