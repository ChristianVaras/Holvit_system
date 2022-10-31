import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
// import { Pedido } from 'src/app/interfaces/pedidos';
import { ApiService } from 'src/app/services/api.service';


// const ELEMENT_DATA: Pedido[] = [
//   {id: 1, nombre: 'Juan Varillas', fecha: 100722, motivo: 'Compensación', acciones: false},
//   {id: 2, nombre: 'Paula Espinoza', fecha: 140722, motivo: 'Licencia', acciones: false},
// ];


@Component({
  selector: 'app-reviews',
  templateUrl: './reviews.component.html',
  styleUrls: ['./reviews.component.scss']
})
export class ReviewsComponent implements OnInit {
   //(ELEMENT_DATA);
  displayedColumns: string[] = [  'id', 'nombre', 'fecha', 'motivo', 'estado', 'acciones' ];
  dataSource! : MatTableDataSource<any>; 
  checked = false;
  indeterminate = false;
  labelPosition: 'before' | 'after' = 'after';
  disabled = false;

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(private api: ApiService) { 
  }

  ngOnInit(): void {
    this.getReviewsAbsences();
  }

  // ngAfterViewInit() {
  //   this.dataSource.paginator = this.paginator;
  //   this.paginator._intl.itemsPerPageLabel = 'Items por página';
  // }

  getReviewsAbsences() {
    this.api.getAbsences()
    .subscribe({
      next: (res) => {
        this.dataSource = new MatTableDataSource(res);
        this.dataSource.paginator = this.paginator;
        this.paginator._intl.itemsPerPageLabel = 'Items por página';
      },
      error: (err)=>{
        alert("Error al insertar datos");
      }
    })
  }
}
