// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.1
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

using UIKit;
using Foundation;

namespace TeeChartBuilder {
	
	// Base type probably should be MonoTouch.Foundation.NSObject or subclass
	[Foundation.Register("AppDelegate")]
    public partial class AppDelegate {
		
		private UIWindow __mt_window;
		
		private UINavigationController __mt_navigationController;
		
		#pragma warning disable 0169
		[Connect("window")]
		private UIWindow window {
			get {
				this.__mt_window = ((UIWindow)(this.GetNativeField("window")));
				return this.__mt_window;
			}
			set {
				this.__mt_window = value;
				this.SetNativeField("window", value);
			}
		}
		
		[Connect("navigationController")]
		private UINavigationController navigationController {
			get {
				this.__mt_navigationController = ((UINavigationController)(this.GetNativeField("navigationController")));
				return this.__mt_navigationController;
			}
			set {
				this.__mt_navigationController = value;
				this.SetNativeField("navigationController", value);
			}
		}
	}
}