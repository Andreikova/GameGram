using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameGram.Models
{
    abstract class DescriptionAdder
    {
        public abstract DescriptionAdder descriptionAdder(Post post, string descriptionToAdd);
    }
}