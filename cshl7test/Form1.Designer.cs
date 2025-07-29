namespace cshl7test
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
            this.components = new System.ComponentModel.Container();
            this.formInfo = new System.Windows.Forms.Label();
            this.payloadSizeSelector = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.outputListbox = new System.Windows.Forms.ListBox();
            this.sendPayload = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.ackListbox = new System.Windows.Forms.ListBox();
            this.ackListboxlabel = new System.Windows.Forms.Label();
            this.connectionInfo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ipAddressInput = new System.Windows.Forms.TextBox();
            this.portInput = new System.Windows.Forms.TextBox();
            this.form1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.form1BindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.form1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.form1BindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // formInfo
            // 
            this.formInfo.AutoSize = true;
            this.formInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.formInfo.ForeColor = System.Drawing.Color.Gray;
            this.formInfo.Location = new System.Drawing.Point(12, 9);
            this.formInfo.Name = "formInfo";
            this.formInfo.Size = new System.Drawing.Size(240, 29);
            this.formInfo.TabIndex = 0;
            this.formInfo.Text = "Interface testing tool";
            // 
            // payloadSizeSelector
            // 
            this.payloadSizeSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.payloadSizeSelector.FormattingEnabled = true;
            this.payloadSizeSelector.Location = new System.Drawing.Point(17, 73);
            this.payloadSizeSelector.Name = "payloadSizeSelector";
            this.payloadSizeSelector.Size = new System.Drawing.Size(118, 21);
            this.payloadSizeSelector.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Payload Size:";
            // 
            // outputListbox
            // 
            this.outputListbox.FormattingEnabled = true;
            this.outputListbox.HorizontalScrollbar = true;
            this.outputListbox.Location = new System.Drawing.Point(17, 151);
            this.outputListbox.Name = "outputListbox";
            this.outputListbox.Size = new System.Drawing.Size(270, 264);
            this.outputListbox.TabIndex = 3;
            // 
            // sendPayload
            // 
            this.sendPayload.Location = new System.Drawing.Point(467, 69);
            this.sendPayload.Name = "sendPayload";
            this.sendPayload.Size = new System.Drawing.Size(72, 27);
            this.sendPayload.TabIndex = 6;
            this.sendPayload.Text = "Send Payload";
            this.sendPayload.UseVisualStyleBackColor = true;
            this.sendPayload.Click += new System.EventHandler(this.sendPayload_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Outbound log";
            // 
            // ackListbox
            // 
            this.ackListbox.FormattingEnabled = true;
            this.ackListbox.HorizontalScrollbar = true;
            this.ackListbox.Location = new System.Drawing.Point(322, 151);
            this.ackListbox.Name = "ackListbox";
            this.ackListbox.Size = new System.Drawing.Size(466, 264);
            this.ackListbox.TabIndex = 8;
            // 
            // ackListboxlabel
            // 
            this.ackListboxlabel.AutoSize = true;
            this.ackListboxlabel.Location = new System.Drawing.Point(322, 132);
            this.ackListboxlabel.Name = "ackListboxlabel";
            this.ackListboxlabel.Size = new System.Drawing.Size(88, 13);
            this.ackListboxlabel.TabIndex = 9;
            this.ackListboxlabel.Text = "Message ack log";
            // 
            // connectionInfo
            // 
            this.connectionInfo.AutoSize = true;
            this.connectionInfo.Location = new System.Drawing.Point(169, 54);
            this.connectionInfo.MaximumSize = new System.Drawing.Size(135, 0);
            this.connectionInfo.Name = "connectionInfo";
            this.connectionInfo.Size = new System.Drawing.Size(58, 13);
            this.connectionInfo.TabIndex = 10;
            this.connectionInfo.Text = "IP Address";
            this.connectionInfo.Click += new System.EventHandler(this.connectionInfo_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(325, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Port";
            // 
            // ipAddressInput
            // 
            this.ipAddressInput.Location = new System.Drawing.Point(172, 73);
            this.ipAddressInput.Name = "ipAddressInput";
            this.ipAddressInput.Size = new System.Drawing.Size(100, 20);
            this.ipAddressInput.TabIndex = 12;
            // 
            // portInput
            // 
            this.portInput.Location = new System.Drawing.Point(325, 73);
            this.portInput.Name = "portInput";
            this.portInput.Size = new System.Drawing.Size(100, 20);
            this.portInput.TabIndex = 13;
            // 
            // form1BindingSource
            // 
            this.form1BindingSource.DataSource = typeof(cshl7test.Form1);
            // 
            // form1BindingSource1
            // 
            this.form1BindingSource1.DataSource = typeof(cshl7test.Form1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.portInput);
            this.Controls.Add(this.ipAddressInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.connectionInfo);
            this.Controls.Add(this.ackListboxlabel);
            this.Controls.Add(this.ackListbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.sendPayload);
            this.Controls.Add(this.outputListbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.payloadSizeSelector);
            this.Controls.Add(this.formInfo);
            this.Name = "Form1";
            this.Text = "Interface Testing Tool";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.form1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.form1BindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label formInfo;
        private System.Windows.Forms.ComboBox payloadSizeSelector;
        private System.Windows.Forms.BindingSource form1BindingSource;
        private System.Windows.Forms.BindingSource form1BindingSource1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox outputListbox;
        private System.Windows.Forms.Button sendPayload;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox ackListbox;
        private System.Windows.Forms.Label ackListboxlabel;
        private System.Windows.Forms.Label connectionInfo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ipAddressInput;
        private System.Windows.Forms.TextBox portInput;
    }
}

