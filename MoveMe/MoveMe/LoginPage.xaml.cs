using MoveMe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoveMe
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
		}

        private void LoginButton_Clicked(object sender, EventArgs e)
        {
            string emailAddress = email.Text;
            string pass = password.Text;

            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                var user = conn.Table<User>().Where(x => x.email == emailAddress && x.password == pass).FirstOrDefault();

                if (user != null)
                {
                    DisplayAlert("Success", "User Login Success", "Great");
                    Navigation.PushAsync(new CompanyListPage());
                }
                else
                {
                    var company = conn.Table<Company>().Where(x => x.email == emailAddress && x.password == pass).FirstOrDefault();
                    if (company != null)
                    {
                        DisplayAlert("Success", "Company Login Success", "Great");
                        Navigation.PushAsync(new MainPage());
                    }
                    else
                    {
                        DisplayAlert("Sorry", "Invalid Credentials", "OK");
                        email.Text = "";
                        password.Text = "";
                    }

                }
            }
        }
    }
}