using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibSudoku
{
    public class Column : IRegion
    {
        public Column() { squares = new Square[9]; }
        #region IRegion Members

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
