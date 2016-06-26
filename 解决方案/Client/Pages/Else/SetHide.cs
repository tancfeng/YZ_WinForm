using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SirdRoom.ManageSystem.Library.Data;
using SirdRoom.ORM;

namespace SirdRoom.ManageSystem.ClientApplication.Pages.Else
{
    public partial class SetHide : UserControl
    {
        Int32 iuser_id = 0;
        public SetHide()
        {
            InitializeComponent();
            iuser_id = SRLibFun.StringConvertToInt32(Param.DPageParameter);

        }
        void BindData()
        {
            String strSql = @"select tb.Id,~tb.Hide as Hide,ta.Name from SRRC_Resourcebiaojirel tb join SRRC_Resource ta  on 
  ta.id= tb.Biaoji_id where tb.User_id=" + iuser_id +" and ta.Pid=0 ";
            DataTable dt = DataBaseHelper.Instance.Helper.ExecuteQuery(CommandType.Text, strSql);
            this.dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String strTrue = "";
            String strFalse = "";
            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                bool bval = Convert.ToBoolean(row.Cells[1].Value);
                if (bval == true)
                {
                    strTrue += row.Cells[0].Value + ",";
                }
                else
                {
                    strFalse += row.Cells[0].Value + ",";
                }
            }
            if (string.IsNullOrEmpty(strTrue) == false)
            {
                DataBase.Instance.tSRRC_Biaoji.Update(new KeyValueCollection<SRRC_BiaojiEntity.FiledType>(){new KeyValue<SRRC_BiaojiEntity.FiledType>(){ Key= SRRC_BiaojiEntity.FiledType.Hide, Value = false}}
                    ," Id in ("+ strTrue +") ");
            }
            if (string.IsNullOrEmpty(strFalse) == false)
            {
                DataBase.Instance.tSRRC_Biaoji.Update(new KeyValueCollection<SRRC_BiaojiEntity.FiledType>() { new KeyValue<SRRC_BiaojiEntity.FiledType>() { Key = SRRC_BiaojiEntity.FiledType.Hide, Value = true } }
                    , " Id in (" + strFalse + ") ");
            }


        }
    }
}
