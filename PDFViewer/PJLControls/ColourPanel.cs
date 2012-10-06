// ColourPanel : implementation file
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
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;

namespace PJLControls
{
	/// <summary>
	/// A control that allows the selection of a color
	/// from a fixed color palette.
	/// </summary>
	/// <remarks>
	/// The color panel displays a grid of colors.  These colors are either derived from the
	/// System.Drawing.KnownColor enumeration, or supplied by the user using the <c>CustomColor</c> property.
	/// <br></br>
	/// <br></br>
	/// The set of colors displayed is controlled by the <see cref="PJLControls.ColorSet">ColorSet</see> property.
	/// </remarks>
	public class ColorPanel : System.Windows.Forms.UserControl
	{
		// defaults
		internal const ColorSortOrder    defaultColorSortOrder   = ColorSortOrder.Distance;
		internal const ColorSet          defaultColorSet         = ColorSet.Web;
		internal const BorderStyle       defaultBorderStyle      = BorderStyle.FixedSingle;
		internal const int               defaultPreferredColumns = 0;
		internal static readonly Size    defaultColorWellSize    = new Size(16,16);
		internal static readonly Color   defaultColor            = Color.Black;

		private System.Windows.Forms.ToolTip     toolTip;
		private System.ComponentModel.IContainer components;

		private System.Windows.Forms.BorderStyle borderStyle      = defaultBorderStyle;
		private Size                             borderSize       = new Size(1,1);
		private Size                             colorWellSize    = defaultColorWellSize;
		private ColorWellInfo[]                  colorWells       = null;
		private ColorWellInfo                    pickColor        = null;
		private ColorWellInfo                    currentColor     = null;
		private ColorSet                         colorSet         = defaultColorSet;
		private ColorSortOrder                   colorSortOrder   = defaultColorSortOrder;
		private int                              preferredColumns = defaultPreferredColumns;
		private Color[]                          customColors     = null;

		private int   columns;
		private int   rows;
		private Point lastMousePosition;

