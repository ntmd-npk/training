import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
@Component({
  selector: 'app-grid-table',
  templateUrl: './grid-table.component.html',
  styleUrls: ['./grid-table.component.scss']
})
export class GridTableComponent implements OnInit
{
  @Input() title: string | undefined;
  @Input() dataSource = [];
  
  @Output() dataSourceChange = new EventEmitter();

  constructor() { }

  ngOnInit(): void
  {
  }

}
