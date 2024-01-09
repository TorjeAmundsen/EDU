namespace AoC.Day8;

class Part1
{
    private static readonly int _start_node = 656565; // AAA in ascii = '65 65 65'
    private static readonly int _end_node = 909090;   // ZZZ in ascii = '90 90 90'

    public static string Run(string puzzle_input)
    {
        bool[] instructions = GetLeftRightInstructions(puzzle_input);

        Dictionary<int, (int left, int right)> nodes = GetNodes(puzzle_input);

        int result = TraverseNodes(instructions, nodes);

        return result.ToString();
    }

    public static bool[] GetLeftRightInstructions(string puzzle_input)
    {
        // left = false & right = true

        char[] first_line  = puzzle_input.Split('\n')[0].ToArray();

        bool[] instructinos = new bool[first_line.Length];

        for (int index = 0; index < first_line.Length; index++)
        {
            instructinos[index] = first_line[index] == 'R'; // L -> false
        }

        return instructinos;
    }

    public static Dictionary<int, (int left, int right)> GetNodes(string puzzle_input)
    {
        // The nodes are represented as three characters,
        // ..we cast these to their corresponding ascii values
        // then we append them one after another to a string
        // finally we create a numeric value which we cast to integer
        // Why? ..working with integers is much faster than strings

        Dictionary<int, (int left, int right)> nodes = new();

        string[] lines  = puzzle_input.Split('\n').ToArray();

        int index = 2; // nodes start from 3rd line in puzzle input
        while (index < lines.Length)
        {
            string line = lines[index];
            if (line.Length < 16) break;

            string position = line.Substring(startIndex: 0, length: 3);
            string left = line.Substring(startIndex:7, length: 3);
            string right = line.Substring(startIndex: 12, length: 3);

            string p = String.Empty;
            string l = String.Empty;
            string r = String.Empty;

            int i = 0;
            while (i < 3)
            {
                // turning characters like "AAA" to string with ascii values "656565"
                p += ((int)position[i]).ToString();
                l += ((int)left[i]).ToString();
                r += ((int)right[i]).ToString();
                i++;
            }

            // turning numeric values to integers e.g. "656565" to 656565
            int int_position = int.Parse(p);
            int int_left = int.Parse(l);
            int int_right = int.Parse(r);

            nodes.Add(int_position, (int_left, int_right));

            index++;
        }

        return nodes;
    }

    public static int TraverseNodes(bool[] instructions, Dictionary<int, (int left, int right)> nodes)
    {
        int steps = 0;
        int index = 0;
        int node = _start_node;

        while (node != _end_node)
        {
            (int left, int right) = nodes[node];

            node = instructions[index] ? right : left;

            // get next instruction
            index++;

            // reset instruction if out of bounds
            if (index == instructions.Length) index = 0;

            // increase steps
            steps++;
        }

        return steps;
    }
}