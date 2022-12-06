using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AdventOfCode.DayTwo
{
    public class DayTwo
    {
        private IEnumerable<(string, string)> input;
        private int RockScore = 1;
        private int PaperScore = 2;
        private int ScissorsScore = 3;

        private int LoseScore = 0;
        private int DrawScore = 3;
        private int WinScore = 6;


        public DayTwo(string fileName = "Input.txt")
        {
            var assembly = Assembly.GetExecutingAssembly();
            string resourceName = assembly.GetManifestResourceNames().Single(str => str.EndsWith("DayTwo." + fileName));
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                var results = reader.ReadToEnd().Split(Environment.NewLine);
                input = results.Select(x =>
                {
                    string[] s = x.Split(" ");
                    return (s[0], s[1]);
                });
            }
        }

        public int PartOne()
        {
            IEnumerable<(RPS, RPS)> rounds = input.Select(x => (ConvertEncryptedPlayToRPS(x.Item1), ConvertEncryptedPlayToRPS(x.Item2)));
            int totalPoints = 0;
            foreach (var round in rounds)
            {
                if (round.Item2 == RPS.Rock)
                {
                    totalPoints += RockScore;
                }
                else if (round.Item2 == RPS.Paper)
                {
                    totalPoints += PaperScore;
                }
                else
                {
                    totalPoints += ScissorsScore;
                }

                var outcome = GetGameOutcome(round.Item2, round.Item1);

                if (outcome == GameOutcome.Lose)
                {
                    totalPoints += LoseScore;
                }
                else if (outcome == GameOutcome.Draw)
                {
                    totalPoints += DrawScore;
                }
                else
                {
                    totalPoints += WinScore;
                }
            }

            return totalPoints;
        }

        public int PartTwo()
        {
            IEnumerable<(RPS, GameOutcome)> rounds = input.Select(x => (ConvertEncryptedPlayToRPS(x.Item1), ConvertEncryptedPlayToGameOutcome(x.Item2)));
            var totalPoints = 0;

            foreach (var round in rounds)
            {
                if (round.Item1 == RPS.Rock)
                {
                    if (round.Item2 == GameOutcome.Lose)
                    {
                        totalPoints += LoseScore + ScissorsScore;
                    }
                    else if (round.Item2 == GameOutcome.Draw)
                    {
                        totalPoints += DrawScore + RockScore;
                    }
                    else
                    {
                        totalPoints += WinScore + PaperScore;
                    }
                }
                else if (round.Item1 == RPS.Paper)
                {
                    if (round.Item2 == GameOutcome.Lose)
                    {
                        totalPoints += LoseScore + RockScore;
                    }
                    else if (round.Item2 == GameOutcome.Draw)
                    {
                        totalPoints += DrawScore + PaperScore;
                    }
                    else
                    {
                        totalPoints += WinScore + ScissorsScore;
                    }
                }
                else
                {
                    if (round.Item2 == GameOutcome.Lose)
                    {
                        totalPoints += LoseScore + PaperScore;
                    }
                    else if (round.Item2 == GameOutcome.Draw)
                    {
                        totalPoints += DrawScore + ScissorsScore;
                    }
                    else
                    {
                        totalPoints += WinScore + RockScore;
                    }
                }
            }

            return totalPoints;
        }

        private RPS ConvertEncryptedPlayToRPS(string play)
        {
            string[] RockValues = { "A", "X" };
            string[] PaperValues = { "B", "Y" };

            if (RockValues.Contains(play))
            {
                return RPS.Rock;
            }
            else if (PaperValues.Contains(play))
            {
                return RPS.Paper;
            }
            else
            {
                return RPS.Scissors;
            }
        }

        private GameOutcome ConvertEncryptedPlayToGameOutcome(string play)
        {
            if (play == "X")
            {
                return GameOutcome.Lose;
            }
            else if (play == "Y")
            {
                return GameOutcome.Draw;
            }
            else
            {
                return GameOutcome.Win;
            }
        }

        private GameOutcome GetGameOutcome(RPS playersMove, RPS opponentMove)
        {
            if (playersMove == RPS.Rock)
            {
                if (opponentMove == RPS.Rock)
                {
                    return GameOutcome.Draw;
                }
                else if (opponentMove == RPS.Paper)
                {
                    return GameOutcome.Lose;
                }
                else
                {
                    return GameOutcome.Win;
                }
            }
            else if (playersMove == RPS.Paper)
            {
                if (opponentMove == RPS.Rock)
                {
                    return GameOutcome.Win;
                }
                else if (opponentMove == RPS.Paper)
                {
                    return GameOutcome.Draw;
                }
                else
                {
                    return GameOutcome.Lose;
                }
            }
            else
            {
                if (opponentMove == RPS.Rock)
                {
                    return GameOutcome.Lose;
                }
                else if (opponentMove == RPS.Paper)
                {
                    return GameOutcome.Win;
                }
                else
                {
                    return GameOutcome.Draw;
                }
            }
        }
    }
}
