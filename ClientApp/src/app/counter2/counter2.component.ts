import { Component } from '@angular/core';

@Component({
  selector: 'app-counter-component',
  templateUrl: './counter2.component.html'
})
export class Counter2Component {
  public currentCount = 0;

  public incrementCounter() {
    this.currentCount++;
  }
}
