using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace LottoTicket
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Lotto ob = new Lotto();
        int[] a;
        public MainWindow()
        {
            InitializeComponent();
            
           
        }
        string ab = "**                                10  12  29  10  50  31                                 **";
       

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int numbeofrows = Int32.Parse(inputTextbox.Text);
            if(numbeofrows <21 && numbeofrows > 0)
            {
                Errormsg.Text = "";
                TextBoxTickets.Text = "";
                TextBoxTickets.Text = TextBoxTickets.Text + "**************************************\n";
                TextBoxTickets.Text = TextBoxTickets.Text + "**                                  **\n";
                TextBoxTickets.Text = TextBoxTickets.Text + "**           Lotto Ticket           **\n";
                TextBoxTickets.Text = TextBoxTickets.Text + "**                                  **\n";
                TextBoxTickets.Text = TextBoxTickets.Text + "**************************************\n";
                for (int i = 0; i < numbeofrows; i++)
                {
                    
                    ob.GenerateNUmber();
                    ob.BuddleSort();
                    TextBoxTickets.Text = TextBoxTickets.Text + ob.PrintNumbers();
                }
                TextBoxTickets.Text = TextBoxTickets.Text + "**************************************";
            }
            else
            {
                Errormsg.Text = "Enter number between 1 to 20";
            }
            char[] ac = ab.ToCharArray();
            Console.WriteLine(ac.Length);
        }
       

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }

}
