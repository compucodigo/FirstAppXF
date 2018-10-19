using FirstAppXF.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace FirstAppXF.Views
{
	public class EditCompanyPage : ContentPage
	{
        private ListView listView;
        private Entry idEntry;
        private Entry nameEntry;
        private Entry addressEntry;
        private Button button;

        Company company = new Company();
        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");

        public EditCompanyPage ()
		{
            this.Title = "Edit Company";
            var db = new SQLiteConnection(_dbPath);
            StackLayout stackLayout = new StackLayout();

            listView = new ListView();
            listView.ItemsSource = db.Table<Company>().OrderBy(x => x.Name).ToList();
            listView.ItemSelected += ListView_ItemSelected;
            stackLayout.Children.Add(listView);

            idEntry = new Entry();
            idEntry.Placeholder = "ID";
            idEntry.IsVisible = false;
            stackLayout.Children.Add(idEntry);

            nameEntry = new Entry();
            nameEntry.Keyboard = Keyboard.Text;
            nameEntry.Placeholder = "Company Name";            
            stackLayout.Children.Add(nameEntry);

            addressEntry = new Entry();
            addressEntry.Keyboard = Keyboard.Text;
            addressEntry.Placeholder = "Address";
            stackLayout.Children.Add(addressEntry);

            button = new Button();
            button.Text = "Update";
            button.Clicked += Button_Clicked;
            stackLayout.Children.Add(button);

            Content = stackLayout;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            Company company = new Company()
            {
                Id = Convert.ToInt32(idEntry.Text),
                Name = nameEntry.Text,
                Address = addressEntry.Text
            };
            db.Update(company);
            await DisplayAlert("Update", "Successfully", "Ok");
            await Navigation.PopAsync();
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            company = (Company)e.SelectedItem;
            idEntry.Text = company.Id.ToString();
            nameEntry.Text = company.Name;
            addressEntry.Text = company.Address;
        }
    }
}