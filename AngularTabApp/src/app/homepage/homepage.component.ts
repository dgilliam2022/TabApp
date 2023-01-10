import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { TabappLogicService } from '../Services/tabapp-logic.service';
import { Entries } from '../Models/Entries';

@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.css']
})
export class HomepageComponent implements OnInit {

  constructor(private tablogic: TabappLogicService, private router: Router) { }

  //showEntries!:Promise<boolean>;
  entries : Entries[] = [];

  viewEntries() : void 
  {
      this.tablogic.getAllEntries().subscribe((res) => 
      {
        this.entries = res;
        //this.showEntries=Promise.resolve(true);
      })
  }

  ngOnInit(): void {
  }

}
