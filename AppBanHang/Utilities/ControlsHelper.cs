using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBanHang.Utilities
{
    public static class ControlsHelper
    {
        public static void SetCondition(bool status, params Control?[] components)
        {
            foreach (var component in components)
            {
                if (component != null)
                {
                    component.IsEnabled = status;
                }
            }
        }
    }
}
