import {AfterViewInit, Component, OnInit, ViewChild} from '@angular/core';
import {MatDialog, MatDialogRef, MatPaginator, MatSort, MatTableDataSource} from '@angular/material';
import {ToastrService} from 'ngx-toastr';
// import {AngConfirmDialogComponent} from 'src/@custor/components/confirm-dialog/confirm-dialog.component';
import {AppTranslationService} from 'src/@custor/services/translation.service';
import {Utilities} from 'src/@custor/helpers/utilities';
import {ActivatedRoute, Router} from '@angular/router';
import {ManagerListDTO} from '../models/manager.model';
import {ManagerService} from '../services/manager.service';
import {ConfigurationService} from 'src/@custor/services/configuration.service';

@Component({
  selector: 'app-manager-list',
  templateUrl: './manager-list.component.html',
  styleUrls: ['./manager-list.component.scss']
})
export class ManagerListComponent implements OnInit, AfterViewInit {


  managers: ManagerListDTO[];
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  isInvestor: boolean;
  displayedColumns = ['FullName', 'FullNameEng', 'actions'];
  dataSource: MatTableDataSource<ManagerListDTO>;

  loadingIndicator: boolean;
  // dialogRef: any;
  // confirmDialogRef: MatDialogRef<AngConfirmDialogComponent>;


  constructor(private managerService: ManagerService,
              private toastr: ToastrService,
              public dialog: MatDialog,
              private router: Router, private configService: ConfigurationService,
              private translationService: AppTranslationService,
              private route: ActivatedRoute) {

    // Assign the data to the data source for the table to render
    this.dataSource = new MatTableDataSource();
  }

  ngOnInit() {
    this.translationService.setDefaultLanguage(this.configService.language);
    this.getManagersByCustomerId();
  }


  getManagersByCustomerId() {
    const customerId = 1; // hard-coded for now
    this.loadingIndicator = true;
    this.managerService.getManagers(customerId)
      .subscribe(result => {
          console.log(result);
          this.managers = result;
          if (!this.managers) {
            this.toastr.error('No records were found to list', 'Error', {
              closeButton: true,
            });
          } else {
            this.dataSource.data = this.managers;
          }
        },
        error => {
          this.toastr.error(`Error: "${Utilities.getHttpResponseMessage(error)}"`);
        });
    this.loadingIndicator = false;
  }


  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  editManager(manager: ManagerListDTO) {
     
    if (manager) {
        this.router.navigate(['/main/customer/manager/', manager.ManagerId], {relativeTo: this.route});
      } else {
        this.router.navigate(['/main/customer/manager', 0]);
      }
  }

  confirmDelete(manager: ManagerListDTO) {
    // this.confirmDialogRef = this.dialog.open(AngConfirmDialogComponent,
    //   {
    //     disableClose: false
    //   });

    // this.confirmDialogRef.componentInstance.confirmMessage = 'Are you sure you want to delete?';
    // this.confirmDialogRef.afterClosed().subscribe(result => {
    //   this.loadingIndicator = true;
    //   if (result) {
    //     this.managerService.delete(manager.AssociateId)
    //       .subscribe(results => {
    //           this.loadingIndicator = false;
    //           this.dataSource.data = this.dataSource.data.filter(item => item !== manager);
    //         },
    //         error => {
    //           // tslint:disable-next-line:max-line-length
    //           this.toastr.error(
    //             `An error occured whilst deleting the manager.\r\nError: "${Utilities.getHttpResponseMessage(error)}"`,
    //             'Delete Error');
    //         });
    //   }
    //   this.loadingIndicator = false;
    // });
  }


  deleteProject(id: number) {
    // console.log(id);
    const response = confirm('Do you want to Delete this Project ?');
    if (response === true) {
      this.managerService.deleteManager(id)
        .subscribe(() => {
        });
      return true;
    } else {
      return false;
    }
  }

}
