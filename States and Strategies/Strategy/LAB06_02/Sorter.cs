using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB06_02
{
    class Sorter
    {
        private SortingAlgorithm sortingAlgorithm;
        public void SetAlgorithm(SortingAlgorithm sortingAlgorithm)
        {
            this.sortingAlgorithm = sortingAlgorithm;
        }
        public List<int> Sort(List<int> numbers)
        {
            return this.sortingAlgorithm.Sort(numbers);
        }

/*        public override string ToString()
        {
            if(this.sortingAlgorithm.Equals(new InsertionSort()))
            {
                return "Insertion sorting!";
            }
            else if (this.sortingAlgorithm.Equals(new SelectionSort()))
            {
                return "Selection sorting!";
            }
            else
            {
                return "Unkown sorting";
            }
        }*/
    }
}
