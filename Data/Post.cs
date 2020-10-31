using Markdig;
using System;

namespace Golb.Data
{
    public class Post
    {
        private const int PREVIEW_LENGTH = 512;

        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime PostedAt { get; set; }

        public string Snippet
        {
            get
            {
                return (this.Body.Length <= PREVIEW_LENGTH) ? this.Body : this.Body.Substring(0, PREVIEW_LENGTH) + "...";
            }
        }

        public string MarkupString {
            get
            {
                return this.Body == null ? "" : Markdown.ToHtml(this.Body);
            }
        }
    }
}