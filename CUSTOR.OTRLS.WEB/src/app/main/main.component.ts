import { Component, ChangeDetectorRef, ViewChild, ViewEncapsulation, OnInit, OnDestroy, ElementRef } from '@angular/core';
import { MediaMatcher } from '@angular/cdk/layout';
import { Router, NavigationStart } from '@angular/router';
import { MatExpansionPanel, MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
// import { CommonModule } from '@angular/common';  
import { AppTranslationService } from 'src/@custor/services/translation.service';
import { AccountService } from 'src/@custor/services/security/account.service';
import { LocalStoreManager } from 'src/@custor/services/storeManager.service';
// import { AppTitleService } from 'src/@custor/services/app-title.service';
import { AuthService } from 'src/@custor/services/security/auth.service';
import { ConfigurationService } from 'src/@custor/services/configuration.service';
import { Permission } from 'src/@custor/models/permission.model';

@Component({
    selector: 'app-main',
    templateUrl: './main.component.html',
    styleUrls: ['./main.component.scss']
})
export class MainComponent implements OnInit, OnDestroy {
    @ViewChild('admin') adminExpander: MatExpansionPanel;

    private _mobileQueryListener: () => void;
    isAppLoaded: boolean;
    isUserLoggedIn: boolean;
    isAdminExpanded = false;
    removePrebootScreen: boolean;
    newNotificationCount = 0;
    appTitle = 'OTRLS';
    appLogo = '';

    mobileQuery: MediaQueryList;

    constructor(storageManager: LocalStoreManager,
                private accountService: AccountService,
                private authService: AuthService,
                private translationService: AppTranslationService,
                public configurations: ConfigurationService,
                public router: Router,
                changeDetectorRef: ChangeDetectorRef,
                media: MediaMatcher) {
        this.mobileQuery = media.matchMedia('(max-width: 600px)');
        this._mobileQueryListener = () => changeDetectorRef.detectChanges();
        this.mobileQuery.addListener(this._mobileQueryListener);
       
        this.translationService.addLanguages(['en', 'et']);
        this.translationService.setDefaultLanguage('en');
    }

    ngOnInit() {
        this.isUserLoggedIn = true; // this.authService.isLoggedIn;
        this.router.events.subscribe(event => {
            if (event instanceof NavigationStart) {
                const url = (event as NavigationStart).url;

                if (url !== url.toLowerCase()) {
                    this.router.navigateByUrl((event as NavigationStart).url.toLowerCase());
                }

                if (this.adminExpander && url.indexOf('admin') > 0) {
                    this.adminExpander.open();
                }
            }
        });
    }

    ngOnDestroy() {
        this.mobileQuery.removeListener(this._mobileQueryListener);
    }


    logout() {
        this.authService.logout();
        this.authService.redirectLogoutUser();
    }

    get userName(): string {
        return this.authService.currentUser ? this.authService.currentUser.UserName : '';
    }

    get fullName(): string {
        return this.authService.currentUser ? this.authService.currentUser.FullName : '';
    }

    get canViewCustomers() {
        return this.accountService.userHasPermission(Permission.viewUsersPermission);
    }

    get canViewProducts() {
        return this.accountService.userHasPermission(Permission.viewUsersPermission);
    }

    get canViewOrders() {
        return true;
    }

    get canViewUsers() {
        return this.accountService.userHasPermission(Permission.viewUsersPermission);
    }

    get canViewRoles() {
        return this.accountService.userHasPermission(Permission.viewRolesPermission);
    }
}
