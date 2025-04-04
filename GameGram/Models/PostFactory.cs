using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameGram.Models
{
    internal abstract class PostFactory : ContentGenerator
    {
        public string filePath = null;
        public string description = " ";
        public override Content makePhotoContent()
        {
            PhotoPost photoPost;

            if (description == null)
            {
                photoPost = new PhotoPost(filePath);
                GameGram.posts.Add(photoPost);
            }
            else
            {
                photoPost = new PhotoPost(filePath, description);
                GameGram.posts.Add(photoPost);
            }
            return photoPost;
        }

        public override Content makeVideoContent()
        {
            VideoPost videoPost;

            if (this.description == " ")
            {
                videoPost = new VideoPost(filePath);
                GameGram.posts.Add(videoPost);
            }
            else
            {
                videoPost = new VideoPost(filePath, description);
                GameGram.posts.Add(videoPost);
            }
            return videoPost;
        }

        public async Task<Content> CreatePhotoPostAsync()
        {
            bool success = await addPhoto();
            if (!success)
            {
                throw new InvalidOperationException("failed to get photo");
            }
            return makePhotoContent();
        }

        public async Task<Content> CreatePhotoPostAsync(string description)
        {
            this.description = description;
            bool success = await addPhoto();
            if (!success)
            {
                throw new InvalidOperationException("failed to get photo");
            }
            return makePhotoContent();
        }

        public async Task<Content> CreateVideoPostAsync()
        {
            bool success = await addVideo();
            if (!success)
            {
                throw new InvalidOperationException("failed to get video");
            }
            return makeVideoContent();
        }

        public async Task<bool> addPhoto()
        {
            try
            {
                var result = await MediaPicker.PickPhotoAsync();
                if (result != null)
                {
                    if (result.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) ||
                        result.FileName.EndsWith("png", StringComparison.OrdinalIgnoreCase) ||
                        result.FileName.EndsWith("gif", StringComparison.OrdinalIgnoreCase) ||
                        result.FileName.EndsWith("pdf", StringComparison.OrdinalIgnoreCase) ||
                        result.FileName.EndsWith("svg", StringComparison.OrdinalIgnoreCase))
                    {
                    }
                    this.filePath = result.FileName;
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                //
            }
            return false;
        }

        public async Task<bool> addVideo()
        {
            try
            {
                var result = await MediaPicker.PickVideoAsync();
                if (result != null)
                {
                    if (result.FileName.EndsWith("mp4", StringComparison.OrdinalIgnoreCase) ||
                       result.FileName.EndsWith("wmv", StringComparison.OrdinalIgnoreCase) ||
                       result.FileName.EndsWith("avi", StringComparison.OrdinalIgnoreCase) ||
                       result.FileName.EndsWith("flv", StringComparison.OrdinalIgnoreCase) ||
                       result.FileName.EndsWith("gifv", StringComparison.OrdinalIgnoreCase) ||
                       result.FileName.EndsWith("mp4", StringComparison.OrdinalIgnoreCase) ||
                       result.FileName.EndsWith("svi", StringComparison.OrdinalIgnoreCase))
                    {
                    }
                    this.filePath = result.FileName;
                    return true;
                }
            }
            catch (Exception)
            {
                //
            }
            return false;
        }
    }
}
