namespace KNN_1
{
     partial class Form1
     {
          /// <summary>
          /// Required designer variable.
          /// </summary>
          private System.ComponentModel.IContainer components = null;

          /// <summary>
          /// Clean up any resources being used.
          /// </summary>
          /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
          protected override void Dispose(bool disposing)
          {
               if (disposing && (components != null))
               {
                    components.Dispose();
               }
               base.Dispose(disposing);
          }

          #region Windows Form Designer generated code

          /// <summary>
          /// Required method for Designer support - do not modify
          /// the contents of this method with the code editor.
          /// </summary>
          private void InitializeComponent()
          {
               this.ptbx = new System.Windows.Forms.PictureBox();
               this.btnOpen = new System.Windows.Forms.Button();
               this.txtbImage = new System.Windows.Forms.TextBox();
               this.btnCheck = new System.Windows.Forms.Button();
               this.label1 = new System.Windows.Forms.Label();
               this.lbResult = new System.Windows.Forms.Label();
               ((System.ComponentModel.ISupportInitialize)(this.ptbx)).BeginInit();
               this.SuspendLayout();
               // 
               // ptbx
               // 
               this.ptbx.Location = new System.Drawing.Point(1, 70);
               this.ptbx.Name = "ptbx";
               this.ptbx.Size = new System.Drawing.Size(1100, 691);
               this.ptbx.TabIndex = 0;
               this.ptbx.TabStop = false;
               // 
               // btnOpen
               // 
               this.btnOpen.Location = new System.Drawing.Point(379, 5);
               this.btnOpen.Name = "btnOpen";
               this.btnOpen.Size = new System.Drawing.Size(113, 28);
               this.btnOpen.TabIndex = 1;
               this.btnOpen.Text = "Nhap anh";
               this.btnOpen.UseVisualStyleBackColor = true;
               this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
               // 
               // txtbImage
               // 
               this.txtbImage.Location = new System.Drawing.Point(82, 8);
               this.txtbImage.Name = "txtbImage";
               this.txtbImage.Size = new System.Drawing.Size(291, 22);
               this.txtbImage.TabIndex = 2;
               // 
               // btnCheck
               // 
               this.btnCheck.Location = new System.Drawing.Point(82, 36);
               this.btnCheck.Name = "btnCheck";
               this.btnCheck.Size = new System.Drawing.Size(113, 28);
               this.btnCheck.TabIndex = 1;
               this.btnCheck.Text = "Kiem tra";
               this.btnCheck.UseVisualStyleBackColor = true;
               this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
               // 
               // label1
               // 
               this.label1.AutoSize = true;
               this.label1.Location = new System.Drawing.Point(574, 23);
               this.label1.Name = "label1";
               this.label1.Size = new System.Drawing.Size(107, 17);
               this.label1.TabIndex = 3;
               this.label1.Text = "Hình ảnh là số: ";
               // 
               // lbResult
               // 
               this.lbResult.Location = new System.Drawing.Point(687, 23);
               this.lbResult.Name = "lbResult";
               this.lbResult.Size = new System.Drawing.Size(46, 17);
               this.lbResult.TabIndex = 0;
               this.lbResult.Text = "?";
               // 
               // Form1
               // 
               this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
               this.ClientSize = new System.Drawing.Size(1144, 785);
               this.Controls.Add(this.lbResult);
               this.Controls.Add(this.label1);
               this.Controls.Add(this.txtbImage);
               this.Controls.Add(this.btnCheck);
               this.Controls.Add(this.btnOpen);
               this.Controls.Add(this.ptbx);
               this.Name = "Form1";
               this.Text = "KNN_Number";
               this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
               ((System.ComponentModel.ISupportInitialize)(this.ptbx)).EndInit();
               this.ResumeLayout(false);
               this.PerformLayout();

          }

          #endregion

          private System.Windows.Forms.PictureBox ptbx;
          private System.Windows.Forms.Button btnOpen;
          private System.Windows.Forms.TextBox txtbImage;
          private System.Windows.Forms.Button btnCheck;
          private System.Windows.Forms.Label label1;
          private System.Windows.Forms.Label lbResult;
     }
}

