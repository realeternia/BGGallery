using System;
using Text_Editor;

namespace BGGallery.Utils
{
    public class TextBoxSelectRecover : IDisposable
    {
        private DasayEditor myEditor;
        private RichTextBoxEx myTextBox;
        private int myStart;
        private int myLen;
        private bool evt;

        public TextBoxSelectRecover(DasayEditor editor, RichTextBoxEx textBox, bool burstEvt = false)
        {
            myEditor = editor;
            myTextBox = textBox;
            myStart = textBox.SelectionStart;
            myLen = textBox.SelectionLength;
            evt = burstEvt;
        }

        public void Dispose()
        {
            if(evt)
            {
                myTextBox.Select(myStart, myLen);
            }
            else
            {
                myEditor.RichtextSelect(myStart, myLen);
            }
      
        }
    }
}
