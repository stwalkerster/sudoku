using System;

namespace LibSudoku
{
    public class Square : ISquare
    {
        protected int _value;

        public Square()
        {
            notes = new bool[9];
        }

        public Square(int val)
        {
            value = val;
            notes = new bool[9];
        }

        public bool[] notes
        { get;
            set;
        }


        public int value
        {
            get { return _value; }
            set
            {
                if (value >= 0 && value <= 9)
                    _value = value;
                else
                    throw new ArgumentOutOfRangeException();
            }
        }

        public Section Section
        { get;
            set;
        }

        public Column Column
        { get;
            set;
        }

        public Row Row
        {
            get; set;
        }

        public void updatenotes()
        {
            if (value != 0)
                return;

            bool[] newnotes = new bool[9];
            for (int i = 0; i < 9; i++)
            {
                newnotes[i] = true;
            }

            foreach (Square square in this.Section.squares)
                if(square.value != 0)
                    newnotes[square.value - 1] = false;
            foreach (Square square in this.Row.squares)
                if (square.value != 0)
                    newnotes[square.value - 1] = false;
            foreach (Square square in this.Column.squares)
                if (square.value != 0)
                    newnotes[square.value - 1] = false;

            notes = newnotes;
        }

        public override string ToString()
        {
            return "[Square]: " + value;
        }

        public bool singleOption()
        {
            bool flag = false;
            for (int i = 0; i < 9; i++)
            {
                if (notes[i])
                    if (flag)
                        return false;
                    else
                        flag = true;
            }
            return flag;
        }
    }
}