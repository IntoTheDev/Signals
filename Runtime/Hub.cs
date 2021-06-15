using System.Collections.Generic;

namespace ToolBox.Signals
{
    public static class Signal<S> where S : struct, ISignal
    {
        private static readonly List<IReceiver<S>> _receivers = new List<IReceiver<S>>(8);

        public static S Last { get; private set; } = default;

        public static void AddListener(IReceiver<S> receiver)
        {
            if (!_receivers.Contains(receiver))
                _receivers.Add(receiver);
        }

        public static void RemoveListener(IReceiver<S> receiver)
        {
            if (_receivers.Contains(receiver))
                _receivers.Remove(receiver);
        }

        public static void Dispatch(in S value)
        {
            Last = value;
            int count = _receivers.Count - 1;

            for (int i = count; i >= 0; i--)
                _receivers[i].Receive(in value);
        }
    }
}
