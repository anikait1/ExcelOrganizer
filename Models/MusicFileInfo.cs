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
        public uint Year { get; init; }
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

        public MusicFileInfo(TagLib.File tfile, FileInfo fileInfo)
        {
            Title = tfile.Tag.Title ?? fileInfo.Name;
            Album = tfile.Tag.Album;
            Genre = tfile.Tag.JoinedGenres;
            Year = tfile.Tag.Year;
            Length = tfile.Properties.Duration;

            ContributingArtists = tfile.Tag.JoinedPerformers;
            AlbumArtists = tfile.Tag.JoinedAlbumArtists;
            Composers = tfile.Tag.JoinedComposers;

            Name = fileInfo.Name;
            Path = tfile.Name;
            Type = tfile.MimeType;
            DateModified = fileInfo.LastWriteTime;
        }
    }
}
