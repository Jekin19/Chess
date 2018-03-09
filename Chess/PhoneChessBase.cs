using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Chess
{
    public abstract class PhoneChessBase : IRuleEngine
    {
        private readonly IDataProvider _dataProvider;

        protected string[,] PhoneMatrix => _dataProvider?.PhoneMatrix;

        protected int RowSize => PhoneMatrix.GetUpperBound(0)+1;

        protected int ColSize => PhoneMatrix.GetUpperBound(1)+1;

        private ConcurrentDictionary<string, HashSet<string>> _states;

        private int? PhoneLength => _dataProvider?.Length;

        protected PhoneChessBase(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        /**
         * Returns number of possible paths starting from given digit of size n
         *
         * @param n     Path size
         * @return Number of paths
         */
        public decimal FindNumberOfPaths(int n )
        {
            try
            {
                Console.WriteLine(DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff",
                    CultureInfo.InvariantCulture));
                var phoneLength = PhoneLength ?? n; 
                List<Task<int>> taskList = new List<Task<int>>();
                decimal totalCount = 0;
                _states = new ConcurrentDictionary<string, HashSet<string>>();
                for (int i = 0; i < RowSize; i++)
                {
                    for (int j = 0; j < ColSize; j++)
                    {
                        //var task = Task.Factory.StartNew(stateObject => FindPath((string)stateObject, phoneLength), PhoneMatrix[i, j]);
                        //taskList.Add(task);
                        totalCount = totalCount + FindPath(PhoneMatrix[i, j], phoneLength);
                    }
                }

                //Task.WaitAll(taskList.ToArray());
                //taskList.ForEach(task => totalCount = totalCount + task.Result);
                Console.WriteLine(DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff",
                    CultureInfo.InvariantCulture));
                return totalCount;
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
                //log exception
                return -1;
            }
        }

        /**
         * Find number of possible paths starting from given digit of size n
         *
         * @param digit Starting digit
         * @param n     Path size
         * @return Number of paths
         */
        protected int FindPath(string digit, int n)
        {

            if (CanNotStartWith(digit) || CanNotContain(digit))
            {
                return 0;
            }
            HashSet<Stack<string>> results = new HashSet<Stack<string>>();

            // start the flow from given digit
            Queue<Stack<string>> queue = new Queue<Stack<string>>();
            Stack<string> path = new Stack<string>();
            path.Push(digit);
            queue.Enqueue(path);

            while (queue.Count > 0)
            {
                path = queue.Dequeue();

                if (path.Count == n && !results.Contains(path))
                {
                    results.Add(path);
                    continue;
                }

                string currentPathDigit = path.Peek();
                HashSet<string> states = GetStates(currentPathDigit);
                if (states != null && states.Count > 0)
                {
                    foreach (var state in states)
                    {
                        Stack<string> newPath = new Stack<string>();
                        var temp = path.Reverse();
                        temp.ToList().ForEach(p => newPath.Push(p));
                        newPath.Push(state);
                        queue.Enqueue(newPath);
                    }
                }
            }

            //foreach (var result in results)
            //{
            //    var temp = result.Reverse().ToList();
            //    foreach (var res in temp)
            //    {
            //        Console.Write(res + " ");
            //    }

            //    Console.WriteLine();
            //}

            return results.Count;
        }
        
        /**
         * Returns possible next states for a given digit; use memoization for optimization
         *
         * @param digit Digit
         * @return All possible states
         */
        protected HashSet<string> GetStates(string digit)
        {
            if (_states.ContainsKey(digit))
            {
                return _states[digit];
            }

            int digitRow = -1;
            int digitCol = -1;
            for (int row = 0; digitRow == -1 && row < RowSize; ++row)
            {
                for (int col = 0; digitCol == -1 && col < ColSize; ++col)
                {
                    if (PhoneMatrix[row, col] == digit)
                    {
                        digitRow = row;
                        digitCol = col;
                        break;
                    }
                }
            }

            HashSet<string> nextStates = GetNextState(digitRow, digitCol);
            _states.TryAdd(digit, nextStates);
            return _states[digit];
        }
        
        /**
         * This method returns the possible states for a given digit
         *
         * @param row   Row index for the given digit
         * @param col   Column index for the given digit
         * @return HashSet of possible states
         */
        protected abstract HashSet<string> GetNextState(int row, int col);

        public bool CanNotContain(string digit)
        {
            if (digit.Equals("*") || digit.Equals("#"))
            {
                return true;
            }

            return false;
        }

        public bool CanNotStartWith(string digit)
        {
            //if (digit.Equals("0") || digit.Equals("1"))
            //{
            //    return true;
            //}
            return false;
        }
    }
}