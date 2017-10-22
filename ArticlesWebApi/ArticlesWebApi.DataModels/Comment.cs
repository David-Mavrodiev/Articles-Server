using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArticlesWebApi.DataModels
{
    public class Comment
    {
        public Comment()
        {
            this.DateCreated = DateTime.Now;
            this.DateModified = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Content { get; set; }

        public string OwnerId { get; set; }

        [ForeignKey("OwnerId")]
        public virtual User Owner { get; set; }

        public Guid ArticleId { get; set; }

        [ForeignKey("ArticleId")]
        public virtual Article Article {get;set;}

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }
    }
}
