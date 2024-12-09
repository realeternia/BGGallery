using BGGallery.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;


namespace BGGallery.UIs
{
    public partial class UCDataView : UserControl
    {
        public class OptiDataTube : IEnumerable<object>
        {
            private List<string> keys = new List<string>();
            private List<object> values = new List<object>();

            private List<string> orders = new List<string>();

            public Color BgColor = Color.White;

            public bool IsNew;

            public OptiDataTube Add(string key, object value)
            {
                keys.Add(key);
                values.Add(value);
                return this;
            }

            public void Update(string key, object value)
            {
                var index = keys.IndexOf(key);
                values[index] = value.ToString();
            }

            public void SetOrder(List<string> order)
            {
                orders = order;
            }

            public string GetId()
            {
                for (int i = 0; i < keys.Count; i++)
                {
                    if (keys[i] == "id")
                    {
                        return values[i].ToString();
                    }
                }

                return "";
            }

            public bool Contains(string s, BGGCellText handler)
            {
                for (int i = 0; i < values.Count; i++)
                {
                    var checkV = values[i];
                    var checkK = keys[i];

                    if (checkV == null)
                        continue;

                    if (handler == null)
                    {
                        if (checkV.ToString().ToLower().Contains(s))
                            return true;
                    }
                    else
                    {
                        if (handler(checkK, checkV.ToString()).ToLower().Contains(s))
                            return true;
                    }
                }

                return false;
            }

            public object GetValue(string keyName)
            {
                for (int i = 0; i < keys.Count; i++)
                {
                    if (keyName == keys[i])
                        return values[i];
                }

                return null;
            }


            public void Set(OptiDataTube other)
            {
                for (int i = 0; i < keys.Count; i++)
                {
                    var keyName = keys[i];
                    var targetInfo = other.GetValue(keyName);
                    if (targetInfo != null)
                    {
                        values[i] = targetInfo;
                    }
                }
            }

