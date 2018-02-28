using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace TVGenCode
{
    public class cTaoDuAn
    {
        public void CreateSolution()
        {
            // Tao ra file solution
            string Path = Program.ThuMucGoc;
            string PrjName = Path.Substring(Path.LastIndexOf("\\") + 1);
            // Tao file Solution
            string[] arrLines = File.ReadAllLines("Templates\\Prj.sln.Template.txt");
            for (int i = 0; i < arrLines.Length; i++)
            {
                if (arrLines[i].IndexOf("<@Prj@>") >= 0)
                    arrLines[i] = arrLines[i].Replace("<@Prj@>", PrjName);

            }
            File.WriteAllLines(Program.ThuMucGoc + "\\" + PrjName + ".sln", arrLines);
        }

        public void CreateEntityPrj(string[] arrTables)
        {
            // Tao ra cac thu muc trong du an
            // 1. Tao thu muc du an
            // 2. Tao thu muc con cua du an
            string Path = Program.ThuMucGoc;
            string PrjName = Path.Substring(Path.LastIndexOf("\\") + 1);
            Directory.CreateDirectory(Program.ThuMucGoc + "\\" + PrjName + ".Entity");
            Directory.CreateDirectory(Program.ThuMucGoc + "\\" + PrjName + ".Entity\\Bin");
            Directory.CreateDirectory(Program.ThuMucGoc + "\\" + PrjName + ".Entity\\Bin\\Debug");
            Directory.CreateDirectory(Program.ThuMucGoc + "\\" + PrjName + ".Entity\\Obj");
            Directory.CreateDirectory(Program.ThuMucGoc + "\\" + PrjName + ".Entity\\Obj\\Debug");
            Directory.CreateDirectory(Program.ThuMucGoc + "\\" + PrjName + ".Entity\\Properties");
            // Tao file Assembly
            string[] arrLines = File.ReadAllLines("Templates\\Entity.AssemblyInfo.Template.txt");
            for (int i = 0; i < arrLines.Length; i++)
            {
                if (arrLines[i].IndexOf("<@Prj@>") >= 0)
                    arrLines[i] = arrLines[i].Replace("<@Prj@>", PrjName);

            }
            File.WriteAllLines(Program.ThuMucGoc + "\\" + PrjName + ".Entity\\Properties\\AssemblyInfo.cs", arrLines);        
            // Tao file du an
            arrLines = File.ReadAllLines("Templates\\Entity.csProj.Template.txt");
            for (int i = 0; i < arrLines.Length; i++)
            {
                if (arrLines[i].IndexOf("<@Prj@>") >= 0)
                    arrLines[i] = arrLines[i].Replace("<@Prj@>", PrjName);
                // Duyet cac tables de ghi vao file
                int index = arrLines[i].IndexOf("<@Class@>");
                if (index >= 0)
                {
                    string line = arrLines[i].Remove(index);
                    arrLines[i] = "";
                    for (int j = 0; j < arrTables.Length; j++)
                        arrLines[i] = arrLines[i] + line + "<Compile Include=\"" + arrTables[j] + "Info.cs\" />";
                }
            }
            File.WriteAllLines(Program.ThuMucGoc + "\\" + PrjName + ".Entity\\" + PrjName + ".Entity.csProj", arrLines);        
        }

        public void CreateDataPrj(string[] arrTables)
        {
            // Tao ra cac thu muc trong du an
            // 1. Tao thu muc du an
            // 2. Tao thu muc con cua du an
            string Path = Program.ThuMucGoc;
            string PrjName = Path.Substring(Path.LastIndexOf("\\") + 1);
            
            Directory.CreateDirectory(Program.ThuMucGoc + "\\" + PrjName + ".Data");
            Directory.CreateDirectory(Program.ThuMucGoc + "\\" + PrjName + ".Data\\Bin");
            Directory.CreateDirectory(Program.ThuMucGoc + "\\" + PrjName + ".Data\\Bin\\Debug");
            Directory.CreateDirectory(Program.ThuMucGoc + "\\" + PrjName + ".Data\\Obj");
            Directory.CreateDirectory(Program.ThuMucGoc + "\\" + PrjName + ".Data\\Obj\\Debug");
            Directory.CreateDirectory(Program.ThuMucGoc + "\\" + PrjName + ".Data\\Properties");
            // Tao cDBase
            string[] arrLines = File.ReadAllLines("Templates\\cDBase.Template.txt");
            for (int i = 0; i < arrLines.Length; i++)
            {
                if (arrLines[i].IndexOf("<@Prj@>") >= 0)
                    arrLines[i] = arrLines[i].Replace("<@Prj@>", PrjName);

            }
            File.WriteAllLines(Program.ThuMucGoc + "\\" + PrjName + ".Data\\cDBase.cs", arrLines);
            // Tao file Assembly
            arrLines = File.ReadAllLines("Templates\\Data.AssemblyInfo.Template.txt");
            for (int i = 0; i < arrLines.Length; i++)
            {
                if (arrLines[i].IndexOf("<@Prj@>") >= 0)
                    arrLines[i] = arrLines[i].Replace("<@Prj@>", PrjName);

            }
            File.WriteAllLines(Program.ThuMucGoc + "\\" + PrjName + ".Data\\Properties\\AssemblyInfo.cs", arrLines);
            // Tao file du an
            arrLines = File.ReadAllLines("Templates\\Data.csProj.Template.txt");
            for (int i = 0; i < arrLines.Length; i++)
            {
                if (arrLines[i].IndexOf("<@Prj@>") >= 0)
                    arrLines[i] = arrLines[i].Replace("<@Prj@>", PrjName);
                // Duyet cac tables de ghi vao file
                int index = arrLines[i].IndexOf("<@Class@>");
                if (index >= 0)
                {
                    string line = arrLines[i].Remove(index);
                    arrLines[i] = "";
                    for (int j = 0; j < arrTables.Length; j++)
                    {
                        arrLines[i] = arrLines[i] + line + "<Compile Include=\"cD" + arrTables[j] + ".cs\" />";
                        arrLines[i] = arrLines[i] + line + "<Compile Include=\"cD" + arrTables[j] + "_Base.cs\">";
                        arrLines[i] = arrLines[i] + line + "\t<DependentUpon>cD" + arrTables[j] + ".cs</DependentUpon>";
                        arrLines[i] = arrLines[i] + line + "</Compile>";
                    }
                }
            }
            File.WriteAllLines(Program.ThuMucGoc + "\\" + PrjName + ".Data\\" + PrjName + ".Data.csProj", arrLines);
        }

        public void CreateBusinessPrj(string[] arrTables)
        {
            // Tao ra cac thu muc trong du an
            // 1. Tao thu muc du an
            // 2. Tao thu muc con cua du an
            string Path = Program.ThuMucGoc;
            string PrjName = Path.Substring(Path.LastIndexOf("\\") + 1);
        
            Directory.CreateDirectory(Program.ThuMucGoc + "\\" + PrjName + ".Business");
            Directory.CreateDirectory(Program.ThuMucGoc + "\\" + PrjName + ".Business\\Bin");
            Directory.CreateDirectory(Program.ThuMucGoc + "\\" + PrjName + ".Business\\Bin\\Debug");
            Directory.CreateDirectory(Program.ThuMucGoc + "\\" + PrjName + ".Business\\Obj");
            Directory.CreateDirectory(Program.ThuMucGoc + "\\" + PrjName + ".Business\\Obj\\Debug");
            Directory.CreateDirectory(Program.ThuMucGoc + "\\" + PrjName + ".Business\\Properties");
            // Tao cBBase
            string[] arrLines = File.ReadAllLines("Templates\\cBBase.Template.txt");
            for (int i = 0; i < arrLines.Length; i++)
            {
                if (arrLines[i].IndexOf("<@Prj@>") >= 0)
                    arrLines[i] = arrLines[i].Replace("<@Prj@>", PrjName);

            }
            File.WriteAllLines(Program.ThuMucGoc + "\\" + PrjName + ".Business\\cBBase.cs", arrLines);
            // Tao file Assembly
            arrLines = File.ReadAllLines("Templates\\Business.AssemblyInfo.Template.txt");
            for (int i = 0; i < arrLines.Length; i++)
            {
                if (arrLines[i].IndexOf("<@Prj@>") >= 0)
                    arrLines[i] = arrLines[i].Replace("<@Prj@>", PrjName);

            }
            File.WriteAllLines(Program.ThuMucGoc + "\\" + PrjName + ".Business\\Properties\\AssemblyInfo.cs", arrLines);
            // Tao file du an
            arrLines = File.ReadAllLines("Templates\\Business.csProj.Template.txt");
            for (int i = 0; i < arrLines.Length; i++)
            {
                if (arrLines[i].IndexOf("<@Prj@>") >= 0)
                    arrLines[i] = arrLines[i].Replace("<@Prj@>", PrjName);
                // Duyet cac tables de ghi vao file
                int index = arrLines[i].IndexOf("<@Class@>");
                if (index >= 0)
                {
                    string line = arrLines[i].Remove(index);
                    arrLines[i] = "";
                    for (int j = 0; j < arrTables.Length; j++)
                        arrLines[i] = arrLines[i] + line + "<Compile Include=\"cB" + arrTables[j] + ".cs\" />";
                }
            }
            File.WriteAllLines(Program.ThuMucGoc + "\\" + PrjName + ".Business\\" + PrjName + ".Business.csProj", arrLines);
        }

    }
}
