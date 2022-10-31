import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit {
  longText = `Está registrado en el área de Sistemas de Tivit desde el 01/10/22`;
  
  constructor() { }

  ngOnInit(): void {
  }

}
