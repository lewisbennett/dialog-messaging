using System.ComponentModel;

namespace DialogMessaging.Interactions
{
    public partial interface ILoadingConfig : IBaseConfig, INotifyPropertyChanged
    {
        #region Properties
        /// <summary>
        /// Gets or sets the progress.
        /// </summary>
        int? Progress { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        string Title { get; set; }
        #endregion
    }

    public partial class LoadingConfig : BaseConfig, ILoadingConfig
    {
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Fields
        private int? _progress;
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the progress.
        /// </summary>
        public int? Progress
        {
            get => _progress;

            set
            {
                _progress = value;
                OnPropertyChanged(nameof(Progress));
            }
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }
        #endregion

        #region Private Methods
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }

    public partial class LoadingAsyncConfig : BaseAsyncConfig, ILoadingConfig
    {
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Fields
        private int? _progress;
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the progress.
        /// </summary>
        public int? Progress
        {
            get => _progress;

            set
            {
                _progress = value;
                OnPropertyChanged(nameof(Progress));
            }
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }
        #endregion

        #region Private Methods
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
