using System;
using Xunit;

namespace SOLID.SingleResponsibility
{
	public class Test
	{
		// Actualy by removing persistance from Journal class we do not have much to 
		// test regarding single responsibility principle. At least I cannot devise one :|
		// I'll test persist to file functionality and some journal functionality, just for fun :)
		[Fact]
		public void SortOfATest() 
        {
			var journalText1 = "today I programmed";
			var journalText2 = "today I did not run";

            var journal = new Journal();
            journal.AddEntry(journalText1);
            journal.AddEntry(journalText2);

            var filename = "c:\\temp\\journal.txt";
            var persistance  = new Persistance();

            persistance.SaveToFile(filename, journal.ToString());

            var journalNew = new Journal(persistance.LoadFromFile(filename));

            Assert.True(journalNew.ToString() == journal.ToString());
			Assert.True(journalNew.AddEntry("Test entry") == 2);
        }
	}
}