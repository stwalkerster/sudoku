using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibSudoku;

namespace SuDoku
{
    public partial class SquareControl : UserControl, ISquare
    {
        public SquareControl()
        {
            InitializeComponent();
        }

        public SquareControl(Square sq)
        {
            this.sq = sq;
            InitializeComponent();
        }

        private Square sq;

        #region Implementation of ISquare

        public bool[] notes
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public int value
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public Section Section
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public Column Column
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public Row Row
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public void updatenotes()
        {
            throw new NotImplementedException();
        }

        public bool singleOption()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
