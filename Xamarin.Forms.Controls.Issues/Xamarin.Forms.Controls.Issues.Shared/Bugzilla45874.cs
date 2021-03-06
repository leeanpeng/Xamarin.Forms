﻿using Xamarin.Forms.CustomAttributes;
using Xamarin.Forms.Internals;

#if UITEST
using Xamarin.UITest;
using NUnit.Framework;
#endif

// Apply the default category of "Issues" to all of the tests in this assembly
// We use this as a catch-all for tests which haven't been individually categorized
#if UITEST
[assembly: NUnit.Framework.Category("Issues")]
#endif

namespace Xamarin.Forms.Controls.Issues
{
	[Preserve(AllMembers = true)]
	[Issue(IssueTracker.Bugzilla, 45874, "Effect not attaching to ScrollView", PlatformAffected.iOS | PlatformAffected.Android)]
	public class Bugzilla45874 : TestContentPage
	{
		const string Success = "Success";

		protected override void Init()
		{
			var label = new Label { Text = "FAIL" };

			var scrollView = new ScrollView { Content = label };

			var effect = Effect.Resolve($"{Issues.Effects.ResolutionGroupName}.BorderEffect");

			scrollView.Effects.Add(effect);

			Content = scrollView;
		}

#if UITEST
		[Test]
		public void Bugzilla45874Test()
		{
			RunningApp.WaitForElement(q => q.Marked(Success));
		}
#endif
	}
}