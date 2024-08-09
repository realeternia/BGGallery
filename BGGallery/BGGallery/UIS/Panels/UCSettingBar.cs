using BGGallery.Model;
using BGGallery.Model.Types;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace BGGallery.UIS
{
    public partial class UCSettingBar : UserControl
    {
        private List<Control> cachedControls = new List<Control>();
        private HashSet<string> catalogs = new HashSet<string>();
        private UCSettingItem nowSettingCtr;

        public UCSettingBar()
        {
            InitializeComponent();

         //   Panels.PanelBorders.InitBorder(this);
        }

        public void Init()
        {
            InitMetas();

            int index = 0;
            UCSettingItem firstItem = null;
            foreach (var cat in catalogs)
            {
                var settingItem = new UCSettingItem();
                settingItem.Title = cat;
                settingItem.Width = 247;
                settingItem.Location = new Point(1, index * 40 + 50);
                settingItem.Click += CatalogItem_Click;
                Controls.Add(settingItem);
                index++;

                if (firstItem == null)
                    firstItem = settingItem;
            }

            SelectTarget(firstItem);
        }

        private void InitMetas()
        {
            Type type = typeof(BGBookCfg);

            // 获取所有属性
            PropertyInfo[] properties = type.GetProperties();

            foreach (var property in properties)
            {
                // 检查属性是否有 SetupItemDesAttribute 特性
                var attribute = (SetupItemDesAttribute)Attribute.GetCustomAttribute(property, typeof(SetupItemDesAttribute));
                if (attribute == null)
                    continue;

                Control newCtr;
                if (property.PropertyType == typeof(bool))
                {
                    var setupSwitch = new UCSetupSwitch();
                    bool bValue = GetPropertyValue<bool>(BGBook.Instance.Cfg, property.Name);
                    setupSwitch.SetData(attribute.Name, attribute.Des, bValue);
                    setupSwitch.OnModify = (va) => SetPropertyValue(BGBook.Instance.Cfg, property.Name, va);

                    newCtr = setupSwitch;
                }
                else if (property.PropertyType == typeof(int))
                {
                    var numberItem = new UCSetupNumberItem();
                    int sValue = GetPropertyValue<int>(BGBook.Instance.Cfg, property.Name);
                    numberItem.MinVal = attribute.NumMin;
                    numberItem.MaxVal = attribute.NumMax;
                    numberItem.SetData(attribute.Name, attribute.Des, sValue);
                    numberItem.OnModify = (va) => SetPropertyValue(BGBook.Instance.Cfg, property.Name, va);

                    newCtr = numberItem;
                }
                else if (property.PropertyType == typeof(string[]))
                {
                    var stringItem = new UCSetupStrArrayItem();
                    var sValue = GetPropertyValue<string[]>(BGBook.Instance.Cfg, property.Name);
                    stringItem.SetData(attribute.Name, attribute.Des, sValue);
                    stringItem.OnModify = (va) => SetPropertyValue(BGBook.Instance.Cfg, property.Name, va);

                    newCtr = stringItem;
                }
                else if (property.PropertyType == typeof(ColorCfg))
                {
                    var colorItem = new UCSetupColorItem();
                    var sValue = GetPropertyValue<ColorCfg>(BGBook.Instance.Cfg, property.Name);
                    colorItem.SetData(attribute.Name, attribute.Des, sValue.ToColor());
                    colorItem.OnModify = (va) => SetPropertyValue(BGBook.Instance.Cfg, property.Name, ColorCfg.FromColor(va));

                    newCtr = colorItem;
                }
                else if (property.PropertyType == typeof(TextColorCfg[]))
                {
                    var stringItem = new UCTextColorArrayItem();
                    var sValue = GetPropertyValue<TextColorCfg[]>(BGBook.Instance.Cfg, property.Name);
                    stringItem.SetData(attribute.Name, attribute.Des, sValue);
                    stringItem.OnModify = (va) => SetPropertyValue(BGBook.Instance.Cfg, property.Name, va);

                    newCtr = stringItem;
                }
                else
                {
                    var stringItem = new UCSetupStringItem();
                    string sValue = GetPropertyValue<string>(BGBook.Instance.Cfg, property.Name);
                    stringItem.SetData(attribute.Name, attribute.Des, sValue);
                    stringItem.OnModify = (va) => SetPropertyValue(BGBook.Instance.Cfg, property.Name, va);

                    newCtr = stringItem;
                }

                newCtr.Tag = attribute.Catalog;
                catalogs.Add(attribute.Catalog);
                newCtr.Height = 70;
                newCtr.Width = 900 - 25;
              //  newCtr.Location = new Point(0, 90 + panel1.Controls.Count * 70);

                cachedControls.Add(newCtr);
            }
        }

        static T GetPropertyValue<T>(object obj, string propertyName)
        {
            Type type = obj.GetType();
            PropertyInfo propertyInfo = type.GetProperty(propertyName);

            if (propertyInfo != null)
            {
                // 获取属性的值
                object value = propertyInfo.GetValue(obj);

                // 尝试将值转换为 T 类型
                if (value != null && value is T)
                {
                    return (T)value;
                }
            }

            // 返回默认值，如果获取值失败
            return default(T);
        }

        static void SetPropertyValue(object obj, string propertyName, object value)
        {
            Type type = obj.GetType();
            PropertyInfo propertyInfo = type.GetProperty(propertyName);

            if (propertyInfo != null && propertyInfo.CanWrite)
            {
                // 设置属性的值
                propertyInfo.SetValue(obj, value);
            }
            else
            {
                Console.WriteLine($"Property {propertyName} not found or is read-only.");
            }
        }

        private void CatalogItem_Click(object sender, System.EventArgs e)
        {
            var mItem = sender as UCSettingItem;
            if (nowSettingCtr == mItem)
                return;

            SelectTarget(mItem);
        }

        private void SelectTarget(UCSettingItem mItem)
        {
            if (nowSettingCtr != null)
                nowSettingCtr.SetSelect(false);
            nowSettingCtr = mItem;
            mItem.SetSelect(true);

            RefreshItems(mItem.Title);
        }

        private void RefreshItems(string cat)
        {
            panel1.SuspendLayout();
            panel1.Controls.Clear();

            foreach(var ctr in cachedControls)
            {
                if(ctr.Tag.ToString() == cat)
                {
                    ctr.Location = new Point(0, 90 + panel1.Controls.Count * 70);
                    panel1.Controls.Add(ctr);
                }
            }
            panel1.Height = panel1.Controls.Count * 70 + 90;
            panel1.ResumeLayout();

            panel1.Invalidate(new Rectangle(0, 0, 870, 100));
        }

        private void doubleBufferedPanel1_Paint(object sender, PaintEventArgs e)
        {
            if (nowSettingCtr != null)
                using (var ft = new Font("微软雅黑", 12))
                    e.Graphics.DrawString(nowSettingCtr.Title, ft, Brushes.White, 55, 35);
            e.Graphics.DrawLine(Pens.Gray, 55, 75, 870, 75);
        }

        private void panel1_Scroll(object sender, ScrollEventArgs e)
        {
            panel1.Invalidate(new Rectangle(0, 0, 870, 100));
        }
    }
}
