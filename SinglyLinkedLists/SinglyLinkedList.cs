using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinglyLinkedLists
{
    public class SinglyLinkedList
    {
        private SinglyLinkedListNode first_node;
        private int listLength = 0;
        public SinglyLinkedList()
        {
            // NOTE: This constructor isn't necessary, once you've implemented the constructor below.
        }

        // READ: http://msdn.microsoft.com/en-us/library/aa691335(v=vs.71).aspx
        public SinglyLinkedList(params object[] values)
        {
            for (var i = 0; i < values.Length; i++)
            {
                this.AddLast(values[i] as String);
            }   
        }

        // READ: http://msdn.microsoft.com/en-us/library/6x16t2tx.aspx
        public string this[int i]
        {
            get { return this.ElementAt(i); }
            set
            {
                var copy_of_list = new SinglyLinkedList();
                for (var j = 0; j < this.Count(); j++)
                {
                    if (j == i)
                    {
                        copy_of_list.AddLast(value);
                    }
                    else
                    {
                        copy_of_list.AddLast(this.ElementAt(j));
                    }
                }

                first_node = new SinglyLinkedListNode(copy_of_list.First());
                for (var o = 1; o < copy_of_list.Count(); o++)
                {
                    this.AddLast(copy_of_list.ElementAt(o));
                }                
            }
        }

        public void AddAfter(string existingValue, string value)
        {
            var node = this.first_node;
            var inputValue = IndexOf(existingValue);
            var value2Add = new SinglyLinkedListNode(value);

            if (IndexOf(existingValue) == -1)
            {
                throw new ArgumentException();
            } 

            for (var i = 0; i < this.Count(); i++)
            {

                if (node.Value == existingValue)
                {
                    // gets the index of the found node
                    var foundPosition = node;

                    // set the pointer for the new node
                    value2Add.Next = foundPosition.Next;

                    // set the new value for after foundPosition
                    foundPosition.Next = value2Add;
                }
                else if (!node.IsLast())
                {
                    this.AddLast(value2Add.Value);
                }

                node = new SinglyLinkedListNode(value);
            }
        }

        public object NodeAt(int index)
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

                return node;
            }
        }

        public void AddFirst(string value)
        {
            if (this.First() == null)
            {
                first_node = new SinglyLinkedListNode(value);
            }
            else
            {
                // feeding value for new first node into a variable
                var newFirstNode = new SinglyLinkedListNode(value);

                // keeping track of rest of the list
                var currentFirstNode = this.first_node;
                
                // put newFirstNode into first position? 
                this.first_node = newFirstNode;

                // making a pointer to the rest of everything else
                this.first_node.Next = currentFirstNode;
            }

            listLength++;
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
            listLength++;
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
           var node = this.first_node;

            if (this.Count() > 0)
            {
                for (var i = 0; i < this.Count(); i++)
                {
                    if (node.Value == value)
                    {
                        return i;
                    }
                    else if (node.IsLast() && node.Value != value)
                    {
                        return -1;
                    }

                    node = node.Next;
                }

            }
            else if (this.Count() == 0)
            {
                return -1;
            }

            return -1;
        }

        public bool IsSorted()
        {
            if (this.Count() < 2 ) 
            {
                return true;
            }
            else
            {
                for (var i = 0; i < this.Count(); i++)
                {
                    var currentNode = this.first_node;
                    if (String.Compare(currentNode.Value, currentNode.Next.Value) > 0)
                    {
                        return false;
                    }

                    currentNode = currentNode.Next;
                }

                return true;
            }
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
            var copy_of_list = new SinglyLinkedList();
            var listIteration = this.first_node;
            var theIndexVal = this.IndexOf(value);

            for (var i = 0; i < this.Count(); i++)
            {
                if ( theIndexVal != i )
                {
                    copy_of_list.AddLast(listIteration.Value);
                }

                listIteration = listIteration.Next;
            }

            first_node = new SinglyLinkedListNode(copy_of_list.First());
            for (var o = 1; o < copy_of_list.Count(); o++)
            {
                this.AddLast(copy_of_list.ElementAt(o));
            }
        }

        public void Sort()
        {
            throw new NotImplementedException();
        }

        public string[] ToArray()
        { 
            string[] array = new string[this.Count()];

            for (var i = 0; i < this.Count(); i++)
            {
                array[i] = this.ElementAt(i);
            }

            return array;
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
