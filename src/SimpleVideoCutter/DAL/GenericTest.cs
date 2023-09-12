using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleVideoCutter.DAL
{
 public   class GenericTest
    {
        public  void ShowMessageBoxIfStringList<T>(List<T> inputList)
        {
            if (typeof(T) == typeof(string))
            {
                //MessageBox.Show("This is a List<string>.");
            }
            else
            {
                //MessageBox.Show("This is not a List<string>.");
            }
        }
        List<int> intList = new List<int>();
        List<string> stringList = new List<string>();

       //ShowMessageBoxIfStringList(intList); // This will show "This is not a List<string>."
       // ShowMessageBoxIfStringList(stringList); // This will show "This is a List<string>."

        public void ProcessList<T>(List<T> inputList)
        {
            foreach (T item in inputList)
            {
                // Perform some processing on each item in the list
                Console.WriteLine(item);
            }
        }
        public class MyClass
        {
            public void ProcessList<T>(List<T> inputList)
            {
                foreach (T item in inputList)
                {
                    // Perform some processing on each item in the list
                    Console.WriteLine(item);
                }
            }
        }
        private void b11()
        {
            MyClass myClass = new MyClass();

            List<int> intList = new List<int> { 1, 2, 3, 4, 5 };
            List<string> stringList = new List<string> { "apple", "banana", "cherry" };

            Console.WriteLine("Processing intList:");
            myClass.ProcessList(intList);

            Console.WriteLine("\nProcessing stringList:");
            myClass.ProcessList(stringList);
        }

    }
}
