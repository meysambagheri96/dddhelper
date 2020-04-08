using System;

namespace Domain
{
    public abstract class Event
    {
        public DateTime Timestamp { get; set; }
        public virtual string EventName => GetType().FullName;
        public virtual bool MustPropagate { get; set; }
        public int Version { get; set; }
        public object EventMetadata { get; set; }
    }
}
