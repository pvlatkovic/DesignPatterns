using System;
using System.Collections.Generic;

namespace SOLID.LiskovSubstitute
{
	class L // Liskov substitue principle
	{
		public static int Area(Rectangle r) => r.Width * r.Height;
	}

	// virtual/override, walk over the virtual function table (check for virtual) if found then execute

	public class Square : Rectangle 
	{
		public override int Width 
		{
			set { base.Width = value; base.Height = value; }
		}

		public override int Height 
		{
			set { base.Width = value; base.Height = value; }
		}
	}

	public class Rectangle
	{
		public virtual int Width { get; set; } // without virtual we need to use 'new' while defining the width/height for square.
		public virtual int Height { get; set; }

		public Rectangle()
		{
		}

		public Rectangle(int width, int height)
		{
			Width = width;
			Height = height;
		}

		public override string ToString()
		{
			return $"{nameof(Width)}: {Width}, {nameof(Height)}: {Height}";
		}
	}
}