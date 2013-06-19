using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using VisualControls.ModalContentHandler;
using WeddingManager.ViewModels;

namespace WeddingManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        // TODO: What is better - Event or overriding 'OnStartup' method
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // TODO: Why creation of Main Window should be the first?
            var mainWindow = new MainWindow();
            Application.Current.MainWindow = mainWindow;

            // Chose Wedding Project dialog
            var projectSelectorVM = new ProjectSelectorViewModel();
            var ProjectSelectorWindow = new ModalDialog(projectSelectorVM, ModalButton.Ok | ModalButton.Exit);
            var projectSelected = ProjectSelectorWindow.ShowDialog();

            if (projectSelected != true)
                Application.Current.Shutdown();

            // Show MainWindow
            mainWindow.Show();

        }

        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            // TODO: Any additional methods of catching unhandled exceptions?
        }
    }
}
