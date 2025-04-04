namespace GameGram.Models
{
    internal abstract class StoryFactory : ContentGenerator
    {
        public string filePath { get; set; }
        public override Content makePhotoContent()
        {
            GameGram.stories.Add(new PhotoStory(filePath));

            return new PhotoStory(filePath);
        }

        public override Content makeVideoContent()
        {
            //TODO: use mediapicker and implement
            return null;
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
