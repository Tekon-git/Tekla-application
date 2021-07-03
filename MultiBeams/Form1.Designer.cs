
namespace TwoBeams
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
            this.btn_multiBeams = new System.Windows.Forms.Button();
            this.tb_materialPlates = new System.Windows.Forms.TextBox();
            this.materialCatalog1 = new Tekla.Structures.Dialog.UIControls.MaterialCatalog();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_thcikPlates = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_namePlates = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.boltCatalogStandard1 = new Tekla.Structures.Dialog.UIControls.BoltCatalogStandard();
            this.boltCatalogSize1 = new Tekla.Structures.Dialog.UIControls.BoltCatalogSize();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_nameBeams = new System.Windows.Forms.TextBox();
            this.tb_profileBeams = new System.Windows.Forms.TextBox();
            this.tb_materialBeams = new System.Windows.Forms.TextBox();
            this.materialCatalogBeams = new Tekla.Structures.Dialog.UIControls.MaterialCatalog();
            this.profileCatalogBeams = new Tekla.Structures.Dialog.UIControls.ProfileCatalog();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_multiBeams
            // 
            this.structuresExtender.SetAttributeName(this.btn_multiBeams, null);
            this.structuresExtender.SetAttributeTypeName(this.btn_multiBeams, null);
            this.structuresExtender.SetBindPropertyName(this.btn_multiBeams, null);
            this.btn_multiBeams.Location = new System.Drawing.Point(193, 271);
            this.btn_multiBeams.Name = "btn_multiBeams";
            this.btn_multiBeams.Size = new System.Drawing.Size(292, 45);
            this.btn_multiBeams.TabIndex = 0;
            this.btn_multiBeams.Text = "Create Multi Beams";
            this.btn_multiBeams.UseVisualStyleBackColor = true;
            this.btn_multiBeams.Click += new System.EventHandler(this.btn_multiBeams_Click);
            // 
            // tb_materialPlates
            // 
            this.structuresExtender.SetAttributeName(this.tb_materialPlates, null);
            this.structuresExtender.SetAttributeTypeName(this.tb_materialPlates, null);
            this.structuresExtender.SetBindPropertyName(this.tb_materialPlates, null);
            this.tb_materialPlates.Location = new System.Drawing.Point(411, 129);
            this.tb_materialPlates.Name = "tb_materialPlates";
            this.tb_materialPlates.Size = new System.Drawing.Size(134, 22);
            this.tb_materialPlates.TabIndex = 3;
            // 
            // materialCatalog1
            // 
            this.structuresExtender.SetAttributeName(this.materialCatalog1, null);
            this.structuresExtender.SetAttributeTypeName(this.materialCatalog1, null);
            this.materialCatalog1.BackColor = System.Drawing.Color.Transparent;
            this.structuresExtender.SetBindPropertyName(this.materialCatalog1, null);
            this.materialCatalog1.ButtonText = "...";
            this.materialCatalog1.Location = new System.Drawing.Point(554, 129);
            this.materialCatalog1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.materialCatalog1.Name = "materialCatalog1";
            this.materialCatalog1.SelectedMaterial = "";
            this.materialCatalog1.Size = new System.Drawing.Size(28, 25);
            this.materialCatalog1.TabIndex = 4;
            this.materialCatalog1.SelectClicked += new System.EventHandler(this.materialCatalog1_SelectClicked);
            this.materialCatalog1.SelectionDone += new System.EventHandler(this.materialCatalog1_SelectionDone);
            // 
            // label4
            // 
            this.structuresExtender.SetAttributeName(this.label4, null);
            this.structuresExtender.SetAttributeTypeName(this.label4, null);
            this.label4.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label4, null);
            this.label4.Location = new System.Drawing.Point(320, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Material";
            // 
            // tb_thcikPlates
            // 
            this.structuresExtender.SetAttributeName(this.tb_thcikPlates, null);
            this.structuresExtender.SetAttributeTypeName(this.tb_thcikPlates, null);
            this.structuresExtender.SetBindPropertyName(this.tb_thcikPlates, null);
            this.tb_thcikPlates.Location = new System.Drawing.Point(411, 92);
            this.tb_thcikPlates.Name = "tb_thcikPlates";
            this.tb_thcikPlates.Size = new System.Drawing.Size(134, 22);
            this.tb_thcikPlates.TabIndex = 3;
            // 
            // label5
            // 
            this.structuresExtender.SetAttributeName(this.label5, null);
            this.structuresExtender.SetAttributeTypeName(this.label5, null);
            this.label5.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label5, null);
            this.label5.Location = new System.Drawing.Point(320, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 17);
            this.label5.TabIndex = 2;
            this.label5.Text = "Thickness";
            // 
            // tb_namePlates
            // 
            this.structuresExtender.SetAttributeName(this.tb_namePlates, null);
            this.structuresExtender.SetAttributeTypeName(this.tb_namePlates, null);
            this.structuresExtender.SetBindPropertyName(this.tb_namePlates, null);
            this.tb_namePlates.Location = new System.Drawing.Point(411, 53);
            this.tb_namePlates.Name = "tb_namePlates";
            this.tb_namePlates.Size = new System.Drawing.Size(134, 22);
            this.tb_namePlates.TabIndex = 3;
            // 
            // label6
            // 
            this.structuresExtender.SetAttributeName(this.label6, null);
            this.structuresExtender.SetAttributeTypeName(this.label6, null);
            this.label6.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label6, null);
            this.label6.Location = new System.Drawing.Point(320, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 17);
            this.label6.TabIndex = 2;
            this.label6.Text = "Name";
            // 
            // label7
            // 
            this.structuresExtender.SetAttributeName(this.label7, null);
            this.structuresExtender.SetAttributeTypeName(this.label7, null);
            this.label7.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label7, null);
            this.label7.Location = new System.Drawing.Point(34, 190);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 17);
            this.label7.TabIndex = 2;
            this.label7.Text = "Bolt Standard";
            // 
            // label8
            // 
            this.structuresExtender.SetAttributeName(this.label8, null);
            this.structuresExtender.SetAttributeTypeName(this.label8, null);
            this.label8.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label8, null);
            this.label8.Location = new System.Drawing.Point(34, 224);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 17);
            this.label8.TabIndex = 2;
            this.label8.Text = "Bolt Size";
            // 
            // boltCatalogStandard1
            // 
            this.structuresExtender.SetAttributeName(this.boltCatalogStandard1, "BoltStd");
            this.structuresExtender.SetAttributeTypeName(this.boltCatalogStandard1, "String");
            this.structuresExtender.SetBindPropertyName(this.boltCatalogStandard1, "Text");
            this.boltCatalogStandard1.FormattingEnabled = true;
            this.boltCatalogStandard1.LinkedBoltCatalogSize = this.boltCatalogSize1;
            this.boltCatalogStandard1.Location = new System.Drawing.Point(153, 187);
            this.boltCatalogStandard1.Name = "boltCatalogStandard1";
            this.boltCatalogStandard1.Size = new System.Drawing.Size(136, 24);
            this.boltCatalogStandard1.TabIndex = 3;
        
            // 
            // boltCatalogSize1
            // 
            this.structuresExtender.SetAttributeName(this.boltCatalogSize1, "BoltSize");
            this.structuresExtender.SetAttributeTypeName(this.boltCatalogSize1, "Distance");
            this.structuresExtender.SetBindPropertyName(this.boltCatalogSize1, "Text");
            this.boltCatalogSize1.FormattingEnabled = true;
            this.boltCatalogSize1.Location = new System.Drawing.Point(153, 217);
            this.boltCatalogSize1.Name = "boltCatalogSize1";
            this.boltCatalogSize1.Size = new System.Drawing.Size(136, 24);
            this.boltCatalogSize1.TabIndex = 4;
           
            // 
            // label1
            // 
            this.structuresExtender.SetAttributeName(this.label1, null);
            this.structuresExtender.SetAttributeTypeName(this.label1, null);
            this.label1.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label1, null);
            this.label1.Location = new System.Drawing.Point(37, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.structuresExtender.SetAttributeName(this.label2, null);
            this.structuresExtender.SetAttributeTypeName(this.label2, null);
            this.label2.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label2, null);
            this.label2.Location = new System.Drawing.Point(37, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Profile";
            // 
            // label3
            // 
            this.structuresExtender.SetAttributeName(this.label3, null);
            this.structuresExtender.SetAttributeTypeName(this.label3, null);
            this.label3.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label3, null);
            this.label3.Location = new System.Drawing.Point(37, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Material";
            // 
            // tb_nameBeams
            // 
            this.structuresExtender.SetAttributeName(this.tb_nameBeams, null);
            this.structuresExtender.SetAttributeTypeName(this.tb_nameBeams, null);
            this.structuresExtender.SetBindPropertyName(this.tb_nameBeams, null);
            this.tb_nameBeams.Location = new System.Drawing.Point(99, 48);
            this.tb_nameBeams.Name = "tb_nameBeams";
            this.tb_nameBeams.Size = new System.Drawing.Size(134, 22);
            this.tb_nameBeams.TabIndex = 3;
            // 
            // tb_profileBeams
            // 
            this.structuresExtender.SetAttributeName(this.tb_profileBeams, null);
            this.structuresExtender.SetAttributeTypeName(this.tb_profileBeams, null);
            this.structuresExtender.SetBindPropertyName(this.tb_profileBeams, null);
            this.tb_profileBeams.Location = new System.Drawing.Point(99, 87);
            this.tb_profileBeams.Name = "tb_profileBeams";
            this.tb_profileBeams.Size = new System.Drawing.Size(134, 22);
            this.tb_profileBeams.TabIndex = 3;
            // 
            // tb_materialBeams
            // 
            this.structuresExtender.SetAttributeName(this.tb_materialBeams, null);
            this.structuresExtender.SetAttributeTypeName(this.tb_materialBeams, null);
            this.structuresExtender.SetBindPropertyName(this.tb_materialBeams, null);
            this.tb_materialBeams.Location = new System.Drawing.Point(99, 124);
            this.tb_materialBeams.Name = "tb_materialBeams";
            this.tb_materialBeams.Size = new System.Drawing.Size(134, 22);
            this.tb_materialBeams.TabIndex = 3;
            // 
            // materialCatalogBeams
            // 
            this.structuresExtender.SetAttributeName(this.materialCatalogBeams, null);
            this.structuresExtender.SetAttributeTypeName(this.materialCatalogBeams, null);
            this.materialCatalogBeams.BackColor = System.Drawing.Color.Transparent;
            this.structuresExtender.SetBindPropertyName(this.materialCatalogBeams, null);
            this.materialCatalogBeams.ButtonText = "...";
            this.materialCatalogBeams.Location = new System.Drawing.Point(240, 123);
            this.materialCatalogBeams.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.materialCatalogBeams.Name = "materialCatalogBeams";
            this.materialCatalogBeams.SelectedMaterial = "";
            this.materialCatalogBeams.Size = new System.Drawing.Size(28, 25);
            this.materialCatalogBeams.TabIndex = 4;
            this.materialCatalogBeams.SelectClicked += new System.EventHandler(this.materialCatalogBeams_SelectClicked);
            this.materialCatalogBeams.SelectionDone += new System.EventHandler(this.materialCatalogBeams_SelectionDone);
            // 
            // profileCatalogBeams
            // 
            this.structuresExtender.SetAttributeName(this.profileCatalogBeams, null);
            this.structuresExtender.SetAttributeTypeName(this.profileCatalogBeams, null);
            this.profileCatalogBeams.BackColor = System.Drawing.Color.Transparent;
            this.structuresExtender.SetBindPropertyName(this.profileCatalogBeams, null);
            this.profileCatalogBeams.ButtonText = "...";
            this.profileCatalogBeams.Location = new System.Drawing.Point(240, 87);
            this.profileCatalogBeams.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.profileCatalogBeams.Name = "profileCatalogBeams";
            this.profileCatalogBeams.SelectedProfile = "";
            this.profileCatalogBeams.Size = new System.Drawing.Size(28, 22);
            this.profileCatalogBeams.TabIndex = 5;
            this.profileCatalogBeams.SelectClicked += new System.EventHandler(this.profileCatalogBeams_SelectClicked);
            this.profileCatalogBeams.SelectionDone += new System.EventHandler(this.profileCatalogBeams_SelectionDone);
            // 
            // label9
            // 
            this.structuresExtender.SetAttributeName(this.label9, null);
            this.structuresExtender.SetAttributeTypeName(this.label9, null);
            this.label9.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label9, null);
            this.label9.Location = new System.Drawing.Point(320, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 21);
            this.label9.TabIndex = 6;
            this.label9.Text = "Plates";
            // 
            // label10
            // 
            this.structuresExtender.SetAttributeName(this.label10, null);
            this.structuresExtender.SetAttributeTypeName(this.label10, null);
            this.label10.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label10, null);
            this.label10.Location = new System.Drawing.Point(38, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 21);
            this.label10.TabIndex = 6;
            this.label10.Text = "Beams";
            // 
            // Form1
            // 
            this.structuresExtender.SetAttributeName(this, null);
            this.structuresExtender.SetAttributeTypeName(this, null);
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.structuresExtender.SetBindPropertyName(this, null);
            this.ClientSize = new System.Drawing.Size(667, 355);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tb_materialPlates);
            this.Controls.Add(this.profileCatalogBeams);
            this.Controls.Add(this.materialCatalog1);
            this.Controls.Add(this.boltCatalogSize1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.materialCatalogBeams);
            this.Controls.Add(this.tb_thcikPlates);
            this.Controls.Add(this.boltCatalogStandard1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tb_namePlates);
            this.Controls.Add(this.tb_materialBeams);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tb_profileBeams);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tb_nameBeams);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_multiBeams);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_multiBeams;
        private System.Windows.Forms.TextBox tb_materialPlates;
        private Tekla.Structures.Dialog.UIControls.MaterialCatalog materialCatalog1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_thcikPlates;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_namePlates;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private Tekla.Structures.Dialog.UIControls.BoltCatalogStandard boltCatalogStandard1;
        private Tekla.Structures.Dialog.UIControls.BoltCatalogSize boltCatalogSize1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_nameBeams;
        private System.Windows.Forms.TextBox tb_profileBeams;
        private System.Windows.Forms.TextBox tb_materialBeams;
        private Tekla.Structures.Dialog.UIControls.MaterialCatalog materialCatalogBeams;
        private Tekla.Structures.Dialog.UIControls.ProfileCatalog profileCatalogBeams;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
    }
}

