using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace VisualControls.ModalContentHandler
{
    /// <summary>
    /// Interaction logic for ModalDialog.xaml
    /// </summary>
    public partial class ModalDialog : Window
    {
        private readonly ModalButton _buttons;

        // Original constructor
        private ModalDialog()
        {
            InitializeComponent();
        }

        public ModalDialog(IModalContent contentData, ModalButton buttons)
            :this()
        {
            //if (contentData == null)
            //    throw new ArgumentNullException("'contentData' - Can not be null");
            
            if (buttons == ModalButton.NotDefined)
                throw new ArgumentException("'buttons' - Buttons are not defined");
            
            this.DataContext = contentData;
            _buttons = buttons;
        }

        private void Button_Ok_Click(object sender, RoutedEventArgs e)
        {
            ((IModalContent)DataContext).OnOkPressed();
            this.DialogResult = true;
        }

        private void Button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            ((IModalContent)DataContext).OnCancelPressed();
            this.DialogResult = false;
        }

        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            ((IModalContent)DataContext).OnSavePressed();
            this.DialogResult = true;
        }

        private void Button_Exit_Click(object sender, RoutedEventArgs e)
        {
            ((IModalContent)DataContext).OnExitPressed();
            this.DialogResult = false;
        }
    }
}
