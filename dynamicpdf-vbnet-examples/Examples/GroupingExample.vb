Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements

Namespace DynamicPDFCoreSuite.Examples
    Public Class GroupingExample
        Public Shared Sub Run()
            GroupExample()
            AnchorGroupExample()
            AreaGroupExample()
            TransformationGroupExample()
            TransparencyGroupExample()
            ContentAreaExample()
        End Sub

        Public Shared Sub GroupExample()
            Dim document As New Document()
            Dim page As New Page()
            document.Pages.Add(page)

            Dim mygroup As New Group()
            mygroup.Add(New Rectangle(0, 0, 200, 200, 3))
            mygroup.Add(New Line(0, 100, 100, 0, 3))
            mygroup.Add(New Line(100, 0, 200, 100, 3))
            mygroup.Add(New Line(200, 100, 100, 200, 3))
            mygroup.Add(New Line(100, 200, 0, 100, 3))

            page.Elements.Add(mygroup)
            document.Draw(Util.GetPath("Output/group-output.pdf"))
        End Sub

        Public Shared Sub ContentAreaExample()
            Dim document As New Document()
            Dim page As New Page()
            document.Pages.Add(page)

            Dim myArea As New ContentArea(10, 400, 400, 600)
            myArea.Add(New Rectangle(0, 0, 200, 200, 3))
            myArea.Add(New Line(0, 100, 100, 0, 3))
            myArea.Add(New Line(100, 0, 200, 100, 3))
            myArea.Add(New Line(200, 100, 100, 200, 3))
            myArea.Add(New Line(100, 200, 0, 100, 3))

            page.Elements.Add(myArea)
            document.Draw(Util.GetPath("Output/content-area-output.pdf"))
        End Sub

        Public Shared Sub AnchorGroupExample()
            Dim document As New Document()
            Dim page As New Page()
            document.Pages.Add(page)

            Dim group As New AnchorGroup(0, 0, Align.Left, VAlign.Center)
            group.AnchorTo = AnchorTo.Margins
            group.Add(New Rectangle(0, 0, 200, 200, 1))
            group.Add(New Label("A Label", 0, 300, 100, 0))

            page.Elements.Add(group)
            document.Draw(Util.GetPath("Output/anchor-group-output.pdf"))
        End Sub

        Public Shared Sub AreaGroupExample()
            Dim document As New Document()
            Dim page As New Page()
            document.Pages.Add(page)

            Dim group1 As New AreaGroup(200, 200)
            group1.Add(New Rectangle(0, 0, 200, 200, 3))
            group1.Add(New Line(0, 100, 100, 0, 3))
            group1.Add(New Line(100, 0, 200, 100, 3))
            group1.Add(New Line(200, 100, 100, 200, 3))
            group1.Add(New Line(100, 200, 0, 100, 3))

            page.Elements.Add(group1)
            document.Draw(Util.GetPath("Output/area-group-output.pdf"))
        End Sub

        Public Shared Sub TransformationGroupExample()
            Dim document As New Document()
            Dim page As New Page()
            document.Pages.Add(page)

            Dim group1 As New TransformationGroup(100, 100, 200, 200, 30)
            group1.Add(New Rectangle(0, 0, 75, 75, RgbColor.Blue, RgbColor.Blue))
            group1.Add(New Label("This text is inside a TransformationGroup.", 0, 100, 300, 12))
            group1.ScaleY = 2
            group1.Angle = 35

            page.Elements.Add(group1)
            document.Draw(Util.GetPath("Output/transformation-group-output.pdf"))
        End Sub

        Public Shared Sub TransparencyGroupExample()
            Dim document As New Document()
            Dim page As New Page()
            document.Pages.Add(page)

            Dim group1 As New TransparencyGroup(0.35F)
            group1.Add(New Rectangle(0, 0, 75, 75, RgbColor.Blue, RgbColor.Blue))
            group1.Add(New Label("This text is inside a TransparencyGroup.", 0, 100, 300, 12))

            page.Elements.Add(group1)
            document.Draw(Util.GetPath("Output/transparency-group-output.pdf"))
        End Sub
    End Class
End Namespace

