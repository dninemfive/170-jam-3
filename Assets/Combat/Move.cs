using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace JamazonBrine
{
    /// <summary>
    /// The base definition of a Move, which is any action a character can perform in combat.
    /// </summary>
    public abstract record Move
    {
        public static readonly DebugMove DebugMove = new("Debug move");
        /// <summary>
        /// The move's display name. Ideally, unique, however this is not (yet?) enforced.
        /// </summary>
        public string Name;
        public Move(string name)
        {
            Name = name;
        }
        /// <summary>
        /// Executes the effects of the move.
        /// </summary>
        public abstract void Execute(Character user);
        public override string ToString() => Name;
    }
    /// <summary>
    /// A simple debug move, used for testing.
    /// </summary>
    public record DebugMove : Move
    {
        public DebugMove(string n) : base(n) { }
        public override void Execute(Character _)
        {
            Debug.Log($"Executing {this}!");
            RoundManager.BeginNextTurn();
        }
    }
    public abstract record TargetedMove : Move
    {
        public TargetedMove(string n) : base(n) { }
        protected Character Target = null;
        public override void Execute(Character user)
        {
            if(user.Side is Side side)
            {
                Target = RoundManager.CurrentScenario.CharactersOn(side.Opposite()).Random();
                
                
            } 
            else
            {
                
            }
        }
    }
    public record Attack : TargetedMove
    {
        public enum StatType { Health, Conviction }
        public int Damage { get; private set; }
        public StatType TargetStat { get; private set; }
        public bool IsHeal => Damage < 0;
        public Attack(string n, int damage, StatType type) : base(n)
        {
            Damage = damage;
            TargetStat = type;
        }
        public void Execute(Character user, Character target = null)
        {
            base.Execute(user);
            if(target is null)
            {
                if(user.Side is Side targetSide)
                {
                    if (!IsHeal) targetSide = targetSide.Opposite();
                    Target = RoundManager.CurrentScenario.CharactersOn(targetSide).Random();
                    if (Target is not null)
                    {
                        Debug.Log($"{user.Name} targets {Target.Name} with {Name}");
                    }
                    else
                    {
                        Debug.LogWarning($"Character {user.Name} attempted to execute move {Name}, but no targets could be found!");
                    }
                } 
                else
                {
                    Debug.LogWarning($"Character {user.Name} attempted to execute move {Name}, " +
                    $"but they are not on either Side of the current scenario {RoundManager.CurrentScenario.Name}!");
                }
            }
            Stat targetStat = TargetStat switch
            {
                StatType.Health => Stat.Health,
                StatType.Conviction => Stat.Conviction,
                _ => throw new Exception($"{TargetStat} is not a valid StatType!")
            };
            Target[targetStat].TakeDamage(Damage, user);
        }
    }
}