            public IEnumerator<object> GetEnumerator()
            {
                foreach (var columnName in orders)
                {
                    var idx = keys.IndexOf(columnName);
                    yield return values[idx];
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            public int Count
            {
                get { return keys.Count; }
            }

        }
        public class OptiRowDataAgent
        {
            private DataGridViewRow rowData;
            private List<string> columnNameList;
            public OptiRowDataAgent(DataGridViewRow rowData, List<string> columnNameList)
            {
                this.rowData = rowData;
                this.columnNameList = columnNameList;
            }

            public string GetValue(string name)
            {
                var idx = columnNameList.IndexOf(name);
                return rowData.Cells[idx].Value.ToString();
            }

            public object GetTag(string name)
            {
                var idx = columnNameList.IndexOf(name);
                return rowData.Cells[idx].Tag;
            }
            public void SetValue(string name, string val)
            {
                var idx = columnNameList.IndexOf(name);
                rowData.Cells[idx].Value = val;
            }

            public void SetCellColor(string name, Color color)
            {
                var idx = columnNameList.IndexOf(name);
                rowData.Cells[idx].Style.BackColor = color;
            }
        }

        public delegate void BGGNewEvt();
        public delegate bool BGGRowEvt(OptiRowDataAgent rowData, int rowIndex);
        public delegate bool BGGRowEvtDetail(OptiRowDataAgent rowData, int rowIndex, int columnIndex, string colName);
        public delegate bool BGGCellDraw(DataGridViewCellPaintingEventArgs g, string col, string value);
        public delegate string BGGCellText(string col, string value);

        public enum OptiControlTypes
        {
            TextBox,
            CheckBox,
            ComboBox,
            Button
        }

        public enum OptiTagTypes
        {
            None,
            Time,
            Url,
        }

        public BGGRowEvt OnModify;
        public BGGRowEvt OnDelete;
        public BGGRowEvtDetail OnButtonClick;
        public BGGRowEvtDetail OnCellValueChange;
        public BGGCellDraw OnCellDraw;
        public BGGCellText OnCellText;
        public BGGNewEvt OnClickNew;
        public BGGNewEvt OnSave;

        private Dictionary<string, OptiTagTypes> tags = new Dictionary<string, OptiTagTypes>(); //每个字段可以存一个tag
        private Dictionary<string, OptiControlTypes> types = new Dictionary<string, OptiControlTypes>(); //每个字段可以存一个type

        private List<string> columnNameList = new List<string>();
        public List<string> ColumnNameList { get { return columnNameList; } }
        private List<OptiDataTube> dataTubeList = new List<OptiDataTube>(); //缓存住数据，和view分离
        private Dictionary<int, int> rowIndex2ListIndex = new Dictionary<int, int>();
        private Dictionary<string, string> name2HeaderDict = new Dictionary<string, string>();

        private bool noModify;
        public bool NoModify
        {
            get { return noModify; }
            set { noModify = value;
                dataGridView1.ReadOnly = value;
            }
        }

        private bool idReadOnly;
        public bool IdReadOnly
        {
            get { return idReadOnly; }
            set
            {
                idReadOnly = value;
                if (dataGridView1.Columns.Count == 0) return;
                dataGridView1.Columns[0].ReadOnly = value;
            }
        }

        public UCDataView()
        {
            InitializeComponent();

            //利用反射设置DataGridView的双缓冲
            Type dgvType = this.dataGridView1.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(this.dataGridView1, true, null);

            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
            this.dataGridView1.SortCompare += (object sender, DataGridViewSortCompareEventArgs e) => {
                if (e.Column.Name.ToLower() == "id" || e.Column.Name.ToLower() == "count")
                {
                    var res = Convert.ToInt32(e.CellValue1) - Convert.ToInt32(e.CellValue2);
                    if (res > 0) e.SortResult = 1;
                    else if (res < 0) e.SortResult = -1;
                    else e.SortResult = 0;
                }
                else
                {
                    e.SortResult = string.Compare(Convert.ToString(e.CellValue1), Convert.ToString(e.CellValue2));
                }
                e.Handled = true;
            };

            comboBoxStyle.SelectedIndex = 2;

            dataGridView1.CellValueChanged += DataGridView1_CellValueChanged;
            dataGridView1.CurrentCellDirtyStateChanged += DataGridView1_CurrentCellDirtyStateChanged;
        }

        private void DataGridView1_CurrentCellDirtyStateChanged(object sender, System.EventArgs e)
        {
            if (this.dataGridView1.CurrentCell.ColumnIndex == 0)
                this.dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        public int SelectIndex
        {
            get
            {
                var selectIndex = 0;
                if (dataGridView1.SelectedRows.Count > 0)
                    selectIndex = dataGridView1.SelectedRows[0].Index;
                return selectIndex;
            }
        }

        public int RowCount
        {
            get { return dataGridView1.RowCount; }
        }
        public DataGridViewRow LastRow
        {
            get { return dataGridView1.Rows[RowCount-1]; }
        }
        public DataGridViewRow GetRow(int rowIndex)
        {
            return dataGridView1.Rows[rowIndex];
        }

        private bool isFirstCol = true;
        public void AddColumn(OptiControlTypes type, string header, string name, int width, OptiTagTypes tag, string[] infos, bool readOnly = false)
        {
            if (tag != OptiTagTypes.None)
            {
                tags[name] = tag;
            }
            types[name] = type;

            columnNameList.Add(name);
            name2HeaderDict[name] = string.IsNullOrWhiteSpace(header) ? name : header;
            if (type == OptiControlTypes.TextBox)
            {
                 var ctr = new System.Windows.Forms.DataGridViewTextBoxColumn();
                ctr.HeaderText = header;
                ctr.Name = name;
                ctr.Width = width;
                ctr.ReadOnly = readOnly;
                this.dataGridView1.Columns.Add(ctr);


                if (isFirstCol)
                {//把第一列默认冻结住
                    isFirstCol = false;
                    ctr.Frozen = true;
                }
            }
            else if (type == OptiControlTypes.CheckBox)
            {
                var ctr = new System.Windows.Forms.DataGridViewCheckBoxColumn();
                ctr.HeaderText = header;
                ctr.Name = name;
                ctr.Width = width;
                ctr.ReadOnly = readOnly;
                ctr.Resizable = System.Windows.Forms.DataGridViewTriState.True;
                ctr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
       
                this.dataGridView1.Columns.Add(ctr);
            }
            else if (type == OptiControlTypes.ComboBox)
            {
                var ctr = new System.Windows.Forms.DataGridViewComboBoxColumn();
                ctr.Items.AddRange(infos);
                ctr.HeaderText = header;
                ctr.Name = name;
                ctr.Width = width;
                ctr.ReadOnly = readOnly;
                ctr.FlatStyle = FlatStyle.Popup;
                ctr.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
                ctr.Resizable = System.Windows.Forms.DataGridViewTriState.True;
                ctr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
                this.dataGridView1.Columns.Add(ctr);
            }
            else if (type == OptiControlTypes.Button)
            {
                var ctr = new System.Windows.Forms.DataGridViewButtonColumn();
                ctr.HeaderText = header;
                ctr.Name = name;
                ctr.Width = width;
                ctr.ReadOnly = readOnly;
                this.dataGridView1.Columns.Add(ctr);
            }

        }

        public void AddData(OptiDataTube data)
        {
            Decorate(data);

            dataTubeList.Add(data);

            UpdateView();
        }

        public void AddDatas(List<OptiDataTube> datas)
        {
            foreach (OptiDataTube data in datas)
            {
                Decorate(data);
                dataTubeList.Add(data);
            }

            UpdateView();
        }

        public List<OptiDataTube> ExportData()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                OptiDataTube tube = new OptiDataTube();
                var dataAgent = new OptiRowDataAgent(dataGridView1.Rows[row.Index], columnNameList);
                foreach (var colName in columnNameList)
                {
                    if (colName == "commit" || colName == "delete")
                        continue;

                    var val = dataAgent.GetValue(colName);
                    tube.Add(colName, val);
                }
                var target = dataTubeList.Find(a => a.GetId() == tube.GetId());
                target.Set(tube);
            }

            return dataTubeList;
        }

