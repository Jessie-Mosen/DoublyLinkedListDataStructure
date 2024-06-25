using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Globalization;
using System.Text;

namespace Assessment2DLList
{
    internal class DLList
    {
        public Node Head { get; set; }
        public Node Tail { get; set; }
        public Node Current { get; set; }
        public int Counter { get; set; }

        public DLList()
        {
            Head = null;
            Tail = null;
            Current = null;
            Counter = 0;
        }
        private void InsertAtFront(Node node)
        {
            //check if the list is null
            if (Head == null)
            {
                Head = node;
                Tail = node;
                Current = node;
            }
            else
            {
                //Attach the list to the new Node
                node.Next = Head;
                Head.Prev = node;

                //reassign The Head to the new to keep at top of stack
                Head = node;
                Current = node;
            }
            Counter++;
        }
        private void InsertAtRear(Node node)
        {
            if (Head == null)
            {
                Head = node;
                Tail = node;
                Current = node;
            }
            else
            {
                //insert node at the end of the list
                Tail.Next = node;
                node.Prev = Tail;

                //Reassign the tail to the new node 
                Tail = node;
                Current = node;
            }
            Counter++;

        }
        public void AddToEnd(string word)
        {
            Node temp = new Node(word);
            InsertAtRear(temp);
        }
        public void AddToFront(string word)
        {
            Node temp = new Node(word);
            InsertAtFront(temp);
        }
        private bool InsertBefore(Node node, Node targetNode)
        {
            bool inserted = false;
            if (Head == null)
            {
                //list is empty
                return inserted;
            }
            if (targetNode.Word == Head.Word)
            {
                InsertAtFront(node);
                inserted = true;
            }
            else
            {
                //list is not empty, set the Current to find the target Node
                Current = Head;
                while (Current != null && !inserted)
                {
                    if (Current.Word == targetNode.Word)
                    {
                        node.Next = Current;
                        node.Prev = Current.Prev;
                        Current.Prev.Next = node;
                        Current.Prev = node;
                        inserted = true;
                        Counter++;
                    }
                    else
                    {
                        Current = Current.Next;
                    }
                }
            }
            return inserted;
        }

        //add delete methods
        private Node DeleteAtFront()  //delete the front and only the front 
        {
            if (Head == null)
            {
                return null;
            }
            else
            {
                Node nodeToRemove = new Node();
                nodeToRemove = Head;

                Head = Head.Next;
                Head.Prev = null;
                Current = Head;
                Counter--;
                return nodeToRemove;
            }
        }
        private Node DeleteAtEnd()  //delete only the end node
        {
            if (Head == null)
            {
                return null;
            }
            else
            {
                Node nodeToRemove = new Node();
                nodeToRemove = Tail;

                Tail = Tail.Prev;
                Tail.Next = null;
                Current = Tail;
                Counter--;

                return nodeToRemove;
            }
        }
        private Node DeleteNode(Node nodeToDelete)   //Delete any node in the list apart from the end and front
        {
            Node NodeToRemove = null;
            if (Head == null)
            {
                NodeToRemove = null;
            }
            else if (Head.Word == nodeToDelete.Word)
            {
                NodeToRemove = Head;
                DeleteAtFront();
            }
            else if (Tail.Word == nodeToDelete.Word)
            {
                NodeToRemove = Tail;
                DeleteAtEnd();
            }
            else
            {
                Current = Head;
                bool deleted = false;
                while (Current != null && !deleted)
                {
                    if (Current.Word == nodeToDelete.Word)
                    {
                        NodeToRemove = Current;
                        Current.Next.Prev = Current.Prev;
                        Current.Prev.Next = Current.Next;
                        deleted = true;
                        Counter--;
                    }
                    Current = Current.Next;
                }

            }
            return NodeToRemove;
        }
        public string RemoveNode(string word)   //ui call for delete node
        {
            Node nodeToRemove = new Node(word);
            Node targetNode = nodeToRemove;
            nodeToRemove = DeleteNode(nodeToRemove);

            if (nodeToRemove != null)
            {
                return "Target " + targetNode.Word + " found, Node: " + nodeToRemove.Word + " Removed"; //Node to remove is showing me the type not the word deleted
            }
            else
            {
                return "Target " + targetNode.Word + " Not found, or empty list";
            }

        }
        //add search method
        private int Search(Node nodeToFind)
        {
            int pos = 0;

            if (Head == null)
            {
                return pos;
            }
            else
            {
                Current = Head;
                bool found = false;
                while (Current != null && !found)
                {
                    if (Current.Word == nodeToFind.Word)
                    {
                        found = true;
                    }
                    else
                    {
                        Current = Current.Next;
                    }
                    pos++;
                }
                if (!found)
                {
                    pos = 0;
                }
            }
            return pos;
        }
        public string Find(string word)
        {
            int pos = 0;
            Node nodeTofind = new Node(word);

            pos = Search(nodeTofind);

            if (pos >= 1 && pos <= Counter)
            {
                return "Target: " + word.ToString() + ", Node found at postion: " + pos.ToString();
            }
            else
            {
                return "Target: " + word.ToString() + ", Node not found, OR List is empty ";
            }
        }

        //add UI call for Search or find method
        public string ToPrint()
        {
            StringBuilder sb = new StringBuilder();
            if (Head == null)
            {
                return "Empty List";
            }
            else
            {
                Node current = Head;
                while (current != null)
                {
                    sb.Append(current.ToPrint()).Append("\n");
                    current = current.Next;
                }
            }
            return sb.ToString();
        }
    }
}

   
