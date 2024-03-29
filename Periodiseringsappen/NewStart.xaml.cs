﻿using System;
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
        StoredValues values = new StoredValues();
        List<AccountEvent> events = new List<AccountEvent>();
        
        const string fileNameValues = "values.bin";
        const string fileNameEvents = "events.bin";

        public NewStart()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                values.BigSum = Decimal.Parse(txtBigSum.Text);
                values.RemainingSum = values.BigSum;
                AccountEvent ev = new AccountEvent();
                events.Add(ev);
                events.Remove(ev);
                
                FileOperations.Serialize(values, fileNameValues);
                FileOperations.Serialize(events, fileNameEvents);

                MainWindow mw = new MainWindow();
                mw.Show();
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Du måste ange ett värde.");
            }

            
        }
    }
}
