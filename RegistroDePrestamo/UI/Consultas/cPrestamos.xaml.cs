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
    /// Interaction logic for cPrestamos.xaml
    /// </summary>
    public partial class cPrestamos : Window
    {
        public cPrestamos()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Prestamos>();
            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 1: //Nombre
                        listado = PrestamoBLL.GetList(e => e.Nombres.ToLower().Contains(CriterioTextBox.Text.ToLower()));
                        break;
                    case 2: //Apellido
                        listado = PrestamoBLL.GetList(e => e.Apellidos.ToLower().Contains(CriterioTextBox.Text.ToLower()));
                        break;

                    case 3: //Direccion
                        listado = PrestamoBLL.GetList(e => e.Direccion.ToLower().Contains(CriterioTextBox.Text.ToLower()));
                        break;

                    case 4: //Celular
                        listado = PrestamoBLL.GetList(e => e.Celular.ToLower().Contains(CriterioTextBox.Text.ToLower()));
                        break;

                }
            }
            else
            {
                listado = PrestamoBLL.GetList(e => true);
            }

            if (DesdeDataPicker.SelectedDate != null)
                listado = PrestamoBLL.GetList(c => c.FechaRegistro.Date >= DesdeDataPicker.SelectedDate);

            if (HastaDataPicker.SelectedDate != null)
                listado = PrestamoBLL.GetList(c => c.FechaRegistro.Date <= HastaDataPicker.SelectedDate);

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;

        }
    }
}
