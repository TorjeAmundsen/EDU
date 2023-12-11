﻿// Commandline-argument for this application should be passed as follows
// dotnet run <day> <part>

// Example for day 1 and part 2: dotnet run 1 2
class Program
{
    private static readonly int current_day = 5;
    static void Main(string[] args)
    {
        var stop_watch = System.Diagnostics.Stopwatch.StartNew();

        if (args.Length == 0)
        {
            // run all days up to (and including) current_day
            for (int day = 1; day <= current_day; day++)
            {
                for (int part = 1; part <= 2; part++)
                {
                    Puzzle(day.ToString(), part.ToString());
                }
            }
        }
        else if (args.Length == 1)
        {
            // run one day and both parts
            Puzzle(args[0], "1");
            Puzzle(args[0], "2");
        }
        else
        {
            // run one day and one part
            Puzzle(args[0], args[1]);
        }

        stop_watch.Stop();
        long timer = stop_watch.ElapsedMilliseconds;

        Console.WriteLine($"Total execution time: {timer} milliseconds");
    }

    private static void Puzzle(string day, string part)
    {
        var puzzle_io = new AoC.PuzzleIO(day, part);

        string puzzle_input = puzzle_io.In();

        var stop_watch = System.Diagnostics.Stopwatch.StartNew();

        string puzzle_output = (day, part) switch
        {
            ( "1", "1" ) => AoC.Day1.Part1.Run(puzzle_input),
            ( "1", "2" ) => AoC.Day1.Part2.Run(puzzle_input),

            ( "2", "1" ) => AoC.Day2.Part1.Run(puzzle_input),
            ( "2", "2" ) => AoC.Day2.Part2.Run(puzzle_input),

            ( "3", "1" ) => AoC.Day3.Part1.Run(puzzle_input),
            ( "3", "2" ) => AoC.Day3.Part2.Run(puzzle_input),

            ( "4", "1" ) => AoC.Day4.Part1.Run(puzzle_input),
            ( "4", "2" ) => AoC.Day4.Part2.Run(puzzle_input),

            ( "5", "1" ) => AoC.Day5.Part1.Run(puzzle_input),
            ( "5", "2" ) => AoC.Day5.Part2.Run(puzzle_input),

            _ => String.Empty,
        };

        stop_watch.Stop();

        if (puzzle_output != String.Empty)
        {
            string out_path = puzzle_io.Out(puzzle_output);
            long timer = stop_watch.ElapsedMilliseconds;
            Console.WriteLine($"Day {day} part {part} > {out_path} | {timer} milliseconds");
        }
    }
}
