using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Xamarin.Plugin.Calendar.Shared.Models
{
    public class DayEventCollection
    {
        #region Properties
        public Color EventIndicatorColor { get; set; }
        public Color EventIndicatorSelectedColor { get; set; }
        public ICollection DayEvents { get; set; }
        #endregion
    }
}
