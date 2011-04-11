using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibSudoku
{
    public class FixedSquare : Square
    {
        private int val;

        public FixedSquare( int val ) : base(val)
        {
            this._value = val;
        }
        public new int value
        {
            get
            {
                return _value;
            }
        }

        public override string ToString()
        {
            return "[Fixed Square]: " + value;
        }
    }
}
