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
        //Amount bigSum = new Amount();
        //Amount leftSum = new Amount();
        StoredValues values = new StoredValues();
        List<AccountEvent> events = new List<AccountEvent>();

        //const string fileNameBig = "big.bin";
        //const string fileNameLeft = "left.bin";
        const string fileNameValues = "values.bin";
        const string fileNameEvents = "events.bin";
        public MainWindow()
        {
            InitializeComponent();

            if (File.Exists(fileNameValues) && File.Exists(fileNameEvents))
            {
                //bigSum = (Amount)FileOperations.Deserialize(fileNameBig);
                //leftSum = (Amount)FileOperations.Deserialize(fileNameLeft);
                values = (StoredValues)FileOperations.Deserialize(fileNameValues);
                events = (List<AccountEvent>)FileOperations.Deserialize(fileNameEvents);
            }
            else
            {
                NewStart ns = new NewStart();
                ns.Show();
                this.Close();
            }

            txtBigSum.Text = values.BigSum.ToString();
            txtLeftSum.Text = values.RemainingSum.ToString();
            lviewEvents.ItemsSource = events;
            
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            values.BigSum = Decimal.Parse(txtBigSum.Text);
            values.RemainingSum = Decimal.Parse(txtLeftSum.Text);
            //FileOperations.Serialize(bigSum, fileNameBig);
            //FileOperations.Serialize(leftSum, fileNameLeft);
            FileOperations.Serialize(values, fileNameValues);
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
                
                    values.RemainingSum = values.RemainingSum - Decimal.Parse(txtSubtract.Text);
                    txtLeftSum.Text = values.RemainingSum.ToString();
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
