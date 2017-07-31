using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ttree
{
	public class TernaryTreeNode
	{
		char _split;
		object _data = null;
		bool _hasData = false;

		TernaryTreeNode _left = null;
		TernaryTreeNode _right = null;
		TernaryTreeNode _center = null;

		public char SplitChar
		{
			get { return _split; }
			set { _split = value; }
		}


		public TernaryTreeNode Left
		{
			get { return _left; }
			set { _left = value; }
		}

		public TernaryTreeNode Right
		{
			get { return _right; }
			set { _right = value; }
		}

		public TernaryTreeNode Center
		{
			get { return _center; }
			set { _center = value; }
		}

		public bool HasData
		{
			get { return _hasData; }
			set { _hasData = value; }
		}

		public object Data
		{
			get { return _data; }
			set {
				_hasData = true;
				_data = value; 
			}
		}
		
	}
}
