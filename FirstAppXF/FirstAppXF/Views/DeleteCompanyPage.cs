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
	public class DeleteCompanyPage : ContentPage
	{
        private ListView listView;
        private Button button;

        Company company = new Company();
        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");

        public DeleteCompanyPage ()
		{
            this.Title = "Delete Company";
            var db = new SQLiteConnection(_dbPath);
            StackLayout stackLayout = new StackLayout();

            listView = new ListView();
            listView.ItemsSource = db.Table<Company>().OrderBy(x => x.Name).ToList();            
            listView.ItemSelected += ListView_ItemSelected;
            stackLayout.Children.Add(listView);

            button = new Button();
            button.Text = "Delete";
            button.Clicked += Button_Clicked;
            stackLayout.Children.Add(button);

            Content = stackLayout;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            
            bool msj = await DisplayAlert("Warning", "Delete the record? ", "Ok", "Cancel");
            if (msj == true)
            {
                db.Table<Company>().Delete(x => x.Id == company.Id);
                await DisplayAlert("Delete", "Successfully", "Ok");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Warning", "Cancelled", "Ok");
            }            
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            company = (Company)e.SelectedItem;            
        }
    }
}