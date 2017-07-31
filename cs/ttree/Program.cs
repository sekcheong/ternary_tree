using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ttree
{
	public class Program
	{
		static void InsertHelper(TernaryTree t, string[] data, int low, int height) {
			if (low > height) {
				return;
			}
			if (low == height) {
				t.Insert(data[low], null);
				return;
			}
			else {
				int m = (height + low) / 2;
				t.Insert(data[m], null);
				InsertHelper(t, data, low, m - 1);
				InsertHelper(t, data, m + 1, height);
			}
		}


		static void InsertHelper(TernaryTree t, List<string> data, int low, int height)
		{
			if (low > height) {
				return;
			}
			if (low == height) {
				t.Insert(data[low], null);
				return;
			}
			else {
				int m = (height + low) / 2;
				t.Insert(data[m], null);
				InsertHelper(t, data, low, m - 1);
				InsertHelper(t, data, m + 1, height);
			}
		}

		static TernaryTree LoadTreeFromDict(string fileName, out List<string> words)
		{
			Stream s = new FileStream(fileName, FileMode.Open);
			StreamReader r = new StreamReader(s);
			TernaryTree t = new TernaryTree();
			words = new List<string>();
			string line;
			while ((line = r.ReadLine()) != null) {
				words.Add(line.Trim());
			}
			InsertHelper(t, words, 0, words.Count-1);
			return t;
		}

		static TernaryTree LoadTreeFromDict2(string fileName, out List<string> words)
		{
			Stream s = new FileStream(fileName, FileMode.Open);
			StreamReader r = new StreamReader(s);
			TernaryTree t = new TernaryTree();
			words = new List<string>();
			string line;
			while ((line = r.ReadLine()) != null) {
				words.Add(line.Trim());				
			}

			for (int i = words.Count - 1; i > 0; i--) {
				t.Insert(words[i], null);
			}

			
			return t;
		}

		static void VerifyTree(TernaryTree t, List<string> words)
		{
			TernaryTreeNode n;			
			foreach (string word in words) {
				n = t.Search(word);
				if (n == null) {
					Console.WriteLine(word + " NOT found!");
				}
			}
		}


		static int MaxTreeHeight(TernaryTreeNode root)
		{
			if (root == null) { return 0; }
			if (root.Left == null && root.Right == null && root.Center == null) { return 1; }
			int leftH, rightH, centerH;
			leftH = MaxTreeHeight(root.Left);
			rightH = MaxTreeHeight(root.Right);
			centerH = MaxTreeHeight(root.Center);
			int max;
			max=leftH;
			if (centerH > max) max = centerH;
			if (rightH > max) max = rightH;
			return 1 + max;
		}


		static void Main(string[] args)
		{
			List<string> words;
			TernaryTree t = LoadTreeFromDict2(@"C:\EpicSource\ttree\dictwords.txt", out words);
			Console.WriteLine("Tree Height: " +  MaxTreeHeight(t.Root) + "," + t.NodeCount);
			//VerifyTree(t, words);
			//TernaryTree t = new TernaryTree();
			//string[] data = new string[12];
			//data[0] = "as";
			//data[1] = "at";
			//data[2] = "be";
			//data[3] = "by";
			//data[4] = "he";
			//data[5] = "in";
			//data[6] = "is";
			//data[7] = "it";
			//data[8] = "of";
			//data[9] = "on";
			//data[10] = "or";
			//data[11] = "to";
			//InsertHelper(t, data, 0, data.Length - 1);
			//t.Insert("izz",null);
			//t.Search("iz");
			//foreach (string s in data) {
			//  TernaryTreeNode n = t.Search(s);
			//  if (n != null) {
			//    Console.WriteLine("Found: " + s);
			//  }
			//}
		}
	}
}
