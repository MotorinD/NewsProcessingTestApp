using NewsProcessingTestApp.Interfaces.ShowData;

namespace NewsProcessingTestApp.Logic.ShowData
{
    public class ShowDataConsole : ShowDataBase
    {
        public ShowDataConsole(string text, IShowDataBehaviour showDataBehaviour ) : base(text)
        {
            ShowDataBehaviour = showDataBehaviour;
        }
    }
}
