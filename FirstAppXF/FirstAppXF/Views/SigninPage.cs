using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace FirstAppXF.Views
{
	public class SigninPage : ContentPage
	{
        private Label headerLabel;
        private Entry emailEntry;
        private Entry passwordEntry;
        private Button singinButton;

		public SigninPage ()
		{
            StackLayout stackLayout = new StackLayout();

            headerLabel = new Label();
            headerLabel.Text = "Signin Page";
            headerLabel.FontAttributes = FontAttributes.Bold;
            headerLabel.Margin = new Thickness(10, 10);
            headerLabel.HorizontalOptions = LayoutOptions.StartAndExpand;
            stackLayout.Children.Add(headerLabel);

            emailEntry = new Entry();
            emailEntry.Keyboard = Keyboard.Email;
            emailEntry.Placeholder = "Email ID";
            emailEntry.Text = "jmph81@gmail.com";
            stackLayout.Children.Add(emailEntry);

            passwordEntry = new Entry();
            passwordEntry.Keyboard = Keyboard.Text;
            passwordEntry.Placeholder = "Password";
            passwordEntry.Text = "1234";
            passwordEntry.IsPassword = true;
            stackLayout.Children.Add(passwordEntry);

            singinButton = new Button();
            singinButton.Text = "Sign in";
            singinButton.Clicked += singinButton_Clicked;
            stackLayout.Children.Add(singinButton);

            Content = stackLayout;
        }

        private async void singinButton_Clicked(object sender, EventArgs e)
        {
            string email = emailEntry.Text;
            string password = passwordEntry.Text;

            if (email=="jmph81@gmail.com" && password=="1234")
            {
                await Navigation.PushAsync(new MainPage());
            }
            else
            {
                await DisplayAlert("Alert", "Error in Id or Password", "Accept");
            }
        }
    }
}