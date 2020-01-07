import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PedidosComponent } from './pedidos/pedidos.component';
import { PedidoComponent } from './pedidos/pedido/pedido.component';
import { PedidoProductosComponent } from './pedidos/pedido-productos/pedido-productos.component';
import { PedidoService } from './shared/pedido.service';

@NgModule({
  declarations: [
    AppComponent,
    PedidosComponent,
    PedidoComponent,
    PedidoProductosComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [PedidoService],
  bootstrap: [AppComponent]
})
export class AppModule { }
