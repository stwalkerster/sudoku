using System;
using System.Text;

namespace LibSudoku
{
    public class Game : IGame
    {
        private readonly Column[] _columns = new Column[9];
        private readonly Row[] _rows = new Row[9];
        private readonly Section[] _sections = new Section[9];
        private readonly Square[] _squares = new Square[81];

        /// <summary>
        /// Generates a new <see cref="Game"/>.
        /// </summary>
        public Game()
        {
            throw new NotImplementedException();
        }

        private Game(bool blank)
        {
        }

        /// <summary>
        /// Initializes a new instance of a <see cref="Game"/> from the given input string.
        /// </summary>
        /// <param name="data">The data.</param>
        public Game(string data)
        {
            importData(data);

            setupRegions();
        }


        public Row[] rows
        {
            get { return _rows; }
        }

        public Section[] sections
        {
            get { return _sections; }
        }

        public Column[] columns
        {
            get { return _columns; }
        }

        public Square[] squares
        {
            get { return _squares; }
        }

        private void importData(string data)
        {
            if (data.Length != 81)
                throw new ArgumentOutOfRangeException("data", "Wrong length");

            for (int i = 0; i < 81; i++)
            {
                int val = int.Parse(data[i].ToString());
                _squares[i] = val == 0 ? new Square() : new FixedSquare(val);
            }
        }

        public string exportCurrentState()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < 81; i++)
            {
                sb.Append(_squares[i].value);
            }

            return sb.ToString();
        }

        public string exportOriginal()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < 81; i++)
            {
                if (_squares[i] is FixedSquare)
                    sb.Append(_squares[i].value);
                else
                    sb.Append(0);
            }

            return sb.ToString();
        }

        private void setupRegions()
        {
            // rows
            for (int i = 0; i < 9; i++)
            {
                _rows[i] = new Row();
                for (int j = 0; j < 9; j++)
                {
                    int index0 = (i*9) + j;
                    _rows[i].squares[j] = _squares[index0];
                    _squares[index0].Row = _rows[i];
                }
            }

            // columns
            for (int i = 0; i < 9; i++)
            {
                _columns[i] = new Column();

                for (int j = 0; j < 9; j++)
                {
                    int index0 = i + (j*9);
                    _columns[i].squares[j] = _squares[index0];
                    _squares[index0].Column = _columns[i];
                }
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    _sections[i + (j*3)] = new Section();

                    Square[] sq = {
                                      _squares[((i*3) + 0) + (((j*3) + 0)*9)],
                                      _squares[((i*3) + 1) + (((j*3) + 0)*9)],
                                      _squares[((i*3) + 2) + (((j*3) + 0)*9)],
                                      _squares[((i*3) + 0) + (((j*3) + 1)*9)],
                                      _squares[((i*3) + 1) + (((j*3) + 1)*9)],
                                      _squares[((i*3) + 2) + (((j*3) + 1)*9)],
                                      _squares[((i*3) + 0) + (((j*3) + 2)*9)],
                                      _squares[((i*3) + 1) + (((j*3) + 2)*9)],
                                      _squares[((i*3) + 2) + (((j*3) + 2)*9)],
                                  };

                    _squares[((i*3) + 0) + (((j*3) + 0)*9)].Section = _sections[i + (j*3)];
                    _squares[((i*3) + 0) + (((j*3) + 1)*9)].Section = _sections[i + (j*3)];
                    _squares[((i*3) + 0) + (((j*3) + 2)*9)].Section = _sections[i + (j*3)];
                    _squares[((i*3) + 1) + (((j*3) + 0)*9)].Section = _sections[i + (j*3)];
                    _squares[((i*3) + 1) + (((j*3) + 1)*9)].Section = _sections[i + (j*3)];
                    _squares[((i*3) + 1) + (((j*3) + 2)*9)].Section = _sections[i + (j*3)];
                    _squares[((i*3) + 2) + (((j*3) + 0)*9)].Section = _sections[i + (j*3)];
                    _squares[((i*3) + 2) + (((j*3) + 1)*9)].Section = _sections[i + (j*3)];
                    _squares[((i*3) + 2) + (((j*3) + 2)*9)].Section = _sections[i + (j*3)];

                    _sections[i + (j*3)].squares = sq;
                }
            }
            return;
        }

        public void Solve()
        {
            throw new NotImplementedException();
        }

        public void doSolveStep()
        {
            foreach (Square square in squares)
            {
                if(square.value!=0) continue;

                if (square.singleOption())
                {
                    for (int i = 0; i < 9; i++)
                    {
                        if (!square.notes[i]) continue;
                        square.value = ++i;
                        square.Column.updatenotes();
                        square.Row.updatenotes();
                        square.Section.updatenotes();
                        return;
                    }
                    throw new Exception();
                }
            }
            return;
        }

        public void updatenotes()
        {
            foreach (Square square in squares)
            {
                square.updatenotes();
            }
        }

        public string render()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 9; i++)
            {
                if (i == 3 || i == 6)
                    sb.AppendLine("------+-------+-------");

                for (int j = 0; j < 9; j++)
                {   
                    if(j == 3 || j == 6)
                        sb.Append("| ");

                    sb.Append(_rows[i].squares[j].value == 0 ? "  " : _rows[i].squares[j].value + " ");
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}