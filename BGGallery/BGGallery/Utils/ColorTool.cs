using System;
using System.Collections.Generic;
using System.Drawing;

namespace BGGallery.Utils
{
    class ColorTool
    {
        public readonly static Dictionary<string, Color> BaseColorTable = new Dictionary<string, Color>
        {
            ["红色系"] = Color.FromArgb(255, 0, 0),
            ["黄色系"] = Color.FromArgb(255, 255, 0),
            ["绿色系"] = Color.FromArgb(0, 255, 0),
            ["蓝色系"] = Color.FromArgb(0, 0, 255),
            ["紫色系"] = Color.FromArgb(128, 0, 128),
            ["灰色系"] = Color.FromArgb(128, 128, 128),
       //     ["棕色系"] = Color.FromArgb(139, 69, 19),
        };

        public readonly static Dictionary<string, Color> DarkColorTable = new Dictionary<string, Color>
        {
            ["深黄"] = Color.FromArgb(0x40, 0x33, 0x24),
            ["深蓝"] = Color.FromArgb(0x1b, 0x2d, 0x38),
            ["深红"] = Color.FromArgb(0x3e, 0x28, 0x25),
            ["深绿"] = Color.FromArgb(0x00, 0x33, 0x00),  // 深绿
            ["浅紫"] = Color.FromArgb(0x33, 0x19, 0x33),  // 浅紫
            ["橙色"] = Color.FromArgb(0x4C, 0x33, 0x00),  // 橙色
            ["橄榄绿"] = Color.FromArgb(0x26, 0x26, 0x00),  // 橄榄绿
            ["靛青"] = Color.FromArgb(0x00, 0x33, 0x33),  // 靛青
            ["玫瑰红"] = Color.FromArgb(0x4C, 0x00, 0x19),  // 玫瑰红
            ["湖蓝"] = Color.FromArgb(0x00, 0x4C, 0x4C),  // 湖蓝
            ["深灰"] = Color.FromArgb(0x19, 0x19, 0x19),  // 深灰
        };

