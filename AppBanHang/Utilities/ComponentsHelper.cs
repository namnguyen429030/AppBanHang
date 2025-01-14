using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBanHang.Utilities
{
    public static class ComponentsHelper
    {
        public static void SetButtonsCondition(bool status, params Button?[] buttons)
        {
            foreach (var button in buttons)
            {
                if (button != null)
                {
                    button.IsEnabled = status;
                }
            }
        }
    }
}
