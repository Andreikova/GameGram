using GameGram.Models;
using System.Collections.ObjectModel;

namespace GameGram
{
    public partial class MainPage : ContentPage
    {
        private ObservableCollection<Story> _stories;
        private ObservableCollection<Post> _posts;

        public MainPage()
        {
            InitializeComponent();

            // Initialize GameGram static collections
            Models.GameGram.stories = new List<Story>();
            Models.GameGram.posts = new List<Post>();

            // Initialize observable collections for UI
            _stories = new ObservableCollection<Story>();
            _posts = new ObservableCollection<Post>();

            // Set the collection view data sources
            StoriesCollectionView.ItemsSource = _stories;
            PostsCollectionView.ItemsSource = Models.GameGram.posts;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            RefreshCollections();
        }

        private void RefreshCollections()
        {
            // Clear and repopulate stories
            _stories.Clear();
            foreach (var story in Models.GameGram.stories)
            {
                _stories.Add(story);
            }

            // Clear and repopulate posts
            _posts.Clear();
            foreach (var post in Models.GameGram.posts)
            {
                _posts.Add(post);
            }
        }

        private async void OnAddPhotoStoryClicked(object sender, EventArgs e)
        {
            try
            {
                StoryFactory storyFactory = new PhotoStory(string.Empty);
                var content = await storyFactory.CreatePhotoStoryAsync();
                RefreshCollections();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Failed to create photo story: {ex.Message}", "OK");
            }
        }

        private async void OnAddVideoStoryClicked(object sender, EventArgs e)
        {
            try
            {
                StoryFactory storyFactory = new VideoStory(string.Empty);
                var content = await storyFactory.CreateVideoStoryAsync();
                RefreshCollections();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Failed to create video story: {ex.Message}", "OK");
            }
        }

        private async void OnAddPhotoPostClicked(object sender, EventArgs e)
        {
            try
            {
                PostFactory postFactory = new PhotoPost(string.Empty);
                var content = await postFactory.CreatePhotoPostAsync();
                RefreshCollections();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Failed to create photo post: {ex.Message}", "OK");
            }
        }

        private async void OnAddVideoPostClicked(object sender, EventArgs e)
        {
            try
            {
                PostFactory postFactory = new VideoPost(string.Empty);
                var content = await postFactory.CreateVideoPostAsync();
                RefreshCollections();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Failed to create video post: {ex.Message}", "OK");
            }
        }

        private void OnPostLiked(object sender, EventArgs e)
        {
            if (sender is Button button && button.BindingContext is Post post)
            {
                post.isLiked = true;
                RefreshCollections();
            }
        }

        private void OnStoryLiked(object sender, EventArgs e)
        {
            if (sender is Button button && button.BindingContext is Story story)
            {
                story.isLiked = true;
                RefreshCollections();
            }
        }
    }

    // Color converter for likes
    public class BoolToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is bool isLiked && isLiked)
                return Colors.Red;
            return Colors.Transparent;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}