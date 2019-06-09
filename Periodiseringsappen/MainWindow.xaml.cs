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

        const string fileName = "amounts.bin";
        public MainWindow()
        {
            InitializeComponent();

            if (File.Exists(fileName)) // Reads the file, if there is one.
            {
                bigSum = (Amount)FileOperations.Deserialize(fileName);
            }
            else
            {
                NewStart ns = new NewStart();
                ns.Show();
                this.Close();
            }

            txtTotalSum.Text = bigSum.Value.ToString();
            
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            bigSum.Value = Decimal.Parse(txtTotalSum.Text);
            FileOperations.Serialize(bigSum, fileName);
            this.Close();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            NewStart ns = new NewStart();
            ns.Show();
            this.Close();
        }
    }
}
