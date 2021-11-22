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
    /// Interaction logic for cEmpleado.xaml
    /// </summary>
    public partial class cEmpleado : Window
    {
        public cEmpleado()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Empleados>();

            if (CriterioEmpleadoTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroEmpleadoComboBox.SelectedIndex)
                {
                    case 0: //CodigoEmpleado
                        listado = EmpleadoBLL.GetList(e => e.CodigoEmpleado == Utilidades.ToInt(CriterioEmpleadoTextBox.Text));
                        break;

                    case 1: //Nombres                       
                        listado = EmpleadoBLL.GetList(e => e.Nombres.Contains(CriterioEmpleadoTextBox.Text, StringComparison.OrdinalIgnoreCase));
                        break;
                }
            }
            else
            {
                listado = EmpleadoBLL.GetList(c => true);
            }

            if (DesdeDataPicker.SelectedDate != null)
                listado = EmpleadoBLL.GetList(c => c.FechaEmpleado.Date >= DesdeDataPicker.SelectedDate);

            if (HastaDataPicker.SelectedDate != null)
                listado = EmpleadoBLL.GetList(c => c.FechaEmpleado.Date <= HastaDataPicker.SelectedDate);

            EmpleadoDataGrid.ItemsSource = null;
            EmpleadoDataGrid.ItemsSource = listado;
        }
    }
    
}
