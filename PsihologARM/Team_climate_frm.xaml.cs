using System.ComponentModel;
using System.Windows;

namespace PsihologARM
{
    public partial class Team_climate_frm : Window
    {
        public Team_climate_frm()
        {
            InitializeComponent();
        }

        private void Btn_close_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            this.Owner.Show();
            // Возможно, правильнее isClosing = !e.Cancel;
            //  если выдаете запрос на закрытие или что-то типа того
        }

        private void Btn_GoBack_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}