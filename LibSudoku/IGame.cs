namespace LibSudoku
{
    public interface IGame
    {
        Row[] rows { get; }
        Section[] sections { get; }
        Column[] columns { get; }
        Square[] squares { get; }
        string exportCurrentState();
        string exportOriginal();
        void Solve();
        void doSolveStep();
        void updatenotes();
        string render();
    }
}