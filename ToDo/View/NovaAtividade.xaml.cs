using ToDo.Model;

namespace ToDo.View;

public partial class NovaAtividade : ContentPage
{
	private Atividade atividade = new Atividade();
    public NovaAtividade()
	{
		InitializeComponent();
	}

	public async void capturarAtividade( object sender, EventArgs e)
	{
		atividade.Nome = entNome.Text;
        atividade.Descricao = entDescricao.Text;
        atividade.DataCriacao = dtData.Date.Value.ToString();
        atividade.Status = cbStatus.IsChecked ? 1 : 0;
        string resultado = atividade.Inserir(atividade);
        
        var list = atividade.GetAllAtividades();
        await DisplayAlertAsync("Resultado", resultado, "OK");
    } 
}