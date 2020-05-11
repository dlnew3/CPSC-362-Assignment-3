using System;
using System.Numerics;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace App2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    
    public sealed partial class BlankPage1 : Page
    {
        //Initializes the textbox txt_Survey with a relevant survey item to gather info related to the item
        public void loadSurvey(string surveyItem)
        {
            txt_SurveyItem.Text = surveyItem;
        }
        //============================================================================

        //Error Content Dialog created from the 'else' statement in OnNavigatedTo
        private async void DisplayErrorDialog()
        {
            ContentDialog errorDialog = new ContentDialog
            {
                Title = "No Surveys found!",
                Content = "There are no available surveys at this time. Please try again later.",
                PrimaryButtonText = "OK"
            };

            ContentDialogResult result = await errorDialog.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                this.Frame.Navigate(typeof(MainPage));
            }
        }
        //============================================================================

        //When pg_Survey is navigated to; attempts to receive a string array from MainPage
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is string && e.Parameter != null){
                loadSurvey(e.Parameter.ToString());
            }
            else    //else statement occurs if a string array was not sent to the pg_Survey page
            {
                DisplayErrorDialog();
            }
            base.OnNavigatedTo(e);
        }
        //=============================================================================

        // Calculates the rewards amount to return to the MainPage
        private double calcRewards()
        {
            double output = 0;
            //rewards is increased by 24c per rating entered.
            if(rtg_Survey1.Value > -1)
            {
                output += .24;
            }
            if(rtg_Survey2.Value > -1)
            {
                output += .24;
            }
            return output;
        }
        //=============================================================================

        public BlankPage1()
        {
            this.InitializeComponent();
        }


        private void Btn_Return_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void Btn_submit_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage), calcRewards());
        }
    }


}
