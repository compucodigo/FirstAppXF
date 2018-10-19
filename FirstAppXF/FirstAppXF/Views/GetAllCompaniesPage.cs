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
	public class GetAllCompaniesPage : ContentPage
	{
        private ListView listView;
        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");

        public GetAllCompaniesPage ()
		{
            this.Title = "Companies";

            var db = new SQLiteConnection(_dbPath);

            StackLayout stackLayout = new StackLayout();

            listView = new ListView();
            listView.ItemsSource = db.Table<Company>().OrderBy(x => x.Name).ToList();
            stackLayout.Children.Add(listView);

            Content = stackLayout;
		}
	}
}