import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './person.component.html',
})
export class PersonComponent {
  formData = { firstName: '', lastName: '' };
  response: string = "";

  constructor(private httpClient: HttpClient) {}

  onSubmit() {
    this.httpClient.post('http://localhost:5000/api/save', this.formData).subscribe(
      (response) => {
        this.response = 'Data saved successfully!';
      },
      (error) => {
        this.response = 'Error saving data';
      }
    );
  }
}