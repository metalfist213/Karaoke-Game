namespace ClientTest
{
	partial class Controller
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
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.camera = new System.Windows.Forms.FlowLayoutPanel();
			this.audience = new System.Windows.Forms.FlowLayoutPanel();
			this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.textLog = new System.Windows.Forms.TextBox();
			this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
			this.label2 = new System.Windows.Forms.Label();
			this.singstarScore = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.audienceScore = new System.Windows.Forms.TextBox();
			this.continueShowTick = new System.Windows.Forms.CheckBox();
			this.setLightColor = new System.Windows.Forms.Button();
			this.continueShow = new System.Windows.Forms.Button();
			this.colorDialog1 = new System.Windows.Forms.ColorDialog();
			this.flowingCamera = new System.Windows.Forms.CheckBox();
			this.tableLayoutPanel1.SuspendLayout();
			this.camera.SuspendLayout();
			this.flowLayoutPanel2.SuspendLayout();
			this.flowLayoutPanel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.camera, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.audience, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel3, 1, 1);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(802, 477);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// camera
			// 
			this.camera.Controls.Add(this.flowingCamera);
			this.camera.Location = new System.Drawing.Point(3, 3);
			this.camera.Name = "camera";
			this.camera.Size = new System.Drawing.Size(395, 232);
			this.camera.TabIndex = 2;
			// 
			// audience
			// 
			this.audience.Location = new System.Drawing.Point(404, 3);
			this.audience.Name = "audience";
			this.audience.Size = new System.Drawing.Size(395, 232);
			this.audience.TabIndex = 3;
			// 
			// flowLayoutPanel2
			// 
			this.flowLayoutPanel2.Controls.Add(this.label1);
			this.flowLayoutPanel2.Controls.Add(this.textLog);
			this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 241);
			this.flowLayoutPanel2.Name = "flowLayoutPanel2";
			this.flowLayoutPanel2.Size = new System.Drawing.Size(395, 233);
			this.flowLayoutPanel2.TabIndex = 4;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(25, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Log";
			// 
			// textLog
			// 
			this.textLog.Location = new System.Drawing.Point(3, 16);
			this.textLog.Multiline = true;
			this.textLog.Name = "textLog";
			this.textLog.ReadOnly = true;
			this.textLog.Size = new System.Drawing.Size(392, 217);
			this.textLog.TabIndex = 0;
			// 
			// flowLayoutPanel3
			// 
			this.flowLayoutPanel3.Controls.Add(this.label2);
			this.flowLayoutPanel3.Controls.Add(this.singstarScore);
			this.flowLayoutPanel3.Controls.Add(this.label3);
			this.flowLayoutPanel3.Controls.Add(this.audienceScore);
			this.flowLayoutPanel3.Controls.Add(this.continueShowTick);
			this.flowLayoutPanel3.Controls.Add(this.setLightColor);
			this.flowLayoutPanel3.Controls.Add(this.continueShow);
			this.flowLayoutPanel3.Location = new System.Drawing.Point(404, 241);
			this.flowLayoutPanel3.Name = "flowLayoutPanel3";
			this.flowLayoutPanel3.Size = new System.Drawing.Size(395, 233);
			this.flowLayoutPanel3.TabIndex = 5;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(76, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Singstar Score";
			this.label2.Click += new System.EventHandler(this.Label2_Click);
			// 
			// singstarScore
			// 
			this.singstarScore.Location = new System.Drawing.Point(85, 3);
			this.singstarScore.Name = "singstarScore";
			this.singstarScore.Size = new System.Drawing.Size(224, 20);
			this.singstarScore.TabIndex = 2;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(3, 26);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(83, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Audience Score";
			// 
			// audienceScore
			// 
			this.audienceScore.Location = new System.Drawing.Point(92, 29);
			this.audienceScore.Name = "audienceScore";
			this.audienceScore.Size = new System.Drawing.Size(217, 20);
			this.audienceScore.TabIndex = 4;
			// 
			// continueShowTick
			// 
			this.continueShowTick.AutoSize = true;
			this.continueShowTick.Location = new System.Drawing.Point(3, 55);
			this.continueShowTick.Name = "continueShowTick";
			this.continueShowTick.Size = new System.Drawing.Size(104, 17);
			this.continueShowTick.TabIndex = 8;
			this.continueShowTick.Text = "Continue Show?";
			this.continueShowTick.UseVisualStyleBackColor = true;
			this.continueShowTick.CheckedChanged += new System.EventHandler(this.ContinueShowTick_CheckedChanged);
			// 
			// setLightColor
			// 
			this.setLightColor.Location = new System.Drawing.Point(3, 78);
			this.setLightColor.Name = "setLightColor";
			this.setLightColor.Size = new System.Drawing.Size(379, 80);
			this.setLightColor.TabIndex = 6;
			this.setLightColor.Text = "Set Light Color";
			this.setLightColor.UseVisualStyleBackColor = true;
			this.setLightColor.Click += new System.EventHandler(this.SetLightColor_Click);
			// 
			// continueShow
			// 
			this.continueShow.Location = new System.Drawing.Point(3, 164);
			this.continueShow.Name = "continueShow";
			this.continueShow.Size = new System.Drawing.Size(379, 28);
			this.continueShow.TabIndex = 1;
			this.continueShow.Text = "Continue Show";
			this.continueShow.UseVisualStyleBackColor = true;
			this.continueShow.Click += new System.EventHandler(this.ContinueShow_Click);
			// 
			// colorDialog1
			// 
			this.colorDialog1.Color = System.Drawing.Color.White;
			// 
			// flowingCamera
			// 
			this.flowingCamera.AutoSize = true;
			this.flowingCamera.Location = new System.Drawing.Point(3, 3);
			this.flowingCamera.Name = "flowingCamera";
			this.flowingCamera.Size = new System.Drawing.Size(109, 17);
			this.flowingCamera.TabIndex = 9;
			this.flowingCamera.Text = "Translate Camera";
			this.flowingCamera.UseVisualStyleBackColor = true;
			// 
			// Controller
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(826, 501);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "Controller";
			this.Text = "Controller";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.camera.ResumeLayout(false);
			this.camera.PerformLayout();
			this.flowLayoutPanel2.ResumeLayout(false);
			this.flowLayoutPanel2.PerformLayout();
			this.flowLayoutPanel3.ResumeLayout(false);
			this.flowLayoutPanel3.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.FlowLayoutPanel camera;
		private System.Windows.Forms.ColorDialog colorDialog1;
		private System.Windows.Forms.FlowLayoutPanel audience;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textLog;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
		private System.Windows.Forms.Button continueShow;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox singstarScore;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox audienceScore;
		private System.Windows.Forms.Button setLightColor;
		private System.Windows.Forms.CheckBox continueShowTick;
		private System.Windows.Forms.CheckBox flowingCamera;
	}
}