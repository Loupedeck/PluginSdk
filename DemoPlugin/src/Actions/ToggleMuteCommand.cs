namespace Loupedeck.DemoPlugin
{
    using System;
    using System.Runtime.InteropServices;

    // This command toggles the system mute on both macOS and Windows.
    // It is a universal command (no application linked) so it works globally.

    public class ToggleMuteCommand : PluginDynamicCommand
    {
        // Tracks the current mute state to update the button text accordingly.
        private Boolean _isMuted = false;

        // Initializes the command with display name, description, and group.
        public ToggleMuteCommand()
            : base(displayName: "Toggle Mute", description: "Mutes and unmutes system volume", groupName: "Audio")
        {
        }

        // This method is called when the user presses the button assigned to this command.
        protected override void RunCommand(String actionParameter)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                // On macOS, use osascript to toggle the mute state.
                // Reads the current mute state and flips it.
                System.Diagnostics.Process.Start("osascript", "-e \"set volume output muted not (output muted of (get volume settings))\"");
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                // On Windows, use PowerShell to send the VolumeMute key (keycode 173).
                System.Diagnostics.Process.Start("powershell", "-c \"(New-Object -ComObject WScript.Shell).SendKeys([char]173)\"");
            }

            // Flip the mute state and refresh the button label.
            this._isMuted = !this._isMuted;
            this.ActionImageChanged();
        }

        // Returns the button label based on the current mute state.
        protected override String GetCommandDisplayName(String actionParameter, PluginImageSize imageSize)
        {
            // Show "MUTED" when muted, "UNMUTED" when sound is on.
            return this._isMuted ? "Mute" : "Unmute";
        }
    }
}
