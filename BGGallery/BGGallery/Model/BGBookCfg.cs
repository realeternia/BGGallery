using BGGallery.Model.Types;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace BGGallery.Model
{
    class BGBookCfg
    {
        public List<string> RecentIcons = new List<string>();

        [SetupItemDes("外观", "人名字色", "编辑器中人名颜色")]
        public ColorCfg PeopleColor { get; set; } = new ColorCfg(Color.Yellow);
        [SetupItemDes("外观", "时间字色", "编辑器中普通时间的颜色")]
        public ColorCfg TimeCommonColor { get; set; } = new ColorCfg(Color.LightGreen);
        [SetupItemDes("外观", "ddl字色", "编辑器中ddl时间的颜色")]
        public ColorCfg TimeDDLColor { get; set; } = new ColorCfg(Color.Purple);

        [SetupItemDes("外观", "url字色", "编辑器中颜色url")]
        public ColorCfg KWUrlColor { get; set; } = new ColorCfg(Color.Cyan);
    }
}
