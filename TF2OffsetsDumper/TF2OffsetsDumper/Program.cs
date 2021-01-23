using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TF2OffsetsDumper
{
    class Program
    {
        static void Main(string[] args)
        {
        start:
            Console.Title = "TF2 Offsets Dumper - by Lufzys";
            if(Globals.mem.ProcessIsRunning())
            {
                Globals.mem.Initialize();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(Environment.NewLine + "  [TF2] Modules has been searching...");

                while (Globals.Client == default(NullMemory.NullMemory.Module) || Globals.Engine == default(NullMemory.NullMemory.Module))
                {
                    Globals.Client = new NullMemory.NullMemory.Module(Globals.mem.NullProcess, "client.dll");
                    Globals.Engine = new NullMemory.NullMemory.Module(Globals.mem.NullProcess, "engine.dll");
                }

                Console.WriteLine("  [TF2] Modules has been founded");
                Console.WriteLine(Environment.NewLine + "  [TF2] Signature Scanning has been started!");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(Environment.NewLine + "  [TF2] Offsets | " + DateTime.Now.ToString("dd/mm/yyyy") + Environment.NewLine);

                Globals.sb.AppendLine("[TF2 Offsets Dumper | " + DateTime.Now.ToString("dd/mm/yyyy") + "]" + Environment.NewLine);
                int dwButtonBase = Globals.mem.FindPattern(Globals.Client, "68 ? ? ? ? 8B 40 28 FF D0 A1", 1, 0, true);
                int dwButtonBase2 = Globals.mem.FindPattern(Globals.Client, "A1 ? ? ? ? 5E A8 01 75 17", 1, 0, true);

                #region for .cs
                Globals.cs.AppendLine("using System;");
                Globals.cs.AppendLine();
                Globals.cs.AppendLine("namespace tf2dump");
                Globals.cs.AppendLine("{");
                Globals.cs.AppendLine("    //" + DateTime.Now.ToString("dd/mm/yyyy") + " | Created with TF2 Offsets Dumper - by Lufzys");
                Globals.cs.AppendLine("    public static class signatures");
                Globals.cs.AppendLine("    {");
                #endregion

                int dwLocalPlayer = Globals.mem.FindPattern(Globals.Client, "A1 ? ? ? ? 33 C9 83 C4 04", 1, 0, true);
                Console.WriteLine("  [OFFSET] dwLocalPlayer = 0x" + dwLocalPlayer.ToString("X"));
                Globals.sb.AppendLine("dwLocalPlayer = 0x" + dwLocalPlayer.ToString("X"));
                Globals.cs.AppendLine("        public const Int32 dwLocalPlayer = 0x" + dwLocalPlayer.ToString("X") + ";");

                int dwEntityList = Globals.mem.FindPattern(Globals.Client, "A1 ? ? ? ? A8 01 75  51 83 C8 01", 1, 0, true);
                dwEntityList += 0x18;
                Console.WriteLine("  [OFFSET] dwEntityList = 0x" + dwEntityList.ToString("X"));
                Globals.sb.AppendLine("dwEntityList = 0x" + dwEntityList.ToString("X"));
                Globals.cs.AppendLine("        public const Int32 dwEntityList = 0x" + dwEntityList.ToString("X") + ";");

                Console.WriteLine();
                Globals.sb.AppendLine();

                int dwForceAttack = dwButtonBase + 0x2C;
                Console.WriteLine("  [OFFSET] dwForceAttack = 0x" + dwForceAttack.ToString("X"));
                Globals.sb.AppendLine("dwForceAttack = 0x" + dwForceAttack.ToString("X"));
                Globals.cs.AppendLine("        public const Int32 dwForceAttack = 0x" + dwForceAttack.ToString("X") + ";");

                int dwForceAttack2 = dwButtonBase + 0x38;
                Console.WriteLine("  [OFFSET] dwForceAttack2 = 0x" + dwForceAttack2.ToString("X"));
                Globals.sb.AppendLine("dwForceAttack2 = 0x" + dwForceAttack2.ToString("X"));
                Globals.cs.AppendLine("        public const Int32 dwForceAttack2 = 0x" + dwForceAttack2.ToString("X") + ";");

                int dwForceJump = dwButtonBase + 0x20;
                Console.WriteLine("  [OFFSET] dwForceJump = 0x" + dwForceJump.ToString("X"));
                Globals.sb.AppendLine("dwForceJump = 0x" + dwForceJump.ToString("X"));
                Globals.cs.AppendLine("        public const Int32 dwForceJump = 0x" + dwForceJump.ToString("X") + ";");

                int dwForceDuck = dwButtonBase + 0x5C;
                Console.WriteLine("  [OFFSET] dwForceDuck = 0x" + dwForceDuck.ToString("X"));
                Globals.sb.AppendLine("dwForceDuck = 0x" + dwForceDuck.ToString("X"));
                Globals.cs.AppendLine("        public const Int32 dwForceDuck = 0x" + dwForceDuck.ToString("X") + ";");

                int dwForceRight = dwButtonBase2 + 0x30;
                Console.WriteLine("  [OFFSET] dwForceRight = 0x" + dwForceRight.ToString("X"));
                Globals.sb.AppendLine("dwForceRight = 0x" + dwForceRight.ToString("X"));
                Globals.cs.AppendLine("        public const Int32 dwForceRight = 0x" + dwForceRight.ToString("X") + ";");

                int dwForceLeft = dwButtonBase2 + 0x24;
                Console.WriteLine("  [OFFSET] dwForceLeft = 0x" + dwForceLeft.ToString("X"));
                Globals.sb.AppendLine("dwForceLeft = 0x" + dwForceLeft.ToString("X"));
                Globals.cs.AppendLine("        public const Int32 dwForceLeft = 0x" + dwForceLeft.ToString("X") + ";");

                Console.WriteLine();
                Globals.sb.AppendLine();

                int dwForceMoveLeft = dwButtonBase2 + 0x78;
                Console.WriteLine("  [OFFSET] dwForceMoveLeft = 0x" + dwForceMoveLeft.ToString("X"));
                Globals.sb.AppendLine("dwForceMoveLeft = 0x" + dwForceMoveLeft.ToString("X"));
                Globals.cs.AppendLine("        public const Int32 dwForceMoveLeft = 0x" + dwForceMoveLeft.ToString("X") + ";");

                int dwForceMoveRight = dwButtonBase2 + 0x84;
                Console.WriteLine("  [OFFSET] dwForceMoveRight = 0x" + dwForceMoveRight.ToString("X"));
                Globals.sb.AppendLine("dwForceMoveRight = 0x" + dwForceMoveRight.ToString("X"));
                Globals.cs.AppendLine("        public const Int32 dwForceMoveRight = 0x" + dwForceMoveRight.ToString("X") + ";");

                int dwForceMoveForwards = dwButtonBase + 0xFCC;
                Console.WriteLine("  [OFFSET] dwForceMoveForwards = 0x" + dwForceMoveForwards.ToString("X"));
                Globals.sb.AppendLine("dwForceMoveForwards = 0x" + dwForceMoveForwards.ToString("X"));
                Globals.cs.AppendLine("        public const Int32 dwForceMoveForwards = 0x" + dwForceMoveForwards.ToString("X") + ";");

                int dwForceMoveBackwards = dwButtonBase + 0xFC0;
                Console.WriteLine("  [OFFSET] dwForceMoveBackwards = 0x" + dwForceMoveBackwards.ToString("X"));
                Globals.sb.AppendLine("dwForceMoveBackwards = 0x" + dwForceMoveBackwards.ToString("X"));
                Globals.cs.AppendLine("        public const Int32 dwForceMoveBackwards = 0x" + dwForceMoveBackwards.ToString("X") + ";");

                Console.WriteLine();
                Globals.sb.AppendLine();

                int dwGlowObjectManager = Globals.mem.FindPattern(Globals.Client, "B9 ? ? ? ? E8 ? ? ? ? B0 01 5D", 1, 0, true);
                Console.WriteLine("  [OFFSET] dwGlowObjectManager = 0x" + dwGlowObjectManager.ToString("X"));
                Globals.sb.AppendLine("dwGlowObjectManager = 0x" + dwGlowObjectManager.ToString("X"));
                Globals.cs.AppendLine("        public const Int32 dwGlowObjectManager = 0x" + dwGlowObjectManager.ToString("X") + ";");

                Console.WriteLine();
                Globals.sb.AppendLine();

                int dwGetMaxClients = Globals.mem.FindPattern(Globals.Engine, "83 3D ? ? ? ? ? 75 38", 2, 0, true);
                Console.WriteLine("  [OFFSET] dwGetMaxClients = 0x" + dwGetMaxClients.ToString("X"));
                Globals.sb.AppendLine("dwGetMaxClients = 0x" + dwGetMaxClients.ToString("X"));
                Globals.cs.AppendLine("        public const Int32 dwGetMaxClients = 0x" + dwGetMaxClients.ToString("X") + ";");

                int dwIsInGame = Globals.mem.FindPattern(Globals.Engine, "83 3D ? ? ? ? ?  0F 9D C0 C3", 2, 0, true);
                Console.WriteLine("  [OFFSET] dwIsInGame = 0x" + dwIsInGame.ToString("X"));
                Globals.sb.AppendLine("dwIsInGame = 0x" + dwIsInGame.ToString("X"));
                Globals.cs.AppendLine("        public const Int32 dwIsInGame = 0x" + dwIsInGame.ToString("X") + ";");

                int dwIsConnected = Globals.mem.FindPattern(Globals.Engine, "80 3D  ? ? ? ? ? 0F 85 ? ? ? ? E8 ? ? ? ? 6A 00", 2, 0, true);
                Console.WriteLine("  [OFFSET] dwIsConnected = 0x" + dwIsConnected.ToString("X"));
                Globals.sb.AppendLine("dwIsConnected = 0x" + dwIsConnected.ToString("X"));
                Globals.cs.AppendLine("        public const Int32 dwIsConnected = 0x" + dwIsConnected.ToString("X") + ";");

                int dwViewAngles = Globals.mem.FindPattern(Globals.Engine, "D9 1D ? ? ? ? D9 46 04", 2, 0, true);
                Console.WriteLine("  [OFFSET] dwViewAngles = 0x" + dwViewAngles.ToString("X"));
                Globals.sb.AppendLine("dwViewAngles = 0x" + dwViewAngles.ToString("X"));
                Globals.cs.AppendLine("        public const Int32 dwViewAngles = 0x" + dwViewAngles.ToString("X") + ";");

                int dwViewMatrix = Globals.mem.FindPattern(Globals.Engine, "8B 0D ? ? ? ? 8B 01 FF 60 7C", 2, 0, true);
                dwViewMatrix += 0x34;
                Console.WriteLine("  [OFFSET] dwViewMatrix = 0x" + dwViewMatrix.ToString("X"));
                Globals.sb.AppendLine("dwViewMatrix = 0x" + dwViewMatrix.ToString("X") + " // I'm not sure");
                Globals.cs.AppendLine("        public const Int32 dwViewMatrix = 0x" + dwViewMatrix.ToString("X") + "; // I'm not sure");

                #region for .cs
                Globals.cs.AppendLine("    }");
                Globals.cs.AppendLine("}");
                #endregion

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(Environment.NewLine + "  [TF2] Do you want to save to a file [Y] Yes | [N] No");
                string result = Console.ReadLine();
                if(result == "Y" || result == "y")
                {
                    File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "/tf2-dump.txt", Globals.sb.ToString());
                    File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "/tf2dump.cs", Globals.cs.ToString());
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(Environment.NewLine + "  [TF2] hl2.exe not founded!");
                Thread.Sleep(5000);
                Environment.Exit(0);
            }
        }
    }
}
