using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using ricaun.Revit.UI;
using System;
using System.Collections.Generic;
using System.Windows;

namespace RevitAddin.WpfUi.Sample.Revit
{
    [AppLoader]
    public class App : IExternalApplication
    {
        private static RibbonPanel ribbonPanel;
        public Result OnStartup(UIControlledApplication application)
        {
            ribbonPanel = application.CreatePanel("WpfUi");

            ribbonPanel.CreatePushButton<Commands.Command>("Main")
                .SetLargeImage("Resources/Revit.ico");

            ribbonPanel.CreatePushButton<Commands.CommandSimple>("Simple")
                .SetLargeImage("Resources/Revit.ico");

            var themesDictionary = new Wpf.Ui.Markup.ThemesDictionary();
            var controlsDictionary = new Wpf.Ui.Markup.ControlsDictionary();

            ResourcesDictionaries.Add(themesDictionary);
            ResourcesDictionaries.Add(controlsDictionary);

            foreach (var item in ResourcesDictionaries)
            {
                //Application.Current?.Resources.MergedDictionaries.Add(item);
            }

            return Result.Succeeded;
        }

        private List<ResourceDictionary> ResourcesDictionaries = new List<ResourceDictionary>();

        public Result OnShutdown(UIControlledApplication application)
        {
            ribbonPanel?.Remove();

            foreach (var item in ResourcesDictionaries)
            {
                Application.Current?.Resources.MergedDictionaries.Remove(item);
            }

            return Result.Succeeded;
        }
    }

}