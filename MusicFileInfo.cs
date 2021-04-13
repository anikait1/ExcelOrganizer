using System;
using System.IO;

namespace MusicExcelOrganizer
{
    /// <summary>
    /// Stores information about each song track. Information is constructed
    /// using available Tags and File Metadata.
    /// </summary>
    class MusicFileInfo
    {
        #region Song Information 
        public string Title { get; set; }
        public string Album { get; set; }
        public string Genre { get; set; }
        public uint Year { get; set; }
        public TimeSpan Length { get; set; }
        #endregion

        #region Artist Information
        public string ContributingArtists { get; set; }
        public string AlbumArtists { get; set; }
        public string Composers { get; set; }
        #endregion

        #region File Information
        public string Name { get; set; }
        public string Path { get; set; }
        public string Type { get; set; }
        public DateTime DateModified { get; set; }
        #endregion

        public MusicFileInfo(TagLib.File tfile, FileInfo fileInfo)
        {
            Title = tfile.Tag.Title;
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
