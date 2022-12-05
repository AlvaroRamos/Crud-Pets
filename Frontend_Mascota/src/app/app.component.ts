import { Component } from '@angular/core';
import { Mascota } from './models/mascota';
import { MascotaService } from './services/mascota.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Frontend_Mascota';
  mascota:Mascota = new Mascota();
  datatable:any =[];

  constructor(private mascotaService:MascotaService){
  }

  ngOnInit(){
    this.onDatatable();    
  }

  onDatatable(){
    this.mascotaService.getMascotas().subscribe(
      mascotas => {
        this.datatable = mascotas;
      }
    );
  }

  onAddMascota(mascota:Mascota):void{
    this.mascotaService.addMascota(mascota).subscribe(
      response => {
       if(response){
        alert(`La Mascota ${mascota.nombre} se ha agregado correctamente`);
        this.clear();
        this.onDatatable();
       }else{
        alert("error");
       }
      }
    );
  }
  onUpdateMascota(mascota:Mascota):void{
    this.mascotaService.updateMascota(mascota.id ,mascota).subscribe(
      response => {
       if(response){
        alert(`La Mascota ${mascota.id} se ha Actualizado correctamente`);
        this.clear();
        this.onDatatable();
       }else{
        alert("error");
       }
      }
    );
  }
  onDeleteMascota(id:number):void{
    this.mascotaService.deleteMascota(id).subscribe(
      response => {
       if(response){
        alert(`La Mascota numero ${id} se ha Eliminado correctamente`);
        this.clear();
        this.onDatatable();
       }else{
        alert("error");
       }
      }
    );
  }
  onSetData(select:any){
    this.mascota.id =select.id;
    this.mascota.nombre = select.nombre;
    this.mascota.edad = select.edad;
    this.mascota.descripcion = select.descripcion;

  }
  clear(){
    this.mascota.id = 0;
    this.mascota.nombre = '';
    this.mascota.edad = 0;
    this.mascota.descripcion = '';
  }

}
