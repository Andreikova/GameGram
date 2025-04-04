using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameGram.Models
{
    interface Post : Content
    {
        public string description { get; set; }
        public bool isLiked { get; set; }

        public abstract Post makePost();

        public abstract void AddDescription(string text);
    }
}