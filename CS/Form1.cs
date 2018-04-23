using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using DevExpress.XtraCharts;

namespace ChartPerfMon
{
    public partial class Form1 : Form
    {
        private SystemPerformanceCounters spc;
        private List<SeriesPoint> tempPoints;

        public Form1()
        {
            InitializeComponent();
            InitializeChart();
        }

        private void InitializeChart()
        {
            Series series = new Series();

            // Adjust series
            series.ArgumentScaleType = ScaleType.DateTime;
            series.ValueScaleType = ScaleType.Numerical;
            series.Label.Border.Visible = false;
            series.Label.BackColor = Color.Transparent;
            series.CrosshairLabelVisibility = DevExpress.Utils.DefaultBoolean.False;
            series.ChangeView(ViewType.Area);
            ((AreaSeriesView)series.View).Color = Color.Aqua; 
            ((AreaSeriesView)series.View).MarkerOptions.Kind = MarkerKind.Diamond;
            ((AreaSeriesView)series.View).MarkerOptions.Size = 7;

            series.Points.Add(new SeriesPoint(DateTime.Now, new double[] { 0 }));

            chartControl1.Series.Add(series);

            // Adjust time axis
            ((XYDiagram)chartControl1.Diagram).AxisX.DateTimeScaleOptions.MeasureUnit = DateTimeMeasureUnit.Millisecond;
            ((XYDiagram)chartControl1.Diagram).AxisX.Label.DateTimeOptions.Format = DateTimeFormat.LongTime;
            ((XYDiagram)chartControl1.Diagram).AxisX.DateTimeScaleOptions.GridAlignment = DateTimeGridAlignment.Millisecond;
            ((XYDiagram)chartControl1.Diagram).AxisX.Range.SideMarginsEnabled = false;
            ((XYDiagram)chartControl1.Diagram).AxisX.MinorCount = 10;
            ((XYDiagram)chartControl1.Diagram).Margins.Right = 25;
            //((XYDiagram)chartControl1.Diagram).AxisX.GridSpacingAuto = false;

            // Adjust label
            ChartTitle title = new ChartTitle();

            title.Text = "Title";
            chartControl1.Titles.Add(title);

            tempPoints = new List<SeriesPoint>(10);
        }

        private void AdjustChartRange()
        {
            ((XYDiagram)chartControl1.Diagram).AxisX.Range.MinValue = DateTime.Now - new TimeSpan(0, 0, 0, 5);
            ((XYDiagram)chartControl1.Diagram).AxisX.Range.MaxValue = DateTime.Now + new TimeSpan(0, 0, 0, 5);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            spc = new SystemPerformanceCounters();

            cbCategories.DataSource = spc.PerformanceCounterCategories;
            cbCategories.DisplayMember = cbCategories.ValueMember = "CategoryName";

            //panel1_MouseLeave(null, null);
            Form1_Resize(null, null);
        }

        private void cbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            spc.CurrentCategoryName = cbCategories.Text;
            
            try {
                lbCounters.DataSource = spc.GetPerformanceCounters(cbCategories.Text);
                lbCounters.DisplayMember = "CounterName";
            }
            catch {
                MessageBox.Show("No data avaliable for " + cbCategories.Text);
            }
        }

        private void lbCounters_SelectedIndexChanged(object sender, EventArgs e)
        {
            spc.CurrentCounterName = (lbCounters.SelectedValue as PerformanceCounter).CounterName;

            lblCounterInfo.Text =
                spc.CurrentCategoryName + "/" +
                spc.CurrentCategoryInstanceName + "/" +
                spc.CurrentCounterName;
        }

        private void tmClock_Tick(object sender, EventArgs e)
        {
            string counterValue = spc.CurrentCounterValue;
            SeriesPoint nextPoint = new SeriesPoint(DateTime.Now, new double[] { double.Parse(counterValue) });
            
            chartControl1.Titles[0].Text = "Current value: " + counterValue;

            foreach (SeriesPoint point in chartControl1.Series[0].Points)
                if (Convert.ToDateTime(point.Argument) < DateTime.Now - new TimeSpan(0, 0, 5))
                    tempPoints.Add(point);

            if (tempPoints.Count > 0)
                tempPoints.RemoveAt(0);

            foreach (SeriesPoint point in tempPoints)
                chartControl1.Series[0].Points.Remove(point);

            tempPoints.Clear();
            
            chartControl1.Series[0].Points.Add(nextPoint);

            AdjustChartRange();
        }

        private void panel1_MouseHover(object sender, EventArgs e)
        {
            //panel1.Left = 0;
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            //panel1.Left = 10 - panel1.Width;
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            //panel1.Left = 10 - panel1.Width;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            chartControl1.Left = lbCounters.Left + lbCounters.Width + 10;
            chartControl1.Width = this.Width - chartControl1.Left - 10;
            chartControl1.Height = this.Height - chartControl1.Top - 50;
            lbCounters.Height = this.Height - lbCounters.Top - 50;
        }

    }
}