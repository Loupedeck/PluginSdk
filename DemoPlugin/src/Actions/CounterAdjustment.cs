namespace Loupedeck.DemoPlugin
{
    using System;

    // This adjustment counts the rotation ticks of a dial/encoder.
    // Rotating right increases the counter, rotating left decreases it.
    // Pressing the dial resets the counter to zero.

    public class CounterAdjustment : PluginDynamicAdjustment
    {
        // Holds the current value of the counter.
        private Int32 _counter = 0;

        // Initializes the adjustment.
        // hasReset: true automatically creates a reset button for this adjustment.
        public CounterAdjustment()
            : base(displayName: "Counter", description: "Counts rotation ticks of the dial", groupName: "Adjustments", hasReset: true)
        {
        }

        // This method is called when the dial is rotated.
        // diff is positive when rotating right, negative when rotating left.
        protected override void ApplyAdjustment(String actionParameter, Int32 diff)
        {
            // Increase or decrease the counter by the number of ticks.
            this._counter += diff;

            // Notify the Plugin Service that the value has changed.
            this.AdjustmentValueChanged();

            PluginLog.Info($"Counter changed by {diff}, new value: {this._counter}");
        }

        // This method is called when the reset button is pressed.
        protected override void RunCommand(String actionParameter)
        {
            // Reset the counter back to zero.
            this._counter = 0;

            // Notify the Plugin Service that the value has changed.
            this.AdjustmentValueChanged();

            PluginLog.Info("Counter reset to 0");
        }

        // Returns the current counter value shown next to the dial.
        protected override String GetAdjustmentValue(String actionParameter) => this._counter.ToString();
    }
}
