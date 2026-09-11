using ToDo.View;

namespace ToDo
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private async void novaAtividadeButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NovaAtividade());
        }
    }
}
