using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameGram.Models
{
    internal abstract class PostFactory : ContentGenerator
    {
        public override Content makePhotoContent()
        {

            //TODO: use mediapicker and implement
            return null;
        }

        public override Content makeVideoContent()
        {
            //TODO: use mediapicker and implement
            return null;
        }
    }
}
