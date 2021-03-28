using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Base21
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Resultados : ContentPage
    {
        static string nombreArchivo = "prueba.txt";
        static string ruta = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        static string rutaCompleta = Path.Combine(ruta, nombreArchivo);
        public Resultados()
        {
            InitializeComponent();
            fetchResultados();
            tbHome.Clicked += onHomeClicked;
        }

        private void onHomeClicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new MainPage());
        }

        private void fetchResultados()
        {
            if (File.Exists(rutaCompleta)) { 
                using (var lector = new StreamReader(rutaCompleta, true)) {
                    string TextoLeido;
                    while ((TextoLeido = lector.ReadLine()) != null) {
                        resultados.Text += $"{TextoLeido}\n"; 
                    } 
                } 
            }
        }
    }
}