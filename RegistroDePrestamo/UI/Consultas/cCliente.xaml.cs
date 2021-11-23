using RegistroDePrestamo.BLL;
using RegistroDePrestamo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RegistroDePrestamo.UI.Consultas
{
    /// <summary>
    /// Interaction logic for cCliente.xaml
    /// </summary>
    public partial class cCliente : Window
    {
        public cCliente()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Clientes>();
            if (CriterioClienteTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroClienteComboBox.SelectedIndex)
                {
                    case 1: //Nombre
                        listado = ClienteBLL.GetList(e => e.Nombres.ToLower().Contains(CriterioClienteTextBox.Text.ToLower()));
                        break;
                    case 2: //Apellido
                        listado = ClienteBLL.GetList(e => e.Apellidos.ToLower().Contains(CriterioClienteTextBox.Text.ToLower()));
                        break;
                    case 3: //Celular
                        listado = ClienteBLL.GetList(e => e.Celular.ToLower().Contains(CriterioClienteTextBox.Text.ToLower()));
                        break;

                }
            }
            else
            {
                listado = ClienteBLL.GetList(e => true);
            }

            if (DesdeDataPicker.SelectedDate != null)
                listado = ClienteBLL.GetList(c => c.FechaCliente.Date >= DesdeDataPicker.SelectedDate);

            if (HastaDataPicker.SelectedDate != null)
                listado = ClienteBLL.GetList(c => c.FechaCliente.Date <= HastaDataPicker.SelectedDate);

            ClienteDataGrid.ItemsSource = null;
            ClienteDataGrid.ItemsSource = listado;
        }

        private void FiltroClienteComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ClienteDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
