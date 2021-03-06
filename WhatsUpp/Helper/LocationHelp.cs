using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsUpp.Helper
{
	public class LocationHelp
	{
        GeoCoordinateWatcher watcher;

        public void GetLocationEvent()
        {
            this.watcher = new GeoCoordinateWatcher();
            bool started = this.watcher.TryStart(false, TimeSpan.FromMilliseconds(1000));

            this.watcher.PositionChanged += new EventHandler<GeoPositionChangedEventArgs<GeoCoordinate>>(watcher_PositionChanged);

            if (!started)
            {
                Console.WriteLine("GeoCoordinateWatcher timed out on start.");
            }
        }

        public void watcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            ClassHelp.CurrentLocation[0] = e.Position.Location.Latitude;
            ClassHelp.CurrentLocation[1] = e.Position.Location.Longitude;
        }
    }
}
