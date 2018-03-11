using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Chess
{
    public abstract class PhoneChessBase : IRuleEngine
    {
        #region Members
        
        private readonly Dictionary<string, HashSet<string>> _states = new Dictionary<string, HashSet<string>>();

        #endregion

        /**
         * Returns all number of possible paths of size phoneLength
         *
         * @param phoneMatrix     Input Matrix
         * @param phoneLength     Path size
         * @return Number of paths
         */
        public int FindAllNumberOfPaths(string[,] phoneMatrix, int phoneLength)
        {
            try
            {
                int totalCount = 0;
                if (phoneMatrix != null)
                {  for (int i = 0; i <= phoneMatrix.GetUpperBound(0); i++)
                    {
                        for (int j = 0; j <= phoneMatrix.GetUpperBound(1); j++)
                        {
                            totalCount = totalCount + FindNumberOfPaths(phoneMatrix, phoneLength, phoneMatrix[i, j]);
                        }
                    }

                }

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
         * @param phoneMatrix     Input Matrix
         * @param phoneLength     Path size
         * @param digit           Starting digit
         * @return Number of paths
         */
        public int FindNumberOfPaths(string[,] phoneMatrix, int phoneLength, string startingDigit)
        {
            if (string.IsNullOrEmpty(startingDigit) || CanNotStartWith(startingDigit) || CanNotContain(startingDigit) || 
                phoneLength < 1 || phoneMatrix == null)
            {
                return 0;
            }
            HashSet<Stack<string>> results = new HashSet<Stack<string>>();

            // start the flow from given digit
            Queue<Stack<string>> queue = new Queue<Stack<string>>();
            Stack<string> path = new Stack<string>();
            path.Push(startingDigit);
            queue.Enqueue(path);

            while (queue.Count > 0)
            {
                path = queue.Dequeue();

                if (path.Count == phoneLength && !results.Contains(path))
                {
                    results.Add(path);
                    continue;
                }

                string currentPathDigit = path.Peek();
                HashSet<string> states = GetStates(phoneMatrix, currentPathDigit);
                if (states != null && states.Count > 0)
                {
                    foreach (var state in states)
                    {
                        Stack<string> newPath = new Stack<string>();
                        path.ToList().ForEach(p => newPath.Push(p));
                        newPath.Push(state);
                        queue.Enqueue(newPath);
                    }
                }
            }
            return results.Count;
         
        }

        /**
         * Returns possible next states for a given digit; use memoization for optimization
         *
         * @param phoneMatrix     Input Matrix
         * @param digit           Digit
         * @return All possible states
         */
        private HashSet<string> GetStates(string[,] phoneMatrix, string digit)
        {
            if (_states.ContainsKey(digit))
            {
                return _states[digit];
            }

            int digitRow = -1;
            int digitCol = -1;
            for (int row = 0; digitRow == -1 && row <= phoneMatrix.GetUpperBound(0); ++row)
            {
                for (int col = 0; digitCol == -1 && col <= phoneMatrix.GetUpperBound(1); ++col)
                {
                    if (phoneMatrix[row, col].Equals(digit))
                    {
                        digitRow = row;
                        digitCol = col;
                        break;
                    }
                }
            }

            HashSet<string> nextStates = GetNextState(digitRow, digitCol, phoneMatrix, this);
            _states.Add(digit, nextStates);
            return _states[digit];
        }

        /**
         * This method returns the possible states for a given digit
         *
         * @param row   Row index for the given digit
         * @param col   Column index for the given digit
         * @param phoneMatrix     Input Matrix
         * @param ruleEngine      Rules to comply for valid phone number
         * @return HashSet of possible states
         */
        protected abstract HashSet<string> GetNextState(int row, int col, string[,] phoneMatrix, IRuleEngine ruleEngine);

        #region Rule Engine 
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
            if (digit.Equals("0") || digit.Equals("1"))
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}