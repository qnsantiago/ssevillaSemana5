using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ssevillaSemana5
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AcEliminar : ContentPage
    {
        private string URL = "http://192.168.10.21:8080/ws_uisrael/post.php";
        public AcEliminar(Estudiante datos)
        {
            InitializeComponent();
            txtCodigo.Text = datos.codigo.ToString();
            txtNombre.Text = datos.nombre.ToString();
            txtApellido.Text = datos.apellido.ToString();
            txtEdad.Text = datos.edad.ToString();
        }

        private void btnActualizar_Clicked(object sender, EventArgs e)
        {
            WebClient cliente = new WebClient();
            var datos = new System.Collections.Specialized.NameValueCollection();
            try
            {

                datos.Add("codigo", txtCodigo.Text);
                datos.Add("nombre", txtNombre.Text);
                datos.Add("apellido", txtApellido.Text);
                datos.Add("edad", txtEdad.Text);

                cliente.UploadValues(URL+"?codigo=" + txtCodigo.Text + "&nombre=" + txtNombre.Text + "&apellido=" + txtApellido.Text + "&edad=" + txtEdad.Text, "PUT", datos);
                var mensaje = "Dato actualizado con exito";
                DependencyService.Get<Mensaje>().longAlert(mensaje);
                Navigation.PushAsync(new MainPage());
            }
            catch (Exception ex)
            {
                DependencyService.Get<Mensaje>().longAlert(ex.Message);

            }


        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {

            WebClient cliente = new WebClient();
            var datos = new System.Collections.Specialized.NameValueCollection();
            try
            {

                datos.Add("codigo", txtCodigo.Text);
                cliente.UploadValues(URL + "?codigo=" + txtCodigo.Text, "DELETE", datos);
                var mensaje = "Dato eliminado con exito";
                DependencyService.Get<Mensaje>().longAlert(mensaje);
                Navigation.PushAsync(new MainPage());
            }
            catch (Exception ex)
            {
                DependencyService.Get<Mensaje>().longAlert(ex.Message);

            }


        }
    }
}