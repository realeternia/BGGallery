using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BGGallery.UIS.Panels
{
    class UCBGPropertyAttrItem : Label
    {
        private bool checked1;
        public bool Checked { get { return checked1; } set { checked1 = value; OnCheckStateChanged(); } }

        public UCBGPropertyAttrItem()
        {
            AutoSize = true;
            Click += UCBGPropertyAttrItem_Click;
        }

        private void UCBGPropertyAttrItem_Click(object sender, EventArgs e)
        {
            checked1 = !checked1;
            OnCheckStateChanged();
        }

        private void OnCheckStateChanged()
        { 
            if(!checked1)
            {
                ForeColor = Color.DimGray;
            }
            else
            {
                ForeColor = Color.LawnGreen;
            }
        }

    }
}
