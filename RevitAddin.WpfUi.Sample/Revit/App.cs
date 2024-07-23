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

            return Result.Succeeded;
        }

        private List<ResourceDictionary> ResourcesDictionaries = new List<ResourceDictionary>();

        public Result OnShutdown(UIControlledApplication application)
        {
            ribbonPanel?.Remove();

            return Result.Succeeded;
        }
    }

}