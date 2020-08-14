using System;
using System.Collections.Generic;

namespace CollectionsLectureNotes
{
    class Program
    {
        static void Main(string[] args)
        {
            // LIST<T>
            //
            // Lists allow us to hold collections of data. They are declared with a type of data that they hold
            // only allowing items of that type to go inside of them.
            //
            // The syntax used for declaring a new list of type T is
            //      List<T> list = new List<T>();
            //
            //

            // Creating lists of integers

            List<int> integerList = new List<int> { 5, 3, 3 };


            // Creating lists of strings

            List<string> stringList = new List<string>();

            /////////////////


            //////////////////
            // OBJECT EQUALITY
            //////////////////



            /////////////////
            // ADDING ITEMS
            /////////////////

            // Adding items one at a time to each list


            /////////////////
            // ADDING MULTIPLE ITEMS
            /////////////////



            //////////////////
            // ACCESSING BY INDEX
            //////////////////

            Console.WriteLine(integerList[0]);
            Console.WriteLine(integerList[integerList.Count - 1]);


            ///////////////////
            // ACCESSING WITH FOR-EACH
            ///////////////////


            ////////////////////
            // ADDITIONAL LIST<T> METHODS
            ////////////////////


            ////////////////////////
            // SORT and PRINT A LIST
            ////////////////////////




            // QUEUE <T>
            //
            // Queues are a special type of data structure that follow First-In First-Out (FIFO).
            // With Queues, we Enqueue (add) and Dequeue (remove) items.


            /////////////////////
            // PROCESSING ITEMS IN A QUEUE
            /////////////////////

            //FIFO - first in first out
            //LILO - last in last out

            Queue<int> myQueue = new Queue<int>();
            myQueue.Enqueue(5);
            myQueue.Enqueue(7);
            while (myQueue.Count > 0){
                Console.WriteLine(myQueue.Dequeue());

            }

            // STACK <T>
            //
            // Stacks are another type of data structure that follow Last-In First-Out (LIFO).
            // With Stacks, we Push (add) and Pop (remove) items. 

            //FILO, First in Last Out
            //or LIFO Last in First Out


            ////////////////////
            // PUSHING ITEMS TO THE STACK
            //////////////////// 

            Stack<string> myStack = new Stack<string>();
            myStack.Push("first in");
            myStack.Push("second in");

            ////////////////////
            // POPPING THE STACK
            ////////////////////
            
            while(myStack.Count > 0)
            {
                Console.WriteLine(myStack.Pop());
            }

            Console.ReadLine();

        }
    }
}
