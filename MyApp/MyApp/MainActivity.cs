using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;

namespace MyApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            var txtUser = FindViewById<EditText>(Resource.Id.txtUser);
            var btnSearch = FindViewById<Button>(Resource.Id.btnSearch);
            var lvwRepositories = FindViewById<ListView>(Resource.Id.lvwRepositories);

            btnSearch.Click += async (object sender, System.EventArgs e) => {
                var github = new Shared.GitHubApi();
                var repositories = await github.GetAsync(txtUser.Text);
                lvwRepositories.Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItemSingleChoice, repositories);
            };
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}