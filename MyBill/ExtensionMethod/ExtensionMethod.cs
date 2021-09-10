using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Windows.Forms;

public static  class BillExtensionMethod
{
    public static void SelectItemByValue(this ComboBox cbo, string value)
    {
        foreach (ListItem item in cbo.Items)
        {
            if (item.Value == value)
            {
                cbo.SelectedItem = item;
                break;
            }
        }       
    }
}

