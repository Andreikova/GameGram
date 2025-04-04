using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameGram.Models
{
    internal class VideoPost : PostFactory, Post
    {
        private string _pathToFile;
        private string _description = "";
        private bool _isLiked;

        public VideoPost(string pathToFile)
        {
            this.pathToFile = pathToFile;
            this._isLiked = false;
        }

        public VideoPost(string pathToFile, string description)
        {
            this.pathToFile = pathToFile;
            this._isLiked = false;
            AddDescription(description);
        }

        public string pathToFile
        {
            get => this._pathToFile;
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    this._pathToFile = value;
                }
            }
        }

        public string description { get => this._description; set => _description = description; }
        public bool isLiked { get => this.isLiked; set => this.isLiked = !isLiked; }

        public void AddDescription(string text)
        {
            this._description += text;
        }

        public Post makePost()
        {
            return this;
        }
    }
}