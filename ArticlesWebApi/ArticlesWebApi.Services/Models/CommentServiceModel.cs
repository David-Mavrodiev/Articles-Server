using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticlesWebApi.Services.Models
{
    public class CommentServiceModel
    {
        public Guid Id { get; set; }

        public string Content { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }
    }
}
