import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { IPropertyBase } from '../model/ipropertybase';
import { Property } from '../model/property';

@Injectable({
  providedIn: 'root'
})
export class HousingService {

  constructor(private http: HttpClient) { }

  getAllProperties(SellRent: number): Observable<IPropertyBase[]> {
    return this.http.get('data/properties.json').pipe(
      map(data => {
      const propertiesArray: Array<IPropertyBase> = [];
      const localProperties = JSON.parse(localStorage.getItem('newProperty'));

      if (localProperties) {
        for (const id in localProperties) {
          if (localProperties.hasOwnProperty(id) && localProperties[id].SellRent === SellRent) {
            propertiesArray.push(localProperties[id]);
          }
        }
      }

      for (const id in data) {
        if (data.hasOwnProperty(id) && data[id].SellRent === SellRent) {
          propertiesArray.push(data[id]);
        }
      }
      return propertiesArray;
      })
    );
  }
  addProperty(property: Property) {
    let newProperty = [property];

    // Add new property in array if newProperty alreay exists in local storage
    if (localStorage.getItem('newProperty')) {
      newProperty = [property, ...JSON.parse(localStorage.getItem('newProperty'))];
    }

    localStorage.setItem('newProperty', JSON.stringify(newProperty));
  }

  newPropertyID() {
    if (localStorage.getItem('PID')) {
      localStorage.setItem('PID', String(parseInt(localStorage.getItem('PID')) + 1));
      return parseInt(localStorage.getItem('PID'));
    } else {
      localStorage.setItem('PID', '101');
      return 101;
    }
  }
}
