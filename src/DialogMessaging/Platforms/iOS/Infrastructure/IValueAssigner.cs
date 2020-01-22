namespace DialogMessaging.Infrastructure
{
    public interface IValueAssigner
    {
        #region Public Methods
        /// <summary>
        /// Assigns values to UI elements.
        /// </summary>
        /// <param name="config">The alert configuration.</param>
        void AssignValues(object config);
        #endregion
    }
}
