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
    public partial class GameControl : UserControl, IGame
    {
        public GameControl()
        {
            InitializeComponent();
            
        }

        private string _data;
        public string data
        {
            get { return _data; }
            set { _data = value;
                initialise(); }
        }

        private void initialise()
        {
            tableLayoutPanel1.Controls.Clear();

            game = new Game(data);


            for (int i = 0; i < 9; i++)
                tableLayoutPanel1.Controls.Add(new SectionControl(game.sections[i]) {Dock = DockStyle.Fill});
        }

        private IGame game;

        #region Implementation of IGame

        public Row[] rows
        {
            get { return game.rows; }
        }

        public Section[] sections
        {
            get { return game.sections; }
        }

        public Column[] columns
        {
            get { return game.columns; }
        }

        public Square[] squares
        {
            get { return game.squares; }
        }

        public string exportCurrentState()
        {
            return game.exportCurrentState();
        }

        public string exportOriginal()
        {
            return game.exportOriginal();
        }

        public void Solve()
        {
            game.Solve();
        }

        public void doSolveStep()
        {
          game.doSolveStep();
        }

        public void updatenotes()
        {
           game.updatenotes();
        }

        public string render()
        {
            return game.render();
        }

        #endregion
    }
}
