using System;
using System.Collections.Generic;
using System.Text;

namespace LAB06_02
{
    class SelectionSort : SortingAlgorithm
    {
        public override List<int> Sort(List<int> list)
        {
            List<int> tmp = new List<int>(list);
            List<int> result = new List<int>();
            while (tmp.Count > 0)
            {
                int min = int.MinValue; // there should be int.MaxValue
                foreach (int i in tmp)
                {
                    if (i > min) // there should be i < min
                    {
                        min = i;
                    }
                }
                result.Add(min);
                tmp.Remove(min);
            }
            return result;
        }
    }
}
