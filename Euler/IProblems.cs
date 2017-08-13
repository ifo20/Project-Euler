// Declare interface IProblems
namespace Euler
{
    // Each Problem class will interface IProblems. Pose() prints out the problem, Solve() will return a string representing the answer
    public interface IProblems
    {
        string Solve();

        void Pose();
    }
}
