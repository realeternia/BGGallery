﻿using BGGallery.Model;
using BGGallery.UIs;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static BGGallery.Model.BGBookRecords;
using static BGGallery.UIs.UCDataView;

namespace BGGallery.UIS.Main
{
    public partial class RecordBox : UserControl
    {
        private BGItemInfo itemInfo;
        public RecordBox()
        {
            InitializeComponent();

            ucDataView1.OnClickNew += OnNewRecord;
            ucDataView1.OnSave += OnSave;
            ucDataView1.OnButtonClick += OnButtonClick;

            ucDataView1.AddColumn(UCDataView.OptiControlTypes.TextBox, "id", "id", 60, UCDataView.OptiTagTypes.None, null, true);
            ucDataView1.AddColumn(UCDataView.OptiControlTypes.TextBox, "时间", "begintime", 140, UCDataView.OptiTagTypes.Time, null, false);
            ucDataView1.AddColumn(UCDataView.OptiControlTypes.ComboBox, "持续", "lasttime", 60, UCDataView.OptiTagTypes.None, new string[] { "", "30分", "1小时", "2小时", "3小时" }, false);
            ucDataView1.AddColumn(UCDataView.OptiControlTypes.TextBox, "备注", "infos", 300, UCDataView.OptiTagTypes.None, null, false);
          //  ucDataView1.AddColumn(UCDataView.OptiControlTypes.Button, "保存", "commit", 80, UCDataView.OptiTagTypes.None, null, false);
            ucDataView1.AddColumn(UCDataView.OptiControlTypes.Button, "删除", "delete", 80, UCDataView.OptiTagTypes.None, null, false);
        }

        public void Init(BGItemInfo item)
        {
            if (item == itemInfo)
                return;

            itemInfo = item;

            ucDataView1.ClearData();
            var rs = BGBook.Instance.Records.Records.FindAll(a => a.GameId == itemInfo.Id);
            if(rs.Count > 0)
            {
                var tubes = new List<UCDataView.OptiDataTube>();
                foreach (var record in rs)
                {
                    var tube = new UCDataView.OptiDataTube();
                    tube.Add("id", record.Id);
                    tube.Add("begintime", record.BeginTime);
                    tube.Add("lasttime", record.LastTime);
                    tube.Add("infos", record.Details);
                    tubes.Add(tube);
                }
                ucDataView1.AddDatas(tubes);
                ucDataView1.RefreshView();
            }
            //RefreshAll();

        }

        public void OnNewRecord()
        {
            var tube = new UCDataView.OptiDataTube();
            tube.Add("id", BGBook.Instance.Records.GetNextId());
            tube.Add("begintime", 0);
            tube.Add("lasttime", "");
            tube.Add("infos", "");
            ucDataView1.AddData(tube);
            ucDataView1.RefreshView();
        }
        public void OnSave()
        {
            var dts = ucDataView1.ExportData();

            List<PlayRecords> newRecords = new List<PlayRecords>();
            foreach (var item in dts)
            {
                var checkItem = BGBook.Instance.Records.Records.Find(a => a.Id.ToString() == item.GetId());
                if(checkItem != null) //修改
                {
                    checkItem.BeginTime = uint.Parse(item.GetValue("begintime").ToString());
                    checkItem.LastTime = item.GetValue("lasttime").ToString();
                    checkItem.Details = item.GetValue("infos").ToString();
                }
                else
                {
                    PlayRecords newRecord = new PlayRecords
                    {
                        Id = int.Parse(item.GetId()),
                        GameId = itemInfo.Id,
                        BeginTime = uint.Parse(item.GetValue("begintime").ToString()),
                        LastTime = item.GetValue("lasttime").ToString(),
                        Details = item.GetValue("infos").ToString()
                    };
                    newRecords.Add(newRecord);
                }
            }

            BGBook.Instance.Records.Records.AddRange(newRecords);
        }

        public bool OnButtonClick(OptiRowDataAgent rowData, int rowIndex, int columnIndex, string colName)
        {
            if(colName == "begintime")
            {
                PanelManager.Instance.ShowTimeForm(t => rowData.SetValue(colName, t.ToString()));
            }

            return true;
        }
    }

}
