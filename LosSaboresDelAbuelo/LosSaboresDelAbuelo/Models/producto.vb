'------------------------------------------------------------------------------
' <auto-generated>
'     Este código se generó a partir de una plantilla.
'
'     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
'     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Collections.Generic

Namespace LosSaboresDelAbuelo

    Partial Public Class producto
        Public Property IdProducto As Integer
        Public Property NombreProducto As String
        Public Property Precio As Decimal
    
        Public Overridable Property pedidoDetalle As ICollection(Of pedidoDetalle) = New HashSet(Of pedidoDetalle)
    
    End Class

End Namespace
