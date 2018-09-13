import { Component, OnInit } from '@angular/core';
import {CompanyService} from '../Shared/company.service';
import {Company} from '../Shared/company.model';
import {ToastrService} from 'ngx-toastr';
@Component({
  selector: 'app-company-list',
  templateUrl: './company-list.component.html',
  styleUrls: ['./company-list.component.css']
})
export class CompanyListComponent implements OnInit {

  constructor(private companyService:CompanyService,private toastr : ToastrService) { }

  ngOnInit() {
    this.companyService.getCompanyList();
  }
  showForEdit(cmp: Company) {
    this.companyService.selectedCompany = Object.assign({}, cmp);;
  }
 
 
  onDelete(id: number) {
    if (confirm('Are you sure to delete this record ?') == true) {
      this.companyService.deleteCompany(id)
      .subscribe(x => {
        this.companyService.getCompanyList();
        this.toastr.warning("Deleted Successfully","Employee Register");
      })
    }
  }
  addPortfolio(cmp:Company){

  }

}
