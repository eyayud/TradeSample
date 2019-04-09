import { NgModule } from '@angular/core';
// import { ContentHeaderComponent } from '../components/form-header/content-header.component';
import { RouterModule } from '@angular/router';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import {
    // MatAutocompleteModule,
    // MatButtonModule,
    // MatButtonToggleModule,
    // MatCardModule,
    // MatCheckboxModule,
    // MatChipsModule,
    // MatDatepickerModule,
    // MatDialogModule,
    MatExpansionModule,
    // MatGridListModule,
    MatIconModule,
    // MatInputModule,
    MatListModule,
    MatMenuModule,
    // MatNativeDateModule,
    // MatPaginatorModule,
    // MatProgressBarModule,
    // MatProgressSpinnerModule,
    // MatRadioModule,
    // MatRippleModule,
    MatSelectModule,
    MatSidenavModule,
    // MatSliderModule,
    // MatSlideToggleModule,
    // MatSnackBarModule,
    // MatSortModule,
    // MatTableModule,
    // MatTabsModule,
    MatToolbarModule,
    MatTooltipModule,
    // MatStepperModule
   
} from '@angular/material';

@NgModule({
    imports: [
        MatExpansionModule,
        MatIconModule,
        MatMenuModule,
        // MatSelectModule,
        MatSidenavModule,
        MatToolbarModule,
        MatTooltipModule,
        MatListModule,
        RouterModule,
        FormsModule,
        ReactiveFormsModule,
        CommonModule
    ],
    exports: [
        MatExpansionModule,
        MatIconModule,
        MatMenuModule,
        // MatSelectModule,
        MatSidenavModule,
        MatToolbarModule,
        MatTooltipModule,
        MatListModule,
        // ContentHeaderComponent
    ],
    declarations: [
        // ContentHeaderComponent
    ]
})
export class SharedMinModule { }
