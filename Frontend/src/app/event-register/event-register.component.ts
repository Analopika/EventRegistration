import { Component, ViewChild } from '@angular/core';
import { RegistrationService } from '../_services/registration.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-event-register',
  templateUrl: './event-register.component.html',
  styleUrls: ['./event-register.component.css']
})
export class EventRegisterComponent {
  model: any = {}
  code: any = {}
  @ViewChild('popupTemplate') popupTemplate:any;
  constructor(private registrationService:RegistrationService, private NgbModal:NgbModal){}

  ngOnInit(){

  }

  register(content: any){
    this.registrationService.register(this.model).subscribe({
      next: response => {
        console.log(response)
        this.code = response.code
        this.openPopUp(content)
    },
    error: error => {
      console.log(error);
    }
    })
  }

  openPopUp(content:any){
    this.NgbModal.open(content);
  }

  closePopup(){
    this.NgbModal.dismissAll();
    this.resetForm();
  }

  resetForm() {
    this.model.email = '';
  }
}
