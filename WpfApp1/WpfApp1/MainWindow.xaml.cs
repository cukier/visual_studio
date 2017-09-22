using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        private GM master;

        public MainWindow()
        {
            try
            {
                InitializeComponent();
                master = new GM();
                Timer aTimer = new Timer();
                aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);                
                aTimer.Interval = 500;
                aTimer.Enabled = true;
                label.Content = "456456";

            }
            catch (Exception ex)
            {
                //Console.Out.Write(ex.ToString());
            }
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            String txt;

            txt = "Angulo Atual: " + master.get_angulo();
            label.Content = txt;
            Console.Out.WriteLine(txt);
        }
    }
}
