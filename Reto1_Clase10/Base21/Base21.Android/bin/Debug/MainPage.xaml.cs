using System;
using System.ComponentModel;
using System.IO;
using Xamarin.Forms;
using System.Text.RegularExpressions;
using D = System.Double;

namespace Base21
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]

    public partial class MainPage : ContentPage
    {
        static string nombreArchivo = "prueba.txt";
        static string ruta = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        static string rutaCompleta = Path.Combine(ruta, nombreArchivo);
        public MainPage()
        {
            InitializeComponent();
            BtnSuma.Clicked += ejecutarOperacion;
            BtnRest.Clicked += ejecutarOperacion; 
            BtnDiv.Clicked += ejecutarOperacion;
            BtnMult.Clicked += ejecutarOperacion;
            BtnLimp.Clicked += BtnLimp_Clicked;
            tbSave.Clicked += guardar;
            tbResultados.Clicked += onResultadosClicked;
        }

        private void onResultadosClicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new Resultados());
        }

        /*Guarda operacion y resultado en archivo de texto*/
        private void guardar(object sender, EventArgs e)
        {
            string resultado = lblres.Text;
            using (StreamWriter sw = File.AppendText(rutaCompleta)){ sw.WriteLine(resultado); }
        }

        /*Ejecuta operacion. Posibles operaciones son: suma, resta, multiplicacion, o division*/
        private void ejecutarOperacion(object sender, EventArgs e)
        {
            double primer_numero, segundo_numero;
            if (!(D.TryParse(num1.Text, out primer_numero) && D.TryParse(num2.Text, out segundo_numero))) return;
            string resultado = "";
            var boton_operacion = (Button)sender;
            string operacion = boton_operacion.ClassId;
            switch (operacion)
            {
                case "+":
                    resultado = (primer_numero + segundo_numero).ToString();
                    break;
                case "-":
                    resultado = (primer_numero - segundo_numero).ToString();
                    break;
                case "*":
                    resultado = (primer_numero * segundo_numero).ToString();
                    break;
                case "/":
                    if (segundo_numero == 0) { resultado = "?"; break; }
                    resultado = (primer_numero / segundo_numero).ToString();
                    break;
            }
            lblres.Text = $"{primer_numero} {operacion} {segundo_numero} = {resultado}";
        }
        private void BtnLimp_Clicked(object sender, EventArgs e)
        {
            num1.Text = String.Empty;
            num2.Text = String.Empty;
            res.Text = String.Empty; 
        }
    }

}
