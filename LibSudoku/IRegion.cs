namespace LibSudoku
{
    public interface IRegion
    {
        Square[ ] squares
        {
            get;
            set;
        }

        int complete
        {
            get;
        }

        void updatenotes();
    }
}
