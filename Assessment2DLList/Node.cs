using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment2DLList
{
    internal class Node
    {
        public string Word { get; set; }
        public Node Next { get; set; }
        public Node Prev { get; set; }

        public Node()
        {
            Next = null;
            Prev = null;
            Word = "0";
        }
        public Node(string Word)
        {
            this.Word = Word;
            Next = null;
            Prev = null;
        }
        public string ToPrint()
        {
            return Word;
        }
    }
}
