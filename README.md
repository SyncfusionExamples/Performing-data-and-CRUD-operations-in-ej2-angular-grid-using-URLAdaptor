# Syncfusion EJ2 Angular Grid — URLAdaptor CRUD (Angular + ASP.NET Core)

## Repository Description
A practical demonstration of implementing the Syncfusion EJ2 Angular Grid component in an Angular frontend using the URLAdaptor to perform server-driven paging, sorting, filtering and full CRUD operations backed by an ASP.NET Core server.

## Overview
This repository contains two projects:
- `urladaptor.client`: Angular front-end showcasing an EJ2 Grid wired to server endpoints via the URLAdaptor.
- `UrlAdaptor.Server`: ASP.NET Core back-end that exposes CRUD and data-query endpoints consumed by the grid.

## Features
- Syncfusion EJ2 Grid integration with URLAdaptor
- Server-side paging, sorting, searching and filtering
- Full CRUD endpoints (Insert, Update, Remove, BatchUpdate, CrudUpdate)
- Example dataset and a simple in-memory model (`OrdersDetails`)

## Project Prerequisites
- Node.js (LTS recommended)
- npm (comes with Node.js)
- .NET SDK 8.0 or compatible installed
- Basic knowledge of Angular and ASP.NET Core

## Installation
Clone the repository and install dependencies for both projects:

```bash
git clone https://github.com/SyncfusionExamples/Performing-data-and-CRUD-operations-in-ej2-angular-grid-using-URLAdaptor.git
cd Performing-data-and-CRUD-operations-in-ej2-angular-grid-using-URLAdaptor

# Install server dependencies (if any) and restore dotnet packages
cd UrlAdaptor.Server
dotnet restore
cd ..

# Install client dependencies
cd urladaptor.client
npm install
```

## Running the Application (Development)
Start the ASP.NET Core server and the Angular client in separate terminals.

Server (API):

```bash
cd UrlAdaptor.Server
dotnet run
```

Client (Angular):

```bash
cd urladaptor.client
ng serve
# the dev server typically runs at http://localhost:4200/
```

## Examples & References
- Syncfusion Grid - remote data examples:
  - https://ej2.syncfusion.com/angular/demos/#/material/grid/remote-data
  - URLAdaptor docs: https://ej2.syncfusion.com/documentation/data/adaptors/#url-adaptor

---

