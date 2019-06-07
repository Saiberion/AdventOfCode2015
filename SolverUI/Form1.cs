using Days;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SolverUI
{
    public partial class Form1 : Form
    {
        List<Days.Day> days = new List<Days.Day>()
        {
            new Day01() { Name = "Day 01", StopWatch = new System.Diagnostics.Stopwatch() },
            new Day02() { Name = "Day 02", StopWatch = new System.Diagnostics.Stopwatch() },
            new Day03() { Name = "Day 03", StopWatch = new System.Diagnostics.Stopwatch() },
            new Day04() { Name = "Day 04", StopWatch = new System.Diagnostics.Stopwatch() },
            new Day05() { Name = "Day 05", StopWatch = new System.Diagnostics.Stopwatch() },
            new Day06() { Name = "Day 06", StopWatch = new System.Diagnostics.Stopwatch() },
            new Day07() { Name = "Day 07", StopWatch = new System.Diagnostics.Stopwatch() },
            new Day08() { Name = "Day 08", StopWatch = new System.Diagnostics.Stopwatch() },
            new Day09() { Name = "Day 09", StopWatch = new System.Diagnostics.Stopwatch() },
            new Day10() { Name = "Day 10", StopWatch = new System.Diagnostics.Stopwatch() },
            new Day11() { Name = "Day 11", StopWatch = new System.Diagnostics.Stopwatch() },
            new Day12() { Name = "Day 12", StopWatch = new System.Diagnostics.Stopwatch() },
            new Day13() { Name = "Day 13", StopWatch = new System.Diagnostics.Stopwatch() },
            new Day14() { Name = "Day 14", StopWatch = new System.Diagnostics.Stopwatch() },
            new Day15() { Name = "Day 15", StopWatch = new System.Diagnostics.Stopwatch() },
            new Day16() { Name = "Day 16", StopWatch = new System.Diagnostics.Stopwatch() },
            new Day17() { Name = "Day 17", StopWatch = new System.Diagnostics.Stopwatch() },
            new Day18() { Name = "Day 18", StopWatch = new System.Diagnostics.Stopwatch() },
            new Day19() { Name = "Day 19", StopWatch = new System.Diagnostics.Stopwatch() },
            new Day20() { Name = "Day 20", StopWatch = new System.Diagnostics.Stopwatch() },
            new Day21() { Name = "Day 21", StopWatch = new System.Diagnostics.Stopwatch() },
            new Day22() { Name = "Day 22", StopWatch = new System.Diagnostics.Stopwatch() },
            new Day23() { Name = "Day 23", StopWatch = new System.Diagnostics.Stopwatch() },
            new Day24() { Name = "Day 24", StopWatch = new System.Diagnostics.Stopwatch() },
            new Day25() { Name = "Day 25", StopWatch = new System.Diagnostics.Stopwatch() }
        };

        public Form1()
        {
            InitializeComponent();

            SetDoubleBuffered(tableLayoutPanel2);

            for (int i = 0; i < days.Count; i++)
            {
                tableLayoutPanel2.RowCount++;
                tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));

                Button b = new Button
                {
                    Anchor = AnchorStyles.None,
                    Name = string.Format("buttonSolveDay{0}", i + 1),
                    Text = string.Format("Solve day {0}", i + 1),
                    Size = new Size(90, 25),
                    Tag = days[i]
                };
                b.Click += ButtonSolveSingleDay;
                tableLayoutPanel2.Controls.Add(b, 0, i + 1);
                
                tableLayoutPanel2.Controls.Add(new Label()
                {
                    Anchor = AnchorStyles.None,
                    Name = string.Format("labelD{0}P1", i + 1),
                    Text = "",
                    AutoSize = true
                }, 1, i + 1);

                tableLayoutPanel2.Controls.Add(new Label()
                {
                    Anchor = AnchorStyles.None,
                    Name = string.Format("labelD{0}P2", i + 1),
                    Text = "",
                    AutoSize = true
                }, 2, i + 1);

                tableLayoutPanel2.Controls.Add(new Label()
                {
                    Anchor = AnchorStyles.None,
                    Name = string.Format("labelD{0}Perf", i + 1),
                    Text = "",
                    AutoSize = true
                }, 3, i + 1);
            }
            
            Button b2 = new Button
            {
                Anchor = AnchorStyles.None,
                Name = "buttonSolveAll",
                Text = "Solve all days",
                Size = new Size(90, 25)
            };
            b2.Click += ButtonSolveAllDays;
            tableLayoutPanel2.Controls.Add(b2, 0, 0);
        }

        private void ButtonSolveAllDays(object sender, EventArgs e)
        {
            for (int i = 1; i < tableLayoutPanel2.RowCount; i++)
            {
                Button b = tableLayoutPanel2.GetControlFromPosition(0, i) as Button;
                ButtonSolveSingleDay(b, new EventArgs());
            }
        }

        private void ButtonSolveSingleDay(object sender, EventArgs e)
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += BackgroundWorkerDaySolver;
            bw.RunWorkerCompleted += BackgroundWorkerDaySolverCompleted;
            bw.ProgressChanged += BackgroundWorkerDaySolverProgressChanged;
            bw.WorkerReportsProgress = true;
            bw.RunWorkerAsync(sender);

            Button b = sender as Button;
            TableLayoutPanel tbl = b.Parent as TableLayoutPanel;
            TableLayoutPanelCellPosition pos = tbl.GetCellPosition(b);
            Label l3 = tbl.GetControlFromPosition(3, pos.Row) as Label;
            l3.Text = "initialised";
        }

        private void BackgroundWorkerDaySolverProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Button b = e.UserState as Button;
            TableLayoutPanel tbl = b.Parent as TableLayoutPanel;
            TableLayoutPanelCellPosition pos = tbl.GetCellPosition(b);
            Label l3 = tbl.GetControlFromPosition(3, pos.Row) as Label;
            l3.Text = "Running";
        }

        private void BackgroundWorkerDaySolverCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Button b = e.Result as Button;
            Days.Day d = b.Tag as Days.Day;
            TableLayoutPanel tbl = b.Parent as TableLayoutPanel;
            TableLayoutPanelCellPosition pos = tbl.GetCellPosition(b);
            Label l1 = tbl.GetControlFromPosition(1, pos.Row) as Label;
            Label l2 = tbl.GetControlFromPosition(2, pos.Row) as Label;
            Label l3 = tbl.GetControlFromPosition(3, pos.Row) as Label;
            l1.Text = d.Part1Solution;
            l2.Text = d.Part2Solution;
            l3.Text = d.StopWatch.Elapsed.ToString();
        }

        private void BackgroundWorkerDaySolver(object sender, DoWorkEventArgs e)
        {
            Button b = e.Argument as Button;
            BackgroundWorker bw = sender as BackgroundWorker;
            bw.ReportProgress(0, b);
            Days.Day d = b.Tag as Days.Day;
            d.StopWatch.Restart();
            d.Solve();
            d.StopWatch.Stop();
            e.Result = b;
        }

        #region .. Double Buffered function ..
        public static void SetDoubleBuffered(System.Windows.Forms.Control c)
        {
            if (System.Windows.Forms.SystemInformation.TerminalServerSession)
                return;
            System.Reflection.PropertyInfo aProp = typeof(System.Windows.Forms.Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            aProp.SetValue(c, true, null);
        }

        #endregion


        #region .. code for Flucuring ..

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        #endregion
    }
}
