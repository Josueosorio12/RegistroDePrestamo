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

namespace RegistroDePrestamo.UI.Registros
{
    /// <summary>
    /// Interaction logic for rEmpleado.xaml
    /// </summary>
    public partial class rEmpleado : Window
    {
        public class DateFormat : System.Windows.Data.IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if (value == null) return null;

                return ((DateTime)value).ToString("dd/MM/yyyy");
            }

            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }

        private Empleados empleados = new Empleados();
        

        public rEmpleado()
        {
            InitializeComponent();
            this.DataContext = empleados;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Empleados encontrado = EmpleadoBLL.Buscar(empleados.CodigoEmpleado);

            if (encontrado != null)
            {
                empleados = encontrado;

                Cargar();
            }
            else
            {
                Limpiar();
                MessageBox.Show("El Empleado no existe en la base de datos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;
            bool paso = false;

            if (empleados.CodigoEmpleado == 0)
            {
                paso = EmpleadoBLL.Guardar(empleados);
            }
            else
            {
                if (ExisteEnLaBaseDedatos())
                {
                    paso = EmpleadoBLL.Guardar(empleados);
                }
                else
                {
                    MessageBox.Show("No existe en la base de datos :(", "Error");
                }
            }

            if (paso)
            {
                Limpiar();
                MessageBox.Show("¡Transacion exictosa :)", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("¡Fallo al Guardar! :(", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            Empleados existe = EmpleadoBLL.Buscar(empleados.CodigoEmpleado);

            if (existe == null)
            {
                MessageBox.Show("No existe el  Empleado en la base de datos :(", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                EmpleadoBLL.Eliminar(empleados.CodigoEmpleado);
                MessageBox.Show("¡Empleado Eliminado! :)", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }

        }
        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = empleados;
        }
        private void Limpiar()
        {
            this.empleados = new Empleados();
            this.DataContext = empleados;
        }

        private bool Validar()
        {
            bool esValido = true;

            if (NombreTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Favor LLenar el campo nombre", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (ApellidoTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Favor LLenar el campo apellido", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (TipoDocumentoComboBox.SelectedIndex < 0)
            {
                esValido = false;
                MessageBox.Show("Favor LLenar el campo tipo documento", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if (NumeroDocumentoTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Favor LLenar el campo numero de documento", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if (DireccionTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Favor LLenar el campo direccion", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if (CiudadTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Favor LLenar el campo ciudad", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if (SexoComboBox.SelectedIndex == 0)
            {
                esValido = false;
                MessageBox.Show("Favor LLenar el campo sexo ", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (EstadoCivilComboBox.SelectedIndex < 0)
            {
                esValido = false;
                MessageBox.Show("Favor LLenar el campo estado  civil", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (TelefonoTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Favor LLenar el campo telefono", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if (CelularTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Favor LLenar el campo celular", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (EmailTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Favor LLenar el campo Email", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if (EmpresaTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Favor LLenar el campo el nombre de la empresa", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if (CargoTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Favor LLenar el campo Cargo", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if (TipoPagoComboBox.SelectedIndex < 0)
            {
                esValido = false;
                MessageBox.Show("Favor selecionar el Tipo de pago", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if (EstadoComboBox.SelectedIndex == 0)
            {
                esValido = false;
                MessageBox.Show("Favor selecionar el estado", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            return esValido;
        }
        private bool ExisteEnLaBaseDedatos()
        {
            Empleados esValido = EmpleadoBLL.Buscar(empleados.CodigoEmpleado);
            return (esValido != null);
        }
    }
}
