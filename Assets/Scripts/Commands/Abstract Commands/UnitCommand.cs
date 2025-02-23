using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Command.Player;

namespace Command.Commands
{
    public abstract class UnitCommand : ICommand
    {
        public CommandData commandData;

        protected UnitController actorUnit;
        protected UnitController targetUnit;

        public abstract void Execute();
        public abstract bool WillHitTarget();
    }
}