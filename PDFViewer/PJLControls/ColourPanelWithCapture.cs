// ColourPanelFormWithCapture.cs : implementation file
//
// Part of ColorPicker controls.
//
// Author      : Philip Lee (pl@pjl.nildram.co.uk)
// Date        : 14 October 2001
//
// Copyright © PJL Consultants Ltd. 2001, All Rights Reserved                      
//
// This code may be used in compiled form in any way you desire. This
// file may be redistributed unmodified by any means PROVIDING it is 
// not sold for profit without the authors written consent, and 
// providing that this notice and the authors name is included. If 
// the source code in this file is used in any commercial application 
// then a simple email would be nice.
//
// This file is provided "as is" with no expressed or implied warranty.
// The author accepts no liability for any damage, in any form, caused
// by this code. Use it at your own risk and as with all code expect bugs!
// It's been tested but I'm not perfect.
// 
// Please use and enjoy. Please let me know of any bugs/mods/improvements 
// that you have found/implemented and I will fix/incorporate them into this
// file.

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

using System.Windows.Forms;


namespace PJLControls
{

	/// <summary>
	/// This internal class adds mouse capture to the ColorPanel
	/// so we can close the containing modal dialog 'ColorPanelForm'
	/// appropriately.
	/// </summary>
	internal class ColorPanelWithCapture : PJLControls.ColorPanel
	{
		private System.ComponentModel.IContainer components = null;
		private int parentWidth = 300;

		public ColorPanelWithCapture()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// ColorPanelWithCapture
			// 
			this.Name = "ColorPanelWithCapture";
		}
		#endregion

		protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
		{
			base.OnMouseDown(e);

			if( Capture )
			{
				if( !ClientRectangle.Contains(e.X, e.Y) )
				{
					OnClosePanel();
				}
			}
		}

		protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
		{
			base.OnMouseUp(e);

			// For some reason OnMouseUp outside of the client area
			// cancels mouse capture, so we need to take it again
			Capture = true;
		}

		protected override void OnKeyDown(System.Windows.Forms.KeyEventArgs e)
		{
			base.OnKeyDown(e);

			if( e.KeyCode == Keys.Escape )
			{
				OnClosePanel();
			}
		}

		[Browsable(true), Category("ColorPanel")]
		internal event ColorPanelClosingEventHandler PanelClosing;
		protected virtual void OnClosePanel()
		{
			if( null != PanelClosing )
			{
				PanelClosing(this, new System.EventArgs());
			}
		}		

		internal int ParentWidth
		{
			set
			{
				parentWidth = value;
				AutoSizePanel();
			}
		}

		/// <summary>
		/// Override the base class preferred width to be that of the 
		/// our parent ColorPicker control.
		/// </summary>
		/// <returns></returns>
		protected override int GetPreferredWidth()
		{
			return parentWidth;
		}

		/// <summary>
		/// Overrides OnGotFocus in order to grab Mouse Capture.
		/// </summary>
		/// <param name="e"></param>
		protected override void OnGotFocus(System.EventArgs e)
		{
			base.OnGotFocus(e);

			Capture = true;
		}
	}

    internal delegate void ColorPanelClosingEventHandler(object sender, System.EventArgs e);
}

