using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

namespace ContextMenu2
{
    public class CMenu
    {
        public String Name { get; set; }
        public string GestureText { get; set; }
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            var cm = new ContextMenu();
            var menuItem1 = new MenuItem();
            cm.Items.Add(menuItem1);
            var t = cm.Template;
            var m = menuItem1.Template;
            var str = new StringBuilder();
            using (var writer = new StringWriter(str))
                XamlWriter.Save(m, writer);
            Debug.Write(str);
            InitializeComponent();
            DataContext = this;
        }

        public ObservableCollection<CMenu> Items { get; set; } = new ObservableCollection<CMenu>
        {
            new CMenu()
            {
                Name = "Press me",
                GestureText =
                    new KeyGesture(Key.Q, ModifierKeys.Control).GetDisplayStringForCulture(CultureInfo.CurrentUICulture)
            },
            new CMenu()
            {
                Name = "Press me too",
                GestureText =
                    new KeyGesture(Key.R, ModifierKeys.Control).GetDisplayStringForCulture(CultureInfo.CurrentUICulture)
            }
        };
    }
}

