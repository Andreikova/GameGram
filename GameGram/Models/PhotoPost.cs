using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameGram.Models
{
    internal class PhotoPost : PostFactory, Post
    {
        private string _pathToFile;
        private string _description = "";
        public bool _isLiked;

        public PhotoPost(string pathToFile)
        {
            this.pathToFile = pathToFile;
            this._isLiked = false;
        }

        public PhotoPost(string pathToFile, string description)
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

        public string description { get => this._description; set => description = _description; }
        public bool isLiked { get => this._isLiked; set => this._isLiked = !isLiked; }


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