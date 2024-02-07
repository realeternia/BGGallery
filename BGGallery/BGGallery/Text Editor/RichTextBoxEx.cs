using System;
using System.Windows.Forms;

namespace Text_Editor
{
    public class RichTextBoxEx : RichTextBox
    {
        private const int WM_SETCURSOR = 0x20;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr SetCursor(IntPtr hCursor);

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_SETCURSOR)
            {
                if (SelectionType == RichTextBoxSelectionTypes.Object)
                {
                    // Necessary to avoid recursive calls
                    if (Cursor != Cursors.Cross)
                    {
                        Cursor = Cursors.Cross;
                    }
                }
                else
                {
                    // Necessary to avoid recursive calls
                    if (Cursor != Cursors.IBeam)
                    {
                        Cursor = Cursors.IBeam;
                    }
                }

                SetCursor(Cursor.Handle);
                return;
            }

            base.WndProc(ref m);
        }

        private const int WM_SETREDRAW = 0x0B;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        public bool IsSuspendPainting;
        public void SuspendPainting()
        {
            IsSuspendPainting = true;
            SendMessage(this.Handle, WM_SETREDRAW, 0, 0);
        }

        public void ResumePainting()
        {
            IsSuspendPainting = false;
            SendMessage(this.Handle, WM_SETREDRAW, 1, 0);

           // this.Invalidate();
        }

    }
}
