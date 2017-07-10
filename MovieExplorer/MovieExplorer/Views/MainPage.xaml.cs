using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Syncfusion.SfPullToRefresh.XForms;
using MovieExplorer.ViewModels;

namespace MovieExplorer.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            // SF Pull To Refresh.
            pullToRefresh.Refreshed += PullToRefresh_Refreshed;
            pullToRefresh.Pulling += PullToRefresh_Pulling;
            pullToRefresh.Refreshing += PullToRefresh_Refreshing;
        }

        /// <summary>
        /// Refreshing event is triggered once pointer is released. This event will occur till the IsRefreshing property is set as false.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private async void PullToRefresh_Refreshing(object sender, EventArgs args)
        {
            pullToRefresh.IsRefreshing = true;
            await Task.Delay(2000);

            MainPageViewModel vm = this.BindingContext as MainPageViewModel;

            /// ViewModel Pull To Refresh Method.
            await vm.PullToRefreshAsync();

            pullToRefresh.IsRefreshing = false;
        }

        /// <summary>
        /// Pulling event is triggered whenever you start pulling down on the PullableContent with 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void PullToRefresh_Pulling(object sender, PullingEventArgs args)
        {
            args.Cancel = false;
            var prog = args.Progress;
        }

        /// <summary>
        /// Refreshed event is triggered once the Refreshing event is completed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void PullToRefresh_Refreshed(object sender, EventArgs args)
        {
            pullToRefresh.IsRefreshing = false;
        }
    }
}
