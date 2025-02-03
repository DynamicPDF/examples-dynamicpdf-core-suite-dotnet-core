Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.LayoutEngine
Imports ceTe.DynamicPDF.LayoutEngine.Data
Imports dynamicpdf_vbnet_examples.ProductCategoryData
Imports Newtonsoft.Json
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Linq
Imports System.Text
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
            GenerateSubReportUsingJson()
            GenerateSubreportUsingDataObjects()
            GenerateSubReportUsingSqlJson()
            GenerateSubReportUsingSqlEvent()
            GenerateUsingDatabaseAndJson()
            GenerateUsingEnumeration()
        End Sub
        Public Shared Sub GenerateUsingEnumeration()
            Dim layoutReport As DocumentLayout = New DocumentLayout(Util.GetPath("Resources/DLEXs/report-with-cover-page.dlex"))

            Dim products As Products = New Products()

            Dim enumData As EnumerableReportData = New EnumerableReportData(products)

            Dim layoutData As LayoutData = New LayoutData()
            layoutData.Add("Products", enumData)
            layoutData.Add("ReportCreatedFor", "Alex Smith")

            Dim document As Document = layoutReport.Layout(layoutData)
            document.Author = "DynamicPDF ReportWriter"
            document.Title = "Simple Report Example"
            document.Draw(Util.GetPath("Output/report-enumeration-layout-data-output.pdf"))
        End Sub
        Public Shared Sub GenerateUsingDatabaseAndJson()
            Dim queryWithForJson As String = "SELECT ProductID, ProductName, QuantityPerUnit, UnitPrice FROM Products FOR JSON AUTO, ROOT('Products')"

            Using conn As New SqlConnection(CONNECTION_STRING)
                Using cmd As New SqlCommand(queryWithForJson, conn)
                    conn.Open()
                    Dim jsonResult As New StringBuilder()
                    Dim reader As SqlDataReader = cmd.ExecuteReader()

                    If Not reader.HasRows Then
                        jsonResult.Append("[]")
                    Else
                        While reader.Read()
                            jsonResult.Append(reader.GetValue(0).ToString())
                        End While
                    End If

                    Dim jsonData = JsonConvert.DeserializeObject(jsonResult.ToString())
                    Dim layoutReport As New DocumentLayout(Util.GetPath("Resources/DLEXs/report-with-cover-page.dlex"))
                    Dim layoutData As New LayoutData(jsonData)
                    layoutData.Add("ReportCreatedFor", "John Doe")

                    Dim document As Document = layoutReport.Layout(layoutData)
                    document.Draw(Util.GetPath("Output/report-forjson-json-layout-data-output.pdf"))
                End Using
            End Using
        End Sub
        Public Shared Sub GenerateSubReportUsingSqlEvent()
            Dim documentLayout As New DocumentLayout(Util.GetPath("Resources/DLEXs/subreport.dlex"))
            AddHandler documentLayout.ReportDataRequired, AddressOf DocumentLayout_ReportDataRequired
            Dim layoutData As New LayoutData()
            Dim document As Document = documentLayout.Layout(layoutData)
            document.Draw(Util.GetPath("Output/subreport_db_sql_output.pdf"))
        End Sub

        Private Shared Sub DocumentLayout_ReportDataRequired(sender As Object, args As ReportDataRequiredEventArgs)
            If args.ElementId = "ProductsByCategoryReport" Then
                Dim sqlString As String =
                "SELECT CategoryID, CategoryName Name " &
                "FROM   Categories "

                Dim connection As New SqlConnection(CONNECTION_STRING)
                Dim command As New SqlCommand(sqlString, connection)
                connection.Open()
                Dim reader As SqlDataReader = command.ExecuteReader()
                args.ReportData = New DataReaderReportData(connection, reader)

            ElseIf args.ElementId = "ProductsByCategorySubReport" Then
                Dim sqlString As String =
                "SELECT ProductID, ProductName, QuantityPerUnit, UnitPrice, Discontinued " &
                "FROM   Products " &
                "WHERE  CategoryID = " & args.Data("CategoryID") & " " &
                "ORDER BY ProductName "

                Dim connection As New SqlConnection(CONNECTION_STRING)
                Dim command As New SqlCommand(sqlString, connection)
                connection.Open()
                Dim reader As SqlDataReader = command.ExecuteReader()
                args.ReportData = New DataReaderReportData(connection, reader)
            End If
        End Sub
        Public Shared Sub GenerateSubReportUsingSqlJson()
            Dim queryWithForJson As String = "SELECT CategoryName as Name, ProductID, ProductName, " &
                                         "QuantityPerUnit, Discontinued, UnitPrice " &
                                         "FROM Categories, Products FOR JSON auto, root('ProductsByCategory')"

            Using conn As New SqlConnection(CONNECTION_STRING)
                Using cmd As New SqlCommand(queryWithForJson, conn)
                    conn.Open()
                    Dim jsonResult As New StringBuilder()
                    Dim reader As SqlDataReader = cmd.ExecuteReader()

                    If Not reader.HasRows Then
                        jsonResult.Append("[]")
                    Else
                        While reader.Read()
                            jsonResult.Append(reader.GetValue(0).ToString())
                        End While
                    End If

                    Dim jsonData As Object = JsonConvert.DeserializeObject(jsonResult.ToString())
                    Dim layoutReport As New DocumentLayout(Util.GetPath("Resources/DLEXs/subreport.dlex"))
                    Dim layoutData As New LayoutData(jsonData)
                    Dim document As Document = layoutReport.Layout(layoutData)
                    document.Draw(Util.GetPath("Output/subreport-forjson-json-layout-data-output.pdf"))
                End Using
            End Using
        End Sub
        Public Shared Sub GenerateSubreportUsingDataObjects()
            Dim layoutReport As New DocumentLayout(Util.GetPath("Resources/DLEXs/subreport.dlex"))
            Dim layoutData As New NameValueLayoutData()
            Dim productCategoryData As List(Of ProductCategory) = GetProductCategoryObjects()
            layoutData.Add("ProductsByCategory", productCategoryData)
            Dim document As Document = layoutReport.Layout(layoutData)
            document.Draw(Util.GetPath("Output/subreport-dataobject-layout-data-output.pdf"))
        End Sub
        Public Shared Sub GenerateSubReportUsingJson()
            Dim data As String = File.ReadAllText(Util.GetPath("Resources/Data/subreport.json"))
            Dim jsonData As Object = JsonConvert.DeserializeObject(data)

            Dim layoutReport As New DocumentLayout(Util.GetPath("Resources/DLEXs/subreport.dlex"))
            Dim layoutData As New LayoutData(jsonData)
            Dim document As Document = layoutReport.Layout(layoutData)
            document.Draw(Util.GetPath("Output/subreport-json-layout-data-output.pdf"))
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

