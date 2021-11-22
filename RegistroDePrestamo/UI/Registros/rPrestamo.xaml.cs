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
    /// Interaction logic for rPrestamo.xaml
    /// </summary>
    public partial class rPrestamo : Window
    {
        private Prestamos prestamos = new Prestamos();
        public rPrestamo()
        {
            InitializeComponent();
            this.DataContext = prestamos;
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

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void RegistrarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            if (prestamos.Prestamoid == 0)
            {
                paso = PrestamoBLL.Guardar(prestamos);
            }
            else
            {
                if (ExisteEnLaBaseDedatos())
                {
                    paso = PrestamoBLL.Guardar(prestamos);
                }
                else
                {
                    MessageBox.Show("No existe en la base de datos", "Error");
                }
            }

            if (paso)
            {
                Limpiar();
                MessageBox.Show("¡Registrado!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("¡Fallo al Registrar! :(", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            Prestamos existe = PrestamoBLL.Buscar(prestamos.Prestamoid);

            if (existe == null)
            {
                MessageBox.Show("No existe el Registro en la base de datos :(", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                PrestamoBLL.Eliminar(prestamos.Prestamoid);
                MessageBox.Show("¡Registro Eliminado! :)", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }
        }

        private void AgregarCuotaButton_Click(object sender, RoutedEventArgs e)
        {
            var Listado = new List<PrestamoBLL>();


            float ResultadoDivision = 0;
            float Residuo = 0;
            float MontoIntere = 0;
            float MontoPrestamo = 0;
            float porcentaje_interes = 0;
            float numerocuotas = 0;

            MontoPrestamo = Convert.ToSingle(MontoTextBox.Text.ToString());
            porcentaje_interes = Convert.ToSingle(InteresTextBox.Text.ToString());
            numerocuotas = Convert.ToSingle(NumeroCuotaTextBox.Text.ToString());

            MontoIntere = (MontoPrestamo * porcentaje_interes) / 100;
            MontoPrestamo += MontoIntere;

            ResultadoDivision = Convert.ToSingle(MontoPrestamo) / Convert.ToSingle(numerocuotas);
            Residuo = Convert.ToSingle(MontoPrestamo) % Convert.ToSingle(numerocuotas);


            /*for (int i = 1; i <= numerocuotas; i++)
            {
                ListaCuota.Add(new Cuota()
                {
                   
                    NumeroCuota = i,
                    MontoCuota = i == 0 ? (ResultadoDivision + Residuo) : ResultadoDivision,
                    EstadoCuota = "Pediente",
                    ProximoPago = i == 1 ? 1 : 0

                });
            }*/

            MontoCuotaTextBox.Text = ResultadoDivision.ToString("0.00");
            TotalInteresTextBox.Text = MontoIntere.ToString("0.00");
            MontoTotalTextBox.Text = MontoPrestamo.ToString("0.00");
        }

        private void AgregarButton_Click(object sender, RoutedEventArgs e)
        {
            prestamos.Detalle.Add(new PrestamoDetalle(prestamos.Prestamoid, Convert.ToInt32(NumeroCuotaTextBox.Text), Convert.ToSingle(MontoCuotaTextBox.Text),
               Convert.ToSingle(TotalInteresTextBox.Text), Convert.ToSingle(MontoTotalTextBox.Text)));

            Cargar();

            MontoCuotaTextBox.Focus();
            MontoCuotaTextBox.Clear();

            TotalInteresTextBox.Focus();
            TotalInteresTextBox.Clear();

            MontoTotalTextBox.Focus();
            MontoTotalTextBox.Clear();
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

        private bool ExisteEnLaBaseDedatos()
        {
            Prestamos esValido = PrestamoBLL.Buscar(prestamos.Prestamoid);
            return (esValido != null);
        }
     
    }
}
