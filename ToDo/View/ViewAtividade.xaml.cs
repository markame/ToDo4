using ToDo.Model;

namespace ToDo.View;

public partial class ViewAtividade : ContentPage
{
    public int idAtividade;
    public ViewAtividade(Atividade a)
	{
		InitializeComponent();
        idAtividade = a.Id;
        entTNome.Text = a.Nome;
		entTDescricao.Text = a.Descricao;
        dtTData.Date = DateTime.Parse(a.DataCriacao);
        if (a.Status == 1)
        {
            cbTStatus.IsChecked = true;
        }
        else
        {
            cbTStatus.IsChecked = false;
        }
    }

    private async void UpdateAtividade(object sender, EventArgs e)
    {
        Atividade a = new Atividade();
        a.Id = idAtividade;
        a.Nome = entTNome.Text;
        a.Descricao = entTDescricao.Text;
        a.DataCriacao = dtTData.Date.Value.ToString();
        a.Status = cbTStatus.IsChecked ? 1 : 0;
        string resultado = a.UptadeAtividade(a);
        DisplayAlertAsync("Resultado", resultado, "OK");
        LimparCampos(Formulario);
        await Navigation.PopToRootAsync();

    }
    private void LimparCampos(IView view)
    {
        switch (view)
        {
            case Entry entry:
                entry.Text = string.Empty;
                break;

            case Editor editor:
                editor.Text = string.Empty;
                break;

            case Picker picker:
                picker.SelectedIndex = -1;
                break;

            case CheckBox checkBox:
                checkBox.IsChecked = false;
                break;

            case Switch switchCampo:
                switchCampo.IsToggled = false;
                break;

            case DatePicker datePicker:
                datePicker.Date = DateTime.Today;
                break;

            case TimePicker timePicker:
                timePicker.Time = TimeSpan.Zero;
                break;

            case Slider slider:
                slider.Value = slider.Minimum;
                break;

            case Stepper stepper:
                stepper.Value = stepper.Minimum;
                break;
        }

        if (view is Layout layout)
        {
            foreach (var filho in layout.Children)
            {
                LimparCampos(filho);
            }
        }
        else if (view is ContentView contentView &&
                 contentView.Content is IView conteudo)
        {
            LimparCampos(conteudo);
        }
        else if (view is ScrollView scrollView &&
                 scrollView.Content is IView conteudoScroll)
        {
            LimparCampos(conteudoScroll);
        }
    }
}