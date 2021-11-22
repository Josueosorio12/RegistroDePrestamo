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

        private bool ExisteEnLaBaseDedatos()
        {
            Empleados esValido = EmpleadoBLL.Buscar(empleados.CodigoEmpleado);
            return (esValido != null);
        }
    }
}
