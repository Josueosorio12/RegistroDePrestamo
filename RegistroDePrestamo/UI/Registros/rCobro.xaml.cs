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
    /// Interaction logic for rCobro.xaml
    /// </summary>
    public partial class rCobro : Window
    {
        private Prestamos prestamos = new Prestamos();
        private PrestamoDetalle detalles = new PrestamoDetalle();
        public rCobro()
        {
            InitializeComponent();
            this.DataContext = prestamos;
        }

        private void PagarButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Prestamos encontrado = PrestamoBLL.Buscar(prestamos.Prestamoid);

            if (encontrado != null)
            {
                prestamos = encontrado;

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
            this.DataContext = prestamos;
        }
        private void Limpiar()
        {
            this.prestamos = new Prestamos();
            this.DataContext = prestamos;
        }

    }
}
