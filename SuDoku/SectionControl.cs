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
    public partial class SectionControl : UserControl, IRegion
    {
        public SectionControl()
        {
            InitializeComponent();
        }

        private Section section;

        public SectionControl(Section sect)
        {
            section = sect;
            InitializeComponent();

            tableLayoutPanel1.Controls.Clear();


            for (int i = 0; i < 9; i++)
                tableLayoutPanel1.Controls.Add(new SquareControl(section.squares[i]) {Dock = DockStyle.Fill});
        }

        #region Implementation of IRegion

        public Square[] squares
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public int complete
        {
            get { throw new NotImplementedException(); }
        }

        public void updatenotes()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
