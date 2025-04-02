using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameGram.Models
{
    internal abstract class PostFactory : ContentGenerator
    {
        public override PhotoPost makePhotoContent()
        {

            //TODO: use mediapicker and implement
            return null;
        }

        public override VideoPost makeVideoContent()
        {
            //TODO: use mediapicker and implement
            return null;
        }
    }
}
