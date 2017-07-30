using Android.App;
using Android.Widget;
using Android.OS;
using System.Net.Mail;
using System.Net;
using Java.Lang;
using System.Security.Cryptography.X509Certificates;

namespace SMTPSend
{
    [Activity(Label = "SMTPSend", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);



            //Llamamos a la funcion que envia el correo
            EnviarCorreo("Este es el mensaje que le envio desde xamarin android ");
        }
        public void EnviarCorreo(string mensaje)
        {
            // Paso 1Habilitar el permiso de nuestro Gmail https://www.google.com/settings/security/lesssecureapps &  "Activar"

            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("brian.molina.27@gmail.com");//Este debe ser nuestro correo Gmail al que le dimos los permisos necesarios es decir el que envia los correos
                mail.To.Add("brian593@live.com");//este es el correo al que llegara el correo
                mail.Subject = "Message Subject";// El titulo del mensaje
                mail.Body = mensaje;//El mensaje que se almaceno en el estring 
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("brian.molina.27@gmail.com", "tucontraseñagmail");// aqui debe ir nuestro correo Gmail y nuestra contraseña
                SmtpServer.EnableSsl = true;
                ServicePointManager.ServerCertificateValidationCallback = delegate (object sender, X509Certificate certificate, X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors) {
                    return true;
                };
                SmtpServer.Send(mail);
                Toast.MakeText(Application.Context, "Correo enviado correctamente", ToastLength.Short).Show();
            }

            catch (Exception ex)
            {
                Toast.MakeText(Application.Context, ex.ToString(), ToastLength.Long);
            }
        }
    }
}

