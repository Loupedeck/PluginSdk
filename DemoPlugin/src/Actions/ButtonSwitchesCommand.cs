namespace Loupedeck.DemoPlugin
{
    using System;

    // This command creates multiple toggle switches assigned to buttons.
    // Each switch independently tracks its own on/off state.

    public class ButtonSwitchesCommand : PluginDynamicCommand
    {
        // Total number of switches available.
        private const Int32 NumberOfSwitches = 4;

        // Array to store the on/off state of each switch.
        private readonly Boolean[] _switches = new Boolean[NumberOfSwitches];

        // Initializes the command and adds a parameter for each switch.
        public ButtonSwitchesCommand() : base()
        {
            for (var i = 0; i < NumberOfSwitches; i++)
            {
                // Each switch uses its index as the action parameter.
                var actionParameter = i.ToString();

                // Register each switch as a separate button in the "Switches" group.
                this.AddParameter(actionParameter, $"Switch {i}", "Switches");
            }
        }

        // This method is called when the user presses a switch button.
        protected override void RunCommand(String actionParameter)
        {
            if (Int32.TryParse(actionParameter, out var i))
            {
                // Toggle the switch state.
                this._switches[i] = !this._switches[i];

                // Notify the Plugin Service to refresh the button label.
                this.ActionImageChanged(actionParameter);
            }
        }

        // Returns the button label showing the switch index and its current state.
        protected override String GetCommandDisplayName(String actionParameter, PluginImageSize imageSize)
        {
            if (Int32.TryParse(actionParameter, out var i))
            {
                // Show "Switch 0: On" or "Switch 0: Off" based on state.
                return $"Switch {i}: {(this._switches[i] ? "On" : "Off")}";
            }

            return null;
        }
    }
}
