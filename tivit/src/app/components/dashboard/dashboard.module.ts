import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DashboardRoutingModule } from './dashboard-routing.module';
import { SharedModule } from '../shared/shared.module';

//Components
import { HomeComponent } from './home/home.component';
import { NavbarComponent } from './navbar/navbar.component';
import { ProfileComponent } from './profile/profile.component';
import { VacationsComponent } from './vacations/vacations.component';
import { DashboardComponent } from './dashboard.component';
import { AbsencesComponent } from './absences/absences.component';
import { ReviewsComponent } from './reviews/reviews.component';


@NgModule({
  declarations: [
    DashboardComponent,
    HomeComponent,
    NavbarComponent,
    ProfileComponent,
    VacationsComponent,
    AbsencesComponent,
    ReviewsComponent,
  ],
  imports: [
    CommonModule,
    DashboardRoutingModule,
    SharedModule,
  ]
})
export class DashboardModule { }
