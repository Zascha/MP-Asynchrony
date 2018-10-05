using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace MP.Asynchrony.Downloader
{
    public class HttpDownloadManager : IDownloadManager
    {
        public void StartDownloading(DownloadItem downloadItem)
        {
            StartDownloadingAsync(downloadItem).Wait();
        }

        public async Task StartDownloadingAsync(DownloadItem downloadItem)
        {
            if (downloadItem == null)
                throw new ArgumentNullException(nameof(downloadItem));

            if (string.IsNullOrEmpty(downloadItem.Uri) || !IsUriValid(downloadItem.Uri))
                throw new ArgumentException(nameof(downloadItem.Uri));

            if (string.IsNullOrEmpty(downloadItem.OutputPath) || !IsFilePathValid(downloadItem.OutputPath))
                throw new ArgumentException(nameof(downloadItem.OutputPath));

            await Task.Run(() => DownloadFromSource(downloadItem), downloadItem.CancellationTokenSource.Token);
        }

        public Task CancelDownloading(DownloadItem downloadItem)
        {
            if (downloadItem == null)
                throw new ArgumentNullException(nameof(downloadItem));

            downloadItem.CancellationTokenSource.Cancel();

            return Task.CompletedTask;
        }

        #region Private methods

        private bool IsUriValid(string uri)
        {
            return Uri.TryCreate(uri, UriKind.Absolute, out var outUri);
        }

        private bool IsFilePathValid(string outputPath)
        {
            return outputPath.IndexOfAny(Path.GetInvalidPathChars()) == -1;
        }

        private void DownloadFromSource(DownloadItem downloadItem)
        {
            new HttpClient().GetAsync(downloadItem.Uri, downloadItem.CancellationTokenSource.Token)
                            .ContinueWith(response => WriteHttpResponseToFile(response.Result, downloadItem), downloadItem.CancellationTokenSource.Token)
                            .Wait();

        }

        private void WriteHttpResponseToFile(HttpResponseMessage responseMessage, DownloadItem downloadItem)
        {
            responseMessage.EnsureSuccessStatusCode();

            responseMessage.Content.ReadAsStreamAsync()
                                   .ContinueWith(stream => WriteStreamToFile(stream.Result, downloadItem.OutputPath), downloadItem.CancellationTokenSource.Token)
                                   .Wait();
        }

        private void WriteStreamToFile(Stream stream, string outputPath)
        {
            using (var fileStream = File.Create(outputPath))
            {
                stream.CopyTo(fileStream);
            }
        }

        #endregion
    }
}
