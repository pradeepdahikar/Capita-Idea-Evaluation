import { Component, OnInit } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-idea-evaluate',
  templateUrl: './idea-evaluate.component.html',
  styleUrls: ['./idea-evaluate.component.css']
})
export class IdeaEvaluateComponent implements OnInit {

  ideas: any = null;
  userID: number = 0;

  constructor(
    private _httpClinet: HttpClient,
    private route: ActivatedRoute
  ) {

  }

  ngOnInit(): void {
    debugger;
    this.userID = this.route.snapshot.params['data'];
    this.getIdeasToEvaluate();
  }

  getIdeasToEvaluate() {
    const _headers = new HttpHeaders().set('content-type', 'application/json');
    
    let options = {
      headers: _headers
    };
    this._httpClinet.post("https://localhost:44346/api/Ideas", this.userID, options)
      .subscribe(
        data => {
          debugger;
          this.ideas = data;
        },
        error => {
          alert("Error Getting Data");
        }
      );
  }


  showAlert() {
    alert('Work in progress');
  }
}
