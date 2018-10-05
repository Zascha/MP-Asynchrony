using System.Threading.Tasks;

namespace MP.Asynchrony.Downloader
{
    public interface IDownloadManager
    {
        void StartDownloading(DownloadItem downloadItem);

        Task StartDownloadingAsync(DownloadItem downloadItem);

        Task CancelDownloading(DownloadItem downloadItem);
    }
}
