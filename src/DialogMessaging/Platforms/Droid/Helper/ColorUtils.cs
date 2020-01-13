using Android.Graphics;
using DialogMessaging.Infrastructure;
using System;

namespace DialogMessaging.Platforms.Droid.Helper
{
    public static class ColorUtils
    {
        #region Public Methods
        /// <summary>
        /// Tries to parse a hex color to an Android.Graphics.Color.
        /// </summary>
        /// <param name="hexColor">The color in hex format.</param>
        public static Color? TryParseColor(string hexColor)
        {
            try
            {
                return Color.ParseColor(hexColor);
            }
            catch (Exception e)
            {
                Log.Error("Parse Color", $"Could not parse color. Make sure it is in the correct format: #RRGGBB.\n{e.ToString()}");
                return null;
            }
        }
        #endregion
    }
}
