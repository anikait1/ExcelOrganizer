using ATL;
using ClosedXML.Excel;
using System;
using System.IO;

namespace MusicExcelOrganizer.Models
{
    /// <summary>
    /// Stores information about each song track. Information is constructed
    /// using available Tags and File Metadata.
    /// </summary>
    public class AudioFile : IExcelSerializer
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

        public AudioFile(Track track, FileInfo fileInfo)
        {
            Title = string.IsNullOrWhiteSpace(track.Title) ? fileInfo.Name : track.Title;
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

        public void WriteToExcelRow(IXLWorksheet worksheet, int row)
        {
            worksheet.Cell(row, 1).Value = Name;
            worksheet.Cell(row, 2).Value = Title;
            worksheet.Cell(row, 3).Value = ContributingArtists;
            worksheet.Cell(row, 4).Value = Year;

            worksheet.Cell(row, 5).Value = Genre;
            worksheet.Cell(row, 6).Value = Album;
            worksheet.Cell(row, 7).Value = Path;
            worksheet.Cell(row, 8).Value = AlbumArtists;

            worksheet.Cell(row, 9).Value = DateModified;
            worksheet.Cell(row, 10).Value = Length;
            worksheet.Cell(row, 11).Value = Type;
            worksheet.Cell(row, 12).Value = Composers;
        }
    }
}
