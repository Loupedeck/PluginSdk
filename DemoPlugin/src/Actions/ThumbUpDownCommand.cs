namespace Loupedeck.DemoPlugin
{
    using System;

    // This command toggles between a Thumb Up and Thumb Down image on the button.
    // It demonstrates how to use embedded image resources for button icons.

    public class ThumbUpDownCommand : PluginDynamicCommand
    {
        // Tracks whether the current state is thumb down or thumb up.
        private Boolean _isThumbDown = false;

        // Resource paths for the thumb up and thumb down images.
        private readonly String _imageResourcePathThumbUp;
        private readonly String _imageResourcePathThumbDown;

        // Initializes the command and loads the embedded image resource paths.
        public ThumbUpDownCommand()
            : base(displayName: "Thumb Up/Down", description: "Toggles between thumb up and thumb down", groupName: "Switches")
        {
            // Find the embedded image resources by filename.
            this._imageResourcePathThumbUp = PluginResources.FindFile("ThumbUp.png");
            this._imageResourcePathThumbDown = PluginResources.FindFile("ThumbDown.png");
        }

        // This method is called when the user presses the button.
        protected override void RunCommand(String actionParameter)
        {
            // Toggle the thumb state.
            this._isThumbDown = !this._isThumbDown;

            // Notify the Plugin Service to refresh the button image.
            this.ActionImageChanged();
        }

        // Returns the correct image based on the current thumb state.
        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {
            // Show ThumbDown image when down, ThumbUp image when up.
            var resourcePath = this._isThumbDown ? this._imageResourcePathThumbDown : this._imageResourcePathThumbUp;
            return PluginResources.ReadImage(resourcePath);
        }
    }
}