        public readonly static Dictionary<string, Color> FullColorTable = new Dictionary<string, Color>
        {
            ["绯色"] = Color.FromArgb(237, 87, 54),
            ["赫赤"] = Color.FromArgb(201, 31, 55),
            ["石榴红"] = Color.FromArgb(242, 12, 0),
            ["海棠红"] = Color.FromArgb(219, 90, 107),
            ["品红"] = Color.FromArgb(240, 0, 86),
            ["洋红色"] = Color.FromArgb(255, 0, 151),
            ["胭脂"] = Color.FromArgb(157, 41, 51),
            ["桃夭"] = Color.FromArgb(246, 190, 200),
            ["长春"] = Color.FromArgb(220, 107, 130),
            ["蚩尤旗"] = Color.FromArgb(168, 88, 88),
            ["鹅黄色"] = Color.FromArgb(255, 241, 67),
            ["半见"] = Color.FromArgb(255, 251, 199),
            //   ["姚黄"] = Color.FromArgb(214, 188, 70),
            ["杏黄"] = Color.FromArgb(255, 166, 49),
            ["琥珀"] = Color.FromArgb(202, 105, 36),
            //  ["鞠衣"] = Color.FromArgb(211, 162, 55),
            ["黄埃"] = Color.FromArgb(180, 146, 115),
            ["黄封"] = Color.FromArgb(202, 178, 114),
            //   ["鸭卵青"] = Color.FromArgb(224, 238, 232),
            ["瓷秘"] = Color.FromArgb(191, 192, 150),
            ["青玉荼"] = Color.FromArgb(168, 176, 146),
            ["麹尘"] = Color.FromArgb(192, 208, 157),
            ["青粲"] = Color.FromArgb(195, 217, 78),
            ["嫩绿"] = Color.FromArgb(189, 221, 34),
            ["青色"] = Color.FromArgb(0, 224, 158),
            ["松花色"] = Color.FromArgb(188, 230, 114),
            ["人籁"] = Color.FromArgb(158, 188, 25),
            ["绿色"] = Color.FromArgb(0, 229, 0),
            ["碧山"] = Color.FromArgb(119, 150, 73),
            ["松柏绿"] = Color.FromArgb(33, 166, 117),
            ["庭芫绿"] = Color.FromArgb(104, 148, 92),
            ["官绿"] = Color.FromArgb(42, 11, 63),
            ["雀梅"] = Color.FromArgb(120, 138, 111),
            ["绿云"] = Color.FromArgb(69, 73, 61),
            ["碧落"] = Color.FromArgb(174, 208, 238),
            ["碧蓝"] = Color.FromArgb(62, 237, 231),
            ["湖蓝"] = Color.FromArgb(48, 223, 243),
            //   ["孔雀蓝"] = Color.FromArgb(73, 148, 196),
            ["苍苍"] = Color.FromArgb(89, 118, 186),
            ["宝蓝"] = Color.FromArgb(75, 92, 196),
            ["柔蓝"] = Color.FromArgb(16, 104, 152),
            //  ["群青"] = Color.FromArgb(46, 89, 167),
            ["藏蓝"] = Color.FromArgb(59, 46, 126),
            ["绀青绀紫"] = Color.FromArgb(0, 51, 113),
            ["花青"] = Color.FromArgb(26, 40, 71),
            ["暮山紫"] = Color.FromArgb(164, 171, 214),
            ["丁香色"] = Color.FromArgb(204, 164, 227),
            ["雪青"] = Color.FromArgb(176, 164, 227),
            ["紫色"] = Color.FromArgb(141, 75, 187),
            ["青莲"] = Color.FromArgb(128, 29, 174),
            ["紫棠"] = Color.FromArgb(86, 0, 79),
            ["自酱紫"] = Color.FromArgb(129, 84, 118),
            ["黛紫"] = Color.FromArgb(87, 66, 102),
            ["紫檀"] = Color.FromArgb(76, 34, 27),
            ["苍色"] = Color.FromArgb(117, 135, 138),
            ["仓青"] = Color.FromArgb(115, 151, 171),
            ["苍翠"] = Color.FromArgb(81, 154, 115),
            ["仓黑"] = Color.FromArgb(57, 82, 96),
            //  ["苍白"] = Color.FromArgb(209, 217, 224),
            ["水色"] = Color.FromArgb(136, 173, 166),
            //  ["水蓝"] = Color.FromArgb(210, 240, 244),
            //   ["淡青"] = Color.FromArgb(211, 224, 243),
            ["霜色"] = Color.FromArgb(233, 241, 246),
            ["玉色"] = Color.FromArgb(234, 228, 209),
         //   ["藕丝秋半"] = Color.FromArgb(211, 203, 197),
            ["普鲁士蓝"] = Color.FromArgb(0, 49, 83),
            ["勃艮第红"] = Color.FromArgb(128, 0, 32),
            ["邦迪蓝"] = Color.FromArgb(0, 149, 182),
            // ["木乃伊棕"] = Color.FromArgb(143, 75, 40),
            ["卡布里蓝"] = Color.FromArgb(26, 85, 153),
            ["提香红"] = Color.FromArgb(176, 89, 35),
           // ["蒂凡尼蓝"] = Color.FromArgb(129, 216, 208),
            ["覆盆子红"] = Color.FromArgb(158, 46, 36),
            ["虎皮黄"] = Color.FromArgb(226, 175, 66),
            ["薄荷绿"] = Color.FromArgb(64, 125, 82),
            ["草黄"] = Color.FromArgb(207, 182, 74),
          //  ["星蓝"] = Color.FromArgb(154, 180, 205),
            //  ["鸢尾蓝"] = Color.FromArgb(65, 138, 180),
            ["苋菜紫"] = Color.FromArgb(142, 41, 97),
            ["钢蓝"] = Color.FromArgb(16, 20, 32),
            ["云峰白"] = Color.FromArgb(218, 227, 230),
            ["岩石棕"] = Color.FromArgb(140, 80, 44),
            ["橄榄石绿"] = Color.FromArgb(184, 206, 142),
          //  ["竹绿"] = Color.FromArgb(79, 164, 133),
            ["钴蓝"] = Color.FromArgb(70, 146, 185),
            ["月影白"] = Color.FromArgb(194, 196, 195),
            ["笋皮棕"] = Color.FromArgb(107, 51, 26),
            ["银丝灰"] = Color.FromArgb(128, 128, 128),
            ["石炭灰"] = Color.FromArgb(96, 96, 96),
            ["幽墨灰"] = Color.FromArgb(64, 64, 64),
            ["淡紫色"] = Color.FromArgb(182, 160, 255),
            ["皇室紫"] = Color.FromArgb(120, 81, 169),
            ["深紫"] = Color.FromArgb(102, 51, 153),
            ["灰紫"] = Color.FromArgb(204, 153, 204),
            ["李子紫"] = Color.FromArgb(142, 69, 133),
        };
        public static Color ColorPlus(Color c, float exp)
        {
            return Color.FromArgb((byte)(c.R * exp), (byte)(c.G * exp), (byte)(c.B * exp));
        }
    }
}
