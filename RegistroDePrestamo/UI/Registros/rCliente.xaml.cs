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
    /// Interaction logic for rCliente.xaml
    /// </summary>
    public partial class rCliente : Window
    {
        private Clientes clientes = new Clientes();
        private PrestamoDetalle detalles = new PrestamoDetalle();
        private Prestamos prestamos = new Prestamos();
        public rCliente()
        {
            InitializeComponent();
            this.DataContext = clientes;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            if (clientes.CodigoCliente == 0)
            {
                paso = ClienteBLL.Guardar(clientes);
            }
            else
            {
                if (ExisteEnLaBaseDedatos())
                {
                    paso = ClienteBLL.Guardar(clientes);
                }
                else
                {
                    MessageBox.Show("No existe en la base de datos", "Error");
                }
            }

            if (paso)
            {
                Limpiar();
                MessageBox.Show("¡Cliente Guardado!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("¡Fallo Cliente no eliminado! :(", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            Clientes existe = ClienteBLL.Buscar(clientes.CodigoCliente);

            if (existe == null)
            {
                MessageBox.Show("No existe el Cliente en la base de datos :(", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                ClienteBLL.Eliminar(clientes.CodigoCliente);
                MessageBox.Show("¡Cliente Eliminado! :)", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Clientes encontrado = ClienteBLL.Buscar(clientes.CodigoCliente);
            if (encontrado != null)
            {
                clientes = encontrado;
                Cargar();
            }
            else
            {
                Limpiar();
                MessageBox.Show("El Registro no existe en la base de datos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = clientes;
        }
        private void Limpiar()
        {
            this.clientes = new Clientes();
            this.DataContext = clientes;
        }

        private bool ExisteEnLaBaseDedatos()
        {
            Clientes esValido = ClienteBLL.Buscar(clientes.CodigoCliente);
            return (esValido != null);
        }
    }
}
