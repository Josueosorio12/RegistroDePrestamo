using RegistroDePrestamo.UI.Consultas;
using RegistroDePrestamo.UI.Registros;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RegistroDePrestamo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
           
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            rPrestamo rPrestamo = new rPrestamo();
            rPrestamo.Show();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            rCliente rCliente = new rCliente();
            rCliente.Show();
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            rEmpleado rEmpleado = new rEmpleado();
            rEmpleado.Show();
        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            cEmpleado cEmpleado = new cEmpleado();
            cEmpleado.Show();
        }

        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {
            rUsuario rUsuario = new rUsuario();
            rUsuario.Show();
        }

        private void MenuItem_Click_7(object sender, RoutedEventArgs e)
        {
            cUsuarios cUsuarios = new cUsuarios();
            cUsuarios.Show();
        }

        private void MenuItem_Click_8(object sender, RoutedEventArgs e)
        {
            cCliente cCliente = new cCliente();
            cCliente.Show();
        }

        private void MenuItem_Click_9(object sender, RoutedEventArgs e)
        {
            cPrestamos cPrestamos = new cPrestamos();
            cPrestamos.Show();
        }

        private void MenuItem_Click_10(object sender, RoutedEventArgs e)
        {
            cGeneralPrestamo cGeneralPrestamo = new cGeneralPrestamo();
            cGeneralPrestamo.Show();
        }

        private void MenuItem_Click_11(object sender, RoutedEventArgs e)
        {
            rCobro rCobro = new rCobro();
            rCobro.Show();
        }

        private void MenuItem_Click_12(object sender, RoutedEventArgs e)
        {
            rRoles rRoles = new rRoles();
            rRoles.Show();
        }

        private void MenuItem_Click_13(object sender, RoutedEventArgs e)
        {
            rMoras rMoras = new rMoras();
            rMoras.Show();
        }

        private void MenuItem_Click_14(object sender, RoutedEventArgs e)
        {
            cMora cMora = new cMora();
            cMora.Show();
        }
    }
}
