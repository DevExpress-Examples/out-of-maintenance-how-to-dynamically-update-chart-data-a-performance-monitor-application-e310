namespace ChartPerfMon
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
            DevExpress.XtraCharts.AreaSeriesView areaSeriesView1 = new DevExpress.XtraCharts.AreaSeriesView();
            this.cbCategories = new System.Windows.Forms.ComboBox();
            this.lbCounters = new System.Windows.Forms.ListBox();
            this.tmClock = new System.Windows.Forms.Timer(this.components);
            this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
            this.lblCounterInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(areaSeriesView1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbCategories
            // 
            this.cbCategories.DropDownHeight = 200;
            this.cbCategories.FormattingEnabled = true;
            this.cbCategories.IntegralHeight = false;
            this.cbCategories.Location = new System.Drawing.Point(10, 3);
            this.cbCategories.Name = "cbCategories";
            this.cbCategories.Size = new System.Drawing.Size(187, 21);
            this.cbCategories.Sorted = true;
            this.cbCategories.TabIndex = 0;
            this.cbCategories.SelectedIndexChanged += new System.EventHandler(this.cbCategories_SelectedIndexChanged);
            // 
            // lbCounters
            // 
            this.lbCounters.FormattingEnabled = true;
            this.lbCounters.Location = new System.Drawing.Point(12, 30);
            this.lbCounters.Name = "lbCounters";
            this.lbCounters.Size = new System.Drawing.Size(180, 238);
            this.lbCounters.TabIndex = 1;
            this.lbCounters.SelectedIndexChanged += new System.EventHandler(this.lbCounters_SelectedIndexChanged);
            // 
            // tmClock
            // 
            this.tmClock.Enabled = true;
            this.tmClock.Interval = 200;
            this.tmClock.Tick += new System.EventHandler(this.tmClock_Tick);
            // 
            // chartControl1
            // 
            this.chartControl1.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Center;
            this.chartControl1.Legend.AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.Bottom;
            this.chartControl1.Legend.Direction = DevExpress.XtraCharts.LegendDirection.LeftToRight;
            this.chartControl1.Legend.BackColor = System.Drawing.Color.Transparent;
            this.chartControl1.Location = new System.Drawing.Point(206, 30);
            this.chartControl1.Name = "chartControl1";
            this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            areaSeriesView1.Transparency = ((byte)(0));
            this.chartControl1.SeriesTemplate.View = areaSeriesView1;
            this.chartControl1.Size = new System.Drawing.Size(430, 238);
            this.chartControl1.TabIndex = 3;
            // 
            // lblCounterInfo
            // 
            this.lblCounterInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCounterInfo.Location = new System.Drawing.Point(203, 9);
            this.lblCounterInfo.Name = "lblCounterInfo";
            this.lblCounterInfo.Size = new System.Drawing.Size(433, 18);
            this.lblCounterInfo.TabIndex = 4;
            this.lblCounterInfo.Text = "Counter Info";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 275);
            this.Controls.Add(this.lbCounters);
            this.Controls.Add(this.cbCategories);
            this.Controls.Add(this.lblCounterInfo);
            this.Controls.Add(this.chartControl1);
            this.Name = "Form1";
            this.Text = "ChartPerfMon";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(areaSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbCategories;
        private System.Windows.Forms.ListBox lbCounters;
        private System.Windows.Forms.Timer tmClock;
        private DevExpress.XtraCharts.ChartControl chartControl1;
        private System.Windows.Forms.Label lblCounterInfo;
    }
}