        public void RemoveData(int index)
        {
            dataTubeList.RemoveAt(index);
            UpdateView();
        }

        public void ClearData()
        {
            dataTubeList.Clear();
            UpdateView();
        }

        private void Decorate(OptiDataTube datas)
        {
            datas.SetOrder(columnNameList);
            for (int i = datas.Count; i < columnNameList.Count; i++)
            {
                datas.Add(columnNameList[i], name2HeaderDict[columnNameList[i]]);
            }
        }

        private void textBoxChoose_TextChanged(object sender, EventArgs e)
        {
            UpdateView();
        }

        private void UpdateView()
        {
            dataGridView1.Rows.Clear();
            rowIndex2ListIndex.Clear();
            var filterTxt = textBoxChoose.Text.ToLower();
            for (int i = 0; i < dataTubeList.Count; i ++)
            {
                var tube = dataTubeList[i];
                if (!string.IsNullOrEmpty(filterTxt) && !tube.IsNew)
                {
                    if (!tube.Contains(filterTxt, OnCellText))
                        continue;
                }

                List<object> realDatas = new List<object>(tube.Count);
                realDatas.AddRange(tube);
                rowIndex2ListIndex[dataGridView1.Rows.Count] = i;
                dataGridView1.Rows.Add(realDatas.ToArray());
                var lastRow = dataGridView1.Rows[dataGridView1.Rows.Count - 1];
                foreach (var lastRowCell in lastRow.Cells)
                {
                    var cell = (lastRowCell as DataGridViewCell);
                    cell.Tag = cell.Value;
                }

                //if (tube.BgColor != Color.White)
                //{
                //    lastRow.DefaultCellStyle.BackColor = tube.BgColor;
                //}
                lastRow.DefaultCellStyle.ForeColor = Color.Black;
            }

            if (dataGridView1.Rows.Count > 1)
                dataGridView1.FirstDisplayedScrollingRowIndex = this.dataGridView1.Rows.Count - 1;
        }

        public string GetColumnName(int idx)
        {
            return columnNameList[idx];
        }

        public int GetColumnIndex(string columnName)
        {
            return columnNameList.IndexOf(columnName);
        }

