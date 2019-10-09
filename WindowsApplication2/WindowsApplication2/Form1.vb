Imports System.IO
Imports System.Drawing.Imaging
Imports System.Collections.Generic


Public Class Form1
    Sub Main()
        Dim pathToPdf As String = "C:\Users\LL\Documents\Visual Studio 2013\Projects\WindowsApplication2\WindowsApplication2/Table.pdf"
        Dim pathToExcel As String = Path.ChangeExtension(pathToPdf, ".xls")

        ' Convert only tables from PDF to XLS spreadsheet and skip all textual data.
        Dim f As New SautinSoft.PdfFocus()

        ' This property is necessary only for registered version
        'f.Serial = "10006108851"

        ' 'true' = Convert all data to spreadsheet (tabular and even textual).
        ' 'false' = Skip textual data and convert only tabular (tables) data.
        f.ExcelOptions.ConvertNonTabularDataToSpreadsheet = False

        ' 'true'  = Preserve original page layout.
        ' 'false' = Place tables before text.
        f.ExcelOptions.PreservePageLayout = True

        ' The information includes the names for the culture, the writing system, 
        ' the calendar used, the sort order of strings, and formatting for dates and numbers.
        Dim ci As New System.Globalization.CultureInfo("en-US")
        ci.NumberFormat.NumberDecimalSeparator = ","
        ci.NumberFormat.NumberGroupSeparator = "."
        f.ExcelOptions.CultureInfo = ci

        f.OpenPdf(pathToPdf)

        If f.PageCount > 0 Then
            Dim result As Integer = f.ToExcel(pathToExcel)

            ' Open the resulted Excel workbook.
            If result = 0 Then
                System.Diagnostics.Process.Start(pathToExcel)
            End If
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Call Main()

    End Sub
End Class
