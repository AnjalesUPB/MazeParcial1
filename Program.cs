using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MazeParcial1
{
    class Program
    {
        static void Main(string[] args)
        {
            Node node1 = new Node(0, 0);
            Node node2 = new Node(1, 0);
            Node node3 = new Node(2, 0);
            Node node4 = new Node(3, 0); //Vacío
            Node node5 = new Node(4, 0);
            Node node6 = new Node(0, 1);
            Node node7 = new Node(1, 1);
            Node node8 = new Node(2, 1);
            Node node9 = new Node(3, 1); //Vacío
            Node node10 = new Node(4, 1);
            Node node11 = new Node(0, 2);
            Node node12 = new Node(1, 2); //Vacío
            Node node13 = new Node(2, 2);
            Node node14 = new Node(3, 2); //Vacío
            Node node15 = new Node(4, 2);
            Node node16 = new Node(0, 3);
            Node node17 = new Node(1, 3); //Vacío
            Node node18 = new Node(2, 3);
            Node node19 = new Node(3, 3);
            Node node20 = new Node(4, 3);
            Node node21 = new Node(0, 4);
            Node node22 = new Node(1, 4);
            Node node23 = new Node(2, 4);
            Node node24 = new Node(3, 4);
            Node node25 = new Node(4, 4);

            Node[] nodes = { node1, node2, node3, /*node4,*/ node5,
                            node6, node7, node8, /*node9,*/ node10,
                            node11, /*node12,*/ node13, /*node14,*/ node15,
                            node16, /*node17,*/ node18, node19, node20,
                            node21, node22, node23, node24, node25 };

            Console.WriteLine("\nMaze:");
            Console.WriteLine("\n o 0 0 x o " +
                              "\n 0 0 0 x 0 " +
                              "\n 0 x 0 x 0 " +
                              "\n 0 x 0 0 0 " +
                              "\n 0 0 0 0 0 \n");

            SearchPath._startingPoint = node1;
            SearchPath._endingPoint = node5;

            Console.WriteLine("Starting Point: (0, 0)");
            Console.WriteLine("Ending Point: (4, 0)");

            Stopwatch timer = new Stopwatch();
            timer.Start();
            SearchPath.LoadAllBlocks(nodes);
            SearchPath.BFS();
            SearchPath.CreatePath();
            SearchPath.GetPath();
            timer.Stop();

            Console.WriteLine("\nProgram timer: {0} miliseconds", timer.ElapsedMilliseconds);
        }
    }


}
