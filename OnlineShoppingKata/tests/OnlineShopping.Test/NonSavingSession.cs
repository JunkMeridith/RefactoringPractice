using Xunit;

namespace OnlineShopping.Test
{
    public class NonSavingSession : Session
    {
        public override void SaveAll()
        {
            
        }
    }
}
