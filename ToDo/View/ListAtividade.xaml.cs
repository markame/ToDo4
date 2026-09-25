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
}