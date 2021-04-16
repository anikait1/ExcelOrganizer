using ATL;
using System;
using System.IO;

namespace MusicExcelOrganizer.Models
{
    /// <summary>
    /// Stores information about each song track. Information is constructed
    /// using available Tags and File Metadata.
    /// </summary>
    public class MusicFileInfo
    {
        #region Song Information 
        public string Title { get; init; }
        public string Album { get; init; }
        public string Genre { get; init; }
        public int Year { get; init; }
        public TimeSpan Length { get; init; }
        #endregion

        #region Artist Information
        public string ContributingArtists { get; init; }
        public string AlbumArtists { get; init; }
        public string Composers { get; init; }
        #endregion

        #region File Information
        public string Name { get; init; }
        public string Path { get; init; }
        public string Type { get; init; }
        public DateTime DateModified { get; init; }
        #endregion

        public MusicFileInfo(Track track, FileInfo fileInfo)
        {
            Title = string.IsNullOrEmpty(track.Title) || string.IsNullOrWhiteSpace(track.Title) ? fileInfo.Name : track.Title;
            Album = track.Album;
            Genre = track.Genre;
            Year = track.Year;
            Length = TimeSpan.FromMilliseconds(track.DurationMs);

            ContributingArtists = track.Artist;
            AlbumArtists = track.AlbumArtist;
            Composers = track.Composer;

            Name = fileInfo.Name;
            Path = fileInfo.FullName;
            Type = track.AudioFormat.Name;
            DateModified = fileInfo.LastWriteTime;
        }
    }
}
