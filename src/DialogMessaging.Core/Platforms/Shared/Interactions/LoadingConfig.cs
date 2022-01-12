using System.Collections.Generic;
using System.ComponentModel;
using DialogMessaging.Interactions.Base;

namespace DialogMessaging.Interactions;

public static partial class LoadingConfigDefaults
{
}

public partial interface ILoadingConfig : IBaseDialogConfig, INotifyPropertyChanged
{
    #region Properties
    /// <summary>
    ///     Gets or sets the progress, if any.
    /// </summary>
    int? Progress { get; set; }
    #endregion
}

public partial class LoadingConfig : BaseDialogConfig, ILoadingConfig
{
    #region Fields
    private int? _progress;
    #endregion

    #region Events
    public event PropertyChangedEventHandler PropertyChanged;
    #endregion

    #region Properties
    /// <summary>
    ///     Gets or sets the progress, if any.
    /// </summary>
    public int? Progress
    {
        get => _progress;

        set
        {
            if (!EqualityComparer<int?>.Default.Equals(_progress, value))
            {
                _progress = value;
                OnPropertyChanged(nameof(Progress));
            }
        }
    }
    #endregion

    #region Protected Methods
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    #endregion
}

public partial class LoadingAsyncConfig : BaseDialogAsyncConfig, ILoadingConfig
{
    #region Fields
    private int? _progress;
    #endregion

    #region Events
    public event PropertyChangedEventHandler PropertyChanged;
    #endregion

    #region Properties
    /// <summary>
    ///     Gets or sets the progress, if any.
    /// </summary>
    public int? Progress
    {
        get => _progress;

        set
        {
            if (!EqualityComparer<int?>.Default.Equals(_progress, value))
            {
                _progress = value;
                OnPropertyChanged(nameof(Progress));
            }
        }
    }
    #endregion

    #region Protected Methods
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    #endregion
}