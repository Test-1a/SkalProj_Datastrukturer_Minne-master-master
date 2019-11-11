using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            while (true)
            {

                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParanthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()[0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '5':
                        ReverseText();
                        break;
                    case '0':
                        return;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */

            //List<string> theList = new List<string>();
            //string input = Console.ReadLine();
            //char nav = input[0];
            //string value = input.substring(1);

            //switch(nav){...}


            //MY OWN CODE:
            //Answers
            //Q2: När ökar listans kapacitet (alltså den underliggande arrayens storlek)?
            //A2: När man passerar gränsen. 4->5 strängar => kapaciteten ökar från 4->8
            //                              8->9 strängar => kapaciteten ökar från 8->16
            //Q3: Med hur mycket ökar kapaciteten?
            //A3: med 100% = den dubblas (4->8->16)
            //Q4: Varför ökar inte listans kapacitet i samma takt som element läggs till?
            //A4: När arrayens capacitet överskrids skapas en ny array med dubblad capacitet på heapen och 
            //      innehållet i den gamla arrayen kopieras till den nya arrayen
            //Q5: Minskar kapaciteten när element tas bort ur listan?
            //A5: NEJ!
            //Q6: När är det då fördelaktigt att använda en egendefinierad array i stället för en lista?
            //A6: När du vet redan från början hur stor listan ska vara och dess storlek ändras inte

            List<string> strings = new List<string>();
            string answer = "";
            char firstLetter = ' ';

            while (true)
            {
                Console.WriteLine("'Q' to return to menu");
                Console.WriteLine("'+' to add the text");
                Console.WriteLine("'-' to remove the text");


                try
                {
                    answer = Console.ReadLine();
                    firstLetter = answer[0];
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }

                switch (firstLetter)
                {
                    case '+':
                        PrintCollectionBefore(strings);
                        PrintArrayCapacity(strings);

                        strings.Add(answer.Substring(1));

                        PrintCollectionAfter(strings);
                        PrintArrayCapacity(strings);
                        break;

                    case '-':
                        PrintCollectionBefore(strings);
                        PrintArrayCapacity(strings);

                        if (strings.Contains(answer.Substring(1))) strings.Remove(answer.Substring(1));
                        else Console.WriteLine("The word was not found in the list!");

                        PrintCollectionAfter(strings);
                        PrintArrayCapacity(strings);
                        break;

                    case 'Q':
                        return;

                    default:
                        break;
                }
            }
        }


        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */

            //MY OWN CODE
            Queue<string> ica = new Queue<string>();
            string answer = "";
            char firstLetter = ' ';

            while (true)
            {
                Console.WriteLine("'Q' to return to menu");
                Console.WriteLine("'+' to add the person to the queue");
                Console.WriteLine("'-' to remove the person from the queue");

                try
                {
                    answer = Console.ReadLine();
                    firstLetter = answer[0];
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }

                switch (firstLetter)
                {
                    case '+':
                        PrintCollectionBefore(ica);

                        ica.Enqueue(answer.Substring(1));
                        Console.WriteLine($"{answer.Substring(1)} entered the Queue");

                        PrintCollectionAfter(ica);
                        break;

                    case '-':
                        PrintCollectionBefore(ica);

                        if (ica.Count > 0)
                        {
                            string s = ica.Dequeue();
                            Console.WriteLine($"{s} left the Queue");
                        }
                        else Console.WriteLine("The Queue is empty!!!!");

                        PrintCollectionAfter(ica);
                        break;

                    case 'Q':
                        return;

                    default:
                        break;
                }
            }
        }


        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */

            //MY OWN CODE
            //Q1: Varför är det inte smart att använda en STACK för att simulera en KÖ?
            //A1: 

            Stack<string> ica = new Stack<string>();
            string answer = "";
            char firstLetter = ' ';

            while (true)
            {
                Console.WriteLine("'Q' to return to menu");
                Console.WriteLine("'+' to push the person to the stack");
                Console.WriteLine("'-' to pop the person from the stack");

                try
                {
                    
                    answer = Console.ReadLine();
                    Console.WriteLine($"Svar: {answer}");
                    firstLetter = answer[0];
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }

                switch (firstLetter)
                {
                    case 'Q':
                        return;

                    case '+':
                        string[] arr = ica.ToArray();
                        PrintCollectionBefore(arr);

                        ica.Push(answer.Substring(1));

                        arr = ica.ToArray();
                        PrintCollectionAfter(arr);
                        break;

                    case '-':
                        string[] carr = ica.ToArray();
                        PrintCollectionBefore(carr);

                        ica.Pop();

                        carr = ica.ToArray();
                        PrintCollectionAfter(carr);
                        break;

                    default:
                        break;
                }

            }
        }


        static void ReverseText()
        {
            Stack<string> ica = new Stack<string>();
            string answer = "";
            char firstLetter = ' ';

            while (true)
            {
                Console.WriteLine("'Q' to return to menu");
                Console.WriteLine("'+' to push the person to the stack");

                try
                {

                    answer = Console.ReadLine();
                    firstLetter = answer[0];
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }

                if (firstLetter == 'q' || firstLetter == 'Q') return;
                else
                {
                    for (int i = 0; i < answer.Count(); i++)
                    {
                        firstLetter = answer[i];
                        ica.Push(firstLetter.ToString());
                    }
                }

                

                string[] reversed = ica.ToArray();
                for (int i = 0; i < reversed.Count(); i++)
                {
                    Console.Write(reversed[i]);
                }
                Console.WriteLine();

            }
        }


        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */


            //MY OWN CODE
            Stack<string> strings = new Stack<string>();
            string answer = "";
            char nextLetter = ' ';

            while (true)
            {
                Console.WriteLine("'Q' to return to menu");
                Console.WriteLine("Write the text that you want to check if it is wellformed");
                

                try
                {
                    answer = Console.ReadLine();
                    Console.WriteLine($"Answer: {answer}");
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }

                for (int i = 0; i < answer.Count(); i++)
                {
                    nextLetter = answer[i];
                    Console.WriteLine($"i: {nextLetter}");

                    if (nextLetter == 'q' || nextLetter == 'Q') return;

                    if (nextLetter == '(' ||
                        nextLetter == '{' ||
                        nextLetter == '[' ||
                        nextLetter == ')' ||
                        nextLetter == '}' ||
                        nextLetter == ']')
                    {
                        Console.WriteLine($"i2: {nextLetter}");

                        if (nextLetter == '('
                            || nextLetter == '{'
                            || nextLetter == '['
                            )
                        {
                            strings.Push(nextLetter.ToString());
                            string[] arr = strings.ToArray();
                            PrintCollectionBefore(arr);
                        }

                        if (strings.Count == 0 && nextLetter == ')' ||
                        strings.Count == 0 && nextLetter == '}' ||
                        strings.Count == 0 && nextLetter == ']')
                        {
                            Console.WriteLine($"{answer} is NOT wellformed 1!");
                            break;
                        }

                        if (strings.Peek() == '('.ToString() && nextLetter == ')' ||
                        strings.Peek() == '{'.ToString() && nextLetter == '}' ||
                        strings.Peek() == '['.ToString() && nextLetter == ']')
                            strings.Pop();

                        //if (strings.Peek() == '('.ToString() && nextLetter != ')' ||
                        //strings.Peek() == '{'.ToString() && nextLetter != '}' ||
                        //strings.Peek() == '['.ToString() && nextLetter != ']')
                        //{
                        //    Console.WriteLine($"{answer} is NOT wellformed 3!");
                        //    break;
                        //}

                            string[] tarr = strings.ToArray();
                        PrintCollectionBefore(tarr);

                        if (i == (answer.Length - 1))
                        {
                            if (strings.Count == 0) Console.WriteLine($"{answer} is wellformed");
                            else Console.WriteLine($"{answer} is NOT wellformed 2");
                        }
                    }

                    
                }

                
            }


        }


        public static void PrintCollectionBefore(IEnumerable<string> coll)
        {
            //Before
            Console.WriteLine("Before: ");
            foreach (var item in coll)
            {
                Console.WriteLine(item);
            }
        }


        public static void PrintCollectionAfter(IEnumerable<string> coll)
        {
            //After
            Console.WriteLine("After: ");
            foreach (var item in coll)
            {
                Console.WriteLine(item);
            }
        }


        public static void PrintArrayCapacity(List<string> list)
        {
            Console.WriteLine($"Array Capacity: {list.Capacity}");
        }
    }
}

