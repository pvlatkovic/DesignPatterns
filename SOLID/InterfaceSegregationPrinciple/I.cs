using System;

namespace SOLID.InterfaceSagregation
{
	class I // interface-segregation principle
	{
		static void MainX(string[] args)
		{
		}

		public class Document
		{

		}

		public interface IMachine
		{
			void Print(Document d);
			void Scan(Document d);
			void Fax(Document d);
		}

		public class MultiFunctionPrinter : IMachine
		{
			public void Fax(Document d)
			{
				//
			}

			public void Print(Document d)
			{
				//
			}

			public void Scan(Document d)
			{
				//
			}
		}

		public class Printer : IMachine
		{
			public void Fax(Document d) // forsing to implement something we do not need, and it will throw an error
			{
				throw new NotImplementedException();
			}

			public void Print(Document d)
			{
				// ok, do some printing
			}

			public void Scan(Document d) // forsing to implement something we do not need, and it will throw an error
			{
				throw new NotImplementedException();
			}
		}

		// INSTEAD

		public interface IPrint
		{
			void Print(Document d);
		}

		public interface IScan
		{
			void Scan(Document d);
		}

		public interface IFax
		{
			void Fax(Document d);
		}

		// THEN

		public interface IMachinePrintScan : IPrint, IScan
		{
			
		}

		// and implement
		public class MultiPrinterScanner : IMachinePrintScan
		{
			private IPrint _printer;
			private IScan _scanner;
			public MultiPrinterScanner(IPrint printer, IScan scanner)
			{
				_scanner = scanner;
				_printer = printer;
			}
			public void Print(Document d)
			{
				_printer.Print(d);
			}

			public void Scan(Document d)
			{
				_scanner.Scan(d);
			}
		}
	}
}