using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameGram.Models
{
    internal class ExtraDescription : DescriptionAdder
    {
        public Post wrappee;
        public string descriptionToAdd;

        public ExtraDescription(string descriptionToAdd, Post wrappee)
        {
            this.wrappee = wrappee;
            this.descriptionToAdd = descriptionToAdd;
        }

        public override ExtraDescription descriptionAdder(Post post)
        {
            return this;
        }
    }
}
