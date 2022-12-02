using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace JamazonBrine
{
    public class StatTracker
    {
        public Stat BaseStat { get; private set; }
        public string Name => BaseStat.Name;
        public Color BarColor => BaseStat.BarColor;
        private int currentValue;
        public int CurrentValue 
        { 
            get => currentValue;
            set => currentValue = Mathf.Clamp(value, 0, MaxValue);
        }
        public int MaxValue { get; private set; }
        public Character Owner { get; private set; }
        public StatTracker(Stat baseStat, int maxValue, Character owner)
        {
            BaseStat = baseStat;
            MaxValue = maxValue;
            CurrentValue = MaxValue;
            Owner = owner;
        }        
        public void TakeDamage(int amount, Character attacker)
        {
            int originalValue = CurrentValue;
            CurrentValue -= amount;
            string verbed = amount < 0 ? "healed" : "damaged";
            Debug.Log($"{attacker} {verbed} {Owner}'s {Name} stat by {Mathf.Abs(amount)}, going from {originalValue} to {currentValue}");
        }
    }
    public record Stat
    {
        public static readonly Stat Health = new()
        {
            Name = "Health",
            BarColor = new(200, 0, 0)
        };
        public static readonly Stat Conviction = new()
        {
            Name = "Conviction",
            BarColor = new(0, 150, 150),
            DisplayOnNPCsOnly = true
        };
        public string Name;
        public Color BarColor;
        public bool DisplayOnNPCsOnly = false;
    }
}
