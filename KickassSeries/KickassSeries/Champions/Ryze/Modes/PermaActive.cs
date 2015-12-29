
namespace KickassSeries.Champions.Ryze.Modes
{
    public sealed class PermaActive : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return true;
        }

        public override void Execute()
        {
            Functions.AutoStack();
            Functions.AutoCc();
            Functions.AutoHarass();
            Functions.KillSteal();
            Functions.AaBlock();
        }
    }
}
