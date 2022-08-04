using System;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string[,] armory = new string[size, size];
            for (int row = 0; row < size; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < size; col++)
                {
                    armory[row, col] = input[col].ToString();
                }
            }
            int officerRowIndex = 0;
            int officerColIndex = 0;
            for (int row = 0; row < armory.GetLength(0); row++)
            {
                for (int col = 0; col < armory.GetLength(1); col++)
                {
                    if (armory[row, col] == "A")
                    {
                        officerRowIndex = row;
                        officerColIndex = col;
                    }
                }
            }
            int collectedGold = 0;
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "up")
                {
                    armory[officerRowIndex, officerColIndex] = "-";
                    officerRowIndex--;
                    if (officerRowIndex < 0)
                    {
                        armory[officerRowIndex + 1, officerColIndex] = "-";
                        Console.WriteLine("I do not need more swords!");
                        break;
                    }
                    if (armory[officerRowIndex, officerColIndex] != "-" && armory[officerRowIndex, officerColIndex] != "M")
                    {
                        collectedGold += int.Parse(armory[officerRowIndex, officerColIndex]);
                    }
                    if (armory[officerRowIndex, officerColIndex] == "M")
                    {
                        armory[officerRowIndex, officerColIndex] = "-";
                        for (int row = 0; row < armory.GetLength(0); row++)
                        {
                            for (int col = 0; col < armory.GetLength(1); col++)
                            {
                                if (armory[row, col] == "M" && armory[row, col] != armory[officerRowIndex, officerColIndex])
                                {

                                    officerRowIndex = row;
                                    officerColIndex = col;
                                }
                            }
                        }
                    }
                    armory[officerRowIndex, officerColIndex] = "A";
                    if (collectedGold >= 65)
                    {
                        Console.WriteLine("Very nice swords, I will come back for more!");
                        break;
                    }
                }
                else if (command == "down")
                {
                    armory[officerRowIndex, officerColIndex] = "-";
                    officerRowIndex++;
                    if (officerRowIndex > size - 1)
                    {
                        armory[officerRowIndex - 1, officerColIndex] = "-";
                        Console.WriteLine("I do not need more swords!");
                        break;
                    }
                    if (armory[officerRowIndex, officerColIndex] != "-" && armory[officerRowIndex, officerColIndex] != "M")
                    {
                        collectedGold += int.Parse(armory[officerRowIndex, officerColIndex]);
                    }
                    if (armory[officerRowIndex, officerColIndex] == "M")
                    {
                        armory[officerRowIndex, officerColIndex] = "-";
                        for (int row = 0; row < armory.GetLength(0); row++)
                        {
                            for (int col = 0; col < armory.GetLength(1); col++)
                            {
                                if (armory[row, col] == "M" && armory[row, col] != armory[officerRowIndex, officerColIndex])
                                {

                                    officerRowIndex = row;
                                    officerColIndex = col;
                                }
                            }
                        }
                    }
                    armory[officerRowIndex, officerColIndex] = "A";
                    if (collectedGold >= 65)
                    {
                        Console.WriteLine("Very nice swords, I will come back for more!");
                        break;
                    }
                }
                else if (command == "left")
                {
                    armory[officerRowIndex, officerColIndex] = "-";
                    officerColIndex--;
                    if (officerColIndex < 0)
                    {
                        armory[officerRowIndex, officerColIndex + 1] = "-";
                        Console.WriteLine("I do not need more swords!");
                        break;
                    }
                    if (armory[officerRowIndex, officerColIndex] != "-" && armory[officerRowIndex, officerColIndex] != "M")
                    {
                        collectedGold += int.Parse(armory[officerRowIndex, officerColIndex]);
                    }
                    if (armory[officerRowIndex, officerColIndex] == "M")
                    {
                        armory[officerRowIndex, officerColIndex] = "-";
                        for (int row = 0; row < armory.GetLength(0); row++)
                        {
                            for (int col = 0; col < armory.GetLength(1); col++)
                            {
                                if (armory[row, col] == "M" && armory[row, col] != armory[officerRowIndex, officerColIndex])
                                {

                                    officerRowIndex = row;
                                    officerColIndex = col;
                                }
                            }
                        }
                    }
                    armory[officerRowIndex, officerColIndex] = "A";
                    if (collectedGold >= 65)
                    {
                        Console.WriteLine("Very nice swords, I will come back for more!");
                        break;
                    }
                }
                else if (command == "right")
                {
                    armory[officerRowIndex, officerColIndex] = "-";
                    officerColIndex++;
                    if (officerColIndex > size - 1)
                    {
                        armory[officerRowIndex, officerColIndex - 1] = "-";
                        Console.WriteLine("I do not need more swords!");
                        break;
                    }
                    if (armory[officerRowIndex, officerColIndex] != "-" && armory[officerRowIndex, officerColIndex] != "M")
                    {
                        collectedGold += int.Parse(armory[officerRowIndex, officerColIndex]);
                    }
                    if (armory[officerRowIndex, officerColIndex] == "M")
                    {
                        armory[officerRowIndex, officerColIndex] = "-";
                        for (int row = 0; row < armory.GetLength(0); row++)
                        {
                            for (int col = 0; col < armory.GetLength(1); col++)
                            {
                                if (armory[row, col] == "M" && armory[row, col] != armory[officerRowIndex, officerColIndex])
                                {

                                    officerRowIndex = row;
                                    officerColIndex = col;
                                }
                            }
                        }
                    }
                    armory[officerRowIndex, officerColIndex] = "A";
                    if (collectedGold >= 65)
                    {
                        Console.WriteLine("Very nice swords, I will come back for more!");
                        break;
                    }
                }
            }
            Console.WriteLine($"The king paid {collectedGold} gold coins.");
            for (int i = 0; i < armory.GetLength(0); i++)
            {
                for (int j = 0; j < armory.GetLength(1); j++)
                {
                    Console.Write(string.Format("{0}", armory[i, j]));
                }
                Console.WriteLine();
            }
        }
    }
}
