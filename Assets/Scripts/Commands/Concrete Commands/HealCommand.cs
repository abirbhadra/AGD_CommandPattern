using Command.Main;

namespace Command.Commands
{
    public class HealCommand : UnitCommand
    {
        private bool willHitTarget;
        private int previousHealth;

        public HealCommand(CommandData commandData)
        {
            this.commandData = commandData;
            willHitTarget = WillHitTarget();
        }

        public override bool WillHitTarget() => true;

        public override void Execute()
        {
            previousHealth = targetUnit.CurrentHealth;
            GameService.Instance.ActionService.GetActionByType(CommandType.Heal).PerformAction(actorUnit, targetUnit, willHitTarget);
        }

        public override void Undo()
        {
            if (willHitTarget)
            {
                if (previousHealth < targetUnit.CurrentHealth)
                {
                    targetUnit.TakeDamage(actorUnit.CurrentPower);
                }
                actorUnit.Owner.ResetCurrentActiveUnit();
            }
        }
    }
}
