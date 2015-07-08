using System;
using System.Collections.Generic;
using System.Linq;

namespace BookHelper
{
    internal class Book
    {
        private readonly List<PagesRange> _readPages = new List<PagesRange>();

        public readonly int PagesCount;

        public Book(int pagesCount)
        {
            PagesCount = pagesCount;
        }

        public void AddRange(int from, int to)
        {
            _readPages.Add(new PagesRange(from, to));
        }

        public int HowManyPagesLeft()
        {
            // TODO 3: Improve/fix the code here.

            if (!_readPages.Any())
            {
                return 0;
            }

            var arrayOfPage = new bool[PagesCount];
            foreach (var range in _readPages)
            {
                for (int i = range.From; i <= range.To; i++)
                {
                    arrayOfPage[i-1] = true;
                }
            }
            var leftPages = PagesCount - arrayOfPage.Where(item => item == true).Count();
            return leftPages;
        }
    }
}
