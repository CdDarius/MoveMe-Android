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
	public partial class UserRegisterPage : ContentPage
	{
		public UserRegisterPage ()
		{
			InitializeComponent ();
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
            User user = new User()
            {
                firstName = firstName.Text,
                lastName = lastName.Text,
                email = email.Text,
                password = password.Text
            };

            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                conn.CreateTable<User>();
                var numberOfRows = conn.Insert(user);
                if(numberOfRows > 0)
                {
                    DisplayAlert("Success", "User created", "Great");
                    Navigation.PushAsync(new LoginPage());
                } else
                {
                    DisplayAlert("Failure", "User not created", "OK");
                }
            }
        }
    }
}