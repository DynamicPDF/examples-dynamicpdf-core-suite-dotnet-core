using ceTe.DynamicPDF.Merger;

namespace DynamicPDFCoreSuite.Examples
{
    class AcroFormFilling
    {
        public static void Run()
        {
            MergeDocument document = new MergeDocument(Util.GetPath("Resources/PDFs/fw9AcroForm_18.pdf"));
            document.Form.Fields["topmostSubform[0].Page1[0].f1_1[0]"].Value = "Any Company, Inc.";
            document.Form.Fields["topmostSubform[0].Page1[0].f1_2[0]"].Value = "Any Company";
            document.Form.Fields["topmostSubform[0].Page1[0].FederalClassification[0].c1_1[0]"].Value = "1";
            document.Form.Fields["topmostSubform[0].Page1[0].Address[0].f1_7[0]"].Value = "123 Main Street";
            document.Form.Fields["topmostSubform[0].Page1[0].Address[0].f1_8[0]"].Value = "Washington, DC  22222";
            document.Form.Fields["topmostSubform[0].Page1[0].f1_9[0]"].Value = "Any Requester";
            document.Form.Fields["topmostSubform[0].Page1[0].f1_10[0]"].Value = "17288825617";
            document.Draw(Util.GetPath("Output/AcroFormFilling.pdf"));
        }
    }
}
