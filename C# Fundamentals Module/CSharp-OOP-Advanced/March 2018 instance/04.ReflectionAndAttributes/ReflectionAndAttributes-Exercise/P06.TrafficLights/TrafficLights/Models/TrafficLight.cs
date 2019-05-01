namespace TrafficLights.Models
{
    using System;
    using TrafficLights.Models.Enums;

    public class TrafficLight
    {
        public TrafficLight(string signal)
        {
            this.Signal = this.ParseSignal(signal);
        }

        public Signal Signal { get; private set; }

        public void ChangeSignal()
        {
            var signalsCount = Signal.GetValues(typeof(Signal)).Length;

            var newValue = ((int)this.Signal + 1) % signalsCount;

            this.Signal = (Signal)newValue;
        }

        private Signal ParseSignal(string signal)
        {
            Signal parsed;
            if (!Enum.TryParse<Signal>(signal, out parsed))
            {
                throw new ArgumentException("Invalid type of signal");
            }

            return parsed;
        }

        public override string ToString() => this.Signal.ToString();
    }
}
