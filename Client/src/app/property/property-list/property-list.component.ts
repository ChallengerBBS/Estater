import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-property-list',
  templateUrl: './property-list.component.html',
  styleUrls: ['./property-list.component.css']
})
export class PropertyListComponent implements OnInit {
  properties : Array<any>=[
    {
    "Id":1,
    "Name":"Birla house",
    "Type":"House",
    "Price":34000
    },
    {
      "Id":2,
      "Name":"Montreal",
      "Type":"House",
      "Price":55000
    },
    {
        "Id":3,
        "Name":"Macro Home",
        "Type":"House",
        "Price":25000
    },
    {
      "Id":4,
      "Name":"Sunrise Mansion",
      "Type":"Mansion",
      "Price":150000
    }
  ]

  constructor() { }

  ngOnInit(): void {
  }

}
