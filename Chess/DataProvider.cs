

namespace Chess
{
    public class DataProvider : IDataProvider
    {
        public string[,] PhoneMatrix { get; set; }

        public int Length { get; set; }

        public DataProvider()
        {
            PhoneMatrix = new [,] { {"1", "2", "3"},
                                    {"4", "5", "6"}, 
                                    {"7", "8", "9"},
                                    {"*", "0", "#"}};
            Length = 10;
        }


        public DataProvider(string[,] phoneMatrix, int length)
        {
            PhoneMatrix = phoneMatrix;
            Length = length;
        }

        //private int[,] MatrixTransformer(string[,] stringMatrix, IRuleEngine ruleEngine = null)
        //{
        //    if (stringMatrix != null)
        //    {
        //        int[,] matrix = new int[stringMatrix.GetUpperBound(0)+1, stringMatrix.GetUpperBound(1)+1];
        //        for (int i = 0; i <= stringMatrix.GetUpperBound(0); i++)
        //        {
        //            for (int j = 0; j <= stringMatrix.GetUpperBound(1); j++)
        //            {
        //                string current = stringMatrix[i, j];
        //                if (ruleEngine != null && ruleEngine.ExclusionList.Contains(current))
        //                {
        //                    matrix[i, j] = -1;
        //                }

        //                int.TryParse(current, out var curr);
        //                matrix[i, j] = curr;
        //            }
        //        }

        //        return matrix;
        //    }

        //    return null;
        //}
    }
}
