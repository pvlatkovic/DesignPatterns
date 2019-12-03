using System;
using Xunit;

namespace SOLID.OpenClosed
{
	public class Test
	{
		[Fact]
		public void AgregateFiltersTest()
		{
			var apple = new Product() { Name = "apple", Size = SizeEnum.small, Color = ColorEnum.green};
			var book = new Product() { Name = "book", Size = SizeEnum.medium, Color = ColorEnum.blue};
			var car = new Product() { Name = "Tesla S", Size = SizeEnum.big, Color = ColorEnum.blue};
			var rocket = new Product() { Name = "Apolo 5", Size = SizeEnum.huge, Color = ColorEnum.red};
			var items = new Product[] { apple, book, car, rocket};
			
			var filter = new ProductFilter();
			var colorBlueSpecification = new ColorSpecification(ColorEnum.blue);
			var sizeBigSpecification = new SizeSpecification(SizeEnum.big);

			// We did not add third specification for big and blue items
			// but used existing ones to agregate result
			var bigBlueSpecification = new AndSpecification(colorBlueSpecification, sizeBigSpecification); 

			
			var blueItems = filter.Filter(items, colorBlueSpecification);
			var bigItems = filter.Filter(items, sizeBigSpecification);
			var bigBlueItems = filter.Filter(items, bigBlueSpecification);

			//now lets test the results
			var isAllBlue = true;
			var enumerator = blueItems.GetEnumerator();
			while(enumerator.MoveNext())
			{
				if(enumerator.Current.Color != ColorEnum.blue)
					isAllBlue = false;
					break;
			}
			Assert.True(isAllBlue);

			var isAllBig = true;
			enumerator = bigItems.GetEnumerator();
			while(enumerator.MoveNext())
			{
				if(enumerator.Current.Size != SizeEnum.big)
					isAllBig = false;
					break;
			}
			Assert.True(isAllBig);

			var isAllBigAndBlue = true;
			enumerator = bigBlueItems.GetEnumerator();
			while(enumerator.MoveNext())
			{
				if(enumerator.Current.Size != SizeEnum.big || enumerator.Current.Color != ColorEnum.blue)
					isAllBigAndBlue = false;
					break;
			}
			Assert.True(isAllBigAndBlue);
		}
	}
}

// it is always nice to actualy see the results :-)

// Console.WriteLine($"blue items: \n{string.Join(Environment.NewLine, filter.Filter(items, colorSpecification))}");
// Console.WriteLine($"big items: \n{string.Join(Environment.NewLine, filter.Filter(items, sizeSpecification))}");
// Console.WriteLine($"big & blue items: \n{string.Join(Environment.NewLine, filter.Filter(items, bigBlueSpecification))}");
