using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt1_Wojciechowski48655 {
	class Program {
		static void Main(string[] args) {
			var myString = "Hey there" + Environment.NewLine + "How are you doing?";

			foreach (var character in myString) {
				Console.Write(character);
				System.Threading.Thread.Sleep(30);
			}
			Console.WriteLine();
			Console.ReadLine();
		}
	}
}
