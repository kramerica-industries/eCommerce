using System;
using System.Collections.Generic;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Seo;

namespace Nop.Core.Domain.Blogs
{
    /// <summary>
    /// Represents a blog post
    /// </summary>
    public partial class BlogPost : BaseEntity, ISlugSupported
    {
        private ICollection<BlogComment> _blogComments;

        /// <summary>
        /// Gets or sets the language identifier
        /// </summary>
        public int LanguageId { get; set; }

        /// <summary>
        /// Gets or sets the blog post title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the blog post title
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the blog post comments are allowed 
        /// </summary>
        public bool AllowComments { get; set; }

        /// <summary>
        /// Gets or sets the total number of approved comments
        /// <remarks>The same as if we run newsItem.NewsComments.Where(n => n.IsApproved).Count()
        /// We use this property for performance optimization (no SQL command executed)
        /// </remarks>
        /// </summary>
        public int ApprovedCommentCount { get; set; }
        /// <summary>
        /// Gets or sets the total number of not approved comments
        /// <remarks>The same as if we run newsItem.NewsComments.Where(n => !n.IsApproved).Count()
        /// We use this property for performance optimization (no SQL command executed)
        /// </remarks>
        /// </summary>
        public int NotApprovedCommentCount { get; set; }

        /// <summary>
        /// Gets or sets the blog tags
        /// </summary>
        public string Tags { get; set; }

        /// <summary>
        /// Gets or sets the blog post start date and time
        /// </summary>
        public DateTime? StartDateUtc { get; set; }

        /// <summary>
        /// Gets or sets the blog post end date and time
        /// </summary>
        public DateTime? EndDateUtc { get; set; }

        /// <summary>
        /// Gets or sets the date and time of entity creation
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the blog comments
        /// </summary>
        public virtual ICollection<BlogComment> BlogComments
        {
            get { return _blogComments ?? (_blogComments = new List<BlogComment>()); }
            protected set { _blogComments = value; }
        }
        
        /// <summary>
        /// Gets or sets the language
        /// </summary>
        public virtual Language Language { get; set; }
    }
}