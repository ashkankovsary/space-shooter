namespace Space_Shooter_game
{
    partial class AboutForm
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
            backButton = new Button();
            contentPanel = new Panel();
            mainTable = new TableLayoutPanel();
            tableLayoutPanel1 = new TableLayoutPanel();
            author1Label = new Label();
            author2Label = new Label();
            descriptionBox = new TextBox();
            contentPanel.SuspendLayout();
            mainTable.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // backButton
            // 
            backButton.Cursor = Cursors.Hand;
            backButton.Location = new Point(0, 0);
            backButton.Name = "backButton";
            backButton.Size = new Size(46, 29);
            backButton.TabIndex = 0;
            backButton.Text = "<-";
            backButton.UseVisualStyleBackColor = true;
            // 
            // contentPanel
            // 
            contentPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            contentPanel.Controls.Add(mainTable);
            contentPanel.Location = new Point(12, 35);
            contentPanel.Name = "contentPanel";
            contentPanel.Size = new Size(346, 369);
            contentPanel.TabIndex = 1;
            // 
            // mainTable
            // 
            mainTable.ColumnCount = 1;
            mainTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            mainTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            mainTable.Controls.Add(tableLayoutPanel1, 0, 0);
            mainTable.Controls.Add(descriptionBox, 0, 1);
            mainTable.Dock = DockStyle.Fill;
            mainTable.Location = new Point(0, 0);
            mainTable.Name = "mainTable";
            mainTable.RowCount = 2;
            mainTable.RowStyles.Add(new RowStyle(SizeType.Percent, 27.9132786F));
            mainTable.RowStyles.Add(new RowStyle(SizeType.Percent, 72.08672F));
            mainTable.Size = new Size(346, 369);
            mainTable.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(author1Label, 0, 0);
            tableLayoutPanel1.Controls.Add(author2Label, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(340, 97);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // author1Label
            // 
            author1Label.AutoSize = true;
            author1Label.Dock = DockStyle.Fill;
            author1Label.Location = new Point(3, 0);
            author1Label.Name = "author1Label";
            author1Label.Size = new Size(164, 97);
            author1Label.TabIndex = 0;
            author1Label.Text = "Name: Ashkan Kovsary\r\nStd_ID: 404522034";
            author1Label.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // author2Label
            // 
            author2Label.AutoSize = true;
            author2Label.Dock = DockStyle.Fill;
            author2Label.Location = new Point(173, 0);
            author2Label.Name = "author2Label";
            author2Label.Size = new Size(164, 97);
            author2Label.TabIndex = 1;
            author2Label.Text = "Name: Ashkan Ehsani\r\nStd_ID: 404521021";
            author2Label.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // descriptionBox
            // 
            descriptionBox.Dock = DockStyle.Fill;
            descriptionBox.Location = new Point(3, 106);
            descriptionBox.Multiline = true;
            descriptionBox.Name = "descriptionBox";
            descriptionBox.ReadOnly = true;
            descriptionBox.ScrollBars = ScrollBars.Vertical;
            descriptionBox.Size = new Size(340, 260);
            descriptionBox.TabIndex = 1;
            descriptionBox.Text = "description...";
            // 
            // AboutForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(370, 416);
            Controls.Add(contentPanel);
            Controls.Add(backButton);
            Name = "AboutForm";
            Text = "AboutForm";
            contentPanel.ResumeLayout(false);
            mainTable.ResumeLayout(false);
            mainTable.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button backButton;
        private Panel contentPanel;
        private TableLayoutPanel mainTable;
        private TableLayoutPanel tableLayoutPanel1;
        private Label author1Label;
        private Label author2Label;
        private TextBox descriptionBox;
    }
}