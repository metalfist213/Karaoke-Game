namespace ClientTest
{
	partial class TeamRegistration
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.contestantsList = new System.Windows.Forms.FlowLayoutPanel();
			this.contestant1 = new System.Windows.Forms.TextBox();
			this.contestant2 = new System.Windows.Forms.TextBox();
			this.addContestant = new System.Windows.Forms.Button();
			this.flowLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.flowLayoutPanel1.Controls.Add(this.contestant1);
			this.flowLayoutPanel1.Controls.Add(this.contestant2);
			this.flowLayoutPanel1.Controls.Add(this.addContestant);
			this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 12);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(222, 426);
			this.flowLayoutPanel1.TabIndex = 0;
			// 
			// contestantsList
			// 
			this.contestantsList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.contestantsList.Location = new System.Drawing.Point(240, 12);
			this.contestantsList.Name = "contestantsList";
			this.contestantsList.Size = new System.Drawing.Size(518, 426);
			this.contestantsList.TabIndex = 1;
			// 
			// contestant1
			// 
			this.contestant1.Location = new System.Drawing.Point(3, 3);
			this.contestant1.Name = "contestant1";
			this.contestant1.Size = new System.Drawing.Size(219, 20);
			this.contestant1.TabIndex = 0;
			// 
			// contestant2
			// 
			this.contestant2.Location = new System.Drawing.Point(3, 29);
			this.contestant2.Name = "contestant2";
			this.contestant2.Size = new System.Drawing.Size(219, 20);
			this.contestant2.TabIndex = 1;
			// 
			// addContestant
			// 
			this.addContestant.Location = new System.Drawing.Point(3, 55);
			this.addContestant.Name = "addContestant";
			this.addContestant.Size = new System.Drawing.Size(219, 23);
			this.addContestant.TabIndex = 2;
			this.addContestant.Text = "Add Contestant";
			this.addContestant.UseVisualStyleBackColor = true;
			this.addContestant.Click += new System.EventHandler(this.AddContestant_Click);
			// 
			// TeamRegistration
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(770, 450);
			this.Controls.Add(this.contestantsList);
			this.Controls.Add(this.flowLayoutPanel1);
			this.Name = "TeamRegistration";
			this.Text = "TeamRegistration";
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.FlowLayoutPanel contestantsList;
		private System.Windows.Forms.TextBox contestant1;
		private System.Windows.Forms.TextBox contestant2;
		private System.Windows.Forms.Button addContestant;
	}
}