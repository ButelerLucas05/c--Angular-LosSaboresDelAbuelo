Imports System.Data
Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure
Imports System.Linq
Imports System.Net
Imports System.Net.Http
Imports System.Web.Http
Imports System.Web.Http.Description
Imports LosSaboresDelAbuelo.LosSaboresDelAbuelo

Namespace Controllers
    Public Class pedidoController
        Inherits System.Web.Http.ApiController

        Private db As New LosSaboresDelAbueloEntities

        ' GET: api/pedido
        Function Getpedido() As IQueryable(Of pedido)
            Return db.pedido
        End Function

        ' GET: api/pedido/5
        <ResponseType(GetType(pedido))>
        Function Getpedido(ByVal id As Long) As IHttpActionResult
            Dim pedido As pedido = db.pedido.Find(id)
            If IsNothing(pedido) Then
                Return NotFound()
            End If

            Return Ok(pedido)
        End Function

        ' PUT: api/pedido/5
        <ResponseType(GetType(Void))>
        Function Putpedido(ByVal id As Long, ByVal pedido As pedido) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            If Not id = pedido.IdPedido Then
                Return BadRequest()
            End If

            db.Entry(pedido).State = EntityState.Modified

            Try
                db.SaveChanges()
            Catch ex As DbUpdateConcurrencyException
                If Not (pedidoExists(id)) Then
                    Return NotFound()
                Else
                    Throw
                End If
            End Try

            Return StatusCode(HttpStatusCode.NoContent)
        End Function

        ' POST: api/pedido
        <ResponseType(GetType(pedido))>
        Function Postpedido(ByVal pedido As pedido) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            db.pedido.Add(pedido)
            db.SaveChanges()

            Return CreatedAtRoute("DefaultApi", New With {.id = pedido.IdPedido}, pedido)
        End Function

        ' DELETE: api/pedido/5
        <ResponseType(GetType(pedido))>
        Function Deletepedido(ByVal id As Long) As IHttpActionResult
            Dim pedido As pedido = db.pedido.Find(id)
            If IsNothing(pedido) Then
                Return NotFound()
            End If

            db.pedido.Remove(pedido)
            db.SaveChanges()

            Return Ok(pedido)
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Function pedidoExists(ByVal id As Long) As Boolean
            Return db.pedido.Count(Function(e) e.IdPedido = id) > 0
        End Function
    End Class
End Namespace