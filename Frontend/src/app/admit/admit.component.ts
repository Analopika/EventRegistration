import { Component, ViewChild } from '@angular/core';
import { RegistrationService } from '../_services/registration.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-admit',
  templateUrl: './admit.component.html',
  styleUrls: ['./admit.component.css']
})
export class AdmitComponent {
  model: any = {}
  text: any = {}
  @ViewChild('popupTemplate') popupTemplate:any;
  constructor(private registrationService:RegistrationService, private NgbModal:NgbModal){}

  ngOnInit(){

  }

  admit(content: any){
    this.registrationService.admit(this.model).subscribe({
      next: response => {
        console.log(response);
        this.text = response;
        this.openPopUp(content);
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
