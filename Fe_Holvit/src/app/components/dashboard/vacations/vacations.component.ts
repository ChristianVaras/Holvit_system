import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';
import { ApiService } from 'src/app/services/api.service';
import { ResRequest } from 'src/app/interfaces/users';

@Component({
  selector: 'app-vacations',
  templateUrl: './vacations.component.html',
  styleUrls: ['./vacations.component.scss'], 
})
export class VacationsComponent implements OnInit {

  vacationsForm!: FormGroup;
  today = new Date();

  constructor(private fb:FormBuilder, private api : ApiService) {
  }

  ngOnInit(): void {
    this.vacationsForm = this.fb.group({
      reason : "Vacaciones",
      startdate : ['', Validators.required],
      enddate : ['', Validators.required],
      comment : ['', Validators.required],
      day : [this.today],
      state : 0
    })

    
    this.api.getUser().subscribe( res => {
      console.log(res.data[0].name);
    }) 
  }
  
  // date1 : any;
  // date2 : any;
  
  // days : any;

  // calculateDays() {
  //   const startModified = new Date(this.date1);
  //   const endModified = new Date(this.date1);
    
  //   const time = startModified.getTime() - endModified.getTime();
  //   time / (1000 * 3600 * 24)
  // }

  addVacations() {
    if(this.vacationsForm.valid){
      this.api.postAbsences(this.vacationsForm.value)
      .subscribe({
        next: (res) =>{
          alert("Vacaciones registradas exitosamente");
          this.vacationsForm.reset();
        },
        error: () =>{
          alert("Error al ingresar vacaciones")
        }
      })
    }
  }
}

