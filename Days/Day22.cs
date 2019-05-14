using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Days
{
    enum ESpellType
    {
        eMagicMissile,
        eDrain,
        eShield,
        ePoison,
        eRecharge
    }

    class Spell
    {
        public int ManaCost { get; set; }
        /*public int Damage { get; set; }
        public int Heal { get; set; }
        public int EffectTime { get; set; }
        public int EffectArmor { get; set; }
        public int EffectDamage { get; set; }
        public int EffectMana { get; set; }*/
        public ESpellType Type { get; set; }
    }

    class Wizard
    {
        public int Hitpoints { get; set; }
        public int Mana { get; set; }
        public int Armor { get; set; }

        public Wizard(int hp, int mana)
        {
            Hitpoints = hp;
            Mana = mana;
        }
    }

    class Boss
    {
        public int Hitpoints { get; set; }
        public int Damage { get; set; }

        public Boss(int hp, int dmg)
        {
            Hitpoints = hp;
            Damage = dmg;
        }
    }

    class Effect
    {
        public int RemainingTime { get; set; }
        public ESpellType SpellType { get; set; }
    }

    class GameState
    {
        public Wizard wizard;
        public Boss boss;
        public bool IsWizwardTurn;
        public List<Effect> ActiveEffects;
        public int ManaUsage;

        public void ApplyEffects()
        {
            for (int e = 0; e < ActiveEffects.Count; e++)
            {
                switch (ActiveEffects[e].SpellType)
                {
                    case ESpellType.eShield:
                        wizard.Armor = 7;
                        break;
                    case ESpellType.ePoison:
                        boss.Hitpoints -= 3;
                        break;
                    case ESpellType.eRecharge:
                        wizard.Mana += 101;
                        break;
                }
                if (--ActiveEffects[e].RemainingTime == 0)
                {
                    ActiveEffects.Remove(ActiveEffects[e--]);
                }
            }
        }

        public bool BossDown()
        {
            if (boss.Hitpoints <= 0)
            {
                return true;
            }
            return false;
        }
    }

    public class Day22: Day
    {
        public Day22()
        {
            Part1Text = "Least mana spent for victory";
            Part2Text = "Least mana spent for victory (hard mode)";

            Load("inputs/day22.txt");
        }

        private int SimulateGames(bool hardMode)
        {
            int minimumManaUsageForVictory = int.MaxValue;
            GameState currentState;

            List<Spell> spells = new List<Spell>()
            {
                new Spell() { ManaCost = 53, Type = ESpellType.eMagicMissile },
                new Spell() { ManaCost = 73, Type = ESpellType.eDrain },
                new Spell() { ManaCost = 113, Type = ESpellType.eShield },
                new Spell() { ManaCost = 173, Type = ESpellType.ePoison },
                new Spell() { ManaCost = 229, Type = ESpellType.eRecharge }
            };

            GameState initial = new GameState
            {
                wizard = new Wizard(50, 500),
                boss = new Boss(51, 9),
                IsWizwardTurn = true,
                ActiveEffects = new List<Effect>()
            };

            List<GameState> checkStates = new List<GameState>()
            {
                initial
            };

            while (checkStates.Count > 0)
            {
                currentState = checkStates[0];
                checkStates.Remove(currentState);

                if (currentState.IsWizwardTurn && hardMode)
                {
                    if (--currentState.wizard.Hitpoints == 0)
                    {
                        continue;
                    }
                }

                if (currentState.ManaUsage > minimumManaUsageForVictory)
                {
                    continue;
                }

                currentState.ApplyEffects();

                if (currentState.BossDown())
                {
                    minimumManaUsageForVictory = Math.Min(minimumManaUsageForVictory, currentState.ManaUsage);
                    for (int c = 0; c < checkStates.Count; c++)
                    {
                        if (checkStates[c].ManaUsage > minimumManaUsageForVictory)
                        {
                            checkStates.Remove(checkStates[c--]);
                        }
                    }
                    continue;
                }

                if (currentState.IsWizwardTurn)
                {
                    foreach (Spell s in spells)
                    {
                        if (currentState.wizard.Mana >= s.ManaCost)
                        {
                            bool isActive = false;
                            foreach (Effect e in currentState.ActiveEffects)
                            {
                                if (e.SpellType == s.Type)
                                {
                                    isActive = true;
                                    break;
                                }
                            }
                            if (!isActive)
                            {
                                GameState nextState = new GameState
                                {
                                    wizard = new Wizard(currentState.wizard.Hitpoints, currentState.wizard.Mana - s.ManaCost),
                                    boss = new Boss(currentState.boss.Hitpoints, currentState.boss.Damage),
                                    IsWizwardTurn = false,
                                    ActiveEffects = new List<Effect>(),
                                    ManaUsage = currentState.ManaUsage + s.ManaCost
                                };
                                foreach (Effect e in currentState.ActiveEffects)
                                {
                                    nextState.ActiveEffects.Add(new Effect() { RemainingTime = e.RemainingTime, SpellType = e.SpellType });
                                }

                                switch (s.Type)
                                {
                                    case ESpellType.eMagicMissile:
                                        nextState.boss.Hitpoints -= 4;
                                        break;
                                    case ESpellType.eDrain:
                                        nextState.boss.Hitpoints -= 2;
                                        nextState.wizard.Hitpoints += 2;
                                        break;
                                    case ESpellType.eShield:
                                        nextState.ActiveEffects.Add(new Effect() { RemainingTime = 6, SpellType = ESpellType.eShield });
                                        break;
                                    case ESpellType.ePoison:
                                        nextState.ActiveEffects.Add(new Effect() { RemainingTime = 6, SpellType = ESpellType.ePoison });
                                        break;
                                    case ESpellType.eRecharge:
                                        nextState.ActiveEffects.Add(new Effect() { RemainingTime = 5, SpellType = ESpellType.eRecharge });
                                        break;
                                }

                                if (nextState.BossDown())
                                {
                                    minimumManaUsageForVictory = Math.Min(minimumManaUsageForVictory, nextState.ManaUsage);
                                    for (int c = 0; c < checkStates.Count; c++)
                                    {
                                        if (checkStates[c].ManaUsage > minimumManaUsageForVictory)
                                        {
                                            checkStates.Remove(checkStates[c--]);
                                        }
                                    }
                                }
                                else
                                {
                                    checkStates.Add(nextState);
                                }
                            }
                        }
                    }
                }
                else
                {
                    int damageDone = currentState.boss.Damage - currentState.wizard.Armor;

                    currentState.wizard.Hitpoints -= damageDone < 1 ? 1 : damageDone;
                    if (currentState.wizard.Hitpoints <= 0)
                    {
                        // Wizard was defeated
                        continue;
                    }
                    else
                    {
                        GameState g = new GameState
                        {
                            wizard = new Wizard(currentState.wizard.Hitpoints, currentState.wizard.Mana),
                            boss = new Boss(currentState.boss.Hitpoints, currentState.boss.Damage),
                            IsWizwardTurn = true,
                            ActiveEffects = new List<Effect>(),
                            ManaUsage = currentState.ManaUsage
                        };
                        foreach (Effect e in currentState.ActiveEffects)
                        {
                            g.ActiveEffects.Add(new Effect() { RemainingTime = e.RemainingTime, SpellType = e.SpellType });
                        }
                        checkStates.Add(g);
                    }
                }
            }
            return minimumManaUsageForVictory;
        }

        override public void Solve()
        {
            Part1Solution = SimulateGames(false).ToString();
            Part2Solution = SimulateGames(true).ToString();
        }
    }
}
