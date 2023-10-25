using NewsProcessingTestApp.Interfaces.ShowData;

namespace NewsProcessingTestApp.Logic.ShowData
{
    public abstract class ShowDataBase
    {
        protected readonly string Text;
        protected IShowDataBehaviour? ShowDataBehaviour;

        public ShowDataBase(string text)
        {
            this.Text = text;
        }

        public void ShowData()
        {
            ShowDataBehaviour?.Execute(this.Text);
        }
    }
}
