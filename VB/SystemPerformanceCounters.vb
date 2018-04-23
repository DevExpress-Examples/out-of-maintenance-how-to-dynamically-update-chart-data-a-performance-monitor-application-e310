Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Diagnostics

Namespace ChartPerfMon

	Friend Class SystemPerformanceCounters
		Inherits Object
		Private performanceCounterCategories_Renamed As List(Of PerformanceCounterCategory)
		Private categoryPerformanceCounters() As List(Of PerformanceCounter)
		Private currentCategory As PerformanceCounterCategory
		Private currentCounter As PerformanceCounter

		Public ReadOnly Property PerformanceCounterCategories() As PerformanceCounterCategory()
			Get
				Return performanceCounterCategories_Renamed.ToArray()
			End Get
		End Property

		Public Function GetPerformanceCounters(ByVal categoryName As String) As PerformanceCounter()
			For i As Integer = 0 To performanceCounterCategories_Renamed.Count - 1
				If performanceCounterCategories_Renamed(i).CategoryName = categoryName Then
					Return categoryPerformanceCounters(i).ToArray()
				End If
			Next i

			Throw New Exception("Invalid category name: " & categoryName)
		End Function

		Public Property CurrentCategoryName() As String
			Get
				Return currentCategory.CategoryName
			End Get
			Set(ByVal value As String)
				For i As Integer = 0 To performanceCounterCategories_Renamed.Count - 1
					If performanceCounterCategories_Renamed(i).CategoryName = value Then
						currentCategory = performanceCounterCategories_Renamed(i)
						Return
					End If
				Next i

				Throw New Exception("Unknown category name: " & value)
			End Set
		End Property

		Public ReadOnly Property CurrentCategoryInstanceName() As String
			Get
				Dim instanceNames() As String = currentCategory.GetInstanceNames()

				If instanceNames.Length > 0 Then
					Return instanceNames(0)
				Else
					Return "<Noname>"
				End If
			End Get
		End Property

		Public Property CurrentCounterName() As String
			Get
				Return currentCounter.CounterName
			End Get
			Set(ByVal value As String)
				Dim catidx As Integer = performanceCounterCategories_Renamed.IndexOf(currentCategory)

				For i As Integer = 0 To categoryPerformanceCounters(catidx).Count - 1
					If categoryPerformanceCounters(catidx)(i).CounterName = value Then
						currentCounter = categoryPerformanceCounters(catidx)(i)
						Return
					End If
				Next i

				Throw New Exception("Unknown counter name: " & value)
			End Set
		End Property

		Public ReadOnly Property CurrentCounterValue() As String
			Get
				Return currentCounter.NextValue().ToString()
			End Get
		End Property

		Public Sub New()
			MyBase.New()
			Dim categories() As PerformanceCounterCategory = PerformanceCounterCategory.GetCategories()

			performanceCounterCategories_Renamed = New List(Of PerformanceCounterCategory)(100)

			performanceCounterCategories_Renamed.AddRange(categories)

			categoryPerformanceCounters = New List(Of PerformanceCounter)(categories.Length - 1){}

			Dim i As Integer = 0

			For Each category As PerformanceCounterCategory In performanceCounterCategories_Renamed
				categoryPerformanceCounters(i) = New List(Of PerformanceCounter)(10)

				If category.CategoryType = PerformanceCounterCategoryType.SingleInstance Then
					categoryPerformanceCounters(i).AddRange(category.GetCounters())
				Else
					Dim instanceNames() As String = category.GetInstanceNames()

					If instanceNames.Length > 0 Then
						categoryPerformanceCounters(i).AddRange(category.GetCounters(instanceNames(0)))
					End If
				End If
				i += 1
			Next category

			currentCategory = performanceCounterCategories_Renamed(0)
			currentCounter = categoryPerformanceCounters(0)(0)
		End Sub

	End Class
End Namespace
