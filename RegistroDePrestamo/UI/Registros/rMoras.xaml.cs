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
    /// Interaction logic for rMoras.xaml
    /// </summary>
    public partial class rMoras : Window
    {
        private Moras Mora = new Moras();
     
        public rMoras()
        {
            InitializeComponent();
            this.DataContext = Mora;
            PrestamoComboBox.ItemsSource = PrestamoBLL.GetList();
            PrestamoComboBox.SelectedValuePath = "Prestamoid";
            PrestamoComboBox.DisplayMemberPath = "Prestamoid";
          
            TotalTextBox.Text = "0";
        }

        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = Mora;
        }
        private void Limpiar()
        {
            this.Mora = new Moras();
            this.Mora.Fecha = DateTime.Now;
            this.DataContext = Mora;

        }
        private bool ValidarAgregar()
        {
            bool esValido = true;
            if (PrestamoComboBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Ha ocurrido un error, Inserte el prestamo", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (ValorTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Ha ocurrido un error, Inserte el prestamo", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            return esValido;
        }
        
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Moras encontrado = MorasBLL.Buscar(Mora.MoraId);
            if (encontrado != null)
            {
                Mora = encontrado;
                Cargar();
            }
            else
            {
                Limpiar();
                MessageBox.Show("Mora no existe en la base de datos", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Agregar_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidarAgregar())
                return;
            Mora.Total += Convert.ToInt32(ValorTextBox.Text);
            Mora.Detalle.Add(new MorasDetalle(Mora.MoraId, Convert.ToInt32(PrestamoComboBox.SelectedValue), Convert.ToInt32(ValorTextBox.Text)));
            Cargar();
            ValorTextBox.Clear();
        }

        private void Remover_Click(object sender, RoutedEventArgs e)
        {
            if (MorasDataGrid.Items.Count >= 1 && MorasDataGrid.SelectedIndex <= MorasDataGrid.Items.Count - 1)
            {
                MorasDetalle m = (MorasDetalle)MorasDataGrid.SelectedValue;
                Mora.Total -= m.Total;
                Mora.Detalle.RemoveAt(MorasDataGrid.SelectedIndex);
                Cargar();
            }
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }
        private bool ExisteEnLaBaseDeDatos()
        {
            Moras esValido = MorasBLL.Buscar(Mora.MoraId);

            return (esValido != null);
        }
        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;
            if (Mora.MoraId == 0)
            {
                paso = MorasBLL.Guardar(Mora);
            }
            else
            {
                if (ExisteEnLaBaseDeDatos())
                {
                    paso = MorasBLL.Guardar(Mora);
                }
                else
                {
                    MessageBox.Show("No existe en la Mora en la base de datos :(", "Error");
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
            Moras existe = MorasBLL.Buscar(Mora.MoraId);

            if (existe == null)
            {
                MessageBox.Show("No existe la mora en la base de datos", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                MorasBLL.Eliminar(Mora.MoraId);
                MessageBox.Show("Eliminado", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }
        }
    }

}