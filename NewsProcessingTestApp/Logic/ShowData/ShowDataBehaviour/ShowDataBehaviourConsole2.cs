using NewsProcessingTestApp.Helpers;
using NewsProcessingTestApp.Interfaces.ShowData;

namespace NewsProcessingTestApp.Logic.ShowData.ShowDataBehaviour
{
    internal class ShowDataBehaviourConsole2 : IShowDataBehaviour
    {
        public void Execute(string text)
        {
            Console.WriteLine("==>   ");
            Console.WriteLine(text + "\n");
        }
    }
}
