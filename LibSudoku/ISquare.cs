namespace LibSudoku
{
    public interface ISquare
    {
        bool[] notes { get; set; }
        int value { get; set; }
        Section Section { get; set; }
        Column Column { get; set; }
        Row Row { get; set; }
        void updatenotes();
        string ToString();
        bool singleOption();
    }
}