/*
 * LICENSE: https://github.com/BeginTry/XEventHandler/blob/master/LICENSE
 * GitHub repository: https://github.com/BeginTry/XEventHandler
*/
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.XEvent.Linq;

namespace XEventHandler
{
    class XEventReader
    {
        /// <summary>
        /// Subset of events to be handled.
        /// </summary>
        List<string> eventsHandled;
        ResponseOptions responseOpts;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventsHandled">Subset of events to be handled.</param>
        /// <param name="resOpts">Indicates one or more responses to an event.</param>
        internal XEventReader(List<string> eventsHandled, ResponseOptions resOpts)
        {
            this.eventsHandled = eventsHandled;
            responseOpts = resOpts;
        }

        /// <summary>
        /// https://stackoverflow.com/questions/661561/how-to-update-the-gui-from-another-thread-in-c
        /// </summary>
        /// <param name="progress"></param>
        /// <param name="SessionName"></param>
        /// <param name="sqlCSB"></param>
        public void ReadEventStream(IProgress<string> progress, string SessionName,
            SqlConnectionStringBuilder sqlCSB)
        {
            cancelProcessing = false;

            using (QueryableXEventData xEvents = new QueryableXEventData(
                sqlCSB.ConnectionString,
                SessionName,
                EventStreamSourceOptions.EventStream,
                EventStreamCacheOptions.DoNotCache))
            {
                foreach (PublishedEvent xEvent in xEvents)
                {
                    if (cancelProcessing)
                    {
                        //progress.Report("xEvents.Dispose();" + Environment.NewLine);
                        xEvents.Dispose();
                        break;
                    }
                    else
                    {
                        if (eventsHandled.Contains(xEvent.Name))
                        { 
                            progress.Report(xEvent.Name);
                            responseOpts.Respond(xEvent);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void CancelProcessing()
        {
            cancelProcessing = true;
        }

        private bool cancelProcessing = false;

        
    }
}
