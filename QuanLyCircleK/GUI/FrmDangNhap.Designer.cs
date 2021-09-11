
namespace GUI
{
    partial class FrmDangNhap
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
            this.txtMK = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDN = new FontAwesome.Sharp.IconButton();
            this.txtTK = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnHuy = new FontAwesome.Sharp.IconButton();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtMK
            // 
            this.txtMK.Font = new System.Drawing.Font("Yu Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtMK.Location = new System.Drawing.Point(154, 146);
            this.txtMK.Name = "txtMK";
            this.txtMK.Size = new System.Drawing.Size(305, 40);
            this.txtMK.TabIndex = 36;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Yu Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(21, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 26);
            this.label3.TabIndex = 35;
            this.label3.Text = "Mật khẩu:";
            // 
            // btnDN
            // 
            this.btnDN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(62)))), ((int)(((byte)(52)))));
            this.btnDN.FlatAppearance.BorderSize = 0;
            this.btnDN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDN.Font = new System.Drawing.Font("Yu Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDN.IconChar = FontAwesome.Sharp.IconChar.Check;
            this.btnDN.IconColor = System.Drawing.Color.White;
            this.btnDN.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDN.Location = new System.Drawing.Point(21, 212);
            this.btnDN.Name = "btnDN";
            this.btnDN.Size = new System.Drawing.Size(190, 46);
            this.btnDN.TabIndex = 34;
            this.btnDN.Text = "Đăng nhập";
            this.btnDN.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDN.UseVisualStyleBackColor = false;
            this.btnDN.Click += new System.EventHandler(this.btnDN_Click);
            // 
            // txtTK
            // 
            this.txtTK.Font = new System.Drawing.Font("Yu Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtTK.Location = new System.Drawing.Point(154, 86);
            this.txtTK.Name = "txtTK";
            this.txtTK.Size = new System.Drawing.Size(305, 40);
            this.txtTK.TabIndex = 33;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(21, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 26);
            this.label1.TabIndex = 32;
            this.label1.Text = "Tài khoản:";
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(62)))), ((int)(((byte)(52)))));
            this.btnHuy.FlatAppearance.BorderSize = 0;
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.Font = new System.Drawing.Font("Yu Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnHuy.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.btnHuy.IconColor = System.Drawing.Color.White;
            this.btnHuy.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHuy.Location = new System.Drawing.Point(269, 212);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(190, 46);
            this.btnHuy.TabIndex = 37;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(154, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 50);
            this.label2.TabIndex = 38;
            this.label2.Text = "CIRCLE K";
            // 
            // FrmDangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(140)))), ((int)(((byte)(1)))));
            this.ClientSize = new System.Drawing.Size(483, 299);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.txtMK);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnDN);
            this.Controls.Add(this.txtTK);
            this.Controls.Add(this.label1);
            this.Name = "FrmDangNhap";
            this.Text = "FrmDangNhap";
            this.Load += new System.EventHandler(this.FrmDangNhap_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMK;
        private System.Windows.Forms.Label label3;
        private FontAwesome.Sharp.IconButton btnDN;
        private System.Windows.Forms.TextBox txtTK;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconButton btnHuy;
        private System.Windows.Forms.Label label2;
    }
}