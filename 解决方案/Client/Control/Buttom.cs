using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SirdRoom.ManageSystem.ClientApplication.Control
{
    public partial class Buttom : UserControl
    {
        public Buttom()
        {
            InitializeComponent();
        }
        public void BindData()
        {
            String strText = "";
            if(SROperation2.Instance.FocusPanel == "Left")
            {
                if (SROperation2.Instance.PicSelected != null && SROperation2.Instance.PicSelected.Count > 0)
                {
                    List<SRRC_ResourceEntity> entList = SROperation2.Instance.PicSelected;

                    if (entList.Count == 1)
                        strText += String.Format("Total {0} items ({1}MB) | {2} | {3} | {4}KB,Modify Date:{5} | {6} ",
                            entList.Count, (entList[0].Filesize / 1024 / 1024).ToString("F1"),
                            entList[0].Extend1, entList[0].Name,
                            (entList[0].Filesize / 1024).ToString("F1"),
                            entList[0].Addtime, entList[0].Extend2
                            );
                    else
                        strText += String.Format("Total {0} items ({1}MB) | Modify Date:{2}  ",
                            entList.Count, (entList.Sum(m => m.Filesize) / 1024 / 1024).ToString("F1"),
                            String.Format("{0}-{1}", entList.Min(m => m.Addtime), entList.Max(m => m.Addtime))
                            );

                }
                else
                {
                    //int count = Convert.ToInt32(DataBase.Instance.tSRRC_Resource.Math(ORM.FunType.Count, SRRC_ResourceEntity.FiledType.Id, "Pid=[$pid$]", new ORM.DataParameter("pid", SROperation.Instance.LeftSelectedId)));
                    //strText = "Total " + count + " items";
                }
            }            
            this.label1.Text = strText;
        }
        public void BindData(int picId)
        {
            this.label2.Text = Param.UserEnt.Loginname;
            string strText = "";

            SRRC_ResourceEntity ent = DataBase.Instance.tSRRC_Resource.Get_Entity(picId);
            if (ent == null) return; 
           
                strText += String.Format(" {0} | {1} | {2}KB,Modify Date:{3} | {4} ",                  
                    ent.Extend1, ent.Name,
                    (ent.Filesize / 1024).ToString("F1"),
                    ent.Addtime, ent.Extend2
                    );
            
            this.label1.Text = strText;
        }
    }
}
