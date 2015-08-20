using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Stretch Goals: Using Generics, which would include implementing GetType() http://msdn.microsoft.com/en-us/library/system.object.gettype(v=vs.110).aspx
namespace SinglyLinkedLists
{
    public class SinglyLinkedListNode : IComparable
    {
        // Used by the visualizer.  Do not change.
        public static List<SinglyLinkedListNode> allNodes = new List<SinglyLinkedListNode>();

        // READ: http://msdn.microsoft.com/en-us/library/aa287786(v=vs.71).aspx
        private SinglyLinkedListNode next;
        public SinglyLinkedListNode Next
        {
            get { return next; }
            set
            {
                if (this == value || value == null){
                    throw new ArgumentException();
                }

                this.next = value;
            }
        }

        private string value; // same as using this.value
        // Value is a property -- Fix the getter
        public string Value 
        {
            get { return value; }
            set
            {
                this.value = value;
            }
        }

        public static bool operator <(SinglyLinkedListNode node1, SinglyLinkedListNode node2)
        {
            // This implementation is provided for your convenience.
            return node1.CompareTo(node2) < 0;
        }

        public static bool operator >(SinglyLinkedListNode node1, SinglyLinkedListNode node2)
        {
            // This implementation is provided for your convenience.
            return node1.CompareTo(node2) > 0;
        }

        public SinglyLinkedListNode(string value)
        {
            //throw new NotImplementedException();
            this.value = value;

            // Undeclared data members default to null, but...
            this.next = null;

            // Used by the visualizer:
            allNodes.Add(this);
        }

        // READ: http://msdn.microsoft.com/en-us/library/system.icomparable.compareto.aspx
        public int CompareTo(Object obj)
        {
            /* this > null so, if comparing to null and something exists, == 1*/ 
            SinglyLinkedListNode other_node = obj as SinglyLinkedListNode;
            if ( other_node == null)
            {
                return 1;
            } else {
                return this.value.CompareTo(other_node.Value);
            }
        }

        public bool IsLast()
        {
            /* this makes the test pass
            if (this.next == null){
                return true;
            } else {
                return false;
            };*/

            /* Refactor 1: no else statement 

            if (this.Next.Equals(null)) {
                return true;
            } 
                return false;
            
            */

            /* Refactor 2 */

            return this.next == null;
        }

        public override string ToString()
        {
            return this.value;
        }

        public override bool Equals(object obj)
        {
            return this.CompareTo(obj) == 0;
        }
    }
}
