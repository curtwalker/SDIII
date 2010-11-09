using System;
using System.Text;
using System.Collections.Generic;

namespace Part1CDCollection
{   [Serializable]
	public class Track //: IComparable<Track>
	{
        //TrackNumber, TrackName
        private SortedList<int, string> _tracks;

        public Track()
        {
            _tracks = new SortedList<int, string>();
        }

        //Override the ToString() method
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<int, string> pair in _tracks)
            {
            sb.Append(pair.Key);
            sb.Append(". ");
            sb.Append(pair.Value);
            sb.AppendLine();
            }
            return sb.ToString();
        }

        public bool AddTrack(int trackNumber, string trackName)
        {
            _tracks.Add(trackNumber, trackName);
            return true;
        }
	}
}

