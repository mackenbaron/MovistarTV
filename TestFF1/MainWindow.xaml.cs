namespace TestFF1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using System.IO;
    using System.Diagnostics;
    using System.Globalization;
    using System.ComponentModel;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public List<Channel> Channels { get; set; }

        private string processOutput;

        public string ProcessOutput
        {
            get 
            { 
                return processOutput; 
            }

            set 
            { 
                processOutput = value;
                this.OnPropertyChanged("ProcessOutput");
            }
        }


        public MainWindow()
        {
            InitializeComponent();
            this.Channels = new List<Channel>();
            this.Channels.Add(new Channel { Name = "Nickelodeon", Stream = "http://b29273-p104-hc.1.cdn.telefonica.com/_29273/NICK_SUB-audio_esp%3D49600-video%3D500000.m3u8", Logo = new Uri("Logos/nickelodeon.jpg", UriKind.Relative) });
            this.Channels.Add(new Channel { Name = "Disney JR", Stream = "http://b29285-p104-h8.1.cdn.telefonica.com/_29285/DSNJR_SUB-audio_esp%3D49600-video%3D500000.m3u8", Logo = new Uri("Logos/disneyjr.jpg", UriKind.Relative) });
            this.Channels.Add(new Channel { Name = "40TV", Stream = "http://b31312-p104-hc.1.cdn.telefonica.com/_31312/40TV_SUB-audio_esp%3D49600-video%3D500000.m3u8", Logo = new Uri("Logos/40tv.jpg", UriKind.Relative) });
            this.Channels.Add(new Channel { Name = "Disney XD", Stream = "http://b31309-p104-hf.1.cdn.telefonica.com/_31309/DSNYXD_SUB-audio_Esp%3D49600-video%3D500000.m3u8", Logo = new Uri("Logos/disney.jpg", UriKind.Relative) });
            this.Channels.Add(new Channel { Name = "Cocina", Stream = "http://b31305-p104-hf.1.cdn.telefonica.com/_31305/COCINA_SUB-audio_esp%3D49600-video%3D500000.m3u8", Logo = new Uri("Logos/cocina.png", UriKind.Relative) });
            this.Channels.Add(new Channel { Name = "Fox", Stream = "http://b29269-p104-hc.1.cdn.telefonica.com/_29269/FOX_SUB-audio_Esp%3D49600-video%3D500000.m3u8", Logo = new Uri("Logos/fox.jpg", UriKind.Relative) });
            this.Channels.Add(new Channel { Name = "FoxCrime", Stream = "http://b31317-p104-h9.1.cdn.telefonica.com/_31317/FOXCRIME_SUB-audio_esp%3D49600-video%3D500000.m3u8", Logo = new Uri("Logos/foxlife.png", UriKind.Relative) });
            this.Channels.Add(new Channel { Name = "AXN", Stream = "http://b29278-p104-h5.1.cdn.telefonica.com/_29278/AXN_SUB-audio_Esp%3D49600-video%3D500000.m3u8", Logo = new Uri("Logos/axn.png", UriKind.Relative) });
            this.Channels.Add(new Channel { Name = "AXN White", Stream = "http://b31316-p104-he.1.cdn.telefonica.com/_31316/AXNWHITE_SUB-audio_Esp%3D49600-video%3D500000.m3u8", Logo = new Uri("Logos/axnwhite.png", UriKind.Relative) });
            this.Channels.Add(new Channel { Name = "Calle13", Stream = "http://b29270-p104-h0.1.cdn.telefonica.com/_29270/CLL13_SUB-audio_esp%3D49600-video%3D500000.m3u8", Logo = new Uri("Logos/calle13.gif", UriKind.Relative) });
            this.Channels.Add(new Channel { Name = "TNT", Stream = "http://b29280-p104-hc.1.cdn.telefonica.com/_29280/TNT_SUB-audio_esp%3D49600-video%3D500000.m3u8", Logo = new Uri("Logos/tnt.jpg", UriKind.Relative) });            
            this.Channels.Add(new Channel { Name = "Cosmo", Stream = "http://b29283-p104-h8.1.cdn.telefonica.com/_29283/CSMO_SUB-audio_esp%3D49600-video%3D500000.m3u8", Logo = new Uri("Logos/cosmo.png", UriKind.Relative) });
            this.Channels.Add(new Channel { Name = "Paramount", Stream = "http://b29281-p104-h2.1.cdn.telefonica.com/_29281/PCMDY_SUB-audio_esp%3D49600-video%3D500000.m3u8", Logo = new Uri("Logos/paramountcomedy.png", UriKind.Relative) });
            this.Channels.Add(new Channel { Name = "SciFi", Stream = "http://b31311-p104-hc.1.cdn.telefonica.com/_31311/SYFY_SUB-audio_esp%3D49600-video%3D500000.m3u8", Logo = new Uri("Logos/syfy.png", UriKind.Relative) });
            this.Channels.Add(new Channel { Name = "TCM", Stream = "http://b31310-p104-ha.1.cdn.telefonica.com/_31310/TCM_SUB-audio_esp%3D49600-video%3D500000.m3u8", Logo = new Uri("Logos/tcm.jpg", UriKind.Relative) });
            this.Channels.Add(new Channel { Name = "Canal+ Liga", Stream = "http://b29276-p104-hc.1.cdn.telefonica.com/_29276/CPLUSLG_SUB-audio_Esp%3D49600-video%3D500000.m3u8", Logo = new Uri("Logos/liga.jpg", UriKind.Relative) });
            this.Channels.Add(new Channel { Name = "Liga Campeones", Stream = "http://b29275-p104-h7.1.cdn.telefonica.com/_29275/CPLUSCHP_SUB-audio_esp%3D49600-video%3D500000.m3u8", Logo = new Uri("Logos/ligacampeones.jpg", UriKind.Relative) });
            this.Channels.Add(new Channel { Name = "National Geographic", Stream = "http://b29287-p104-h7.1.cdn.telefonica.com/_29287/NTLG_SUB-audio_esp%3D49600-video%3D500000.m3u8", Logo = new Uri("Logos/national.jpg", UriKind.Relative) });
            this.Channels.Add(new Channel { Name = "National Geo. Wild", Stream = "http://b31307-p104-h1.1.cdn.telefonica.com/_31307/NATGEOWILD_SUB-audio_esp%3D49600-video%3D500000.m3u8", Logo = new Uri("Logos/wild.png", UriKind.Relative) });
            this.Channels.Add(new Channel { Name = "Movistar Futbol", Stream = "http://b32861-p104-h8.1.cdn.telefonica.com/_32861/MOVFUTBOL_SUB-audio_esp%3D49600-video%3D500000.m3u8", Logo = new Uri("Logos/movistar futbol.jpg", UriKind.Relative) });

            this.Channels = this.Channels.OrderBy(s => s.Name).ToList();
            this.DataContext = this;
        }

        private Process process;

        private void LaunchChannel(Channel channel)
        {
            string path = System.IO.Path.Combine(System.Environment.GetEnvironmentVariable("TEMP"), "tempfile.exe");
            try
            {
                File.WriteAllBytes(path, MovistarTV.Properties.Resources.ffplay);
            }
            catch (IOException)
            {
                this.process.Kill();
            }

            this.process = new Process();
            this.process.StartInfo.UseShellExecute = false;
            this.process.StartInfo.CreateNoWindow = true;
            this.process.StartInfo.RedirectStandardOutput = true;
            this.process.StartInfo.RedirectStandardError = true;
            this.process.ErrorDataReceived += ProcessErrorDataReceived;
            this.process.OutputDataReceived += ProcessOutputDataReceived;
            this.process.StartInfo.FileName = path;
            this.process.StartInfo.Arguments = string.Format(CultureInfo.InvariantCulture, "-i {0} -window_title {1}", channel.Stream, channel.Name.Replace(" ", string.Empty));
            this.process.Start();
            this.process.BeginErrorReadLine();
            this.process.BeginOutputReadLine();
        }

        void ProcessOutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            this.ProcessOutput = e.Data;
        }
        private string error = string.Empty;
        void ProcessErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            this.error += Environment.NewLine + e.Data;
        }

        private Channel selectedChannel;

        private void List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((e != null) && (e.AddedItems.Count > 0))
            {
                this.selectedChannel = (Channel)e.AddedItems[0];
            }
        }

        private void List_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (this.selectedChannel != null)
            {
                this.LaunchChannel(this.selectedChannel);
            }
        }

        public void OnPropertyChanged(string param)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(param));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
