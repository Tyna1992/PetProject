import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { WebshopComponent } from './webshop/webshop.component';
import { WinetastingComponent } from './winetasting/winetasting.component';
import { AboutComponent } from './about/about.component';
import { ContactComponent } from './contact/contact.component';
import { CheckoutComponent } from './checkout/checkout.component';
import { AdminComponent } from './admin/admin.component';
import { ProfileComponent } from './profile/profile.component';
import { OrderComponent } from './order/order.component';

export const routes: Routes = [
    {path: "", component: HomeComponent},
    {path: "register", component: RegisterComponent},
    {path: "login", component: LoginComponent},
    {path: "webshop", component: WebshopComponent},
    {path: "winetasting", component: WinetastingComponent},
    {path: "about", component: AboutComponent},
    {path: "contact", component: ContactComponent},
    {path: "checkout", component: CheckoutComponent},
    {path: "admin", component: AdminComponent},
    {path: "profile", component: ProfileComponent},
    {path: "order", component: OrderComponent}
];