		/// <summary>
		/// Initializes a new instance of the ColorPanel class.
		/// </summary>
		/// <remarks>
		/// The default constructor initializes all fields to their default values.
		/// </remarks>
		public ColorPanel()
		{
			colorWells = ColorWellInfo.GetColorWells( colorSet, colorSortOrder );

			ResetCustomColors();

			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			UpdateBorderSize();

			AutoSizePanel();
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // toolTip
            // 
            this.toolTip.AutomaticDelay = 0;
            // 
            // ColorPanel
            // 
            this.Name = "ColorPanel";
            this.Size = new System.Drawing.Size(177, 228);
            this.toolTip.SetToolTip(this, "color");
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// This class is used to hold the information about each color well.
		/// </summary>
		private class ColorWellInfo
		{
			private int unsorted_index;
			private long distance;
			public readonly System.Drawing.Color Color;
			public Rectangle colorPosition;

			public ColorWellInfo( Color color, int unsorted_index )
			{
				this.Color = color;
				distance = color.R * color.R + color.B * color.B + color.G * color.G;

				this.unsorted_index = unsorted_index;
			}

			private class DistanceComparer : IComparer
			{
				public int Compare(object a, object b)
				{
					ColorWellInfo _a = (ColorWellInfo)a;
					ColorWellInfo _b = (ColorWellInfo)b;

					return _a.distance.CompareTo(_b.distance);
				}
			}
		
			private class NameComparer : IComparer
			{
				public int Compare(object a, object b)
				{
					ColorWellInfo _a = (ColorWellInfo)a;
					ColorWellInfo _b = (ColorWellInfo)b;

					return _a.Color.Name.CompareTo(_b.Color.Name);
				}
			}
		
			private class SaturationComparer : IComparer
			{
				public int Compare(object a, object b)
				{
					ColorWellInfo _a = (ColorWellInfo)a;
					ColorWellInfo _b = (ColorWellInfo)b;

					return _a.Color.GetSaturation().CompareTo(_b.Color.GetSaturation());
				}
			}

			private class HueComparer : IComparer
			{
				public int Compare(object a, object b)
				{
					ColorWellInfo _a = (ColorWellInfo)a;
					ColorWellInfo _b = (ColorWellInfo)b;

					return _a.Color.GetHue().CompareTo(_b.Color.GetHue());
				}
			}

			private class BrightnessComparer : IComparer
			{
				public int Compare(object a, object b)
				{
					ColorWellInfo _a = (ColorWellInfo)a;
					ColorWellInfo _b = (ColorWellInfo)b;

					return _a.Color.GetBrightness().CompareTo(_b.Color.GetBrightness());
				}
			}

			private class UnsortedComparer : IComparer
			{
				public int Compare(object a, object b)
				{
					ColorWellInfo _a = (ColorWellInfo)a;
					ColorWellInfo _b = (ColorWellInfo)b;

					return _a.unsorted_index.CompareTo(_b.unsorted_index);
				}
			}

			/// <summary>
			/// Returns an new instance of a class used to sort the color table.
			/// </summary>
			/// <returns>IComparer</returns>
			public static IComparer CompareColorDistance()
			{
				return new DistanceComparer();
			}

			/// <summary>
			/// Returns an new instance of a class used to sort the color table.
			/// </summary>
			/// <returns>IComparer</returns>
			public static IComparer CompareColorName()
			{
				return new NameComparer();
			}

			/// <summary>
			/// Returns an new instance of a class used to sort the color table.
			/// </summary>
			/// <returns>IComparer</returns>
			public static IComparer CompareColorSaturation()
			{
				return new SaturationComparer();
			}

			/// <summary>
			/// Returns an new instance of a class used to sort the color table.
			/// </summary>
			/// <returns>IComparer</returns>
			public static IComparer CompareColorHue()
			{
				return new HueComparer();
			}

			/// <summary>
			/// Returns an new instance of a class used to sort the color table.
			/// </summary>
			/// <returns>IComparer</returns>
			public static IComparer CompareColorBrightness()
			{
				return new BrightnessComparer();
			}

			/// <summary>
			/// Returns an new instance of a class used to sort the color table.
			/// </summary>
			/// <returns>IComparer</returns>
			public static IComparer CompareUnsorted()
			{
				return new UnsortedComparer();
			}

			/// <summary>
			/// Generate an array of ColorWellInfo from the supplied array of Color.
			/// </summary>
			/// <param name="customColors"></param>
			/// <param name="colorSortOrder"></param>
			/// <returns></returns>
			public static ColorWellInfo[] GetCustomColorWells( Color[] customColors, ColorSortOrder colorSortOrder )
			{
				int nColors = customColors.Length;

				ColorWellInfo[] colorWells = new ColorWellInfo[nColors];

				for( int i=0; i<customColors.Length; i++ )
				{
					colorWells[i] = new ColorWellInfo(customColors[i], i);
				}

				SortColorWells(colorWells, colorSortOrder);

				return colorWells;
			}

			/// <summary>
			/// This method return an array of colorWells that belong to the desired ColorSet and 
			/// that have been sorted in the desired ColorSortOrder.
			/// </summary>
			/// <param name="colorSet">The color palette to be generated.</param>
			/// <param name="colorSortOrder">The order the generated palette should be sorted.</param>
			/// <returns></returns>
			public static ColorWellInfo[] GetColorWells( ColorSet colorSet, ColorSortOrder colorSortOrder )
			{
				// get array of desired colorWells and sort
				// Could have sort order enum/property
				Array knownColors = Enum.GetValues( typeof(System.Drawing.KnownColor) );

				int nColors = 0;

				// How many colors are there?
				switch( colorSet )
				{
				case ColorSet.Web:
					foreach( KnownColor k in knownColors )
					{
						Color c = Color.FromKnownColor(k);
						if( !c.IsSystemColor && (c.A > 0) )
						{
							nColors++;
						}
					}
					break;
				case ColorSet.System:
					foreach( KnownColor k in knownColors )
					{
						Color c = Color.FromKnownColor(k);
						if( c.IsSystemColor && (c.A > 0) )
						{
							nColors++;
						}
					}
					break;
				}

				ColorWellInfo[] colorWells = new ColorWellInfo[ nColors ];
				
				int index = 0;

				// Get the colors
				switch( colorSet )
				{
				case ColorSet.Web:
					foreach( KnownColor k in knownColors )
					{
						Color c = Color.FromKnownColor(k);

						if( !c.IsSystemColor && (c.A > 0) )
						{
							colorWells[index] = new ColorWellInfo(c,index);
							index++;
						}
					}
					break;
				case ColorSet.System:
					foreach( KnownColor k in knownColors )
					{
						Color c = Color.FromKnownColor(k);

						if( c.IsSystemColor && (c.A > 0) )
						{
							colorWells[index] = new ColorWellInfo(c,index);
							index++;
						}
					}
					break;
				}

				SortColorWells(colorWells, colorSortOrder);

				return colorWells;
			}

			/// <summary>
			/// Sort the supplied colorWells according to the required sort order.
			/// </summary>
			/// <param name="colorWells"></param>
			/// <param name="colorSortOrder"></param>
			public static void SortColorWells( ColorWellInfo[] colorWells, ColorSortOrder colorSortOrder )
			{
				// Sort them
				switch( colorSortOrder )
				{
				case ColorSortOrder.Brightness:
					Array.Sort(colorWells, ColorWellInfo.CompareColorBrightness());
					break;
				case ColorSortOrder.Distance:
					Array.Sort(colorWells, ColorWellInfo.CompareColorDistance());
					break;
				case ColorSortOrder.Hue:
					Array.Sort(colorWells, ColorWellInfo.CompareColorHue());
					break;
				case ColorSortOrder.Name:
					Array.Sort(colorWells, ColorWellInfo.CompareColorName());
					break;
				case ColorSortOrder.Saturation:
					Array.Sort(colorWells, ColorWellInfo.CompareColorSaturation());
					break;
				case ColorSortOrder.Unsorted:
					Array.Sort(colorWells, ColorWellInfo.CompareUnsorted());
					break;
				}
			}


			/// <summary>
			/// Draws the ColorWell on the Graphics surface.
			/// </summary>
			/// <remarks>
			/// This method draws the ColorWell as either enabled or disabled.
			/// It also indicates the currently selected color and the color
			/// that is ready to chosed (picked) by the mouse or keyboard.
			/// </remarks>
			/// <param name="g"></param>
			/// <param name="enabled"></param>
			/// <param name="selected"></param>
			/// <param name="pickColor"></param>
			public void DrawColorWell( System.Drawing.Graphics g, bool enabled, bool selected, bool pickColor )
			{
				if( !enabled )
				{
					Rectangle r = colorPosition;
					r.Inflate(-SystemInformation.BorderSize.Width,-SystemInformation.BorderSize.Height);
					ControlPaint.DrawBorder3D( g, r, Border3DStyle.Flat );
					r.Inflate(-SystemInformation.BorderSize.Width,-SystemInformation.BorderSize.Height);
					g.FillRectangle( SystemBrushes.Control, r );
				}
				else
				{
					SolidBrush br = new SolidBrush(this.Color);

					if( pickColor )
					{
						Rectangle r = colorPosition;
						ControlPaint.DrawBorder3D( g, r, Border3DStyle.Sunken );
						r.Inflate(-SystemInformation.Border3DSize.Width,-SystemInformation.Border3DSize.Height);
						g.FillRectangle( br, r );
					}
					else
					{
						if( selected )
						{
							Rectangle r = colorPosition;
							ControlPaint.DrawBorder3D( g, r, Border3DStyle.Raised );
							r.Inflate(-SystemInformation.Border3DSize.Width,-SystemInformation.Border3DSize.Height);
							g.FillRectangle( br, r );
						}
						else
						{
							Rectangle r = colorPosition;
							g.FillRectangle( SystemBrushes.Control, r );
							r.Inflate(-SystemInformation.BorderSize.Width,-SystemInformation.BorderSize.Height);
							ControlPaint.DrawBorder3D( g, r, Border3DStyle.Flat );
							r.Inflate(-SystemInformation.BorderSize.Width,-SystemInformation.BorderSize.Height);
							g.FillRectangle( br, r );
						}
					}

					br.Dispose();
					br = null;
				}
			}
		}

		/// <summary>
		/// Layout the color wells in the available space.
		/// </summary>
		private void LayoutColorWells()
		{
			int x = borderSize.Width;
			int y = borderSize.Height;

			foreach( ColorWellInfo c in colorWells )
			{
				c.colorPosition = new Rectangle(x, y, colorWellSize.Width, colorWellSize.Height);

				x += colorWellSize.Width;

				if( x + colorWellSize.Width > ClientRectangle.Width )
				{
					y += colorWellSize.Height;
					x = borderSize.Width;
				}
			}
		}

		/// <summary>
		/// The ColorChangedEvent event handler.
		/// </summary>
		[Browsable(true), Category("ColorPanel")]
		public event ColorChangedEventHandler ColorChanged;
		/// <summary>
		/// 
		/// </summary>
		private void FireColorChanged()
		{
			if( null != pickColor )
			{
				OnColorChanged( new ColorChangedEventArgs( pickColor.Color ) );
			}
		}

		/// <summary>
		/// Raises the ColorChanged event.
		/// </summary>
		/// <param name="e">A ColorChangedEventArgs contains the event data.</param>
		protected virtual void OnColorChanged( ColorChangedEventArgs e )
		{
			if( null != ColorChanged )
			{
				ColorChanged(this, e);
			}
		}

		/// <summary>
		/// Get the color well at the specified point.
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		private ColorWellInfo ColorWellFromPoint( int x, int y )
		{
			int w = ClientRectangle.Width;
			int h = ClientRectangle.Height;

			// could be optimized
			foreach( ColorWellInfo c in colorWells )
			{
				if( c.colorPosition.Contains(x,y) )
				{
					return c;
				}
			}

			return null;
		}

		/// <summary>
		/// Get the first color well with the specified color.
		/// There may be multiple color wells with the same color for custom color palettes.
		/// Note that Color.White != Color.Window even when Color.Window is white!
		/// </summary>
		/// <param name="col"></param>
		/// <returns></returns>
		private ColorWellInfo ColorWellFromColor( Color col )
		{
			foreach( ColorWellInfo c in colorWells )
			{
				if( c.Color == col )
				{
					return c;
				}
			}

			return null;
		}

		/// <summary>
		/// Get the sorted index of the color well (not the original index).
		/// </summary>
		/// <param name="col"></param>
		/// <returns></returns>
		private int IndexFromColorWell( ColorWellInfo col )
		{
			int num_colorWells = colorWells.Length;

			int index = -1;

			for( int i=0; i<num_colorWells; i++ )
			{
				if( colorWells[i] == col )
				{
					index = i;
				}
			}

			return index;
		}

		/// <summary>
		/// Overrides the OnClick event in order to detect user color selection.
		/// </summary>
		/// <param name="e"></param>
		protected override void OnClick(System.EventArgs e)
		{
			base.OnClick(e);

			if( null != currentColor )
			{
				// invalidate previous pick color
				if( null != pickColor )
				{
					Invalidate(pickColor.colorPosition);
				}
				
				// set new pick color
				pickColor = currentColor;

				// invalidate new pick color
				Invalidate(pickColor.colorPosition);

				FireColorChanged();

				//Update();
			}
		}

		/// <summary>
		/// Change the color currently selected.  Does not cause
		/// a ColorChanged event.
		/// </summary>
		/// <param name="newColor"></param>
		private void ChangeColor( ColorWellInfo newColor )
		{
			if( newColor != currentColor )
			{
				if( null != currentColor )
				{
					Invalidate( currentColor.colorPosition );
				}

				currentColor = newColor;

				if( null != currentColor )
				{
					Invalidate( currentColor.colorPosition );

					toolTip.SetToolTip( this, currentColor.Color.Name );
				}
				else
				{
					toolTip.SetToolTip( this, "" );
				}

				Update();
			}
		}

		/// <summary>
		/// Overrides the OnMouseMove event in order to track mouse movement.
		/// </summary>
		/// <param name="e"></param>
		protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
		{
			base.OnMouseMove(e);

			if( !Enabled )
				return;

			Point mousePosition = new Point(e.X,e.Y);

			// Invalidation causes an OnMouseMove event - filter it out so it doesn't
			// interfere with keyboard control
			if( ClientRectangle.Contains(mousePosition) && (lastMousePosition != mousePosition) )
			{
				lastMousePosition = mousePosition;

				ColorWellInfo newColor = ColorWellFromPoint(e.X,e.Y);

				ChangeColor(newColor);
			}
		}

		/// <summary>
		/// Overrides OnMouseLeave in order to detect when the mouse
		/// has left the control.
		/// </summary>
		/// <param name="e"></param>
		protected override void OnMouseLeave(System.EventArgs e)
		{
			base.OnMouseLeave(e);

			if( !Enabled )
				return;

			ColorWellInfo invalidColor = currentColor;
			currentColor = null;

			if( null != invalidColor )
			{
				Invalidate( invalidColor.colorPosition );
				Update();
			}
		}

		/// <summary>
		/// Overrides OnGotFocus so the control can be redrawn with the focus.
		/// </summary>
		/// <param name="e"></param>
		protected override void OnGotFocus(System.EventArgs e)
		{
			base.OnGotFocus(e);

			Refresh();
		}

		/// <summary>
		/// Overrides OnLostFocus so the control can be redrawn without the focus.
		/// </summary>
		/// <param name="e"></param>
		protected override void OnLostFocus(System.EventArgs e)
		{
			base.OnLostFocus(e);

			Refresh();
		}

		/// <summary>
		/// Overrides IsInputKey.<br></br><br></br>
		/// This allows the control to tell the base class that the keys
		/// Keys.Left, Keys.Right, Keys.Up and Keys.Down should cause the OnKeyDown event.
		/// </summary>
		/// <param name="keyData">One of the <c>System.Windows.Forms.Keys</c> values</param>
		/// <returns><B>true</B> if keyData is one of 
		/// Keys.Left, Keys.Right, Keys.Up and Keys.Down.  Otherwise <B>false</B>.</returns>
		protected override bool IsInputKey( System.Windows.Forms.Keys keyData )
		{
			bool bIsInputKey = true;

			switch( keyData )
			{
			case Keys.Left:
				break;
			case Keys.Right:
				break;
			case Keys.Down:
				break;
			case Keys.Up:
				break;
			default:
				bIsInputKey = base.IsInputKey(keyData);
				break;
			}

			return bIsInputKey;
		}

		private void MoveColumn( int index, bool bNext )
		{
			int numColors = colorWells.Length;

			int r = index/columns;
			int c = index - (r*columns);

			int nextIndex = 0;

			if( bNext )
			{
				c++;
				if( c >= columns )
				{
					c = 0;
				}

				nextIndex = r*columns + c;

				if( nextIndex >= numColors )
				{
					nextIndex = r*columns;
				}
			}
			else
			{
				c--;

				if( c < 0 )
				{
					c = columns - 1;
				}

				nextIndex = r*columns + c;

				if( nextIndex >= numColors )
				{
					nextIndex = numColors - 1;
				}
			}

			ChangeColor( colorWells[nextIndex] );
		}

		private void MoveRow( int index, bool bNext )
		{
			int numColors = colorWells.Length;

			int r = index/columns;
			int c = index - (r*columns);

			int nextIndex = 0;

			if( bNext )
			{
				r++;
				if( r >= rows )
				{
					r = 0;
				}

				nextIndex = r*columns + c;

				if( nextIndex >= numColors )
				{
					nextIndex = c;
				}
			}
			else
			{
				r--;

				if( r < 0 )
				{
					r = rows - 1;
				}

				nextIndex = r*columns + c;

				if( nextIndex >= numColors )
				{
					nextIndex = (r-1)*columns + c;
				}
			}

			ChangeColor( colorWells[nextIndex] );
		}

		/// <summary>
		/// Overrides OnKeyDown so that a color may be selected using the keyboard.<br></br><br></br>
		/// Use the keys - Left, Right, Up, Down and Enter.
		/// </summary>
		/// <param name="e"></param>
		protected override void OnKeyDown(System.Windows.Forms.KeyEventArgs e)
		{
			base.OnKeyDown(e);

			if( !Enabled )
				return;

			int index = IndexFromColorWell( (null!=currentColor) ? (currentColor) : (pickColor) );

			switch( e.KeyCode )
			{
			case Keys.Enter:
				if( null != currentColor )
				{
					ColorWellInfo oldColor = pickColor;

					pickColor = currentColor;
					FireColorChanged();

					Invalidate( oldColor.colorPosition );
					Invalidate( currentColor.colorPosition );

					Update();
				}
				break;
			case Keys.Left:
				if( index < 0 )
				{
					// start at the last color
					ChangeColor(colorWells[colorWells.Length-1]);
				}
				else
				{
					MoveColumn( index, false );
				}
				break;
			case Keys.Right:
				if( index < 0 || index > (colorWells.Length-1) )
				{
					// start at the first color
					ChangeColor(colorWells[0]);
				}
				else
				{
					MoveColumn( index, true );
				}
				break;
			case Keys.Down:
				if( index < 0 )
				{
					// start at the first color
					ChangeColor(colorWells[0]);
				}
				else
				{
					MoveRow( index, true );
				}
				break;
			case Keys.Up:
				if( index < 0 )
				{
					// start at the last color
					ChangeColor(colorWells[colorWells.Length-1]);
				}
				else
				{
					MoveRow( index, false );
				}
				break;
			}
		}

		/// <summary>
		/// When the ColorPanel is being resized GetPreferredWidth is called to
		/// determine the preferred width.
		/// For ColorPanel the preferred width is the control's default Width, i.e the control may be resized.
		/// <br></br>
		/// Derived classes, such as ColorPanelWithCapture may override this.
		/// </summary>
		/// <returns></returns>
		protected virtual int GetPreferredWidth()
		{
			return Size.Width;
		}

		/// <summary>
		/// This method is called internally to set the control's size.<br></br>
		/// If the Columns property is 0 then the control fixes it's width to the 
		/// nearest number of columns that fit into the value returned by GetPreferredWidth.<br></br>
		/// If the Columns property is greater than 0 then the control will display that many columns.
		/// </summary>
		protected void AutoSizePanel()
		{
			if( preferredColumns <= 0 )
			{
				int preferredWidth = GetPreferredWidth();

				int w    = preferredWidth - borderSize.Width*2;
				int remw = w % colorWellSize.Width;
				columns  = w/colorWellSize.Width;
				rows     = colorWells.Length/columns + ((colorWells.Length%columns != 0)?1:0);
				int h    = rows*colorWellSize.Height +  borderSize.Height*2;

				if( remw != 0 || h != Size.Height )
				{
					w = preferredWidth - remw;

					this.ClientSize = new Size(w,h);
				}

				LayoutColorWells();
				Refresh();
			}
			else
			{
				int preferred = preferredColumns;

				// if there are less color wells than the number of preferredColumns
				// then use the number of color wells
				if( colorWells.Length < preferredColumns )
				{
					preferred = colorWells.Length;
				}

				columns = preferred;
				int w = preferred * colorWellSize.Width + borderSize.Width * 2;

				rows    = colorWells.Length/columns + ((colorWells.Length%columns != 0)?1:0);
				int h = rows*colorWellSize.Height +  borderSize.Height*2;

				this.ClientSize = new Size(w,h);

				LayoutColorWells();
				Refresh();
			}
		}

		/// <summary>
		/// Overrides OnResize so the control can be auto-sized.
		/// </summary>
		/// <remarks>
		/// The control auto-sizes.  It first fixes the width to the nearest
		/// whole multiple of the color well width, and then fixes the height to
		/// the nearest whole multiple of the color well height.
		/// </remarks>
		/// <param name="e"></param>
		protected override void OnResize(System.EventArgs e)
		{
			base.OnResize(e);

			AutoSizePanel();
		}

		/// <summary>
		/// Overrides OnEnabledChanged so the control can redraw itself 
		/// enabled/disabled.
		/// </summary>
		/// <param name="e"></param>
		protected override void OnEnabledChanged(System.EventArgs e)
		{
			Refresh();
		}


		/// <summary>
		/// Overrides OnPaint so the control can be drawn.
		/// </summary>
		/// <param name="e"></param>
		protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
		{
			foreach( ColorWellInfo c in colorWells )
			{
				c.DrawColorWell(e.Graphics, Enabled, c == currentColor, c == pickColor );
			}

			// draw a border (or not)
			switch( borderStyle )
			{
			case BorderStyle.Fixed3D:
				ControlPaint.DrawBorder3D( e.Graphics, ClientRectangle, Border3DStyle.Sunken );
				break;
			case BorderStyle.FixedSingle:
				ControlPaint.DrawBorder3D( e.Graphics, ClientRectangle, Border3DStyle.Flat );
				break;
			}

			if( Focused && Enabled )
			{
				Rectangle r= ClientRectangle;
				r.Inflate( -borderSize.Width+1, -borderSize.Height+1 );
				ControlPaint.DrawFocusRectangle(e.Graphics,r);
			}

			// call base.OnPaint last so clients can paint over the control if required
			base.OnPaint(e);
		}

		/// <summary>
		/// Override OnSystemColorsChanged to that the System color palette
		/// can be updated when a user modifies the system colors.
		/// </summary>
		/// <param name="e"></param>
		protected override void OnSystemColorsChanged(System.EventArgs e)
		{
			base.OnSystemColorsChanged(e);

			if(colorSet == ColorSet.System)
			{
				// generate new set of system colors
				colorWells = ColorWellInfo.GetColorWells(colorSet, colorSortOrder);
				LayoutColorWells();

				UpdatePickColor();

				FireColorChanged();

				Refresh();
			}
		}

		/// <summary>
		/// Set/get the controls border style.
		/// </summary>
		[Browsable(true), Category("Appearance")]
		[DefaultValue(defaultBorderStyle), Description("Indicates the color panel's border style.")]
		public System.Windows.Forms.BorderStyle BorderStyle
		{
			get
			{
				return borderStyle;
			}
			set
			{
				Utils.CheckValidEnumValue( "BorderStyle", value, typeof(System.Windows.Forms.BorderStyle) );

				if( borderStyle != value )
				{
					borderStyle = value;

					UpdateBorderSize();

					AutoSizePanel();
				}
			}
		}
		/// <summary>
		/// Update the border size values based on the current border style.
		/// </summary>
		private void UpdateBorderSize()
		{
			Size bs = new Size();

			switch( borderStyle )
			{
			case BorderStyle.Fixed3D:
				bs = SystemInformation.Border3DSize;
				break;
			case BorderStyle.FixedSingle:
				bs = SystemInformation.BorderSize;
				break;
			case BorderStyle.None:
				break;
			}
			
			// increase border size by 1,1 to accomodate focus rectangle
			bs.Width++;
			bs.Height++;

			borderSize = bs;
		}

		/// <summary>
		/// Set/get the pick Color.
		/// </summary>
		[Browsable(true), Category("ColorPanel"), Description("Get/set the pick color.")]
		public System.Drawing.Color Color
		{
			get
			{
				if( pickColor != null )
				{
					return pickColor.Color;
				}
				else
				{
					return defaultColor;
				}
			}
			set
			{
				if( ((pickColor != null) && ( pickColor.Color != value )) || (pickColor == null) )
				{
					UpdatePickColor(value);

					Refresh();
				}
			}
		}

		/// <summary>
		/// Design time support to reset the Color property to it's default value.
		/// </summary>
		public void ResetColor()
		{
			Color = defaultColor;
		}

		/// <summary>
		/// Design time support to indicate whether the Color property should be serialized.
		/// </summary>
		/// <returns></returns>
		public bool ShouldSerializeColor()
		{
			if( pickColor != null )
			{
				return pickColor.Color != defaultColor;
			}
			else
			{
				return false;
			}
		}

		private void UpdatePickColor()
		{
			if( pickColor != null )
			{
				UpdatePickColor( pickColor.Color );
			}
			else
			{
				UpdatePickColor( defaultColor );
			}
		}

		private void UpdatePickColor( Color c )
		{
			pickColor = ColorWellFromColor( c );

			// if not found then try to find the default color
			if( null == pickColor )
			{
				pickColor = ColorWellFromColor( defaultColor );
			}

			// if still no pickColor then use first in palette 
			if( null == pickColor )
			{
				pickColor = colorWells[0];
			}
		}

		/// <summary>
		/// Set/get the set of colors displayed by the control.<br></br><br></br>
		/// See <see cref="PJLControls.ColorSet">ColorSet</see>.
		/// </summary>
		[Browsable(true)]
		[Category("ColorPanel")]
		[DefaultValue(defaultColorSet)]
		[Description("Get/set the palette of colors to be displayed.")]
		public PJLControls.ColorSet ColorSet
		{
			get
			{
				return colorSet;
			}
			set
			{
				Utils.CheckValidEnumValue( "ColorSet", value, typeof(PJLControls.ColorSet) );

				Trace.WriteLine( string.Format( "Set colorSet={0}, current value={1}", value, colorSet ) );

				if( value != colorSet )
				{
					Trace.WriteLine( string.Format("Set ColorSet {0}", value) );

					if( value == ColorSet.Custom )
					{
						colorWells = ColorWellInfo.GetCustomColorWells( customColors, colorSortOrder );
					}
					else
					{
						colorWells = ColorWellInfo.GetColorWells( value, colorSortOrder);
					}

					colorSet = value;
					
					UpdatePickColor();

					FireColorChanged();

					AutoSizePanel();
				}
			}
		}

		/// <summary>
		/// Set/get the size of the color wells.
		/// </summary>
		[Browsable(true)]
		[Category("ColorPanel")]
		[Description("Set/get the size of the color wells displayed in the color panel.")]
		public System.Drawing.Size ColorWellSize
		{
			get
			{
				return this.colorWellSize;
			}
			set
			{
				if( value.Height > SystemInformation.Border3DSize.Height*2+2 &&
					value.Width > SystemInformation.Border3DSize.Width*2+2 )
				{
					if( value != this.ColorWellSize )
					{
						Trace.WriteLine( string.Format("Set ColorWellSize {0}", value) );

						this.colorWellSize = value;

						AutoSizePanel();
					}
				}
				else
				{
					Size min = new Size(
						SystemInformation.Border3DSize.Height*2+2,
						SystemInformation.Border3DSize.Width*2+2 );

					string msg = string.Format( "The color well size must be at least {0}.", min );

					throw new ArgumentOutOfRangeException( "ColorWellSize", value, msg );
				}
			}
		}

		/// <summary>
		/// Design time support to reset the ColorWellSize property to it's default value.
		/// </summary>
		public void ResetColorWellSize()
		{
			ColorWellSize = defaultColorWellSize;
		}

		/// <summary>
		/// Design time support to indicate whether the ColorWellSize property should be serialized.
		/// </summary>
		/// <returns></returns>
		public bool ShouldSerializeColorWellSize()
		{
			return colorWellSize != defaultColorWellSize;
		}

		/// <summary>
		/// Set/get the order in which colors in the palette should be sorted.<br></br><br></br>
		/// See <see cref="PJLControls.ColorSortOrder">ColorSortOrder</see>.
		/// </summary>
		[Browsable(true), Category("ColorPanel"), DefaultValue(defaultColorSortOrder)]
		[Description("Get/set the order that the colors in the color palette are displayed.")]
		public PJLControls.ColorSortOrder ColorSortOrder
		{
			get
			{
				return colorSortOrder;
			}
			set
			{
				Utils.CheckValidEnumValue( "ColorSortOrder", value, typeof(PJLControls.ColorSortOrder) );

				if( value != colorSortOrder )
				{
					Trace.WriteLine( string.Format("Set ColorSortOrder {0}", value) );

					ColorWellInfo.SortColorWells(colorWells, value);
					LayoutColorWells();
					colorSortOrder = value;

					Refresh();
				}
			}
		}

		/// <summary>
		/// Set/get the number of preferred columns.<br></br><br></br>
		/// If you set this value less than or equal to 0, you may resize the control.<br></br>
		/// If you set this greater that 0 the control will have a fixed width
		/// of 'Columns' unless 
		/// there are fewer colors than 'Columns' in the palette in which case it will display all colors in
		/// a single row.
		/// </summary>
		[Browsable(true), Category("ColorPanel"), DefaultValue(defaultPreferredColumns)]
		[Description("Set/get the number of preferred columns.  If set to 0 the control can be manually resized.")]
		public int Columns
		{
			get
			{
				return preferredColumns;
			}
			set
			{
				if( value > 0 )
				{
					if( value <= colorWells.Length )
					{
						preferredColumns = value;
					}
					else
					{
						preferredColumns = colorWells.Length;
					}
				}
				else
				{
					preferredColumns = 0;
				}

				AutoSizePanel();
			}
		}

		/// <summary>
		/// Set/get the custom color palette to be displayed.
		/// </summary>
		[Browsable(true)]
		[Category("ColorPanel")]
		[Description("Set/get the custom color palette.")]
		public Color[] CustomColors
		{
			get
			{
				return customColors;
			}
			set
			{
				if( value == null || value.Length < 1 )
				{
					value = new Color[] { Color.White };
				}

				customColors = value;

				if( colorSet == ColorSet.Custom )
				{
					// apply custom colors
					colorWells = ColorWellInfo.GetCustomColorWells(customColors, colorSortOrder);

					UpdatePickColor();

					LayoutColorWells();
					AutoSizePanel();
				}
			}
		}

		/// <summary>
		/// Design time support to reset the CustomColors property to it's default value.
		/// </summary>
		public void ResetCustomColors()
		{
			CustomColors = ColorPanel.DefaultCustomColors();
		}

		/// <summary>
		/// Helper for ColorPicker/ColorPanel
		/// </summary>
		/// <returns></returns>
		internal static Color[] DefaultCustomColors()
		{
			return new Color[]
			{ 
				Color.White, Color.White, Color.White, Color.White, Color.White, Color.White, Color.White, Color.White,
				Color.White, Color.White, Color.White, Color.White, Color.White, Color.White, Color.White, Color.White,
				Color.White, Color.White, Color.White, Color.White, Color.White, Color.White, Color.White, Color.White,
				Color.White, Color.White, Color.White, Color.White, Color.White, Color.White, Color.White, Color.White
			};
		}

		/// <summary>
		/// Design time support to indicate whether the CustomColors property should be serialized.
		/// </summary>
		public bool ShouldSerializeCustomColors()
		{
			return ColorPanel.ShouldSerializeCustomColors(customColors);
		}

		/// <summary>
		/// Helper for ColorPicker/ColorPanel
		/// </summary>
		/// <returns></returns>
		internal static bool ShouldSerializeCustomColors( Color[] customColors )
		{
			bool bShouldSerialize = (customColors.Length != 32);

			if( !bShouldSerialize )
			{
				foreach( Color c in customColors )
				{
					if( c != Color.White )
					{
						bShouldSerialize = true;
						break;
					}
				}
			}

			return bShouldSerialize;
		}
	}

