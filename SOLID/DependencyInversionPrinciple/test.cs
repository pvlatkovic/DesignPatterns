using Xunit;

namespace SOLID.DependencyInversion
{
	public class Test
	{
		[Fact]
		public void FindAllChildrenOfAParent()
		{
			//find all children of a parent
			var adultAna 	= new Person() { Name = "Ana"};
			var adultPeca 	= new Person() { Name = "Peca"};

			var childVeronica 	= new Person() { Name = "Veronika"};
			var childMarija 	= new Person() { Name = "Marija"};
			var childMilos 		= new Person() { Name = "Milos"};

			var relationships = new Relationships();

			var childrenOfAna = new Person[3] { childVeronica, childMarija, childMilos};
			foreach(var child in childrenOfAna)
				relationships.AddParentChild(adultAna, child);

			relationships.AddParentChild(adultPeca, childMarija);
			relationships.AddParentChild(adultPeca, childMilos);


			var research = new Research(relationships);
			var childrenOfAnaFound = research.FindAllChildrenOf(adultAna);

			var isAllChildrenPresent = true;

			foreach(var child in childrenOfAna)
			{
				var isChildFound = false;
				foreach(var childFromResearch in childrenOfAnaFound)
				{
					if(childFromResearch.Name == child.Name)
					{
						isChildFound = true;
						break;
					}
				}
				if(!isChildFound)
				{
					isAllChildrenPresent = false;
					break;
				}
			}

			Assert.True(isAllChildrenPresent);

			//count children from result, there should be exactly childrenOfAna.Count
			var countChildrenOfAnaFound = 0;
			foreach (var c in childrenOfAnaFound)
				countChildrenOfAnaFound++;
			
			Assert.True(countChildrenOfAnaFound == childrenOfAna.Length);

			//Console.WriteLine($"children of Ana: {Environment.NewLine}{String.Join(Environment.NewLine, childrenOfAnaFound)}");
		}
	}
}