﻿'------------------------------------------------------------------------------
' <auto-generated>
'     Este código se generó a partir de una plantilla.
'
'     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
'     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure

Namespace LosSaboresDelAbuelo

    Partial Public Class LosSaboresDelAbueloEntities
        Inherits DbContext
    
        Public Sub New()
            MyBase.New("name=LosSaboresDelAbueloEntities")
        End Sub
    
        Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
            Throw New UnintentionalCodeFirstException()
        End Sub
    
        Public Overridable Property cliente() As DbSet(Of cliente)
        Public Overridable Property pedido() As DbSet(Of pedido)
        Public Overridable Property pedidoDetalle() As DbSet(Of pedidoDetalle)
        Public Overridable Property producto() As DbSet(Of producto)
    
    End Class

End Namespace
