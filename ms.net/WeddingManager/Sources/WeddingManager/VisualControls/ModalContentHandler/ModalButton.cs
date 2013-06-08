using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualControls.ModalContentHandler
{
    [Flags]
    public enum ModalButton
    {
        NotDefined = 0,
        Ok = 1,
        Cancel = 2,
        Save = 4,
        Exit = 8
    }
}
