using FirstAppXF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace FirstAppXF.Views
{
    public class TestPage : ContentPage
    {
        private Button _button;
        private Picker _picker;
        private Entry _entry;
        public TestPage()
        {
            this.Title = "ComboBox";
            List<Company> companies = new List<Company>();
            companies.Add(new Company() { Id = 1, Name = "Company A" });
            companies.Add(new Company() { Id = 2, Name = "Company B" });
            companies.Add(new Company() { Id = 3, Name = "Company C" });
            companies.Add(new Company() { Id = 4, Name = "Company D" });
            companies.Add(new Company() { Id = 5, Name = "Company E" });

            StackLayout stackLayout = new StackLayout();
            _picker = new Picker();
            _picker.Title = "Select Company";
            _picker.ItemsSource = companies;
            stackLayout.Children.Add(_picker);

            _button = new Button();
            _button.Text = "Add Company";
            _button.Clicked += Button_Clicked;
            stackLayout.Children.Add(_button);

            _entry = new Entry();
            _entry.Keyboard = Keyboard.Text;
            _entry.Placeholder = "Picker Selected Value";
            stackLayout.Children.Add(_entry);

            Content = stackLayout;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            _entry.Text = _picker.SelectedItem.ToString();
        }
    }
}