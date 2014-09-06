using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chat.Models;

namespace Chat.Data
{
    public class ChatController :IChatController
    {
        private readonly MongoDbContext dbContext;

        public ChatController(MongoDbContext mongoDbContext)
        {
            this.dbContext = mongoDbContext;
        }

        public void AddPost(Post post)
        {
            this.dbContext.Posts.Insert(post);
        }

        public void AddUser(User user)
        {
            this.dbContext.Posts.Insert(user);
        }
    }
}
