Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.LayoutEngine
Imports ceTe.DynamicPDF.LayoutEngine.Data
Imports Newtonsoft.Json
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Linq
Imports System.Xml.Linq

Namespace DynamicPDFCoreSuite.Examples
    Public Class GenerateReportExample
        Private Shared CONNECTION_STRING As String = "Data Source=(local);Initial Catalog=Northwind;Integrated Security=true"

        Public Shared Sub Run()
            GenerateTopLevelExample()
            GenerateUsingJson()
            GenerateUsingDataObjects()
            GenerateUsingLinqData()
            GenerateUsingDatabaseTable()
            GenerateUsingSql()
        End Sub
        Public Shared Sub GenerateTopLevelExample()
            Dim layoutReport As New DocumentLayout(Util.GetPath("Resources/DLEXs/form-fill.dlex"))
            Dim layoutData As New LayoutData()
            layoutData.Add("FirstNameAndI", "Alex B.")
            layoutData.Add("LastName", "Smith")
            layoutData.Add("SSN", "123-45-6789")
            layoutData.Add("HomeAddress", "456 Green Road")
            layoutData.Add("CityStateZip", "Somewhere, Earth  12345")
            layoutData.Add("Allowances", "2")
            layoutData.Add("IsSingle", True)

            Dim document As Document = layoutReport.Layout(layoutData)
            document.Author = "DynamicPDF ReportWriter"
            document.Title = "Form Fill Example"

            document.Draw(Util.GetPath("Output/toplevel-noobject-layoutdata.pdf"))
        End Sub

        Public Shared Sub GenerateUsingJson()
            Dim data As String = File.ReadAllText(Util.GetPath("Resources/Data/report-with-cover-page.json"))
            Dim jsonData = JsonConvert.DeserializeObject(data)

            Dim layoutReport As New DocumentLayout(Util.GetPath("Resources/DLEXs/report-with-cover-page.dlex"))
            Dim layoutData As New LayoutData(jsonData)
            Dim document As Document = layoutReport.Layout(layoutData)
            document.Draw(Util.GetPath("Output/report-json-layout-data-output.pdf"))
        End Sub

        Public Shared Sub GenerateUsingDataObjects()
            Dim layoutReport As New DocumentLayout(Util.GetPath("Resources/DLEXs/report-with-cover-page.dlex"))
            Dim layoutData As New NameValueLayoutData()
            layoutData.Add("ReportCreatedFor", "Alex Smith")
            layoutData.Add("Products", ProductsData.Products)

            Dim document As Document = layoutReport.Layout(layoutData)
            document.Author = "DynamicPDF ReportWriter"
            document.Title = "Simple Report Example"
            document.Draw(Util.GetPath("Output/report-dataobject-layout-data-output.pdf"))
        End Sub

        Public Shared Sub GenerateUsingLinqData()
            Dim root As XElement = XElement.Load(Util.GetPath("Resources/XML/ProductList.xml"))
            Dim products = From p In root.Elements("Products")
                           Select New With {
                               .ProductID = CInt(p.Attribute("ProductID")),
                               .ProductName = CStr(p.Attribute("ProductName")),
                               .QuantityPerUnit = CStr(p.Attribute("QuantityPerUnit")),
                               .UnitPrice = CDec(p.Attribute("UnitPrice"))
                           }

            Dim layoutReport As New DocumentLayout(Util.GetPath("Resources/DLEXs/report-with-cover-page.dlex"))
            Dim layoutData As New LayoutData()
            layoutData.Add("ReportCreatedFor", "John Doe")
            layoutData.Add("Products", products)
            Dim document As Document = layoutReport.Layout(layoutData)
            document.Draw(Util.GetPath("Output/report-linq-layout-data-output.pdf"))
        End Sub

        Public Shared Sub GenerateUsingDatabaseTable()
            Dim sql As String = "SELECT ProductID, ProductName, QuantityPerUnit, UnitPrice FROM Products"
            Dim dataTable As New DataTable()

            Using connection As New SqlConnection(CONNECTION_STRING)
                Using command As New SqlCommand(sql, connection)
                    connection.Open()
                    Using reader As SqlDataReader = command.ExecuteReader()
                        dataTable.Load(reader)
                    End Using
                End Using
            End Using

            Dim layoutReport As New DocumentLayout(Util.GetPath("Resources/DLEXs/report-with-cover-page.dlex"))
            Dim layoutData As New NameValueLayoutData()
            Dim data As New DataTableReportData(dataTable)
            layoutData.Add("ReportCreatedFor", "John Doe")
            layoutData.Add("Products", data)
            Dim document As Document = layoutReport.Layout(layoutData)
            document.Draw(Util.GetPath("Output/report-database-table-layout-data-output.pdf"))
        End Sub

        Public Shared Sub GenerateUsingSql()
            Dim sql As String = "SELECT ProductID, ProductName, QuantityPerUnit, UnitPrice FROM Products"
            Dim document As Document = Nothing
            Dim layoutReport As New DocumentLayout(Util.GetPath("Resources/DLEXs/report-with-cover-page.dlex"))
            Dim layoutData As New NameValueLayoutData()
            layoutData.Add("ReportCreatedFor", "John Doe")

            Using connection As New SqlConnection(CONNECTION_STRING)
                Using command As New SqlCommand(sql, connection)
                    connection.Open()
                    Using reader As SqlDataReader = command.ExecuteReader()
                        layoutData.Add("Products", New DataReaderReportData(connection, reader))
                        document = layoutReport.Layout(layoutData)
                    End Using
                End Using
            End Using

            document.Draw(Util.GetPath("Output/report-query-layout-data-output.pdf"))
        End Sub
    End Class
End Namespace

