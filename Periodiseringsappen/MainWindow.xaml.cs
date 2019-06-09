using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Periodiseringsappen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Amount bigSum = new Amount();
        Amount leftSum = new Amount();
        List<AccountEvent> events = new List<AccountEvent>();

        const string fileNameBig = "big.bin";
        const string fileNameLeft = "left.bin";
        const string fileNameEvents = "events.bin";
        public MainWindow()
        {
            InitializeComponent();

            if (File.Exists(fileNameBig) && File.Exists(fileNameEvents) && File.Exists(fileNameLeft))
            {
                bigSum = (Amount)FileOperations.Deserialize(fileNameBig);
                leftSum = (Amount)FileOperations.Deserialize(fileNameLeft);
                events = (List<AccountEvent>)FileOperations.Deserialize(fileNameEvents);
            }
            else
            {
                NewStart ns = new NewStart();
                ns.Show();
                this.Close();
            }

            txtBigSum.Text = bigSum.Value.ToString();
            txtLeftSum.Text = leftSum.Value.ToString();
            lviewEvents.ItemsSource = events;
            
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            bigSum.Value = Decimal.Parse(txtBigSum.Text);
            leftSum.Value = Decimal.Parse(txtLeftSum.Text);
            FileOperations.Serialize(bigSum, fileNameBig);
            FileOperations.Serialize(leftSum, fileNameLeft);
            FileOperations.Serialize(events, fileNameEvents);
            this.Close();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            NewStart ns = new NewStart();
            ns.Show();
            this.Close();
        }

        private void btnPeriodize_Click(object sender, RoutedEventArgs e)
        {
            AccountEvent ev = new AccountEvent();
            DateTime? d = dateP.SelectedDate;

            if (d == null)
            {
                MessageBox.Show("Du måste välja ett datum.");
            }
            else
            {
                ev.EventName = "Periodisering";
                ev.When = d;

                try
                {
                    ev.Value = Decimal.Parse(txtSubtract.Text);
                    events.Add(ev);
                
                    leftSum.Value = leftSum.Value - Decimal.Parse(txtSubtract.Text);
                    txtLeftSum.Text = leftSum.Value.ToString();
                    lviewEvents.ItemsSource = null;
                    lviewEvents.ItemsSource = events;

                    txtSubtract.Text = null;
                    dateP.SelectedDate = null;
            }
            catch (Exception)
            {
                MessageBox.Show("Du måste ange ett värde.");
            }
            }
        }
    }
}
