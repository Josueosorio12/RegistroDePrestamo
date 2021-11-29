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

    public partial class rPrestamo : Window
    {
        List<Cuota> Amortizacion = new List<Cuota>();

        private Prestamos prestamos = new Prestamos();
        private PrestamoDetalle Detalle = new PrestamoDetalle();
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
            if (!Validar())
                return;
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

            MontoCuotaTextBox.Text = ResultadoDivision.ToString("0.00");
            TotalInteresTextBox.Text = MontoIntere.ToString("0.00");
            MontoTotalTextBox.Text = MontoPrestamo.ToString("0.00");


            Amortizador();


            MontoCuotaTextBox.Focus();

            TotalInteresTextBox.Focus();

            MontoTotalTextBox.Focus();

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



        private void Amortizador()
        {
            Cuota C = new Cuota();

            C.NumeroCuota = Convert.ToInt32(NumeroCuotaTextBox.Text);
            C.Interes = Convert.ToSingle(TotalInteresTextBox.Text) / C.NumeroCuota;
            C.Capital = Convert.ToSingle(MontoTextBox.Text) / C.NumeroCuota;
            C.Total = C.Interes + C.Capital;

            for (int x = 0; x < Convert.ToInt32(NumeroCuotaTextBox.Text); x++)
            {
                C.NumeroCuota = x + 1;
                this.Amortizacion.Add(C);
            }

            DatosPretamosGrid.ItemsSource = null;
            DatosPretamosGrid.ItemsSource = Amortizacion;


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
            if (TipoDocumentoComboBox.SelectedIndex == 0)
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
            if (EstadoCivilComboBox.SelectedIndex == 0)
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

            if (LugarTrabajoTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Favor LLenar el campo lugar de trabajo", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if (OcupacionTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Favor LLenar el campo ocupacion", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if (SueeldoTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Favor LLenar el campo sueldo mensual", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if (MontoTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Favor LLenar el campo Monto prestamo", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if (InteresTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Favor LLenar el campo de intereses", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if (FormaDePago.SelectedIndex == 0)
            {
                esValido = false;
                MessageBox.Show("Favor LLenar el campo de forma de pago", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if (NumeroCuotaTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Favor LLenar el campo de numero de cuota", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            return esValido;
        }
        private bool ExisteEnLaBaseDedatos()
        {
            Prestamos esValido = PrestamoBLL.Buscar(prestamos.Prestamoid);
            return (esValido != null);
        }

    }
}
