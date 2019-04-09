import { Routes, RouterModule, PreloadAllModules  } from '@angular/router';
import { ModuleWithProviders } from '@angular/core';
// import { MainComponent } from './main/main.component';
 

export const routes: Routes = [
        {
                path: '',
                loadChildren: './landing/landing.module#LandingModule'
        },
        {
                path: 'auth',
                loadChildren: './auth/auth.module#AuthenticationModule'
        },
        {
                path: 'main',
                loadChildren: './main/main.module#MainModule'
        },
        // {
        //         path: '',
        //         component: MainComponent, children: [
        //                 { path: 'dashboard', loadChildren: './main/dashboard/dashboard.module#DashboardModule'}
        //         ]

        // }
];


export const routing: ModuleWithProviders = RouterModule.forRoot(routes, {
        // preloadingStrategy: PreloadAllModules,
        // useHash: true
});
