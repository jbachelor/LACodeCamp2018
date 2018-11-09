using System;
using System.Collections.Generic;

namespace LACodeCamp2018.Services
{
    public interface IUserEventTracker
    {
        Dictionary<DateTime, string> GetEvents();
        KeyValuePair<DateTime, string> GetLastEvent();
        void TrackEvent(string userEvent);
    }
}