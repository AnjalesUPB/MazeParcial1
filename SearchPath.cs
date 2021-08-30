using System;
using System.Collections.Generic;
using System.Text;

namespace MazeParcial1
{
    class Node
    {
        private (int, int) trns;
        
        public bool isExplored = false;
        public Node isExploredFrom = null;

        public (int, int) Trns { get; set; }

        public Node(int x, int y)
        {
            Trns = (x, y);
        }

        public (int, int) GetPos()
        {
            return Trns;
        }
    }

    class SearchPath
    {
        public static Node _startingPoint;
        public static Node _endingPoint;

        private static Dictionary<(int, int), Node> _block = new Dictionary<(int,int), Node>(); // For storing all the nodes
        private static (int, int)[] _directions = { (0, 1), (1, 0), (0, -1), (-1, 0) }; // Directions to search in BFS
        private static Queue<Node> _queue = new Queue<Node>(); // Queue for enqueueing nodes and traversing through them
        private static Node _searchingPoint = null; // Current node we are searching
        private static bool _isExploring = true; // If we are end then it is set to false

        private static List<Node> _path = new List<Node>();            // For storing the path traversed

        public static void GetPath()
        {
            Console.WriteLine("\nSolution Path");

            foreach (var item in _path)
            {
                Console.WriteLine("{0},{1}", item.GetPos().Item1, item.GetPos().Item2);
            }
        }

        // For getting all nodes and storing them in the dictionary
        public static void LoadAllBlocks(Node[] nodes)
        {
            foreach (Node node in nodes)
            {
                (int, int) gridPos = node.GetPos();

                // For checking if 2 nodes are in same position; i.e overlapping nodes
                if (_block.ContainsKey(gridPos))
                {
                    Console.WriteLine("2 Nodes present in same position. i.e nodes overlapped.");
                }
                else
                {
                    _block.Add(gridPos, node); // Add the position of each node as key and the Node as the value
                }
            }

        }

        // BFS; For finding the shortest path
        public static void BFS()
        {
            _queue.Enqueue(_startingPoint);
            while (_queue.Count > 0 && _isExploring)
            {
                _searchingPoint = _queue.Dequeue();
                OnReachingEnd();
                ExploreNeighbourNodes();
            }
        }

        // To check if we've reached the Ending point
        private static void OnReachingEnd()
        {
            if (_searchingPoint == _endingPoint)
            {
                _isExploring = false;
            }
            else
            {
                _isExploring = true;
            }
        }

        // Searching the neighbouring nodes
        private static void ExploreNeighbourNodes()
        {
            if (!_isExploring) { return; }

            foreach ((int, int) direction in _directions)
            {
                (int, int) neighbourPos = ((_searchingPoint.GetPos().Item1 + direction.Item1), (_searchingPoint.GetPos().Item2 + direction.Item2));

                if (_block.ContainsKey(neighbourPos)) // If the explore neighbour is present in the dictionary _block, which contians all the blocks with Node.cs attached
                {
                    Node node = _block[neighbourPos];

                    if (!node.isExplored)
                    {
                        _queue.Enqueue(node); // Enqueueing the node at this position
                        node.isExplored = true;
                        node.isExploredFrom = _searchingPoint; // Set how we reached the neighbouring node i.e the previous node; for getting the path
                    }
                }
            }
        }

        // Creating path using the isExploredFrom var of each node to get the previous node from where we got to this node
        public static void CreatePath()
        {
            SetPath(_endingPoint);
            Node previousNode = _endingPoint.isExploredFrom;

            while (previousNode != _startingPoint)
            {
                SetPath(previousNode);
                previousNode = previousNode.isExploredFrom;
            }

            SetPath(_startingPoint);
            _path.Reverse();
        }

        // For adding nodes to the path
        private static void SetPath(Node node)
        {
            _path.Add(node);
        }
    }
}
