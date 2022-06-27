using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SULectureCode
{
    class Program
    {
        static void Main(string[] args)
        {
            int mineSize = int.Parse(Console.ReadLine());
            if (mineSize <= int.MaxValue)
            {
                string[] minerMoves = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                string[,] mine = new string[mineSize, mineSize];
                for (int row = 0; row < mineSize; row++)
                {
                    string[] input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                    for (int col = 0; col < mineSize; col++)
                    {
                        mine[row, col] = input[col];
                    }
                }
                int minerRowIndex = 0;
                int minerColIndex = 0;
                int coalCount = 0;
                bool reachTheEnd = false;
                for (int row = 0; row < mineSize; row++)
                {
                    for (int col = 0; col < mineSize; col++)
                    {
                        if (mine[row, col] == "c")
                        {
                            coalCount++;
                        }
                        if (mine[row, col] == "s")
                        {
                            minerRowIndex = row;
                            minerColIndex = col;
                        }
                    }
                }
                for (int i = 0; i < minerMoves.Length; i++)
                {
                    if (minerMoves[i] == "up")
                    {
                        if (minerRowIndex > 0)
                        {
                            minerRowIndex--;
                            if (mine[minerRowIndex, minerColIndex] == "c")
                            {
                                coalCount--;
                                mine[minerRowIndex, minerColIndex] = "*";
                                if (coalCount == 0)
                                {
                                    Console.WriteLine($"You collected all coals! ({minerRowIndex}, {minerColIndex})");
                                    break;
                                }
                            }
                            if (mine[minerRowIndex, minerColIndex] == "e")
                            {
                                Console.WriteLine($"Game over! ({minerRowIndex}, {minerColIndex})");
                                reachTheEnd = true;
                                break;
                            }
                        }
                    }
                    if (minerMoves[i] == "down")
                    {
                        if (minerRowIndex < mine.GetLength(0) - 1)
                        {
                            minerRowIndex++;
                            if (mine[minerRowIndex, minerColIndex] == "c")
                            {
                                coalCount--;
                                mine[minerRowIndex, minerColIndex] = "*";
                                if (coalCount == 0)
                                {
                                    Console.WriteLine($"You collected all coals! ({minerRowIndex}, {minerColIndex})");
                                    break;
                                }
                            }
                            if (mine[minerRowIndex, minerColIndex] == "e")
                            {
                                Console.WriteLine($"Game over! ({minerRowIndex}, {minerColIndex})");
                                reachTheEnd = true;
                                break;
                            }
                        }
                    }
                    if (minerMoves[i] == "left")
                    {
                        if (minerColIndex > 0)
                        {
                            minerColIndex--;
                            if (mine[minerRowIndex, minerColIndex] == "c")
                            {
                                coalCount--;
                                mine[minerRowIndex, minerColIndex] = "*";
                                if (coalCount == 0)
                                {
                                    Console.WriteLine($"You collected all coals! ({minerRowIndex}, {minerColIndex})");
                                    break;
                                }
                            }
                            if (mine[minerRowIndex, minerColIndex] == "e")
                            {
                                Console.WriteLine($"Game over! ({minerRowIndex}, {minerColIndex})");
                                reachTheEnd = true;
                                break;
                            }
                        }
                    }
                    if (minerMoves[i] == "right")
                    {
                        if (minerColIndex < mine.GetLength(1) - 1)
                        {
                            minerColIndex++;
                            if (mine[minerRowIndex, minerColIndex] == "c")
                            {
                                coalCount--;
                                mine[minerRowIndex, minerColIndex] = "*";
                                if (coalCount == 0)
                                {
                                    Console.WriteLine($"You collected all coals! ({minerRowIndex}, {minerColIndex})");
                                    break;
                                }
                            }
                            if (mine[minerRowIndex, minerColIndex] == "e")
                            {
                                Console.WriteLine($"Game over! ({minerRowIndex}, {minerColIndex})");
                                reachTheEnd = true;
                                break;
                            }
                        }
                    }
                }
                if (coalCount > 0 && reachTheEnd == false)
                {
                    Console.WriteLine($"{coalCount} coals left. ({minerRowIndex}, {minerColIndex})");
                }
            }
        }
    }
}