        public void Sort()
        {
            dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            var col = dataGridView1.Columns[e.ColumnIndex];
            var columnName = col.Name;
            var tipName = GetTag(columnName);
            var colType = GetColType(columnName);

            if (OnButtonClick != null)
                OnButtonClick(new OptiRowDataAgent(dataGridView1.Rows[e.RowIndex], columnNameList), e.RowIndex, e.ColumnIndex, columnName);
        }


        public void SetRowBg(int index, Color color)
        {
            var row = dataGridView1.Rows[index];
            row.DefaultCellStyle.BackColor = color;
        }

        public OptiRowDataAgent GetRowDataAgent(int rowIndex)
        {
            return new OptiRowDataAgent(GetRow(rowIndex), columnNameList);
        }

        public OptiTagTypes GetTag(string name)
        {
            OptiTagTypes tagTypes;
            if (tags.TryGetValue(name, out tagTypes))
            {
                return tagTypes;
            }

            return OptiTagTypes.None;
        }

        public OptiControlTypes GetColType(string colname)
        {
            return types[colname];
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex < 0)
                return;
            var columnName = dataGridView1.Columns[e.ColumnIndex].Name;
            if (e.RowIndex < 0)
                return;

            var colorBarInterval = 0;
            if (comboBoxStyle.SelectedIndex > 0)
            {
                if (comboBoxStyle.SelectedIndex == 1)
                    colorBarInterval = 2;
                else if (comboBoxStyle.SelectedIndex == 2)
                    colorBarInterval = 3;
                else if (comboBoxStyle.SelectedIndex == 3)
                    colorBarInterval = 5;
            }

            var selectCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            var cellBgColor = e.CellStyle.BackColor;
            if (colorBarInterval > 0 && (e.RowIndex % colorBarInterval) == 0)
                cellBgColor = Color.LightBlue;
            if (selectCell.Selected)
                cellBgColor = e.CellStyle.SelectionBackColor;
          
            using (var brush = new SolidBrush(cellBgColor))
                e.Graphics.FillRectangle(brush, e.CellBounds);

            var tipName = GetTag(columnName);
            Font font = dataGridView1.Font;
            if (tipName == OptiTagTypes.Time)
            {
                var time = uint.Parse(e.Value.ToString());
                if (time <= 0)
                {
                    e.Graphics.DrawString("-", font, Brushes.Black, e.CellBounds.X + 5, e.CellBounds.Y + 5);
                }
                else
                {
                    if (time < 86400 * 365)
                    {
                        e.Graphics.DrawString((time / 60).ToString() + "分", font, Brushes.Black, e.CellBounds.X + 5, e.CellBounds.Y + 5);
                    }
                    else
                    {
                        var dt = TimeTool.UnixTimeToDateTime(time);
                        e.Graphics.DrawString(dt.ToString(), font, Brushes.Black, e.CellBounds.X + 5, e.CellBounds.Y + 5);
                    }
                }
            }
            else if(OnCellDraw != null && OnCellDraw(e, columnName, e.Value == null ? "" : e.Value.ToString()))
            {
                 // 上层重写了绘制
            }
            else
            {
                e.PaintContent(e.CellBounds);//画内容
            }
            e.Handled = true;
        }

        public void DrawTransColorBg(Graphics g, Color c, Rectangle r)
        {
            using (var b = new SolidBrush(Color.FromArgb(200, c)))
                g.FillRectangle(b, r);
        }

        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
          //  var editCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
          //  editCell.Style.BackColor = Color.Pink;
            var column = dataGridView1.Columns[e.ColumnIndex];
            OnCellValueChange?.Invoke(new OptiRowDataAgent(dataGridView1.Rows[e.RowIndex], columnNameList), e.RowIndex, e.ColumnIndex, column.Name);
        }

        public void RefreshView()
        {
            dataGridView1.Invalidate();
        }

        private void comboBoxStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshView();
        }

        public void SetStyle(int idx)
        {
            comboBoxStyle.SelectedIndex = idx;
        }

        public void SetTarget(int idx)
        {
            dataGridView1.FirstDisplayedScrollingRowIndex = idx;
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            if (OnClickNew != null)
                OnClickNew();
        }

        private void buttonSaveAll_Click(object sender, EventArgs e)
        {
            if (OnSave != null)
                OnSave();
        }
    }
}

