using System;
using System.Threading;

namespace MP.Asynchrony.Downloader
{
    public enum DownloadStatus
    {
        Downloading,
        Download,
        Cancelled
    }

    public class DownloadItem : IEquatable<DownloadItem>
    {
        public CancellationTokenSource CancellationTokenSource { get; } = new CancellationTokenSource();

        public string SourseId { get; set; }

        public string Uri { get; set; }

        public string OutputPath { get; set; }

        public DownloadStatus Status { get; set; }

        #region Equality methods

        public override int GetHashCode()
        {
            if (!IsDefault())
            {
                return SourseId.GetHashCode() ^ 31;
            }

            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is DownloadItem))
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            if (GetType() != obj.GetType())
                return false;

            DownloadItem item = (DownloadItem)obj;

            if (item.IsDefault() || IsDefault())
                return false;

            return Equals(item);
        }

        public bool Equals(DownloadItem other)
        {
            return SourseId == other?.SourseId;
        }

        public override string ToString()
        {
            return $"{SourseId} - {Status}";
        }

        #endregion

        #region Private methods

        private bool IsDefault()
        {
            return string.IsNullOrEmpty(SourseId) && 
                   string.IsNullOrEmpty(Uri) && 
                   string.IsNullOrEmpty(OutputPath);
        }

        #endregion
    }
}
