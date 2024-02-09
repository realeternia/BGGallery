using BGGallery.Model;
using System;

namespace BGGallery.UIS
{
    interface IDocComp
    {
        void SetData(BGItemInfo info, string k, string v);
        Action<string> OnModify { get; set; }
        void SetReadOnly(bool readOnly);
    }
}
