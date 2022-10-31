import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

//Modules
import { ReactiveFormsModule } from '@angular/forms';

//Angular
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatIconModule } from '@angular/material/icon';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatMomentDateModule } from '@angular/material-moment-adapter';
import { MatCardModule } from '@angular/material/card';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatStepperModule } from '@angular/material/stepper';
import { MatSelectModule } from '@angular/material/select';
import { MatTableModule } from '@angular/material/table';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatCheckboxModule } from '@angular/material/checkbox';

@NgModule({
    declarations: [],
    imports: [
        CommonModule,
        MatFormFieldModule,
        MatInputModule,
        MatButtonModule,
        ReactiveFormsModule,
        MatSnackBarModule,
        MatProgressSpinnerModule,
        MatSidenavModule,
        MatIconModule,
        MatDatepickerModule,
        MatCardModule,
        MatGridListModule,
        MatMomentDateModule,
        MatStepperModule,
        MatSelectModule,
        MatTableModule,
        MatTooltipModule,
        MatPaginatorModule,
        MatCheckboxModule
    ],
    exports: [
        CommonModule,
        MatFormFieldModule,
        MatInputModule,
        MatButtonModule,
        ReactiveFormsModule,
        MatSnackBarModule,
        MatProgressSpinnerModule,
        MatSidenavModule,
        MatIconModule,
        MatDatepickerModule,
        MatCardModule,
        MatGridListModule,
        MatMomentDateModule,
        MatStepperModule,
        MatSelectModule,
        MatTableModule,
        MatTooltipModule,
        MatPaginatorModule,
        MatCheckboxModule
    ]
})
export class SharedModule {}