    /// <summary>
    /// This represents the Z Axis of an RGB color cube.
    /// </summary>
    public enum ZAxis
    {
        /// <summary>The Z Axis is red</summary>
        red,
        /// <summary>The Z Axis is blue</summary>
        blue,
        /// <summary>The Z Axis is green</summary>
        green
    }

    /// <summary>Specifies the set of colors to be displayed in the color palette.</summary>
    /// <remarks><I>If any other useful sets of colors are known please let me know.</I></remarks>
    public enum ColorSet
    {
        /// <summary>Show the system color palette.</summary>
        System,
        /// <summary>Show the web color palette.</summary>
        Web,
        /// <summary>Show user defined color palette.</summary>
        Custom
    }

    /// <summary>
    /// Specifies the order the colors contained in the selected palette should be sorted.
    /// </summary>
    /// <remarks><I>If any other useful sort orders are known please let me know.</I></remarks>
    public enum ColorSortOrder
    {
        /// <summary>Sort by name.</summary>
        Name,
        /// <summary>Sort by brightness.</summary>
        Brightness,
        /// <summary>Sort by hue.</summary>
        Hue,
        /// <summary>Sort by saturation.</summary>
        Saturation,
        /// <summary>Sort by linear distance from the origin (0,0,0) of the RGB color space.</summary>
        Distance,
        /// <summary>
        /// Colors are sorted according to their original order.<br></br>
        /// For System and Web color sets this is the same as sort by name.<br></br>
        /// For custom colors it will be the order of the colors in the array assigned to the CustomColors property
        /// </summary>
        Unsorted
    }

    /// <summary>
    /// Provides data for the <c>ColorChanged</c> event.
    /// </summary>
    /// <remarks>
    /// The ColorChanged event occurs when a user selects a new color in the
    /// ColorPicker, ColorPanel or CustomColorPicker controls.
    /// </remarks>
    public class ColorChangedEventArgs : System.EventArgs
    {
        private System.Drawing.Color color;

        /// <summary>
        /// Initializes a new instance of the <c>ColorChangedEventArgs</c> class.
        /// </summary>
        /// <param name="color">
        /// The selected color.
        /// </param>
        public ColorChangedEventArgs(System.Drawing.Color color)
        {
            this.color = color;
        }

        /// <summary>
        /// Gets the selected color.
        /// </summary>
        public System.Drawing.Color Color
        {
            get
            {
                return this.color;
            }
        }
    }

    /// <summary>
    /// The ColorChangedEvent delegate.
    /// </summary>
    public delegate void ColorChangedEventHandler(object sender, ColorChangedEventArgs e);

}
