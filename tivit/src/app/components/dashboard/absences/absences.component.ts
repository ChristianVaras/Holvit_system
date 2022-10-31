import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormGroup, FormControl } from '@angular/forms';
import { MatCalendarCellClassFunction } from '@angular/material/datepicker';
import { range } from 'rxjs';
import { ApiService } from 'src/app/services/api.service';
import { LoginComponent } from '../../login/login.component';

interface Motivo {
  value: string;
}

@Component({
  selector: 'app-absences',
  templateUrl: './absences.component.html',
  styleUrls: ['./absences.component.scss'],
})

export class AbsencesComponent implements OnInit {
  motivos: Motivo[] = [
    {value: 'Permiso personal'},
    {value: 'Compensación'},
    {value:  'Licencia'},
  ];

  absencesForm! :  FormGroup;
  today = new Date();
  name = this.getName();

  constructor(private fb:FormBuilder, private api : ApiService) { 
    
  }

  ngOnInit(): void {
    this.absencesForm = this.fb.group({
      reason : ['', Validators.required],
      startdate : ['', Validators.required],
      enddate : ['', Validators.required],
      day : [this.today],
      comment : [''],
      username: [this.name]
    })
  }

  addAbsences() {
    if(this.absencesForm.valid){
      this.api.postAbsences(this.absencesForm.value)
      .subscribe({
        next: (res) =>{
          alert("Ausencia registrada exitosamente");
          this.absencesForm.reset();
        },
        error: () =>{
          alert("Error al ingresar ausencia")
        }
      })
    }
  }

  getName() {
    this.api.getUser().subscribe((res: any) => { 
      return res.name
    })
  }
}
