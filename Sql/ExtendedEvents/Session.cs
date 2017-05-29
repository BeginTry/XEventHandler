using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XEventHandler.Sql.ExtendedEvents
{
    public class Session
    {
        string name;
        List<string> targets;
        List<string> selectedEvents;
        bool isStarted;

        public override string ToString()
        {
            return this.name;
        }

        /// <summary>
        /// Name of the Extended Event session.
        /// </summary>
        public string Name
        {
            get { return name; }
        }

        public List<string> Targets
        {
            get { return targets; }
        }

        /// <summary>
        /// Events selected for capture by the Extended Event session.
        /// </summary>
        public List<string> SelectedEvents
        {
            get { return selectedEvents; }
        }

        public bool Started
        {
            get { return isStarted; }
        }

        public Session(string sessionName, List<string>sessionTargets, 
            List<string>sessionSelectedEvents, bool sessionStarted)
        {
            name = sessionName;
            targets = sessionTargets;
            selectedEvents = sessionSelectedEvents;
            isStarted = sessionStarted;
        }
    }
}
