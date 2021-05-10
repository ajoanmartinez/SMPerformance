# SMPerformance
---

An MVC.NET Web application to enable capture of key metrics of all of a single organization’s scrum teams’ performance on a quarterly basis, tracking and modifying scrum teams, scrum masters, and multiple evaluations associated with them, so that it can be utilized as a dashboard to measure the effectiveness and performance of  a team’s assigned Scrum Master over multiple quarters.

## How To Use
To use SMPerformance, clone the repository, open it in Visual Studio, and run (IIS Express). This will pull up a web page that will allow you to navigate to any of the index views for Scrum Teams, Scrum Masters, or Team Metrics . Each index view is set up with intuitive action links that will assist users with navigating through the application, and can be used as a reference for future code enhancements.

---
# TeamMetric

int EvalId [PK] | int TeamId [FK] | int ScrumMasterId [FK] | enum (Quarter) FiscaQuarter [FK] |v double BurnUp  [FK] | int Velocity | double ProdSupport | int CustomerRating | int Trust Rating | Enum (PerformanceRating) RatingOfPerformance |
--- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
0001 | 0001 | 0001 | Q1 | 87.5 | 25 | 87.5 | 1 | 1 | ExceedsExpectations


ScrumMaster (nav Property) | ScrumTeam (nav Property) |OwnerId (Guid Property
--- | --- | --- |
ScrumMaster with id 0001 | ScrumTEam with id 0001 | c505e753-6e5d-4eb7-bed6-df86f07d46f1

`EvalId` is the Primary Key, and as such is not specified during TeamMetric creation. The evaluation is created with  `TeamId`, `ScrumMasterId`, `Fiscalyear`, `FiscalQuarter`, `BurnUp`, `Velocity`, `ProductionSupport`, `CustomerRating`, `TrustRating`, and `PerformanceRating`, where data annotations are used to display data types with spaces between words, and “Scrum Master Name” and “Scrum Team Name” are displayed for `ScrumMasterId` and  `TeamId`, respectively, to the user. The `ScrumMasterId` and `TeamId` are associated with their Navigation Properties, held only as reference to the other tables in the database. TeamMetrics has a many-to-one relationship with both ScrumMaster and ScrumTeam

### TeamMetric URLs and Logic
---
**GET All GET** 
`http://website.com/TeamMetric/Index/` This returns the list of all Evaluations, where concatenated properties `FirstName` and `LastName` from ScrumMaster are passed to the view for  `ScrumMasterId`. 

**GET All By ScrumMaserId GET** 
`http://website.com/TeamMetric/ScrumMasterIndex?scrumMasterId={id}/` This returns the list of evaluations whose `scrumMasterId` matches `id` when selecting the Scrum Master’s name action link from the TeamMetric Index view

**GET All By TeamID GET** 
`http://website.com/TeamMetric/ScrumTeamIndex?teamId={id}/` This returns the list of all evaluations whose `teamId` matches `id` when selecting the Scrum Team’s name action link from the TeamMetric Index view

**GET By EvalId GET** `http://website.com/TeamMetric/Details/{id}/`
This returns the one evaluation whose EvalId matches id when selecting the Details action link from the Index, ScrumMasterIndex, or ScrumTeamIndex views.

**GET New Evaluation CREATE**
`http://website.com/TeamMetric/Create/` This returns the view to the user to input the data that will be interpreted and packaged up by the controller as a model, and then sent to the service layer that will save the new evaluation to the database. The fields required are: `TeamId`, `ScrumMasterId`, `Fiscalyear`, `FiscalQuarter`, `BurnUp`, `Velocity`, `ProdSupport`, `CustomerRating`, `TrustRating`, and `PerformanceRating`. Of those, the properties, `ScrumMasterID`, `TeamId`, `FiscalQuarter`, and `PerformanceRating` are presented to the user in the Create View for TeamMetric as a dropdown list that utilizes ViewBag to query database to present the list of options to the user to select for `ScrumMasterID` and `TeamId`, and where ViewBag is used to get the enum values and present to user as list to select from for `FiscalQuarter` and `PerformanceRating`.

**GET Evaluation EDIT**
`http://website.com/TeamMetric/Edit/{id}/`This returns the view to the user to input the data that will be interpreted and packaged up by the controller as a model, and then sent to the service layer that will save the updated evaluation to the database where `EvalId` matches `id`. The fields required are: `TeamId`, `ScrumMasterId`, `Fiscalyear`, `FiscalQuarter`, `BurnUp`, `Velocity`, `ProdSupport`, `CustomerRating`, `TrustRating`, and `PerformanceRating`. Of those, the properties, `ScrumMasterID`, `TeamId`, `FiscalQuarter`, and `PerformanceRating` are presented to the user as a dropdown list that utilizes ViewBag to query database to present the list of options to the user to select for `ScrumMasterID` and `TeamId`, and  ViewBag to get the enum values and present to user as list to select from for `FiscalQuarter` and `PerformanceRating`.

**GET Evaluation DELETE** 
`http://website.com/TeamMetric/Delete/{id}/` Allows the user to delete an evaluation where `evalId` matches `id`.

---
## ScrumMaster

int ScrumMasterId [PK] | string FirstName | string LastName | ICollection TeamMetric | OwnerId (Guid Property)
--- | --- | --- | --- | --- |
0001 | Amy | Martinez | List of Evaluations associated with Scrum Master 0001 | c505e753-6e5d-4eb7-bed6-df86f07d46f1

`ScrumMasterId` is the Primary Key, and as such is not specified during ScrumMaster creation. Navigation property TeamMetrics is defined on the ScrumMaster entity type and navigates a one-to-many association between one Scrum Master to many evaluations; whereas a many-to-many relationship between Scrum Teams and Scrum Masters is navigated by the joining table, TeamMetrics .

### ScrumMaster URLs and Logic
---
**GET All GET** 
`http://website.com/ScrumMasters/`  This returns the list of all Scrum Masters

**GET By ScrumMasterId GET**
`http://website.com/ScrumMaster/Details/{id}/` This returns the one Scrum master whose `ScrumMasterId` matches `id` when selecting the Details action link Scrum Master Index view.

**GET New ScrumMaster CREATE**
`http://website.com/ScrumMaster/Create/` This returns the view to the user to input the data that will be interpreted and packaged up by the controller as a model, and then sent to the service layer that will save the new scrum master to the database. The fields required are: `FirstName` and `LastName`.

**GET ScrumMaster EDIT**
`http://website.com/ScrumMaster/Edit/{id}/` This returns the view to the user to input the data that will be interpreted and packaged up by the controller as a model, and then sent to the service layer that will save the updated scrum master to the database where `ScrumMasterId` matches `id` . The fields required are: `FirstName` and `LastName`. 

**GET ScrumMaster DELETE**
`http://website.com/ScrumMaster/Delete/{id}/` Allows the user to delete an evaluation where `ScrumMasterId` matches `id`.
 
## ScrumTeam

int TeamId [PK] | string TeamName | DateTime DateCreated | ICollection TeamMetric | OwnerId (Guid Property)
---  | --- | --- | --- | --- |
0001 | SAA | 05/01/2016 | List of Evaluations associated with Scrum Team 0001 | c505e753-6e5d-4eb7-bed6-df86f07d46f1

`TeamId` is the Primary Key, and as such is not specified during ScrumTeam creation. Navigation property TeamMetrics is defined on the ScrumTeam entity type and navigates a one-to-many association between one Scrum Team to many evaluations; whereas a many-to-many relationship between Scrum Teams and Scrum Masters is navigated by the joining table, TeamMetrics .
 
###ScrumTeam  URLs and Logic

**GET All GET**
`http://website.com/ScrumTeams/`  This returns the list of all Scrum Teams. 

**GET By ScrumTeamId GET**
`http://website.com/ScrumTeam/Details/{id}/` This returns the one scrum team whose `TeamId` matches `id` when selecting the Details action link Scrum Team Index view.

**GET New ScrumTeam CREATE** 
`http://website.com/ScrumTeam/Create/` This returns the view to the user to input the data that will be interpreted and packaged up by the controller as a model, and then sent to the service layer that will save the new scrum team to the database. The fields required are: `TeamName` and `DateCreated`, where `DateCreated` represents the date the scrum team was formed within the organization, and not the date it was created in the application, to be entered in MM/DD/YYYY format by the user.

** GET ScrumTeam EDIT**
`http://website.com/ScrumTeam/Edit/{id}/` This returns the view to the user to input the data that will be interpreted and packaged up by the controller as a model, and then sent to the service layer that will save the updated scrum team to the database where `TeamId` matches `id` . The fields required are: `TeamName` and `DateCreate` ,where `DateCreated` represents the date the scrum team was formed within the organization, and not the date it was created in the application, to be entered in MM/DD/YYYY format by the user.

**GET ScrumTeam Delete**
`http://website.com/ScrumTeam/Delete/{id}/` Allows the user to delete an evaluation where `TeamId` matches `id`

## Credits

MVC Architecture and Methods: 
https://elevenfifty.instructure.com/courses/607/pages/eleven-note-0-dot-00-introduction?module_item_id=47245

ViewBags: 
https://zoom.us/rec/share/ztZsvd0xUHhD42QQA1T2hxAIPFqRoqw5pmRSlVTQofSG5Gq6XctcK_L8d5DqnWlN.vx5c91McxKnGqTjW?startTime=1619130802000

Foreign Key Relationships:
https://docs.microsoft.com/en-us/ef/ef6/fundamentals/relationships

Action Links:
https://stackoverflow.com/questions/7709001/html-actionlink-vs-url-action-in-asp-net-razor

DateTime Formatting:
https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings

Debugging and Concating Properties in View:
https://learninggym-3a62e.web.app/
 
