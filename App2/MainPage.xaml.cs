using System;
using System.Numerics;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core.Preview;
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

        ///string[] file_survLines = System.IO.File.ReadAllLines(@"SurveyItems.txt");
        ///Receives input of potential survey items from text file

        //Create empty array of possible Survey topics, initializes array with 5 possible options
        public string[] arr_SurvOptions = new string[5];
        private void initArray(string[] survey)
        {
            survey[0] = "Google";
            survey[1] = "Ford";
            survey[2] = "Tesla";
            survey[3] = "Dell";
            survey[4] = "Intel";
        }
        //  Creation and initialization of survey is for testing purposes
        //=====================================================================================

        // Displays a ContentDialog to verify user intends to exit application
        private async void DisplayExitDialog()
        {
            ContentDialog exitDialog = new ContentDialog
            {
                Title = "Exiting Application",
                Content = "Are you sure you want to exit?",
                PrimaryButtonText = "Exit",
                CloseButtonText = "Cancel"
            };

            ContentDialogResult result = await exitDialog.ShowAsync();

            //Exit Application if PrimaryButton is selected
            if (result == ContentDialogResult.Primary)
            {
                Application.Current.Exit();
            }
            else
            //Occurs if user selected the CloseButton, pressed Esc, or System Back Button
            {
                //do nothing
            }
        }
        //===================================================================================

        //Adds survey credit on return to page
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is double && !double.IsNaN((double)e.Parameter))
            {
                balance += ((double)e.Parameter);
                balUpdate();
            }
            base.OnNavigatedTo(e);
        }
        //
        private void OnCloseRequest(object sender, SystemNavigationCloseRequestedPreviewEventArgs e)
        {
            DisplayExitDialog();
        }
        //===================================================================================



        // Updates the balance of the User
        public void balUpdate()
        {
            txt_Balance.Text = "$" + balance.ToString();
        }
        //===================================================================================


        public MainPage()
        {
            //Initialization of Page
            this.InitializeComponent();
            //Restricts capabilities of user to close application for purposes of presenting a warning when user attempts to close application
            SystemNavigationManagerPreview.GetForCurrentView().CloseRequested += this.OnCloseRequest;
            //Enables Caching of content and state values for page until page cache for the frame is exceeded
            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
            //updates the current balance
            balUpdate();

            // Initialization of the array
            initArray(arr_SurvOptions);
        }

        //Btn_Submit is removed, commenting out click method due to being unnecessary
        /*
        private void Btn_Submit_Click(object sender, RoutedEventArgs e)
        {
            surveyCredit = baseCredit * (numAnswered / numQuestions);
            balance += surveyCredit;
            balUpdate();
        }
        */

        private void Btn_Exit_Click(object sender, RoutedEventArgs e)
        {
            DisplayExitDialog();
        }

        private void Btn_Survey_Click(object sender, RoutedEventArgs e)
        {
            // Selects random item from array and submits to pg_Survey
            Random rand = new Random();
            this.Frame.Navigate(typeof(BlankPage1), arr_SurvOptions[rand.Next(arr_SurvOptions.Length + 1)]);
        }
    }
}
