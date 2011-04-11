using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibSudoku
{
    public class Section : IRegion
    {
        #region IRegion Members
        public Section()
        {
            squares = new Square[9];
        }

        public Square[ ] squares
        { get;
            set;
        }

        public int complete
        {
            get { throw new NotImplementedException(); }
        }

        public void updatenotes()
        {
            foreach (Square square in squares)
            {
                square.updatenotes();
            }
        }

        #endregion
    }
}
