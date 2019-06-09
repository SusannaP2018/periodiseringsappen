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

namespace Periodiseringsappen
{
    /// <summary>
    /// Interaction logic for NewStart.xaml
    /// </summary>
    public partial class NewStart : Window
    {
        Amount bigSum = new Amount();
        Amount leftSum = new Amount();
        List<AccountEvent> events = new List<AccountEvent>();

        const string fileNameBig = "big.bin";
        const string fileNameLeft = "left.bin";
        const string fileNameEvents = "events.bin";

        public NewStart()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            bigSum.Value = Decimal.Parse(txtBigSum.Text);
            leftSum.Value = bigSum.Value;
            AccountEvent ev = new AccountEvent();
            events.Add(ev);
            events.Remove(ev);

            FileOperations.Serialize(bigSum, fileNameBig);
            FileOperations.Serialize(leftSum, fileNameLeft);
            FileOperations.Serialize(events, fileNameEvents);

            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }
    }
}
