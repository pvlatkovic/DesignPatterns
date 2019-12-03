using Xunit;

namespace SOLID.LiskovSubstitute
{
	public class Test
	{
		[Fact]
		public void CalculateAreaOfRectangleInitiatedAsSquare()
		{
			Rectangle square = new Square();
			square.Width = 4;

			var area = L.Area(square);
			Assert.True(area == 16);
		}
	}
}