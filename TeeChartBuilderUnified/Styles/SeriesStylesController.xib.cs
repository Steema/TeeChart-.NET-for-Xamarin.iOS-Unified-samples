
using System;
using System.Collections.Generic;
using System.Linq;
#if __UNIFIED__
using Foundation;
using UIKit;
#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
#endif
using System.Drawing;

namespace TeeChartBuilder
{
	public partial class SeriesStylesController : UIViewController
	{
		#region Constructors
		public List<string> seriesTypes;
		private UITableView tableView;

		// The IntPtr and initWithCoder constructors are required for items that need 
		// to be able to be created from a xib rather than from managed code

		public SeriesStylesController (IntPtr handle) : base(handle)
		{
			Initialize ();
		}

		[Export("initWithCoder:")]
		public SeriesStylesController (NSCoder coder) : base(coder)
		{
			Initialize ();
		}

		public SeriesStylesController () : base("SeriesStylesController", null)
		{
			Initialize ();
		}

		void Initialize ()
		{
			this.View.BackgroundColor = UIColor.Gray;
		}
				
		#endregion
		
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true/false if your app supports:
			// toInterfaceOrientation == UIInterfaceOrientation.LandscapeLeft;
			// toInterfaceOrientation == UIInterfaceOrientation.LandscapeRight;
			// toInterfaceOrientation == UIInterfaceOrientation.Portrait;
			// toInterfaceOrientation == UIInterfaceOrientation.PortraitUpsideDown;
			return true;
		}
		
		public override void ViewDidLoad()
		{
			/*TODO Remove sections = new List<string>()
			{
				"Standard",
				"Extended"
			};*/
			
			seriesTypes = new List<string>()
            {
                                          "Line",
                                          "Points",
                                          "Area",
                                          "FastLine",
                                          "HorizLine",
                                          "Bar",
                                          "HorizBar",
                                          "Pie",
                                          "Shape",
                                          "Arrow",	//10
                                          "Bubble",
                                          "Gantt",
                                          "Candle",
                                          "Donut",
                                          "Volume",
                                          "Bar3D",
                                          "Points3D",
                                          "Polar",
                                          "PolarBar",
                                          "Radar",	 //20
                                          "Clock",
                                          "WindRose",
                                          "Pyramid",
                                          "Surface",
                                          "LinePoint",
                                          "BarJoin",
                                          "ColorGrid",
                                          "Waterfall",
                                          "Histogram",
                                          "Error",			//30
                                          "ErrorBar",
                                          "Contour",
                                          "Smith",
                                          "Bezier",
                                          "Calendar",
                                          "HighLow",
                                          "TriSurface",
                                          "Funnel",
                                          "Box",
                                          "HorizBox",	 //40
                                          "HorizArea",
                                          "Tower",
                                          "PointFigure",
                                          "Gauges",
                                          "Vector3D",
										  "HorizHistogram",
										  "Map",
										  "ImageBar",
                                          "Kagi",
                                          "Renko",			 //50
										  "IsoSurface",
    									  "Darvas",
        								  "VolumePipe",
                                          "ImagePoint",
										  "CircularGauge",
										  "LinearGauge",
										  "VerticalLinearGauge",
										  "NumericGauge",
										  "OrgSeries",
										  "TagCloud",
                                          //"WorldMap", CDI worldmap
										  "PolarGrid",
                                          "Ternary",
										  "KnobGauge"
            };
			
			tableView = new UITableView(new RectangleF(0,0,0,0),UITableViewStyle.Grouped)
            {
	                Delegate = new TableViewDelegate(seriesTypes),
	                DataSource = new TableViewDataSource(/*seriesTypes*/),
	                AutoresizingMask =
	                    UIViewAutoresizing.FlexibleHeight|
	                    UIViewAutoresizing.FlexibleWidth,
	                BackgroundColor = UIColor.LightGray,
            };			
			
			// Set the table view to fit the width of the app.
            tableView.SizeToFit();
			
			// Reposition and resize the receiver
#if __UNIFIED__
            tableView.Frame = new CoreGraphics.CGRect (
                0, 0, this.View.Frame.Width,
                this.View.Frame.Height);
#else
            tableView.Frame = new RectangleF (
                0, 0, this.View.Frame.Width,
                this.View.Frame.Height);
#endif
 
            // Add the table view as a subview
            this.View.AddSubview(tableView);						
		}
		
