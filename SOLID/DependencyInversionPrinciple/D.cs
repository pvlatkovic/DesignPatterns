using System.Collections.Generic;

namespace SOLID.DependencyInversion
{
	public enum RelationEnum { parent, child, sibling}

	// Research class is higher level in class hierarchy
	public class Research
	{
		private Relationships _relationships;
		public Research(Relationships relationships)
		{
			_relationships = relationships;
		}

		public IEnumerable<Person> FindAllChildrenOf(Person parent)
		{
			// find all Ana's children

			// 1. metod 1
			// expose private _relationships._relations as public, wich is baaaad
			// ...

			// 2. method 2
			return _relationships.FindAllChildrenOf(parent.Name);
		}
	}

	public class Person
	{
		public string Name { get; set; }

		public override string ToString()
		{
			return Name;
		}
	}

	public class Relationships : IRelationshipBrowser
	{
		private List<(Person, RelationEnum, Person)> _relations { get; set;}

		public Relationships()
		{
			_relations = new List<(Person, RelationEnum, Person)>();
		}

		public void AddParentChild(Person parent, Person child)
		{
			_relations.Add((parent, RelationEnum.parent, child));
			_relations.Add((child, RelationEnum.child, parent));
		}

		public IEnumerable<Person> FindAllChildrenOf(string name)
		{
			foreach(var relation in _relations)
			{
				if (relation.Item1.Name == name && relation.Item2 == RelationEnum.parent)
					yield return relation.Item3;
			}
		}
	}

	interface IRelationshipBrowser
	{
		IEnumerable<Person> FindAllChildrenOf(string name); 
		//IEnumerable<Person> FindAllParentsOf(Person person);
	}
}