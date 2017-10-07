using Foundation;
using System;
using UIKit;
using System.Collections.Generic;

namespace PhoneApp
{
    public partial class CallHistoryController : UITableViewController
    {
        public List<string> PhoneNumbers { get; set; }
        protected NSString CallHistoryCellID = new NSString("CallHistoryCell");

        public CallHistoryController (IntPtr handle) : base (handle)
        {
            TableView.RegisterClassForCellReuse(typeof(UITableViewCell),CallHistoryCellID);
            TableView.Source = new CallHistoryDataSource(this);
        }

        class CallHistoryDataSource : UITableViewSource
        {
            CallHistoryController Controller;
            public CallHistoryDataSource(CallHistoryController controller)
            {
                this.Controller = controller;
            }
            public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
            {
                var Cell = tableView.DequeueReusableCell(Controller.CallHistoryCellID);

                Cell.TextLabel.Text = Controller.PhoneNumbers[indexPath.Row];

                return Cell;
            }

            public override nint RowsInSection(UITableView tableview, nint section)
            {
                return Controller.PhoneNumbers.Count;
            }
        }
    }
}