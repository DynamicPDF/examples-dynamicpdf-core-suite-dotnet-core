Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.IO
Imports ceTe.DynamicPDF.PageElements

Namespace DynamicPDFCoreSuite.Examples
    Public Class Polygon
        Inherits TaggablePageElement

        Private _xCoordinates As Single()
        Private _yCoordinates As Single()
        Private _borderWidth As Single
        Private _fillColor As Color
        Private _borderColor As Color
        Private _borderStyle As LineStyle

        Private Const defaultForBorderWidth As Single = 1.0F
        Private Shared ReadOnly defaultForFillColor As Color = Nothing
        Private Shared ReadOnly defaultForBorderColor As Color = Grayscale.Black
        Private Shared ReadOnly defaultForStyle As LineStyle = LineStyle.Solid

        Public Sub New(xCoordinates As Single(), yCoordinates As Single())
            Me.xCoordinates = xCoordinates
            Me.YCoordinates = yCoordinates
            Me.fillColor = fillColor
            Me.borderColor = borderColor

            If borderWidth <= 0 Then
                Me.borderWidth = 0
            End If
            Me.borderWidth = borderWidth
            Me.borderStyle = borderStyle
        End Sub

        Public Property BorderStyle As LineStyle
            Get
                Return _borderStyle
            End Get
            Set(value As LineStyle)
                _borderStyle = value
            End Set
        End Property

        Public Property XCoordinates As Single()
            Get
                Return _xCoordinates
            End Get
            Set(value As Single())
                _xCoordinates = value
            End Set
        End Property

        Public Property YCoordinates As Single()
            Get
                Return _yCoordinates
            End Get
            Set(value As Single())
                _yCoordinates = value
            End Set
        End Property

        Public Property BorderWidth As Single
            Get
                Return _borderWidth
            End Get
            Set(value As Single)
                If value <= 0 Then
                    _borderWidth = 0
                Else
                    _borderWidth = value
                End If
            End Set
        End Property

        Public Property BorderColor As Color
            Get
                Return _borderColor
            End Get
            Set(value As Color)
                _borderColor = value
            End Set
        End Property

        Public Property FillColor As Color
            Get
                Return _fillColor
            End Get
            Set(value As Color)
                _fillColor = value
            End Set
        End Property

        Public Overrides Sub Draw(writer As PageWriter)
            writer.SetRelativeToState(MyBase.RelativeTo, MyBase.IgnoreMargins)
            Dim draw As Boolean = True
            Dim fill As Boolean, stroke As Boolean

            If borderWidth > 0 AndAlso fillColor IsNot Nothing Then
                stroke = True
                fill = True
            ElseIf borderWidth > 0 Then
                stroke = True
                fill = False
            ElseIf fillColor IsNot Nothing Then
                fill = True
                stroke = False
            Else
                stroke = False
                fill = False
                draw = False
            End If

            If BorderStyle.Equals(LineStyle.None) Then
                stroke = False
            End If

            If draw Then
                If xCoordinates.Length = yCoordinates.Length AndAlso xCoordinates.Length > 2 Then
                    writer.SetGraphicsMode()
                    If stroke AndAlso fill Then
                        writer.SetLineWidth(borderWidth)
                        writer.SetStrokeColor(borderColor)
                        writer.SetLineStyle(borderStyle)
                        writer.SetLineCap(LineCap.Butt)
                        writer.SetFillColor(fillColor)
                    ElseIf stroke Then
                        writer.SetLineWidth(borderWidth)
                        writer.SetStrokeColor(borderColor)
                        writer.SetLineStyle(borderStyle)
                        writer.SetLineCap(LineCap.Butt)
                    ElseIf fill Then
                        writer.SetFillColor(fillColor)
                    End If

                    writer.Write_m_(xCoordinates(0), yCoordinates(0))
                    For i As Integer = 1 To xCoordinates.Length - 1
                        writer.Write_l_(xCoordinates(i), yCoordinates(i))
                    Next
                    writer.Write_l_(xCoordinates(0), yCoordinates(0))
                    If fill Then
                        If stroke Then
                            writer.Write_b_()
                        Else
                            writer.Write_f()
                        End If
                    Else
                        writer.Write_s_()
                    End If
                Else
                    Throw New GeneratorException("Coordinates are wrong")
                End If
            End If
        End Sub
    End Class
End Namespace

