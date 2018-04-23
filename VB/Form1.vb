Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Diagnostics
Imports DevExpress.XtraCharts

Namespace ChartPerfMon
	Partial Public Class Form1
		Inherits Form
		Private spc As SystemPerformanceCounters
		Private tempPoints As List(Of SeriesPoint)

		Public Sub New()
			InitializeComponent()
			InitializeChart()
		End Sub

		Private Sub InitializeChart()
			Dim series As New Series()

			' Adjust series
			series.ArgumentScaleType = ScaleType.DateTime
			series.ValueScaleType = ScaleType.Numerical
			series.Label.Border.Visible = False
			series.Label.BackColor = Color.Transparent
			series.CrosshairLabelVisibility = DevExpress.Utils.DefaultBoolean.False
			series.ChangeView(ViewType.Area)
			CType(series.View, AreaSeriesView).Color = Color.Aqua
			CType(series.View, AreaSeriesView).MarkerOptions.Kind = MarkerKind.Diamond
			CType(series.View, AreaSeriesView).MarkerOptions.Size = 7

			series.Points.Add(New SeriesPoint(DateTime.Now, New Double() { 0 }))

			chartControl1.Series.Add(series)

			' Adjust time axis
			CType(chartControl1.Diagram, XYDiagram).AxisX.DateTimeMeasureUnit = DateTimeMeasurementUnit.Millisecond
			CType(chartControl1.Diagram, XYDiagram).AxisX.DateTimeOptions.Format = DateTimeFormat.LongTime
			CType(chartControl1.Diagram, XYDiagram).AxisX.DateTimeGridAlignment = DateTimeMeasurementUnit.Millisecond
			CType(chartControl1.Diagram, XYDiagram).AxisX.Range.SideMarginsEnabled = False
			CType(chartControl1.Diagram, XYDiagram).AxisX.MinorCount = 10
			CType(chartControl1.Diagram, XYDiagram).Margins.Right = 25
			'((XYDiagram)chartControl1.Diagram).AxisX.GridSpacingAuto = false;

			' Adjust label
			Dim title As New ChartTitle()

			title.Text = "Title"
			chartControl1.Titles.Add(title)

			tempPoints = New List(Of SeriesPoint)(10)
		End Sub

		Private Sub AdjustChartRange()
			CType(chartControl1.Diagram, XYDiagram).AxisX.Range.MinValue = DateTime.Now - New TimeSpan(0, 0, 0, 5)
			CType(chartControl1.Diagram, XYDiagram).AxisX.Range.MaxValue = DateTime.Now + New TimeSpan(0, 0, 0, 5)
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			spc = New SystemPerformanceCounters()

			cbCategories.DataSource = spc.PerformanceCounterCategories
			cbCategories.ValueMember = "CategoryName"
			cbCategories.DisplayMember = cbCategories.ValueMember

			'panel1_MouseLeave(null, null);
			Form1_Resize(Nothing, Nothing)
		End Sub

		Private Sub cbCategories_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbCategories.SelectedIndexChanged
			spc.CurrentCategoryName = cbCategories.Text

			Try
				lbCounters.DataSource = spc.GetPerformanceCounters(cbCategories.Text)
				lbCounters.DisplayMember = "CounterName"
			Catch
				MessageBox.Show("No data avaliable for " & cbCategories.Text)
			End Try
		End Sub

		Private Sub lbCounters_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles lbCounters.SelectedIndexChanged
			spc.CurrentCounterName = (TryCast(lbCounters.SelectedValue, PerformanceCounter)).CounterName

			lblCounterInfo.Text = spc.CurrentCategoryName & "/" & spc.CurrentCategoryInstanceName & "/" & spc.CurrentCounterName
		End Sub

		Private Sub tmClock_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles tmClock.Tick
			Dim counterValue As String = spc.CurrentCounterValue
			Dim nextPoint As New SeriesPoint(DateTime.Now, New Double() { Double.Parse(counterValue) })

			chartControl1.Titles(0).Text = "Current value: " & counterValue

			For Each point As SeriesPoint In chartControl1.Series(0).Points
				If Convert.ToDateTime(point.Argument) < DateTime.Now - New TimeSpan(0, 0, 5) Then
					tempPoints.Add(point)
				End If
			Next point

			If tempPoints.Count > 0 Then
				tempPoints.RemoveAt(0)
			End If

			For Each point As SeriesPoint In tempPoints
				chartControl1.Series(0).Points.Remove(point)
			Next point

			tempPoints.Clear()

			chartControl1.Series(0).Points.Add(nextPoint)

			AdjustChartRange()
		End Sub

		Private Sub panel1_MouseHover(ByVal sender As Object, ByVal e As EventArgs)
			'panel1.Left = 0;
		End Sub

		Private Sub panel1_MouseLeave(ByVal sender As Object, ByVal e As EventArgs)
			'panel1.Left = 10 - panel1.Width;
		End Sub

		Private Sub panel1_Click(ByVal sender As Object, ByVal e As EventArgs)
			'panel1.Left = 10 - panel1.Width;
		End Sub

		Private Sub Form1_Resize(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Resize
			chartControl1.Left = lbCounters.Left + lbCounters.Width + 10
			chartControl1.Width = Me.Width - chartControl1.Left - 10
			chartControl1.Height = Me.Height - chartControl1.Top - 50
			lbCounters.Height = Me.Height - lbCounters.Top - 50
		End Sub

	End Class
End Namespace