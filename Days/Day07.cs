using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Days
{
    enum EInstruction
    {
        allocation,
        not,
        leftShift,
        rightShift,
        and,
        or
    }

    class Instruction
    {
        public string[] input = new string[2];
        public string output;
        public EInstruction instruction;
    }

    public class Day07: Day
    {
        public Day07()
        {
            Part1Text = "Signal on wire a";
            Part2Text = "Signal on wire a (with preset b)";

            Load("inputs/day07.txt");
        }

        private List<Instruction> ReadInstructionList()
        {
            List<Instruction> instructions = new List<Instruction>();
            foreach (string s in Input)
            {
                string[] splitted = s.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                Instruction instr = new Instruction();
                switch (splitted.Length)
                {
                    case 3:
                        instr.input[0] = splitted[0];
                        instr.output = splitted[2];
                        instr.instruction = EInstruction.allocation;
                        break;
                    case 4:
                        instr.input[0] = splitted[1];
                        instr.output = splitted[3];
                        instr.instruction = EInstruction.not; // allocation
                        break;
                    case 5:
                        instr.input[0] = splitted[0];
                        instr.input[1] = splitted[2];
                        instr.output = splitted[4];
                        switch (splitted[1])
                        {
                            case "AND":
                                instr.instruction = EInstruction.and;
                                break;
                            case "OR":
                                instr.instruction = EInstruction.or;
                                break;
                            case "LSHIFT":
                                instr.instruction = EInstruction.leftShift;
                                break;
                            case "RSHIFT":
                                instr.instruction = EInstruction.rightShift;
                                break;
                        }
                        break;
                }
                instructions.Add(instr);
            }
            return instructions;
        }

        private ushort SimulateCircuit(List<Instruction> allInstructions)
        {
            List<Instruction> executable = new List<Instruction>();
            Dictionary<string, ushort> wires = new Dictionary<string, ushort>();
            int val = 0, in1, in2;

            while (allInstructions.Count > 0)
            {
                foreach (Instruction i in allInstructions)
                {
                    if (i.instruction == EInstruction.allocation)
                    {
                        if (int.TryParse(i.input[0], out val))
                        {
                            executable.Add(i);
                        }
                        else
                        {
                            if (wires.ContainsKey(i.input[0]))
                            {
                                executable.Add(i);
                            }
                        }
                    }
                    else if (i.instruction == EInstruction.not)
                    {
                        if (wires.ContainsKey(i.input[0]))
                        {
                            executable.Add(i);
                        }
                    }
                    else
                    {
                        if ((int.TryParse(i.input[0], out val) || wires.ContainsKey(i.input[0])) &&
                            (int.TryParse(i.input[1], out val) || wires.ContainsKey(i.input[1])))
                        {
                            executable.Add(i);
                        }
                    }
                }

                foreach (Instruction i in executable)
                {
                    switch (i.instruction)
                    {
                        case EInstruction.allocation:
                            if (!int.TryParse(i.input[0], out val))
                            {
                                val = wires[i.input[0]];
                            }
                            break;
                        case EInstruction.not:
                            if (int.TryParse(i.input[0], out val))
                            {
                                val = ~val;
                            }
                            else
                            {
                                val = ~wires[i.input[0]];
                            }
                            break;
                        case EInstruction.and:
                            if (!int.TryParse(i.input[0], out in1))
                            {
                                in1 = wires[i.input[0]];
                            }
                            if (!int.TryParse(i.input[1], out in2))
                            {
                                in2 = wires[i.input[1]];
                            }
                            val = in1 & in2;
                            break;
                        case EInstruction.or:
                            if (!int.TryParse(i.input[0], out in1))
                            {
                                in1 = wires[i.input[0]];
                            }
                            if (!int.TryParse(i.input[1], out in2))
                            {
                                in2 = wires[i.input[1]];
                            }
                            val = in1 | in2;
                            break;
                        case EInstruction.leftShift:
                            if (!int.TryParse(i.input[0], out in1))
                            {
                                in1 = wires[i.input[0]];
                            }
                            if (!int.TryParse(i.input[1], out in2))
                            {
                                in2 = wires[i.input[1]];
                            }
                            val = in1 << in2;
                            break;
                        case EInstruction.rightShift:
                            if (!int.TryParse(i.input[0], out in1))
                            {
                                in1 = wires[i.input[0]];
                            }
                            if (!int.TryParse(i.input[1], out in2))
                            {
                                in2 = wires[i.input[1]];
                            }
                            val = in1 >> in2;
                            break;
                    }

                    if (wires.ContainsKey(i.output))
                    {
                        wires[i.output] = (ushort)val;
                    }
                    else
                    {
                        wires.Add(i.output, (ushort)val);
                    }
                    allInstructions.Remove(i);
                }
                executable.Clear();
            }
            return wires["a"];
        }

        override public void Solve()
        {
            List<Instruction> allInstructions;

            allInstructions = ReadInstructionList();

            ushort presetB = SimulateCircuit(allInstructions);
            Part1Solution = presetB.ToString();
            allInstructions = ReadInstructionList();
            foreach(Instruction i in allInstructions)
            {
                if (i.output.Equals("b"))
                {
                    i.input[0] = presetB.ToString();
                    i.instruction = EInstruction.allocation;
                }
            }
            Part2Solution = SimulateCircuit(allInstructions).ToString();
        }
    }
}
