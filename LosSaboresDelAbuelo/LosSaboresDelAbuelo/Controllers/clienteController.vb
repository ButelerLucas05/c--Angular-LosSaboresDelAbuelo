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
    Public Class clienteController
        Inherits System.Web.Http.ApiController

        Private db As New LosSaboresDelAbueloEntities

        ' GET: api/cliente
        Function Getcliente() As IQueryable(Of cliente)
            Return db.cliente
        End Function

        ' GET: api/cliente/5
        <ResponseType(GetType(cliente))>
        Function Getcliente(ByVal id As Integer) As IHttpActionResult
            Dim cliente As cliente = db.cliente.Find(id)
            If IsNothing(cliente) Then
                Return NotFound()
            End If

            Return Ok(cliente)
        End Function

        ' PUT: api/cliente/5
        <ResponseType(GetType(Void))>
        Function Putcliente(ByVal id As Integer, ByVal cliente As cliente) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            If Not id = cliente.IdCliente Then
                Return BadRequest()
            End If

            db.Entry(cliente).State = EntityState.Modified

            Try
                db.SaveChanges()
            Catch ex As DbUpdateConcurrencyException
                If Not (clienteExists(id)) Then
                    Return NotFound()
                Else
                    Throw
                End If
            End Try

            Return StatusCode(HttpStatusCode.NoContent)
        End Function

        ' POST: api/cliente
        <ResponseType(GetType(cliente))>
        Function Postcliente(ByVal cliente As cliente) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            db.cliente.Add(cliente)
            db.SaveChanges()

            Return CreatedAtRoute("DefaultApi", New With {.id = cliente.IdCliente}, cliente)
        End Function

        ' DELETE: api/cliente/5
        <ResponseType(GetType(cliente))>
        Function Deletecliente(ByVal id As Integer) As IHttpActionResult
            Dim cliente As cliente = db.cliente.Find(id)
            If IsNothing(cliente) Then
                Return NotFound()
            End If

            db.cliente.Remove(cliente)
            db.SaveChanges()

            Return Ok(cliente)
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Function clienteExists(ByVal id As Integer) As Boolean
            Return db.cliente.Count(Function(e) e.IdCliente = id) > 0
        End Function
    End Class
End Namespace