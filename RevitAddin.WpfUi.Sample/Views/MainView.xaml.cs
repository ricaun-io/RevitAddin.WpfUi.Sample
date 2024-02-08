using ricaun.Revit.Mvvm;
using System;
using System.Windows;
using Wpf.Ui.Appearance;

namespace RevitAddin.WpfUi.Sample.Views
{
    public partial class MainView
    {
        public IRelayCommand CommandChangeTheme { get; private set; }

        public MainView()
        {
            CommandChangeTheme = new RelayCommand(() =>
            {
                var theme = ApplicationThemeManager.GetAppTheme() != ApplicationTheme.Light ? ApplicationTheme.Light : ApplicationTheme.Dark;
                ApplicationThemeManager.Apply(theme);
            });

            InitializeComponent();
            InitializeWindow();

            ApplicationThemeManager.Apply(this);
            ApplicationThemeManager.Changed += ApplicationThemeManager_Changed;
            this.Unloaded += (s, e) =>
            {
                ApplicationThemeManager.Changed -= ApplicationThemeManager_Changed;
            };
        }

        private void ApplicationThemeManager_Changed(ApplicationTheme currentApplicationTheme, System.Windows.Media.Color systemAccent)
        {
            ApplicationThemeManager.Apply(this);
        }

        #region InitializeWindow
        private void InitializeWindow()
        {
            //this.SizeToContent = SizeToContent.WidthAndHeight;
            this.ShowInTaskbar = false;
            //this.ResizeMode = ResizeMode.NoResize;
            this.Height = 320;
            this.Width = 480;
            this.MinHeight = 160;
            this.MinWidth = 200;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            new System.Windows.Interop.WindowInteropHelper(this) { Owner = Autodesk.Windows.ComponentManager.ApplicationWindow };
        }
        #endregion
    }
}