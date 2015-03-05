namespace SimpleComputer
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBoxMem = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBoxAcc = new System.Windows.Forms.GroupBox();
            this.textBoxAcc = new System.Windows.Forms.TextBox();
            this.groupBoxInstr = new System.Windows.Forms.GroupBox();
            this.textBoxInstr = new System.Windows.Forms.TextBox();
            this.groupBoxOp = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labelOpVal = new System.Windows.Forms.Label();
            this.labelOp = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelFWrongOp = new System.Windows.Forms.Label();
            this.labelFDivZero = new System.Windows.Forms.Label();
            this.labelFIgnorTimer = new System.Windows.Forms.Label();
            this.labelFOverFlow = new System.Windows.Forms.Label();
            this.labelFOutMemory = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.buttonClearMemory = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.numericUpDownClock = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxConsole = new System.Windows.Forms.TextBox();
            this.groupBoxMem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBoxAcc.SuspendLayout();
            this.groupBoxInstr.SuspendLayout();
            this.groupBoxOp.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownClock)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxMem
            // 
            this.groupBoxMem.AutoSize = true;
            this.groupBoxMem.Controls.Add(this.dataGridView1);
            this.groupBoxMem.Location = new System.Drawing.Point(12, 12);
            this.groupBoxMem.Name = "groupBoxMem";
            this.groupBoxMem.Size = new System.Drawing.Size(550, 256);
            this.groupBoxMem.TabIndex = 0;
            this.groupBoxMem.TabStop = false;
            this.groupBoxMem.Text = "Memory";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView1.Location = new System.Drawing.Point(6, 19);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(538, 218);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            // 
            // groupBoxAcc
            // 
            this.groupBoxAcc.Controls.Add(this.textBoxAcc);
            this.groupBoxAcc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxAcc.Location = new System.Drawing.Point(740, 31);
            this.groupBoxAcc.Name = "groupBoxAcc";
            this.groupBoxAcc.Size = new System.Drawing.Size(200, 48);
            this.groupBoxAcc.TabIndex = 3;
            this.groupBoxAcc.TabStop = false;
            this.groupBoxAcc.Text = "acumulator";
            // 
            // textBoxAcc
            // 
            this.textBoxAcc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxAcc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxAcc.Location = new System.Drawing.Point(7, 26);
            this.textBoxAcc.Name = "textBoxAcc";
            this.textBoxAcc.Size = new System.Drawing.Size(187, 20);
            this.textBoxAcc.TabIndex = 0;
            this.textBoxAcc.Text = "0";
            this.textBoxAcc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxAcc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxAcc_KeyPress);
            // 
            // groupBoxInstr
            // 
            this.groupBoxInstr.Controls.Add(this.textBoxInstr);
            this.groupBoxInstr.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxInstr.Location = new System.Drawing.Point(740, 85);
            this.groupBoxInstr.Name = "groupBoxInstr";
            this.groupBoxInstr.Size = new System.Drawing.Size(200, 48);
            this.groupBoxInstr.TabIndex = 3;
            this.groupBoxInstr.TabStop = false;
            this.groupBoxInstr.Text = "instructionCounter";
            // 
            // textBoxInstr
            // 
            this.textBoxInstr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxInstr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxInstr.Location = new System.Drawing.Point(7, 22);
            this.textBoxInstr.Name = "textBoxInstr";
            this.textBoxInstr.Size = new System.Drawing.Size(187, 20);
            this.textBoxInstr.TabIndex = 0;
            this.textBoxInstr.Text = "0";
            this.textBoxInstr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxInstr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxInstr_KeyPress);
            // 
            // groupBoxOp
            // 
            this.groupBoxOp.Controls.Add(this.label2);
            this.groupBoxOp.Controls.Add(this.labelOpVal);
            this.groupBoxOp.Controls.Add(this.labelOp);
            this.groupBoxOp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxOp.Location = new System.Drawing.Point(740, 139);
            this.groupBoxOp.Name = "groupBoxOp";
            this.groupBoxOp.Size = new System.Drawing.Size(200, 48);
            this.groupBoxOp.TabIndex = 3;
            this.groupBoxOp.TabStop = false;
            this.groupBoxOp.Text = "Operation";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(85, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = ":";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelOpVal
            // 
            this.labelOpVal.Location = new System.Drawing.Point(108, 20);
            this.labelOpVal.Name = "labelOpVal";
            this.labelOpVal.Size = new System.Drawing.Size(46, 23);
            this.labelOpVal.TabIndex = 0;
            this.labelOpVal.Text = "00";
            this.labelOpVal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelOp
            // 
            this.labelOp.Location = new System.Drawing.Point(33, 20);
            this.labelOp.Name = "labelOp";
            this.labelOp.Size = new System.Drawing.Size(46, 23);
            this.labelOp.TabIndex = 0;
            this.labelOp.Text = "+00";
            this.labelOp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelFWrongOp);
            this.groupBox1.Controls.Add(this.labelFDivZero);
            this.groupBox1.Controls.Add(this.labelFIgnorTimer);
            this.groupBox1.Controls.Add(this.labelFOverFlow);
            this.groupBox1.Controls.Add(this.labelFOutMemory);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(740, 201);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 48);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Flags";
            // 
            // labelFWrongOp
            // 
            this.labelFWrongOp.AutoSize = true;
            this.labelFWrongOp.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.labelFWrongOp.Location = new System.Drawing.Point(109, 22);
            this.labelFWrongOp.Name = "labelFWrongOp";
            this.labelFWrongOp.Size = new System.Drawing.Size(20, 20);
            this.labelFWrongOp.TabIndex = 7;
            this.labelFWrongOp.Text = "Е";
            // 
            // labelFDivZero
            // 
            this.labelFDivZero.AutoSize = true;
            this.labelFDivZero.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.labelFDivZero.Location = new System.Drawing.Point(33, 22);
            this.labelFDivZero.Name = "labelFDivZero";
            this.labelFDivZero.Size = new System.Drawing.Size(18, 20);
            this.labelFDivZero.TabIndex = 1;
            this.labelFDivZero.Text = "0";
            // 
            // labelFIgnorTimer
            // 
            this.labelFIgnorTimer.AutoSize = true;
            this.labelFIgnorTimer.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.labelFIgnorTimer.Location = new System.Drawing.Point(85, 22);
            this.labelFIgnorTimer.Name = "labelFIgnorTimer";
            this.labelFIgnorTimer.Size = new System.Drawing.Size(18, 20);
            this.labelFIgnorTimer.TabIndex = 6;
            this.labelFIgnorTimer.Text = "Т";
            // 
            // labelFOverFlow
            // 
            this.labelFOverFlow.AutoSize = true;
            this.labelFOverFlow.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.labelFOverFlow.Location = new System.Drawing.Point(6, 22);
            this.labelFOverFlow.Name = "labelFOverFlow";
            this.labelFOverFlow.Size = new System.Drawing.Size(21, 20);
            this.labelFOverFlow.TabIndex = 0;
            this.labelFOverFlow.Text = "П";
            // 
            // labelFOutMemory
            // 
            this.labelFOutMemory.AutoSize = true;
            this.labelFOutMemory.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.labelFOutMemory.Location = new System.Drawing.Point(57, 22);
            this.labelFOutMemory.Name = "labelFOutMemory";
            this.labelFOutMemory.Size = new System.Drawing.Size(22, 20);
            this.labelFOutMemory.TabIndex = 5;
            this.labelFOutMemory.Text = "М";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.button6);
            this.groupBox2.Controls.Add(this.button5);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(740, 255);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 204);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Key";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(87, 171);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "compile ASM file";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(6, 171);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Copile";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(88, 142);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "reset computer";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(88, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "exec step";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(88, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "run computer";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(88, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "save memory";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(88, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "load memory";
            // 
            // button6
            // 
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button6.Location = new System.Drawing.Point(7, 142);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 4;
            this.button6.Text = "Reset";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button5.Location = new System.Drawing.Point(7, 113);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 3;
            this.button5.Text = "Step";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4.Location = new System.Drawing.Point(7, 84);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 2;
            this.button4.Text = "Run";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(7, 55);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 1;
            this.button3.Text = "Save";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(7, 26);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "Load";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonClearMemory
            // 
            this.buttonClearMemory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClearMemory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonClearMemory.Location = new System.Drawing.Point(12, 271);
            this.buttonClearMemory.Name = "buttonClearMemory";
            this.buttonClearMemory.Size = new System.Drawing.Size(75, 23);
            this.buttonClearMemory.TabIndex = 6;
            this.buttonClearMemory.Text = "ClearMem";
            this.buttonClearMemory.UseVisualStyleBackColor = true;
            this.buttonClearMemory.Click += new System.EventHandler(this.buttonClearMemory_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(669, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(568, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Selected MemCell:";
            // 
            // numericUpDownClock
            // 
            this.numericUpDownClock.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownClock.Location = new System.Drawing.Point(740, 478);
            this.numericUpDownClock.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numericUpDownClock.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownClock.Name = "numericUpDownClock";
            this.numericUpDownClock.Size = new System.Drawing.Size(82, 20);
            this.numericUpDownClock.TabIndex = 9;
            this.numericUpDownClock.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownClock.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(737, 462);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Timer interval(ms):";
            // 
            // textBoxConsole
            // 
            this.textBoxConsole.Location = new System.Drawing.Point(12, 310);
            this.textBoxConsole.Multiline = true;
            this.textBoxConsole.Name = "textBoxConsole";
            this.textBoxConsole.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxConsole.Size = new System.Drawing.Size(550, 100);
            this.textBoxConsole.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(943, 574);
            this.Controls.Add(this.textBoxConsole);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.numericUpDownClock);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonClearMemory);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxOp);
            this.Controls.Add(this.groupBoxInstr);
            this.Controls.Add(this.groupBoxAcc);
            this.Controls.Add(this.groupBoxMem);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "SimpleComputer";
            this.groupBoxMem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBoxAcc.ResumeLayout(false);
            this.groupBoxAcc.PerformLayout();
            this.groupBoxInstr.ResumeLayout(false);
            this.groupBoxInstr.PerformLayout();
            this.groupBoxOp.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownClock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxMem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBoxAcc;
        private System.Windows.Forms.GroupBox groupBoxInstr;
        private System.Windows.Forms.GroupBox groupBoxOp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelOpVal;
        private System.Windows.Forms.Label labelOp;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelFDivZero;
        private System.Windows.Forms.Label labelFOverFlow;
        private System.Windows.Forms.Label labelFOutMemory;
        private System.Windows.Forms.Label labelFIgnorTimer;
        private System.Windows.Forms.Label labelFWrongOp;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxAcc;
        private System.Windows.Forms.TextBox textBoxInstr;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonClearMemory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numericUpDownClock;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxConsole;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;

    }
}

