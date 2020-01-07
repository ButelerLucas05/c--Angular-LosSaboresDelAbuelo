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
    Public Class productoController
        Inherits System.Web.Http.ApiController

        Private db As New LosSaboresDelAbueloEntities

        ' GET: api/producto
        Function Getproducto() As IQueryable(Of producto)
            Return db.producto
        End Function

        ' GET: api/producto/5
        <ResponseType(GetType(producto))>
        Function Getproducto(ByVal id As Integer) As IHttpActionResult
            Dim producto As producto = db.producto.Find(id)
            If IsNothing(producto) Then
                Return NotFound()
            End If

            Return Ok(producto)
        End Function

        ' PUT: api/producto/5
        <ResponseType(GetType(Void))>
        Function Putproducto(ByVal id As Integer, ByVal producto As producto) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            If Not id = producto.IdProducto Then
                Return BadRequest()
            End If

            db.Entry(producto).State = EntityState.Modified

            Try
                db.SaveChanges()
            Catch ex As DbUpdateConcurrencyException
                If Not (productoExists(id)) Then
                    Return NotFound()
                Else
                    Throw
                End If
            End Try

            Return StatusCode(HttpStatusCode.NoContent)
        End Function

        ' POST: api/producto
        <ResponseType(GetType(producto))>
        Function Postproducto(ByVal producto As producto) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            db.producto.Add(producto)
            db.SaveChanges()

            Return CreatedAtRoute("DefaultApi", New With {.id = producto.IdProducto}, producto)
        End Function

        ' DELETE: api/producto/5
        <ResponseType(GetType(producto))>
        Function Deleteproducto(ByVal id As Integer) As IHttpActionResult
            Dim producto As producto = db.producto.Find(id)
            If IsNothing(producto) Then
                Return NotFound()
            End If

            db.producto.Remove(producto)
            db.SaveChanges()

            Return Ok(producto)
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Function productoExists(ByVal id As Integer) As Boolean
            Return db.producto.Count(Function(e) e.IdProducto = id) > 0
        End Function
    End Class
End Namespace