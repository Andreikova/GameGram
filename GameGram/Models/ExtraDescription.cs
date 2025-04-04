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
        public required string descriptionToAdd;

        public override ExtraDescription descriptionAdder(Post post, string descriptionToAdd)
        {
            this.wrappee = post;
            this.descriptionToAdd = descriptionToAdd;
            return this;
        }
    }
}
