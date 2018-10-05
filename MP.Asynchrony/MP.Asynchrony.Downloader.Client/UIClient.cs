using MP.Asynchrony.Common;
using MP.Asynchrony.Common.InputManagers;
using MP.Asynchrony.Common.OutputManagers;
using MP.Asynchrony.Common.SafeExecuteManagers;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MP.Asynchrony.Downloader.Client
{
    public partial class UIClient : Form
    {
        private WinFormOutputManager _outputManager;
        private WinFormInputManager _inputManager;
        private ISafeExecuteManager _safeExecuteManager;
        private IDownloadManager _downloadManager;

        public UIClient()
        {
            InitializeComponent();

            _inputManager = new WinFormInputManager();
            _outputManager = new WinFormOutputManager { OutSource = errorLabel };
            _safeExecuteManager = new SafeExecuteManager(_outputManager);
            _downloadManager = new HttpDownloadManager();
        }

        private void downloadButton_Click(object sender, EventArgs e)
        {
            // 1) Get uri
            var uri = GetStringFromUI(uriTextBox);

            if (string.IsNullOrEmpty(uri))
            {
                _outputManager.DisplayMessage("Uri is not set");
                return;
            }

            // 2) Get filePath
            var fileName = GetStringFromUI(filePathTextBox);

            if (string.IsNullOrEmpty(fileName))
            {
                _outputManager.DisplayMessage("File name is not set");
                return;
            }

            try
            {
                var downloadItem = new DownloadItem
                {
                    SourseId = fileName,
                    Uri = uri,
                    OutputPath = FileSystemHelper.FormOutputDownloadPath(fileName)
                };

                itemsSource.Add(downloadItem);

                _safeExecuteManager.ExecuteWithExceptionHandling(() =>
                {
                    _downloadManager.StartDownloadingAsync(downloadItem)
                                    .ContinueWith(prev => FormListBoxDownloadCompletedString(downloadItem), 
                                                  new CancellationTokenSource().Token,
                                                  TaskContinuationOptions.NotOnCanceled | TaskContinuationOptions.NotOnFaulted,
                                                  TaskScheduler.FromCurrentSynchronizationContext());
                });
            }
            catch(Exception exception)
            {
                _outputManager.DisplayMessage(exception.Message);
            }
            
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            var downloadItem = (DownloadItem)downloadingFileslistBox.SelectedItem;

            if(downloadItem == null)
            {
                return;
            }

            _safeExecuteManager.ExecuteWithExceptionHandling(() =>
            {
                _downloadManager.CancelDownloading(downloadItem)
                                .ContinueWith(prev => FormListBoxDownloadCancelledString(downloadItem), TaskScheduler.FromCurrentSynchronizationContext());
            });
        }


        #region Private methods

        private string GetStringFromUI(TextBox source)
        {
            _inputManager.Source = source;
            return _inputManager.GetInputStringValue();
        }

        private void FormListBoxDownloadCompletedString(DownloadItem item)
        {
            item.Status = DownloadStatus.Download;
            UpdateInListBox(item);
        }

        private void FormListBoxDownloadCancelledString(DownloadItem item)
        {
            item.Status = DownloadStatus.Cancelled;
            UpdateInListBox(item);
        }

        private void UpdateInListBox(DownloadItem item)
        {
            var itemToUpdate = itemsSource.Cast<DownloadItem>().SingleOrDefault(i => i.Equals(item));

            if (itemToUpdate != null)
            {
                itemToUpdate = item;
            }

            downloadingFileslistBox.DataSource = null;
            downloadingFileslistBox.Items.Clear();
            downloadingFileslistBox.DataSource = itemsSource;
        }

        #endregion
    }
}
