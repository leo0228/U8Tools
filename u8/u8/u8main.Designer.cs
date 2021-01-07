namespace u8
{
    partial class u8main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.path = new System.Windows.Forms.Button();
            this.path_string = new System.Windows.Forms.TextBox();
            this.game = new System.Windows.Forms.Label();
            this.game_choose = new System.Windows.Forms.ComboBox();
            this.channel = new System.Windows.Forms.Label();
            this.channel_choose = new System.Windows.Forms.ComboBox();
            this.run = new System.Windows.Forms.Button();
            this.open_apk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // path
            // 
            this.path.Location = new System.Drawing.Point(87, 34);
            this.path.Name = "path";
            this.path.Size = new System.Drawing.Size(195, 31);
            this.path.TabIndex = 0;
            this.path.Text = "选择脚本文件地址";
            this.path.UseVisualStyleBackColor = true;
            this.path.Click += new System.EventHandler(this.Path_Click);
            // 
            // path_string
            // 
            this.path_string.Enabled = false;
            this.path_string.Location = new System.Drawing.Point(35, 89);
            this.path_string.Multiline = true;
            this.path_string.Name = "path_string";
            this.path_string.Size = new System.Drawing.Size(287, 30);
            this.path_string.TabIndex = 1;
            this.path_string.TextChanged += new System.EventHandler(this.Path_string_TextChanged);
            // 
            // game
            // 
            this.game.AutoSize = true;
            this.game.Location = new System.Drawing.Point(46, 156);
            this.game.Name = "game";
            this.game.Size = new System.Drawing.Size(53, 12);
            this.game.TabIndex = 2;
            this.game.Text = "游戏选择";
            // 
            // game_choose
            // 
            this.game_choose.FormattingEnabled = true;
            this.game_choose.Location = new System.Drawing.Point(141, 153);
            this.game_choose.Name = "game_choose";
            this.game_choose.Size = new System.Drawing.Size(170, 20);
            this.game_choose.TabIndex = 3;
            this.game_choose.SelectedIndexChanged += new System.EventHandler(this.Game_choose_SelectedIndexChanged);
            // 
            // channel
            // 
            this.channel.AutoSize = true;
            this.channel.Location = new System.Drawing.Point(46, 202);
            this.channel.Name = "channel";
            this.channel.Size = new System.Drawing.Size(53, 12);
            this.channel.TabIndex = 4;
            this.channel.Text = "渠道选择";
            // 
            // channel_choose
            // 
            this.channel_choose.FormattingEnabled = true;
            this.channel_choose.Location = new System.Drawing.Point(141, 199);
            this.channel_choose.Name = "channel_choose";
            this.channel_choose.Size = new System.Drawing.Size(170, 20);
            this.channel_choose.TabIndex = 5;
            // 
            // run
            // 
            this.run.Location = new System.Drawing.Point(35, 252);
            this.run.Name = "run";
            this.run.Size = new System.Drawing.Size(92, 34);
            this.run.TabIndex = 6;
            this.run.Text = "执行u8打包";
            this.run.UseVisualStyleBackColor = true;
            this.run.Click += new System.EventHandler(this.Run_Click);
            // 
            // open_apk
            // 
            this.open_apk.Location = new System.Drawing.Point(226, 252);
            this.open_apk.Name = "open_apk";
            this.open_apk.Size = new System.Drawing.Size(96, 34);
            this.open_apk.TabIndex = 7;
            this.open_apk.Text = "打开APK目录";
            this.open_apk.UseVisualStyleBackColor = true;
            this.open_apk.Click += new System.EventHandler(this.Open_apk_Click);
            // 
            // u8main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 318);
            this.Controls.Add(this.open_apk);
            this.Controls.Add(this.run);
            this.Controls.Add(this.channel_choose);
            this.Controls.Add(this.channel);
            this.Controls.Add(this.game_choose);
            this.Controls.Add(this.game);
            this.Controls.Add(this.path_string);
            this.Controls.Add(this.path);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "u8main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "u8打包工具";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button path;
        private System.Windows.Forms.TextBox path_string;
        private System.Windows.Forms.Label game;
        private System.Windows.Forms.ComboBox game_choose;
        private System.Windows.Forms.Label channel;
        private System.Windows.Forms.ComboBox channel_choose;
        private System.Windows.Forms.Button run;
        private System.Windows.Forms.Button open_apk;
    }
}

