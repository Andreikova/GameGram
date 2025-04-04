using Microsoft.Maui.Controls;
using Microsoft.Maui.Media;

namespace GameGram.Models
{
    internal abstract class StoryFactory : ContentGenerator
    {
        public string filePath = null;
        public override Content makePhotoContent()
        {
            PhotoStory photoStory = new PhotoStory(filePath);
            GameGram.stories.Add(photoStory);
            return photoStory;

        }

        public override Content makeVideoContent()
        {
            VideoStory videoStory = new VideoStory(filePath);
            GameGram.stories.Add(videoStory);
            return videoStory;
        }

        public async Task<Content> CreatePhotoStoryAsync()
        {
            bool success = await addPhoto();
            if (!success)
            {
                throw new InvalidOperationException("failed to get photo");
            }
            return makePhotoContent();
        }

        public async Task<Content> CreateVideoStoryAsync()
        {
            bool success = await addVideo();
            if (!success)
            {
                throw new InvalidOperationException("failed to get video");
            }
            return makeVideoContent();
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
                        using var stream = await result.OpenReadAsync();
                        var image = ImageSource.FromStream(() => stream);
                    }
                    this.filePath = result.FileName;
                    if (result == null)
                    {
                        return false;
                    }
                    return true;
                }

            }
            catch (Exception)
            {
                //
            }
            return false;
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
                        using var stream = await result.OpenReadAsync();
                        var image = ImageSource.FromStream(() => stream);
                    }
                    this.filePath = result.FileName;
                }
                if (result == null)
                {
                    return false;
                }

                return true;
            }
            catch (Exception)
            {
                //
            }

            return false;
        }

    }
}
