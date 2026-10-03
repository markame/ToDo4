namespace ToDo.View;

using System.Collections.ObjectModel;
using ToDo.Model;

public partial class ListAtividade : ContentPage
{
	public ListAtividade()
	{
		InitializeComponent();
		ObservableAtividades();	

    }

	public void ObservableAtividades()
	{
		
        Atividade a = new Atividade();
		ObservableCollection<Atividade> atividade = new ObservableCollection<Atividade>();
		atividade = a.GetAllAtividades();
		listaAtividades.ItemsSource = atividade;

        
    }

    private async void listaAtividades_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
		var selectedAtividade = e.CurrentSelection.FirstOrDefault() as Atividade;
		/*await DisplayAlertAsync("Atividade Selecionada", $"Nome: " +
			$"{selectedAtividade.Nome}\nDescrição:" +
			$" {selectedAtividade.Descricao}\nData de Criação:" +
			$" {selectedAtividade.DataCriacao}\nStatus:" +
			$" {selectedAtividade.Status}", "OK");*/
		await Navigation.PushAsync(new ViewAtividade(selectedAtividade));
    }
}