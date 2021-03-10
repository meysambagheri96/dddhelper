using System;

namespace Domain
{
    public class Event
    {
        private string _eventName;

        public DateTime Timestamp { get; set; }
        public virtual string EventName
        {
            get
            {
                if (string.IsNullOrEmpty(_eventName))
                {
                    _eventName = this.GetType().FullName;
                }

                return _eventName;
            }
            set
            {
                // used when deserializing to `Domain.Event`
                _eventName = value;
            }
        }
        public virtual bool MustPropagate { get; set; }
        public int Version { get; set; }
        public object EventMetadata { get; set; }
    }
}
