import { Component, OnInit } from '@angular/core';
import {CompanyService} from '../Shared/company.service';
import {NgForm} from '@angular/forms';
import {ToastrService} from 'ngx-toastr';
@Component({
  selector: 'app-company',
  templateUrl: './company.component.html',
  styleUrls: ['./company.component.css']
})
export class CompanyComponent implements OnInit {

  constructor(private companyService:CompanyService ,private toastr: ToastrService) { }

  ngOnInit() {
    this.resetForm();
  }
  resetForm(form?:NgForm)
  {
    if(form ! = null)
    form.reset();
    this.companyService.selectedCompany ={
      CompanyID:null,
      CompanyName:'',
      CompanyAddress:'',
      CompanyEmail:'',
      CompanyPhoneNo:null,
      CompanyContactPerson:''
      
    }
  }
 
  onSubmit(form: NgForm) {
    console.log(form)
    if (form.value.CompanyID == null) {
      this.companyService.postCompany(form.value)
        .subscribe(data => {
          console.log(data)
          this.resetForm(form);
          this.companyService.getCompanyList();
          this.toastr.success('New Record Added Succcessfully', 'Employee Register');
        })
    }
    else {
      this.companyService.putCompany(form.value.CompanyID, form.value)
      .subscribe(data => {
        this.resetForm(form);
        this.companyService.getCompanyList();
        this.toastr.info('Record Updated Successfully!', 'Employee Register');
      });
    }
  }
  

}
