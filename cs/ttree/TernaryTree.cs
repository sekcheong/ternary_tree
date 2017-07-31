using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ttree
{
	public class TernaryTree
	{	
		TernaryTreeNode _root = null;
		int _nodeCount = 0; 

		public TernaryTreeNode Insert(string key, object data)
		{			
			if (_root == null) {
				_root = InsertPrivate(null, key, data, 0);
				return _root;
			}
			return InsertPrivate(_root, key, data, 0);			
		}

		public TernaryTreeNode Insert(TernaryTreeNode n, string key, object data)
		{
			return InsertPrivate(n, key, data, 0);
		}

		private TernaryTreeNode InsertPrivate(TernaryTreeNode n, string key, object data, int keyPos)
		{
			if (n == null) {
				n = new TernaryTreeNode();
				_nodeCount++;
				n.SplitChar = key[keyPos];
				n.Left = n.Right = n.Center =  null;				
				if (keyPos == key.Length - 1) {
					n.Data = data;					
				}
			}
			if (key[keyPos] < n.SplitChar) {
				n.Left = InsertPrivate(n.Left, key, data, keyPos);
			}
			else if (key[keyPos] == n.SplitChar) {
				keyPos++;
				if (keyPos < key.Length) {
					n.Center = InsertPrivate(n.Center, key, data, keyPos);
				}
				else {
					n.Data = data;
				}
			}
			else {
				n.Right = InsertPrivate(n.Right, key, data, keyPos);
			}
			return n;
		}

		public TernaryTreeNode Root
		{
			get { return _root; }
		}

		public int NodeCount
		{
			get { return _nodeCount; }
		}

		public TernaryTreeNode Search(string key)
		{
			TernaryTreeNode p;
			int index = 0;
			p = _root;
			while (p != null) {
				if (key[index] < p.SplitChar) {
					p = p.Left;
				}
				else if (key[index] == p.SplitChar) {
					if (index == key.Length - 1) {
						if (p.HasData) {
							return p;
						}
						else {
							return null;
						}
					}
					p = p.Center;
					index = index + 1;
				}
				else {
					p = p.Right;
				}				
			}
			return null;
		}

		public List<TernaryTreeNode> Match(string key)
		{
			List<TernaryTreeNode> matches = new List<TernaryTreeNode>();

			return matches;
		}

	}
}
