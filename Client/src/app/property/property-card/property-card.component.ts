import { Input } from '@angular/core';
import { IProperty } from '../../model/IProperty';
import { Component, OnInit } from '@angular/core';


@Component({
  selector: 'app-property-card',
  templateUrl: './property-card.component.html',
  styleUrls: ['./property-card.component.scss']
})

export class PropertyCardComponent{
  @Input() property : IProperty;
  @Input() hideIcons: boolean;
  }
