using Chat.Models;

namespace Chat.Data
{
    public interface IChatController
    {
        void AddPost(Post post);

        void AddUser(User user);
    }
}