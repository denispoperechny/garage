using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualControls.ModalContentHandler
{
    public interface IModalContent
    {
        void OnOkPressed();

        void OnCancelPressed();

        void OnSavePressed();

        void OnExitPressed();
    }
}
