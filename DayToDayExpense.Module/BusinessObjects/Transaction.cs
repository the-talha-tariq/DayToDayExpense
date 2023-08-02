using System;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using System.Globalization;

namespace DayToDayExpense.Module.BusinessObjects
{

    [DefaultClassOptions]
    [DefaultProperty("Date")]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Transaction : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        
        public Transaction(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        //private string _PersistentProperty;
        //[XafDisplayName("My display name"), ToolTip("My hint message")]
        //[ModelDefault("EditMask", "(000)-00"), Index(0), VisibleInListView(false)]
        //[Persistent("DatabaseColumnName"), RuleRequiredField(DefaultContexts.Save)]
        //public string PersistentProperty {
        //    get { return _PersistentProperty; }
        //    set { SetPropertyValue(nameof(PersistentProperty), ref _PersistentProperty, value); }
        //}

        //[Action(Caption = "My UI Action", ConfirmationMessage = "Are you sure?", ImageName = "Attention", AutoCommit = true)]
        //public void ActionMethod() {
        //    // Trigger a custom business logic for the current record in the UI (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112619.aspx).
        //    this.PersistentProperty = "Paid";
        //}
        
        DateTime _date;
        //[Size(SizeAttribute.DefaultStringMappingFieldSize)]
        //[DevExpress.Xpo.Indexed(Unique = true)]
        public DateTime Date
        {
            get => _date;
            set => SetPropertyValue(nameof(Date), ref _date, value);
        }

        Bank _bank;
        [Association("Bank.Transaction")]
        public Bank Bank
        {
            get => _bank;
            set => SetPropertyValue(nameof(Bank), ref _bank, value);
        }

        string _purpose;
        //[RuleRequiredField]
        public string Purpose
        {
            get => _purpose;
            set => SetPropertyValue(nameof(Purpose), ref _purpose, value);
        }

        decimal _price;
        // [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public decimal Amount
        {
            get => _price;
            set => SetPropertyValue(nameof(Amount), ref _price, value);
        }
        
        [Association("Transaction.Expenses")]
        public XPCollection<Expenses> Expenses
        {
            get
            {
                return GetCollection<Expenses>(nameof(Expenses));
            }
        }

        string _details;
        //[RuleRequiredField]
        public string Details
        {
            get => _details;
            set => SetPropertyValue(nameof(Details), ref _details, value);
        }


    }
}