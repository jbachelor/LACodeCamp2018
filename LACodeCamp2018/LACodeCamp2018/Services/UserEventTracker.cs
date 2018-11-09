using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prism.Events;

namespace LACodeCamp2018.Services
{
    public class UserEventTracker : IUserEventTracker
    {
        IEventAggregator _eventAggregator;
        Dictionary<DateTime, string> _trackedEventsDict;

        public UserEventTracker(IEventAggregator eventAggregator)
        {
            Console.WriteLine($"{this.GetType().Name}:  ctor");
            _trackedEventsDict = new Dictionary<DateTime, string>();
            _eventAggregator = eventAggregator;
        }

        public void TrackEvent(string userEvent)
        {
            Console.WriteLine($"{this.GetType().Name}.{nameof(TrackEvent)}:  {userEvent}");
            _trackedEventsDict.Add(DateTime.Now, userEvent);
        }

        public Dictionary<DateTime, string> GetEvents()
        {
            Console.WriteLine($"{this.GetType().Name}.{nameof(GetEvents)}");
            return _trackedEventsDict;
        }

        public KeyValuePair<DateTime, string> GetLastEvent()
        {
            Console.WriteLine($"{this.GetType().Name}.{nameof(GetLastEvent)}");
            return _trackedEventsDict.LastOrDefault();
        }
    }
}
