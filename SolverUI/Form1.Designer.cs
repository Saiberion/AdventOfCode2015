namespace SolverUI
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.labelCaptionSolutionPart1 = new System.Windows.Forms.Label();
            this.labelCaptionSolutionPart2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.Controls.Add(this.labelCaptionSolutionPart1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelCaptionSolutionPart2, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 3, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(405, 33);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // labelCaptionSolutionPart1
            // 
            this.labelCaptionSolutionPart1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelCaptionSolutionPart1.AutoSize = true;
            this.labelCaptionSolutionPart1.Location = new System.Drawing.Point(114, 10);
            this.labelCaptionSolutionPart1.Name = "labelCaptionSolutionPart1";
            this.labelCaptionSolutionPart1.Size = new System.Drawing.Size(76, 13);
            this.labelCaptionSolutionPart1.TabIndex = 3;
            this.labelCaptionSolutionPart1.Text = "Solution Part 1";
            // 
            // labelCaptionSolutionPart2
            // 
            this.labelCaptionSolutionPart2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelCaptionSolutionPart2.AutoSize = true;
            this.labelCaptionSolutionPart2.Location = new System.Drawing.Point(215, 10);
            this.labelCaptionSolutionPart2.Name = "labelCaptionSolutionPart2";
            this.labelCaptionSolutionPart2.Size = new System.Drawing.Size(76, 13);
            this.labelCaptionSolutionPart2.TabIndex = 4;
            this.labelCaptionSolutionPart2.Text = "Solution Part 2";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(319, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Durchlaufzeit";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 863);
            this.Controls.Add(this.tableLayoutPanel2);
            this.DoubleBuffered = true;
            this.Location = new System.Drawing.Point(20, 20);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label labelCaptionSolutionPart1;
        private System.Windows.Forms.Label labelCaptionSolutionPart2;
        private System.Windows.Forms.Label label1;
    }
}

