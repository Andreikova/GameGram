using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameGram.Models
{
	interface Story : Content
	{
		public bool isLiked { get; set; }
		public int timer { get; set; }
		public abstract Story makeStory();
	}
}