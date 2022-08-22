using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using UserControlsClassLibrary2.Common;
using System.Collections.ObjectModel;


// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace UserControlsClassLibrary2
{
    public sealed partial class LSNavView : UserControl
    {
        public ObservableCollection<CategoryBase> Categories { get; set; }
        public LSNavView()
        {
            this.InitializeComponent();
            Categories = new ObservableCollection<CategoryBase>();
            Category firstCategory = new Category { Name = "Category 1", Glyph = Symbol.Home, Tooltip = "This is category 1" };
            Categories.Add(firstCategory);
            Categories.Add(new Category { Name = "Category 2", Glyph = Symbol.Keyboard, Tooltip = "This is category 2" });
            Categories.Add(new Category { Name = "Category 3", Glyph = Symbol.Library, Tooltip = "This is category 3" });
            Categories.Add(new Category { Name = "Category 4", Glyph = Symbol.Mail, Tooltip = "This is category 4" });
        }

        public void LSNavView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            string parentNameSpace = "UserControlsClassLibrary2";
            if (args.IsSettingsSelected)
            {
                string settingsPage = parentNameSpace + ".SamplePages.SampleSettingsPage";
                Type settingsPageType = Type.GetType(settingsPage);
                contentFrame.Navigate(settingsPageType);
            }
            else
            {
                Debug.WriteLine("Before hitting sample page 1");
                //var selectedItem = args.SelectedItem;
                var selectedItem = (NavigationViewItem)args.SelectedItem;
                if (selectedItem != null) {
                    //string selectedItemTag = selectedItem.Name;
                    string selectedItemTag = ((string)selectedItem.Tag);
                    //sender.Header = "Sample Page" + selectedItem.ToString();
                    sender.Header = "Sample Page " + selectedItemTag.Substring(selectedItemTag.Length - 1);

                    string pageName = parentNameSpace + ".SamplePages." + selectedItemTag;
                    Type pageType = Type.GetType(pageName);
                    contentFrame.Navigate(pageType);

                }
            }
        }
    }


}
