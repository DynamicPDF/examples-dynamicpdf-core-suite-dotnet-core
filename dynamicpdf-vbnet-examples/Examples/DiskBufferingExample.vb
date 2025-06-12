Imports ceTe.DynamicPDF

Namespace DynamicPDFCoreSuite.Examples

    Class DiskBufferingExample

        Public Shared Sub Run()
            Dim document As New Document()
            document.Pages.Add(New Page())

            Dim options As New DiskBufferingOptions()
            options.Location = "PhysicalTempFilePath"
            document.DiskBuffering = options

            document.Draw(Util.GetPath("Output/diskbuffering-output.pdf"))
        End Sub

    End Class

End Namespace
