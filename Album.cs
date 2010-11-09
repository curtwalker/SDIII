using System;
using System.Text;
using System.Collections.Generic;

namespace Part1CDCollection
{
    [Serializable]
	public class Album : IComparable<Album>
	{
        //Attributes
        private string _albumName;
        private string _albumArtist;
        private Guid _id;

        //Constructor
		public Album (string albumName, string albumArtist)
		{
            _albumName = albumName;
            _albumArtist = albumArtist;
            _id = Guid.NewGuid();
		}
        
        //Properties
        public string AlbumName
        {
            get 
            { 
                return _albumName;
            }
        }

        public string ArtistName
        {
            get 
            { 
                return _albumArtist; 
            }
        }

        public Guid AlbumId
        {
            get
            {
                return _id;
            }
        }

        //Override the ToString() method
         public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(_albumName);
            sb.Append(" by ");
            sb.Append(_albumArtist);
            sb.AppendLine();
            return sb.ToString();
        }

        //Implement IComparable in order to sort the Albums
         public int CompareTo(Album other)
         {
             return _id.CompareTo(other._id);
         }
    }
}


