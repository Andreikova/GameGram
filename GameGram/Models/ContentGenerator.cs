using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameGram.Models
{
    internal abstract class ContentGenerator
    {
        public abstract PhotoPost makePhotoContent();
        public abstract VideoPost makeVideoContent();

    }
}
