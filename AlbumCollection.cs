using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Part1CDCollection
{   [Serializable]
	public class AlbumCollection
	{
        //Attributes
        private SortedDictionary<Album, Track> _albums;
        private List<Guid> _idCollection = new List<Guid>();
        private  Stream stream;
        private Album tempAlbum;
        private IFormatter bFormatter;
    
        //Contructor
		public AlbumCollection ()
		{
            _albums = new SortedDictionary<Album, Track>();
		}

        //Methods
        public bool AddAlbum(string albumName, string artistName)
        {
            tempAlbum = new Album(albumName, artistName);
            if (_albums.ContainsKey(tempAlbum))
            {
                return false; 
            }
            else
            {
                _idCollection.Add(tempAlbum.AlbumId);
                _albums.Add(new Album(albumName, artistName),new Track());               
                return true;
            }
        }

        public bool DeleteAlbum(string albumName, string artistName)
        {
            tempAlbum = new Album(albumName, artistName);
            if (_albums.ContainsKey(tempAlbum) )
            {
                _albums.Remove(tempAlbum);
                return true;
            }
            else
            { 
                return false; 
            }
        }

        public bool AddTrack(string albumName, int trackNumber, string trackName)
        {
            bool isTrue = true;
            foreach (KeyValuePair<Album, Track> pair in _albums)
            {
                for (int x = 0; x < _albums.Count - 1; x++)
                {
                    if (pair.Key.AlbumName == albumName && pair.Key.AlbumId != _idCollection[x])
                    {
                        pair.Value.AddTrack(trackNumber, trackName);
                        isTrue = true;
                    }
                    else
                    {
                        isTrue = false;
                    }
                }
            }
            return isTrue;
        }

        public void Save()
        {
            bFormatter = new BinaryFormatter();
            stream = new FileStream("saveFile.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            bFormatter.Serialize(stream, _albums);
            stream.Close();
        }
        
        public void Load()
        { 
            bFormatter = new BinaryFormatter();
            stream = new FileStream("saveFile.bin", FileMode.Open, FileAccess.Read, FileShare.None);
            _albums = (SortedDictionary<Album, Track>)bFormatter.Deserialize(stream);
            stream.Close();
        }

        public void Display()
        {
            foreach (KeyValuePair<Album, Track> pairs in _albums)
            {
                Console.WriteLine(pairs.Key + "" + pairs.Value);
            }

        }

	}
}

