
using System.Diagnostics;
using System.Reflection.Metadata;

namespace TabbedPageWithIcon
{
    public partial class App : Application
    {
        //public App()
        //{
        //    InitializeComponent();

        //    MainPage = new AppShell();
        //}
        public App()
        {
            MainPage = new MainTabbedPage();
        }
    }
    public class MainTabbedPage : TabbedPage
    {
        public MainTabbedPage()
        {
            var tabPage1 = new ContentPage
            {
                Title = "Tab Page 1",
                IconImageSource = "ic_action_new.png",
                Content = new StackLayout
                {
                    Children = { new Label { Text = "Welcome to Tab Page 1", HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center } }
                }
            };

            var tabPage2 = new ContentPage
            {
                Title = "Tab Page 2",
                IconImageSource = "ic_incident.png",
                Content = new StackLayout
                {
                    Children = { new Label { Text = "Tab Page 2", HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center } }
                }
            };

            var tabPage3 = new ContentPage
            {
                Title = "Tab Page 3",
                IconImageSource = "ic_inspection.png",
                Content = new StackLayout
                {
                    Children = { new Label { Text = "Tab Page 3", HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center } }
                }
            };

            Children.Add(tabPage1);
            Children.Add(tabPage2);
            Children.Add(tabPage3);
            BarBackgroundColor = Color.FromArgb("#2E7D32");

            CurrentPageChanged += MainTabbedPage_CurrentPageChanged;
        }

        private void MainTabbedPage_CurrentPageChanged(object? sender, EventArgs e)
        {
            ChangeTabColor();
        }

        private void ChangeTabColor()
        {
            if (CurrentPage != null)
            {
                // change color selected tab
                for (int i = 0; i < Children.Count; i++)
                {
                    if (Children[i] == CurrentPage)
                    {
                        if (0 == i)
                            BarBackgroundColor = Color.FromArgb("#2E7D32");
                        else if(1 == i)
                            BarBackgroundColor = Color.FromArgb("#ff9933");
                        else if (2 == i)
                            BarBackgroundColor = Color.FromArgb("#1565C0");

                    }
                }
            }
        }
        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            string currentPage = CurrentPage.Title;
            Debug.WriteLine("\nTab Page changed: " + currentPage);
        }
    }
}
