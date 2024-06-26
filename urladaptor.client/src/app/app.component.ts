import { Component, ViewChild } from '@angular/core';
import { DataManager, UrlAdaptor } from '@syncfusion/ej2-data';
import { GridComponent, EditSettingsModel, ToolbarItems } from '@syncfusion/ej2-angular-grids';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
})
export class AppComponent {
  public data?: DataManager;

  @ViewChild('grid')
  public grid?: GridComponent;
  public editSettings?: EditSettingsModel;
  public toolbar?: ToolbarItems[];

  ngOnInit(): void {
    this.data = new DataManager({
      url: 'https://localhost:7018/api/grid', // Replace your hosted link
      insertUrl: 'https://localhost:7018/api/grid/Insert', 
      updateUrl: 'https://localhost:7018/api/grid/Update',
      removeUrl: 'https://localhost:7018/api/grid/Remove',
      //crudUrl:'https://localhost:7018/api/grid/CrudUpdate', // perform all CRUD action at single request using crudURL
      //batchUrl:'https://localhost:7018/api/grid/BatchUpdate', // perform CRUD action using batchURL when enabling batch editing
      adaptor: new UrlAdaptor()
    });
    this.toolbar = ['Add', 'Update', 'Delete', 'Cancel', 'Search'];
    this.editSettings = { allowAdding: true, allowDeleting: true, allowEditing: true, mode: 'Normal' };
  }
}
