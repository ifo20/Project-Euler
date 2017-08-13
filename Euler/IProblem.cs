// Declare interface IProblem
namespace Euler
{
    // Each Problem class will interface IProblem. Pose() prints out the problem, Solve() will return a string representing the answer
    public interface IProblem
    {
        string Solve();

        void Pose();
    }
}
