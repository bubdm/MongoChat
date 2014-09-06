using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Chat.Data;
using Chat.Models;

namespace Chat.WindowClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private User user;
        private IChatController chat;

        public MainWindow(string username)
        {
            InitializeComponent();
            var user = new User
            {
                Name = string.IsNullOrEmpty(username) ? "Guest" : username,
                LoggedTimeFrom = DateTime.Now
            };
            this.user = user;
            this.MsgUser.Content = "Wellcome " + this.user.Name;
            this.InpPost.Focus();
            InitChatController();
        }

        private void InitChatController()
        {
            MongoDbContext dbContext = new MongoDbContext();
            this.chat = new ChatController(dbContext);
        }

        private void SendPostOnClick(object sender, RoutedEventArgs e)
        {
            var postContent = this.InpPost.Text;
            if (string.IsNullOrEmpty(postContent))
            {
                return;
            }

            var postModel = new Post()
            {
                Content = postContent,
                PostOn = DateTime.Now,
                PostedByUser = this.user.Name
            };

            this.InpPost.Text = string.Empty;
            this.chat.AddPost(postModel);
            var formattedDate = postModel.PostOn.ToLocalTime().ToString("dd.MM.yyyy hh:mm:ss");
            string res = string.Format("[{0}] {1}: {2}", formattedDate, postModel.PostedByUser, postModel.Content);
            this.AllPost.Text += (this.AllPost.Text.Length > 0 ? Environment.NewLine : string.Empty) + res;
            this.AllPost.ScrollToEnd();
        }

        private void ShowSessionPostOnClick(object sender, RoutedEventArgs e)
        {

        }

        private void ShowAllPostonClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
