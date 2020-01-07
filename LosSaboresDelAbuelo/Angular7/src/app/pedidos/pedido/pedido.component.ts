import { Component, OnInit } from '@angular/core';
import { PedidoService } from 'src/app/shared/pedido.service';

@Component({
  selector: 'app-pedido',
  templateUrl: './pedido.component.html',
  styles: []
})
export class PedidoComponent implements OnInit {

  constructor(private service: PedidoService ) { }

  ngOnInit() {
  }

}
