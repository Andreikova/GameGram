using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameGram.Models
{
    internal class PhotoStory : StoryFactory, Story
    {
        private const int STORY_UPTIME_DAY = 86400;
        private bool _isLiked = false;
        public string pathToFile = "";
        private int _timer;
        public PhotoStory(string pathToFile)
        {
            if (pathToFile != null)
            { 
                this.pathToFile = pathToFile;
            }
            else
            {
               throw new ArgumentException("Invalid file path");
            }

            this._timer = STORY_UPTIME_DAY;
        }


        //Inverts the boolean on a set call 
        bool Story.isLiked
        {
            get => this._isLiked;
            set
            {
                _isLiked = !_isLiked;
            }
        }
        public int timer { get => _timer; set => _timer = value; }


        public Story makeStory()
        {
            return this;
        }

    }
}