using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinglyLinkedLists
{
    public class SinglyLinkedList
    {
        private SinglyLinkedListNode first_node;
        public SinglyLinkedList()
        {
            // NOTE: This constructor isn't necessary, once you've implemented the constructor below.
        }

        // READ: http://msdn.microsoft.com/en-us/library/aa691335(v=vs.71).aspx
        public SinglyLinkedList(params object[] values)
        {
            throw new NotImplementedException();
        }

        // READ: http://msdn.microsoft.com/en-us/library/6x16t2tx.aspx
        public string this[int i]
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public void AddAfter(string existingValue, string value)
        {
            throw new NotImplementedException();
        }

        public void AddFirst(string value)
        {
            throw new NotImplementedException();
        }

        public void AddLast(string value)
        {
            if (this.First() == null)
            {
                first_node = new SinglyLinkedListNode(value);
            }
            else {
                var node = this.first_node;
                while (!node.IsLast())
                {
                    node = node.Next;
                }
                node.Next = new SinglyLinkedListNode(value);
            }
        }

        // NOTE: There is more than one way to accomplish this.  One is O(n).  The other is O(1).
        public int Count()
        {
            if (this.First() == null)
            {
                return 0;
            }
            else
            {
                int length = 1;
                var node = this.first_node;
                // complexity is O(n)
                while (node.Next != null)
                {
                    length++;
                    node = node.Next;
                }

                return length;
            }
        }

        public string ElementAt(int index)
        {
            if (this.First() == null)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                var node = this.first_node;
                
                for (var i = 0; i <= index; i++)
                {
                    if (i == index)
                    {
                        break;
                    }

                    node = node.Next;
                }

                return node.Value;
            }
        }

        public string First()
        {
            if (this.first_node == null)
            {
                return null;
            }
            else
            {
                return this.first_node.Value;
            }

            // return this.first_node ? null : this.first_node.Value;
        }

        public int IndexOf(string value)
        {
            throw new NotImplementedException();
        }

        public bool IsSorted()
        {
            throw new NotImplementedException();
        }

        // HINT 1: You can extract this functionality (finding the last item in the list) from a method you've already written!
        // HINT 2: I suggest writing a private helper method LastNode()
        // HINT 3: If you highlight code and right click, you can use the refactor menu to extract a method for you...
        public string Last()
        {
            var node = this.first_node;
            if (node == null)
            {
                return null;
            } else
            {
                while (!node.IsLast())
                {
                    node = node.Next;
                }
                return node.Value;
            }
        }

        public void Remove(string value)
        {
            throw new NotImplementedException();
        }

        public void Sort()
        {
            throw new NotImplementedException();
        }

        public string[] ToArray()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            //var opening = "{";
            //var ending = " }";
            //var space = " ";
            //var output = "";
            //var quote = "\"";
            //var comma = "," + space;
            //var node = this.first_node;
            //output += opening;

            //if (this.Count() >= 1)
            //{
            //    output += space;
            //    while (!node.IsLast()) {
            //        output = quote + node.Value + quote;
            //        node = node.Next;
            //    }
            //    output += quote + this.Last() + quote;
            //}

            //output += space;
            //output += ending;
            //return output;

            var strBuilder = new StringBuilder();
            var node = this.first_node;
            var string2Return = " ";

            strBuilder.Append("{ ");

            //// do some stuff
            if (this.Count() == 1 || this.Count() == 0)
            {
                while (node != null)
                {
                    strBuilder.Append("\"").Append(node.Value).Append("\" ").ToString();
                    node = node.Next;
                }
                strBuilder.Append("}");
            }
            else
            {
                while (!node.IsLast())
                {
                    strBuilder.Append("\"").Append(node.Value).Append("\", ").ToString();
                    node = node.Next;
                }

                strBuilder.Append("\"").Append(this.Last()).Append("\" }").ToString();
            }
            return string2Return = strBuilder.ToString();
        }
    }
}
