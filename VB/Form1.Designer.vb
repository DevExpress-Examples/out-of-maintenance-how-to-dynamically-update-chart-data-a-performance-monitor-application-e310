Imports Microsoft.VisualBasic
Imports System
Namespace ChartPerfMon
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Dim areaSeriesView1 As New DevExpress.XtraCharts.AreaSeriesView()
			Me.cbCategories = New System.Windows.Forms.ComboBox()
			Me.lbCounters = New System.Windows.Forms.ListBox()
			Me.tmClock = New System.Windows.Forms.Timer(Me.components)
			Me.chartControl1 = New DevExpress.XtraCharts.ChartControl()
			Me.lblCounterInfo = New System.Windows.Forms.Label()
			CType(Me.chartControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(areaSeriesView1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' cbCategories
			' 
			Me.cbCategories.DropDownHeight = 200
			Me.cbCategories.FormattingEnabled = True
			Me.cbCategories.IntegralHeight = False
			Me.cbCategories.Location = New System.Drawing.Point(10, 3)
			Me.cbCategories.Name = "cbCategories"
			Me.cbCategories.Size = New System.Drawing.Size(187, 21)
			Me.cbCategories.Sorted = True
			Me.cbCategories.TabIndex = 0
'			Me.cbCategories.SelectedIndexChanged += New System.EventHandler(Me.cbCategories_SelectedIndexChanged);
			' 
			' lbCounters
			' 
			Me.lbCounters.FormattingEnabled = True
			Me.lbCounters.Location = New System.Drawing.Point(12, 30)
			Me.lbCounters.Name = "lbCounters"
			Me.lbCounters.Size = New System.Drawing.Size(180, 238)
			Me.lbCounters.TabIndex = 1
'			Me.lbCounters.SelectedIndexChanged += New System.EventHandler(Me.lbCounters_SelectedIndexChanged);
			' 
			' tmClock
			' 
			Me.tmClock.Enabled = True
			Me.tmClock.Interval = 200
'			Me.tmClock.Tick += New System.EventHandler(Me.tmClock_Tick);
			' 
			' chartControl1
			' 
			Me.chartControl1.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Center
			Me.chartControl1.Legend.AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.Bottom
			Me.chartControl1.Legend.Direction = DevExpress.XtraCharts.LegendDirection.LeftToRight
			Me.chartControl1.Legend.BackColor = System.Drawing.Color.Transparent
			Me.chartControl1.Location = New System.Drawing.Point(206, 30)
			Me.chartControl1.Name = "chartControl1"
			Me.chartControl1.SeriesSerializable = New DevExpress.XtraCharts.Series(){}
			areaSeriesView1.Transparency = (CByte(0))
			Me.chartControl1.SeriesTemplate.View = areaSeriesView1
			Me.chartControl1.Size = New System.Drawing.Size(430, 238)
			Me.chartControl1.TabIndex = 3
			' 
			' lblCounterInfo
			' 
			Me.lblCounterInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (CByte(204)))
			Me.lblCounterInfo.Location = New System.Drawing.Point(203, 9)
			Me.lblCounterInfo.Name = "lblCounterInfo"
			Me.lblCounterInfo.Size = New System.Drawing.Size(433, 18)
			Me.lblCounterInfo.TabIndex = 4
			Me.lblCounterInfo.Text = "Counter Info"
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(654, 275)
			Me.Controls.Add(Me.lbCounters)
			Me.Controls.Add(Me.cbCategories)
			Me.Controls.Add(Me.lblCounterInfo)
			Me.Controls.Add(Me.chartControl1)
			Me.Name = "Form1"
			Me.Text = "ChartPerfMon"
'			Me.Load += New System.EventHandler(Me.Form1_Load);
'			Me.Resize += New System.EventHandler(Me.Form1_Resize);
			CType(areaSeriesView1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.chartControl1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private WithEvents cbCategories As System.Windows.Forms.ComboBox
		Private WithEvents lbCounters As System.Windows.Forms.ListBox
		Private WithEvents tmClock As System.Windows.Forms.Timer
		Private chartControl1 As DevExpress.XtraCharts.ChartControl
		Private lblCounterInfo As System.Windows.Forms.Label
	End Class
End Namespace

