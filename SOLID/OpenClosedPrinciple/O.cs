using System;
using System.Collections.Generic;

namespace SOLID.OpenClosed
{
	// open-closed principle, open for extension close for change (ProductFilter)

	public enum ColorEnum { red, green, blue };
	public enum SizeEnum { small, medium, big, huge};

	public class Product
	{
		public string Name { get; set; }
		public ColorEnum Color {get; set;}
		public SizeEnum Size { get; set;}

		public override string ToString()
		{
			return Name;
		}
	}

	public interface ISpecification<T>
	{
		bool IsSatisfied(T t);
	}

	public interface IFilter<T>
	{
		IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> specification);
	}

	public class ColorSpecification : ISpecification<Product>
	{
		private ColorEnum _color;
		public ColorSpecification(ColorEnum color)
		{
			_color = color;
		}

		public bool IsSatisfied(Product product)
		{
			return product != null && product.Color == _color;
		}
	}

	public class SizeSpecification : ISpecification<Product>
	{
		private SizeEnum _size;
		public SizeSpecification(SizeEnum size)
		{
			_size = size;
		}

		public bool IsSatisfied(Product product)
		{
			return product != null && product.Size == _size;
		}
	}

	public class AndSpecification : ISpecification<Product>
	{
		private ISpecification<Product> _spec1, _spec2;
		public AndSpecification(ISpecification<Product> spec1, ISpecification<Product> spec2)
		{
			_spec1 = spec1;
			_spec2 = spec2;
		}
		public bool IsSatisfied(Product product)
		{
			return _spec1.IsSatisfied(product) && _spec2.IsSatisfied(product);
		}
	}

	public class ProductFilter : IFilter<Product>
	{
		public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> specification)
		{
			foreach(var item in items)
			{
				if(specification.IsSatisfied(item))
					yield return item;
			}
		}
	}

}