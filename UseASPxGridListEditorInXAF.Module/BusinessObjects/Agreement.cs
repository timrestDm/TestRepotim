using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseASPxGridListEditorInXAF.Module.BusinessObjects
{
    [ModelDefault("Caption", "Процесс согласования"), NavigationItem("Документооборот")]
    public class AgreementBase : BaseObject
    {
        public AgreementBase(Session session) : base(session) { }

        private DateTime i_CreateDate;
        [DisplayName("Создано")]
        public DateTime CreateDate
        {
            get { return i_CreateDate; }
            set { SetPropertyValue("CreateDate", ref i_CreateDate, value); }
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
        

        public override void AfterConstruction()
        {
            base.AfterConstruction();
           
            CreateDate = DateTime.Now.Date;

        }

        [Association, DisplayName("Шаги согласования")]
        public XPCollection<AgreementStage> AgreementStages
        {
            get { return GetCollection<AgreementStage>("AgreementStages"); }
        }
    }
}
