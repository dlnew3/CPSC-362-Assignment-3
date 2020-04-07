using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App2
{
    
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public double balance = 0.00;
        
        public int numQuestions;
        public int numAnswered;
        public double surveyCredit;

        public int surveyIndex;
        public double baseCredit;

        public void balUpdate()
        {
            txt_Balance.Text = "$" + balance.ToString();
        }


        public MainPage()
        {
            this.InitializeComponent();
            balUpdate();
        }

        private void Btn_Submit_Click(object sender, RoutedEventArgs e)
        {
            surveyCredit = baseCredit * (numAnswered / numQuestions);
            balance += surveyCredit;
            balUpdate();
        }

        private void Btm_Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }
    }
}
