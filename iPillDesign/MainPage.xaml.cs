using System;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using SeasideResearch.LibCurlNet;
using Windows.System;
using Windows.Media.SpeechSynthesis;
using System.Diagnostics;
using System.Linq;

namespace iPillDesign
{
    public sealed partial class MainPage : Page
    {

        private DateTime TimerStart { get; set; }
        private string CurrentPage { get; set; }
        String stunde;
        Uri note = new Uri("http://www.baitmain.de/ipill");

        public MainPage()
        {
            this.InitializeComponent();
            this.TimerStart = DateTime.Now;
            time.Text = DateTime.Now.ToString("HH:mm");

            //Timer starten
            DispatcherTimer dispatchTimer = new DispatcherTimer();
            dispatchTimer.Interval = TimeSpan.FromSeconds(60);
            dispatchTimer.Tick += dispatchTimer_Tick;
            dispatchTimer.Start();

            //Ausgabeknopf inaktiv
            ausgabe.IsEnabled = false;            
        }

        private async void readText(String text)
        {
            //BEnachrichtigung "sprechen"
            MediaElement player = new MediaElement();
            SpeechSynthesizer synthesizer = new SpeechSynthesizer();
            synthesizer.Voice = SpeechSynthesizer.AllVoices
                .First(i => (i.Gender == VoiceGender.Female));
            SpeechSynthesisStream stream = await synthesizer.SynthesizeTextToStreamAsync(text);
            player.DefaultPlaybackRate = 0.8;
            player.SetSource(stream, stream.ContentType);            
            player.Play();
        }

        private void dispatchTimer_Tick(object sender, object e)
        {
            time.Text = DateTime.Now.ToString("HH:mm");
            stunde = DateTime.Now.ToString("HH:mm");

            if (stunde == "08" || stunde == "09")
                if (time.Text == "08:00")
                {
                    einnahme.Text = "Nächste Einnahme: Jetzt";
                    readText("Medikamente jetzt einnehmen");
                    ausgabe.IsEnabled = true;
                }
                else if (time.Text == "08:45")
                {
                    einnahme.Foreground = new SolidColorBrush(Colors.Gold);
                    readText("Medikamente jetzt einnehmen");
                }
                else if (time.Text == "09:15")
                {
                    einnahme.Foreground = new SolidColorBrush(Colors.Red);
                    readText("Medikamente jetzt einnehmen");
                }
                else if (time.Text == "09:59")
                {
                    einnahme.Foreground = new SolidColorBrush(Colors.Green);
                    readText("Einnahme wurde verpasst. Nachricht wird versendet.");
                    web.Navigate(note);
                    ausgabe.IsEnabled = false;
                }
                else { }

            else if (stunde == "13" || stunde == "14")
                if (time.Text == "13:00")
                {
                    einnahme.Text = "Nächste Einnahme: Jetzt";
                    readText("Medikamente jetzt einnehmen");
                    ausgabe.IsEnabled = true;
                }
                else if (time.Text == "13:45")
                {
                    einnahme.Foreground = new SolidColorBrush(Colors.Gold);
                    readText("Medikamente jetzt einnehmen");
                }
                else if (time.Text == "14:15")
                {
                    einnahme.Foreground = new SolidColorBrush(Colors.Red);
                    readText("Medikamente jetzt einnehmen");
                }
                else if (time.Text == "14:59")
                {
                    einnahme.Foreground = new SolidColorBrush(Colors.Green);
                    readText("Einnahme wurde verpasst. Nachricht wird versendet.");
                    web.Navigate(note);
                    ausgabe.IsEnabled = false;
                }
                else { }

            else if (stunde == "18" || stunde == "19")
                if (time.Text == "18:00")
                {
                    einnahme.Text = "Nächste Einnahme: Jetzt";
                    readText("Medikamente jetzt einnehmen");
                    ausgabe.IsEnabled = true;
                }
                else if (time.Text == "18:45")
                {
                    einnahme.Foreground = new SolidColorBrush(Colors.Gold);
                    readText("Medikamente jetzt einnehmen");
                }
                else if (time.Text == "19:15")
                {
                    einnahme.Foreground = new SolidColorBrush(Colors.Red);
                    readText("Medikamente jetzt einnehmen");
                }
                else if (time.Text == "19:59")
                {
                    einnahme.Foreground = new SolidColorBrush(Colors.Green);
                    readText("Einnahme wurde verpasst. Nachricht wird versendet.");
                    web.Navigate(note);
                    ausgabe.IsEnabled = false;
                }
                else { }
            else {
                einnahme.Foreground = new SolidColorBrush(Colors.Green);
                ausgabe.IsEnabled = false;
            }
        }

        private void ausgabe_Click(object sender, RoutedEventArgs e)
        {
            einnahme.Foreground = new SolidColorBrush(Colors.Green);
            ausgabe.IsEnabled = false;
            //Routine, um Medikamente ausfallen zu lassen (Servos etc.)
            if (stunde == "08" || stunde == "09")
            {
                einnahme.Text = "Nächste Einnahme: 13 Uhr";                
                ausgabe.IsEnabled = true;
            }
            else if (stunde == "13" || stunde == "14")
            {
                einnahme.Text = "Nächste Einnahme: 18 Uhr";
            }
            else if (stunde == "18" || stunde == "19")
            {
                einnahme.Text = "Nächste Einnahme: 8 Uhr";
            }
            else
            {
                //Sollte in der Praxis garnicht möglich sein
                einnahme.Text = "Nächste Einnahme: 18 Uhr";
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            //Testknopf 1
            ausgabe.IsEnabled = true;
            einnahme.Foreground = new SolidColorBrush(Colors.Green);
            einnahme.Text = "Nächste Einnahme: Jetzt";
            readText("Medikamente jetzt einnehmen");
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            //Testknopf 2
            ausgabe.IsEnabled = true;
            einnahme.Foreground = new SolidColorBrush(Colors.Gold);
            einnahme.Text = "Nächste Einnahme: Jetzt";
            readText("Medikamente jetzt einnehmen");
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            //Testknopf 3
            ausgabe.IsEnabled = true;
            einnahme.Foreground = new SolidColorBrush(Colors.Red);
            einnahme.Text = "Nächste Einnahme: Jetzt";
            readText("Medikamente jetzt einnehmen");
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            web.Navigate(note);
            einnahme.Foreground = new SolidColorBrush(Colors.Green);
            ausgabe.IsEnabled = false;
            einnahme.Text = "Nächste Einnahme: 13 Uhr";
            readText("Einnahme wurde verpasst. Nachricht wird versendet.");
        }

        private void web_LoadCompleted(object sender, Windows.UI.Xaml.Navigation.NavigationEventArgs e)
        {

        }
    }
}
