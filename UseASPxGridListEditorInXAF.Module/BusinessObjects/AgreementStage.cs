using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseASPxGridListEditorInXAF.Module.BusinessObjects
{
    [ModelDefault("Caption", "Шаг согласования")]
    public class AgreementStage : BaseObject //, ITreeNode
    {
        public AgreementStage(Session session) : base(session) { }

        private int i_Nom;
        [DisplayName("Порядковый номер согласования")]
        public int Nom
        {
            get
            {
                if (i_Nom == 0)
                    i_Nom = GetNom();
                return i_Nom;
            }
            set { SetPropertyValue("Nom", ref i_Nom, value); }
        }

        private int GetNom()
        {
            int res = 0;
            if (AgreementBase != null)
                res = AgreementBase.AgreementStages.Count;

            return res;
        }


        private AgreementBase i_AgreementBase;
        [Association, DisplayName("Согласование")]
        public AgreementBase AgreementBase
        {
            get { return i_AgreementBase; }
            set
            {
                SetPropertyValue("AgreementBase", ref i_AgreementBase, value);
            }
        }

        private DateTime i_StartDate;
        [DisplayName("Начало")]
        public DateTime StartDate
        {
            get { return i_StartDate; }
            set { SetPropertyValue("StartDate", ref i_StartDate, value); }
        }
        private DateTime i_FinishDate;
        [DisplayName("Окончание")]
        public DateTime FinishDate
        {
            get { return i_FinishDate; }
            set { SetPropertyValue("FinishDate", ref i_FinishDate, value); }
        }

        private string i_Name;
        [Size(4000), DisplayName("Примечание")]
        public string Name
        {
            get { return i_Name; }
            set { SetPropertyValue("Name", ref i_Name, value); }
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            //StartDate = DateTime.Now.Date;
        }

        //private AgreementStage i_AgreementStageParent;
        //[Association, DisplayName("Согласование")]
        //public AgreementStage AgreementStageParent
        //{
        //    get { return i_AgreementStageParent; }
        //    set
        //    {
        //        SetPropertyValue("AgreementStageParent", ref i_AgreementStageParent, value);
        //    }
        //}

        //[Association, DisplayName("Шаги согласования")]
        //public XPCollection<AgreementStage> ChildrenAgreementStages
        //{
        //    get { return GetCollection<AgreementStage>("ChildrenAgreementStages"); }
        //}
        
    }
}