		private class TableViewDelegate : UITableViewDelegate
        {
            public TableViewDelegate(List<string> seriesTypes)
            {
            }
			
			private NSIndexPath _previousRow;
 
			public TableViewDelegate(SeriesStylesController controller)
			{
				_previousRow = NSIndexPath.FromRowSection(Settings.SelectedIndex,0);
			}

            public override void RowSelected (
                UITableView tableView, NSIndexPath indexPath)
            {
			// Uncheck the previous row
			if (_previousRow != null)
				tableView.CellAt(_previousRow).Accessory = UITableViewCellAccessory.None;
			
			// Do something with the row
			var row = indexPath.Row;
			Settings.SelectedIndex = row;
			tableView.CellAt(indexPath).Accessory = UITableViewCellAccessory.Checkmark;
			
			_previousRow = indexPath;
			
			// This is what the Settings does under Settings>Mail>Show on an iPhone
			tableView.DeselectRow(indexPath,false);
            }
        }
		
		private class TableViewDataSource : UITableViewDataSource
        {			
			IList<SectionData> _data;
			 
			private class SectionData
			{
				public string Title { get;set; }
				public string CellId { get;set; }
				public IList<string> Data { get;set; }
				 
				public SectionData(string cellId)
				{
					Title = "";
					CellId = cellId;
					Data = new List<string>();
				}
			}
			 
			public TableViewDataSource()
			{
				_data = new List<SectionData>();
				 
				SectionData section1 = new SectionData("section1");
				section1.Data.Add("item 1");
				section1.Data.Add("item 2");
				section1.Data.Add("item 3");
				section1.Title = "Basic";
				_data.Add(section1);
				 
				SectionData section2 = new SectionData("section2");
				section2.Data.Add("option a");
				section2.Data.Add("option b");
				section2.Title = "Advanced";
				_data.Add(section2);
			}
			 
#if __UNIFIED__
			public override string TitleForHeader(UITableView tableView, nint section)
#else
			public override string TitleForHeader(UITableView tableView, int section)
#endif
			{
				return _data[(int)section].Title;
			}
			 
#if __UNIFIED__
			public override nint RowsInSection(UITableView tableview, nint section)
#else
			public override int RowsInSection(UITableView tableview, int section)
#endif
			{
				return _data[(int)section].Data.Count;
			}
			 
#if __UNIFIED__
			public override nint NumberOfSections(UITableView tableView)
#else
			public override int NumberOfSections(UITableView tableView)
#endif
			{
				return _data.Count;
			}
			 
			public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
			{
				SectionData sectionData = _data[indexPath.Section];
				string cellId = sectionData.CellId;
				string row = sectionData.Data[indexPath.Row];
				 
				UITableViewCell cell = tableView.DequeueReusableCell(cellId);      
				if (cell == null )
				{
					cell = new UITableViewCell(UITableViewCellStyle.Default,cellId);
					
					// Set its Accessory if it should be highlighted.
					if (indexPath.Row == Settings.SelectedIndex)
						cell.Accessory = UITableViewCellAccessory.Checkmark;
				}
				 
				cell.TextLabel.Text = row;
				return cell;
			}			
						
			
			/*
			
            static NSString kCellIdentifier =
                new NSString ("MyIdentifier");
            private List<string> seriesTypes;
						
 
            public TableViewDataSource (List<string> seriesTypes)
            {
                this.seriesTypes = seriesTypes;
            }
 
           public override int RowsInSection (
                UITableView tableview, int section)
            {
                return seriesTypes.Count;
				
            }
 
            public override UITableViewCell GetCell (
                UITableView tableView, NSIndexPath indexPath)
            {
                UITableViewCell cell =
                    tableView.DequeueReusableCell (
                        kCellIdentifier);
                if (cell == null)
                {
                    cell = new UITableViewCell (
                        UITableViewCellStyle.Default,
                        kCellIdentifier);
                }
                cell.TextLabel.Text = seriesTypes[indexPath.Row];
				cell.Accessory = UITableViewCellAccessory.Checkmark;

		
				//string fname = listImages[indexPath.Row];
				//cell.ImageView.Image = UIImage.FromFile(fname);
                return cell;
            }*/			
        }		
	}
}

