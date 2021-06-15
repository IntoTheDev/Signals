using System.Collections.Generic;

namespace ToolBox.Signals
{
    public static class Signal<S> where S : struct, ISignal
    {
        private static readonly List<IReceiver<S>> _receivers = new List<IReceiver<S>>(8);
        private static S _last = default;
        private static bool _isSignalWasDispatched = false;

        public static void AddReceiver(IReceiver<S> receiver)
        {
            if (!_receivers.Contains(receiver))
                _receivers.Add(receiver);
        }

        public static void RemoveReceiver(IReceiver<S> receiver)
        {
            if (_receivers.Contains(receiver))
                _receivers.Remove(receiver);
        }

        public static void Dispatch(in S value)
        {
            _last = value;
            _isSignalWasDispatched = true;
            int count = _receivers.Count - 1;

            for (int i = count; i >= 0; i--)
                _receivers[i].Receive(in value);
        }

        public static bool TryGetLast(out S last)
        {
            last = _last;
            return _isSignalWasDispatched;
        }
    }
}
