# Project Progress

## Table of Contents

[Introduction](#Introduction)

[Sprint 0](#sprint-0)

[Sprint 1](#sprint-1)

[Sprint 2](#sprint-2)

[Sprint 3](#sprint-3)

[Sprint 4](#sprint-4)

[Sprint 5](#sprint-5)

[Sprint 6](#sprint-6)

[Sprint 7](#sprint-7)

### Introduction

This project is a Monster Hunter Journal based on the videogame series "Monster Hunter". The application is a journal that provides users with the ability to document "hunts" that they have attempted on monsters in the game. The purpose of these hunting records is to allow for users to review tactics that they have previously employed and compare the methods to determine of which are the most effective. Alternatively the application can also be used simply to document their experience and attempts with monster hunts.  

### Sprint 0

Sprint 0 consisted of preparing documentation for the project and general planning for the project. This mostly included preparing the Kanban board using GitHub and rough sketched ideas of what my project was going to be about. Below are visualisations of my ideas.

**Initial Mind Map**

![MindMap](https://github.com/Jayciee/Assignment/blob/main/Images/Mind%20map.png)

Mind map condensed into **Rough Ideas**, at this point I knew I wanted to do a Monster hunter journal.

![RoughIdeas](https://github.com/Jayciee/Assignment/blob/main/Images/Rough%20Ideas.png)

Kanban board at the end of Sprint 0

![ProjectBoardSprint0](https://github.com/Jayciee/Assignment/blob/main/Images/SprintBoard/ProjectBoardSprint0.png)

To conclude sprint 0 I needed to decide what to do in my official sprint 1. 

### Sprint 1

The project goals for this sprint is to carry out the highest priority user stories for the project. In this case it is:

- The creation of the skeleton of my application
- Designing and initialising of the database. 

I have chosen to carry out these two tasks because a lot of user stories that I have defined are dependent on user stories that involve these two things.
I have made a slight change to the board: introducing an epics column for visual purposes, re-formatting the gherkin syntax to be more clear and adding the dependencies for the definition of ready to each user story again for visual clarity.

**SprintBoard(Start)**

![ProjectBoardSprint1](https://github.com/Jayciee/Assignment/blob/main/Images/SprintBoard/ProjectBoardSprint1Start.png)

**SprintBoard(End)**

![ProjectBoardSprint1](https://github.com/Jayciee/Assignment/blob/main/Images/SprintBoard/ProjectSprintBoard1End.png)

**RetroSpective**

The sum up briefly, sprint 1 was a success. This can be seen by the achievement of all sprint goals laid out at the start of the sprint. Below are some deeper questions that will provide more insight as to how this was achieved and what could be done better.

*What did we do well, that if we don't discuss might forget?*

- There was plenty of leeway time-wise given for sprint goals to be achieved, this was in part due to it being the very first sprint and being unsure of how much was achievable. However it should be duly noted that the extra leeway given was vital for fixing any unforeseen problems and errors that did occur in the time frame given this sprint.
- The normalised data and ERD (despite flaws) were vital to the creation of the database. Planning effectively can significantly reduce development time.

*What did we learn?*

- More time could have been taken in the analytical stage, specifically when sourcing the data that needed to be normalised. There were underlying errors in the data that led to table redundancy. Specifically that the weapons table should not have had an elements column. This meant that the weapons table and the monsters table did not share data therefore it was unnecessary to create an elements table. This was caused by a slight misunderstanding of how weapons dealt elemental damage (It is done through ailments not elements). 
- It is difficult to foresee, without great experience, some of the flaws of the ERD until creating the database and linking the tables. The ERD was re-factored a couple times post to the creation of the database to matchup with changes unforeseen during that planning phase. 

*What should we do differently next time?*

- When completing an ERD have peers review it without explanation of how it should function. If it is navigable without assistance and is easy to read then this should reduce errors when creating the database. In the case where there are no peers then this process can be done yourself or the ERD should only be used as a guide not as a strict plan.
- Taking a little more time to analyse and understand the product before trying to create an application for it could have significantly reduced planning time and development time. 

*What still puzzles us? What potential problems do we foresee?*

- Only basic testing was achieved to see if the database functions as it should. It is possible that this may cause problems down the line if there are any other unforeseen errors missed during the development phase.
- Creating LINQ queries took a little longer than expected but this could hinder development time but it's also possible that self-improvement with exposure with the course of the project to make up for that.
- I am still unsure as to implement certain features of the GUI in WPF, such as swapping between different views/windows. This can be solved with further research.

### Sprint 2

The goals of this sprint are to:

- Create wireframes for the GUI 
- Add starting data that will also serve as test data for future functionality
- Implement the most fundamental functionality of the program

The goals of this sprint were chosen because they are required to fulfil the most basic functionality of the application. The "Create New Hunt Record in App" user story will also serve as a good timestamp to show to me how long it will roughly take to add additional functionality into the application in future sprints. This will better help me plan for those sprints and pace myself accordingly.

**SprintBoard(Start)**

![ProjectBoardSprint2S](https://github.com/Jayciee/Assignment/blob/main/Images/SprintBoard/ProjectSprintBoard2Start.png)

**SprintBoard(End)**

![ProjectBoardSprint2E](https://github.com/Jayciee/Assignment/blob/main/Images/SprintBoard/ProjectSprintBoard2End.png)

**Demo-able Progress**

![Sprint2HuntRecord](https://github.com/Jayciee/Assignment/blob/main/Images/GUIScreenshots/Sprint2NewHuntRecord.png)

**RetroSpective**

Sprint 2 was not as successful as sprint 1, despite that the majority of sprint goals were achieved. The only user story that was not attempted was user story "Create New Hunt Record in App". The reason I opted not to start this user story was because I originally placed it in the sprint with the idea in mind that it was required to accomplish the CREATE functionality which was not the case. In the end I pushed it back to Sprint 3 knowing that most of the WPF functionality would be worked on in that Sprint. This is similar to the user Story 5.4 Initialising Starting Data in database. I felt it was a better use of time to insert test data as I needed them as opposed to doing it all at once in order to get a demo-able application as soon as possible.

*What did we do well, that if we don't discuss might forget?*

- Like in Sprint 1, Time management, giving plenty of time to iron out bugs and work out design plans in the wireframes and laying the foundations for future code which will in the long run speed up development time.
- Doing the sprints incrementally such that we have a demo-able application as early as possible.

*What did we learn?*

-  To think more clearly about the user stories to prioritise during sprint planning 

*What should we do differently next time?*

-  Re-prioritise sprints, it may be easier to categorise them together and do them in chunks now that the skeleton has been made.

*What still puzzles us? What potential problems do we foresee?*

- The wireframes in Sprint 2 (This sprint) will show any flaws they had in Sprint 3 when it comes to creating the WPF GUI's.  
- In Sprint 2 I had designed multiple managers to manage different tables. Initially this was done to improve readability and maintainability of code but I am worried the way this was done (currently without inheritance or interfaces) will lead to lots of redundant code. This may need to be fixed sooner (sprint 3) rather than later. 
- In the coming Sprint my inherent lack of exposure to WPF may severely hinder progress depending on the rate at which I learn the technology.
- I may need to re-implement the Create New Hunter Record functionality such that it fits in the new GUI.

### Sprint 3

The goals in this Sprint are to complete as much of the WPF GUI's as possible:

- Implement the WPF's GUI
- Make sure existing functionality fits correctly into the GUI

The completion of the User stories in this sprint should mark the completion of the laying of the foundations for implementing the rest of the User stories in an incremental fashion. See how well the Create New Hunter Record function fits into the GUI created today will give a good idea of how well the current format I've laid out will work with the rest of the functions.

**SprintBoard(Start)**

![ProjectBoardSprint3](https://github.com/Jayciee/Assignment/blob/main/Images/SprintBoard/ProjectSprintBoard3Start.png)

**SprintBoard(End)**

![ProjectBoardSprint3](https://github.com/Jayciee/Assignment/blob/main/Images/SprintBoard/ProjectSprintBoard3End.png)

**Demo-able Progress**

By the end of this sprint I had managed to create 5 GUI views from my previously designed wireframes and connect them together

![Sprint3HomePage](https://github.com/Jayciee/Assignment/blob/main/Images/GUIScreenshots/Sprint3LandingPage.png)

![Sprint3MonsterList](https://github.com/Jayciee/Assignment/blob/main/Images/GUIScreenshots/Sprint3MonsterList.png)

![Sprint3HuntRecord](https://github.com/Jayciee/Assignment/blob/main/Images/GUIScreenshots/Sprint3NewHuntRecord.png)

![Sprint3MonsterEntry](https://github.com/Jayciee/Assignment/blob/main/Images/GUIScreenshots/Sprint3NewMonsterEntry.png)

![Sprint3Weapon](https://github.com/Jayciee/Assignment/blob/main/Images/GUIScreenshots/Sprint3NewWeapon.png)

**RetroSpective**

A lot of time was spent learning new technology. Most of the user stories have all reached at minimum the review/testing phase. There are some small kinks to iron out but for the most part the project is on track with the number of sprints remaining. The only user story not to make it to at least review/testing is User Story 4.3 which is only missing a small amount of work to finish off. This will be pushed to start of the next sprint to do. With this in mind I may reduce the planned workload in sprint 4 to account for this.

*What did we do well, that if we don't discuss might forget?*

- Taking the time out of the sprint to understand how certain things work in new technologies was useful in making progress  later in the sprint.

*What did we learn?*

- A rudimentary understanding in how MVVM works, particularly how binding and data context is passed between views
- A stronger understanding of general WPF particularly grids and stack panels.
- The benefits of the Material Designs NuGetPackage

*What should we do differently next time?*

- It might be worth trying a paper run of how the user journey to see how the different pages/views should connect with each other. A lot of on-the-fly planning was done to interconnect the pages as from the wireframe alone it was not clear how certain pages should connect and which features should be placed where.
- It may have been more effective for me to further break up certain User Stories to better visualise what left needs doing in a sprint. User Storys 4.2 and 4.3 in particular proved to take longer than anticipated to accomplish.

*What still puzzles us? What potential problems do we foresee?*

- There is currently a minor blocker in the form of not knowing how to create new views in the main window from within a view. This means that I can only dynamically swap views from the main window-bar. I have a couple ideas of how to deal with this issue so this blocker should not last long. It will just take some time to iron out.
- With the way messaging is set out within the views it may become time consuming when coding in the functionality.

### Sprint 4

The goals of this sprint are to: 

- Put in the remaining work for User Story 4.3. 
- Complete Epic 2 which involves User Stories 2.1 and 2.2. 

The completion of these Goals will finish laying the foundations for the rest of the functionality to stand on as well as show the foundations will hold when layered with said functionality.

**SprintBoard(Start)**

![ProjectBoardSprint4](https://github.com/Jayciee/Assignment/blob/main/Images/SprintBoard/ProjectSprintBoard4Start.png)

**SprintBoard(End)**

![ProjectBoardSprint4](https://github.com/Jayciee/Assignment/blob/main/Images/SprintBoard/ProjectSprintBoard4End.png)

**RetroSpective**

This sprint was difficult. I did not complete the user stories I had set out to do due to a major blocker with my view connections. I previously had not employed models to connect views and had just used views directly. This lead to issues with passing data between views and I spent the majority of the sprint re-factoring my window connections. This meant that while I eventually completed User Story 4.3 I failed to complete Epic 2 that I had originally intended to during the sprint.

*What did we do well, that if we don't discuss might forget?*

- Diligently worked through bugs and the major blocker preventing me from connecting the Windows together for User Story 4.3

*What did we learn?*

- That when possible you should always use the industry standard method or an existing methodology to create software. Using rushed methods will lead to poor foundations which will need to be remodelled later anyway.

*What should we do differently next time?*

- Try to follow existing methodology or use proper methods when developing software instead of haphazard methods to band-aid issues.

*What still puzzles us? What potential problems do we foresee?*

- As a side task that I was more curious about was the addition of custom fonts into the application. I had attempted to add it during my lunch-break as a break from the window connection blocker I was having an issue with and I was struggling to get it working. This isn't a particularly significant problem as it is more to do with GUI theme and decoration in User Story 7.1 which is a stretch goal.

### Sprint 5

The goals of this sprint are to:

- Implement the functionality and finish epics 1,2 and 3.

With the completion of the window connection and the base GUI complete it is now possible to add and finish implementing all major epics vital to delivering an MVP.

**SprintBoard(Start)**

![ProjectBoardSprint5](https://github.com/Jayciee/Assignment/blob/main/Images/SprintBoard/ProjectSprintBoard5Start.png)

**SprintBoard(End)**

![ProjectBoardSprint5](https://github.com/Jayciee/Assignment/blob/main/Images/SprintBoard/ProjectSprintBoard5End.png)

**RetroSpective**

This sprint was done counterintuitively. The majority of my user stories were left in-complete due to a complete tangent in code developed. I had attempted TDD and spent most of the day developing business logic to implement the fulfil the requirements in the user stories I set out to accomplish for the day. Unfortunately I had spent the entire sprint creating tests then creating the methods for those tests. While TDD is effective at creating a suite of tests and concrete methods I can rely on it is incredibly time-consuming.

*What did we do well, that if we don't discuss might forget?*

- Unit tests are mostly complete for all major functionality

*What did we learn?*

- It is unnecessary to unit test every single method and attempting to predict which methods will be needed before even attempting to implement them into the GUI. 
- Excessive creation of unit tests will lead to great lack of functionality developed and implemented in other areas.

*What should we do differently next time?*

- Using TDD is appropriate for parts of the functionality. Instead of attempting use this methodology for potential piece for the application it is better to focus on the absolute necessary ones required to fulfilling the user requirements set out in the sprint.

*What still puzzles us? What potential problems do we foresee?*

- Due to a significant amount of time being wasted in this sprint, I may struggle later to implement all epics required to deliver an MVP.

### Sprint 6

The goals of this sprint are to:

- Carry on with implementing the epics 1,2,3 laid out previously in Sprint 7.
- With the stretch goal of implementing themes and backgrounds for User Story 7.1 in time for the presentation before the hand-in.

**SprintBoard(Start)**

![ProjectBoardSprint6](https://github.com/Jayciee/Assignment/blob/main/Images/SprintBoard/ProjectSprintBoard6Start.png)

**SprintBoard(End)**

![ProjectBoardSprint6](https://github.com/Jayciee/Assignment/blob/main/Images/SprintBoard/ProjectSprintBoard6End.png)

**Gui Screen Shots**
By the end of this sprint my GUI had been re-vamped and been implemented with the most vital functionality. This can be seen below:
![MainWindow](https://github.com/Jayciee/Assignment/blob/main/Images/GUIScreenshots/Sprint6HomePage.png)
![MainWindow](https://github.com/Jayciee/Assignment/blob/main/Images/GUIScreenshots/Sprint6Details.png)
![MainWindow](https://github.com/Jayciee/Assignment/blob/main/Images/GUIScreenshots/Sprint6MonsterEditHuntRecord.png)
![MainWindow](https://github.com/Jayciee/Assignment/blob/main/Images/GUIScreenshots/Sprint6MonsterHabitsList.png)
![MainWindow](https://github.com/Jayciee/Assignment/blob/main/Images/GUIScreenshots/Sprint6MonsterHuntRecords.png)
![MainWindow](https://github.com/Jayciee/Assignment/blob/main/Images/GUIScreenshots/Sprint6MonsterHabitsList.png)
![MainWindow](https://github.com/Jayciee/Assignment/blob/main/Images/GUIScreenshots/Sprint6MonsterHuntRecordsList.png)
![MainWindow](https://github.com/Jayciee/Assignment/blob/main/Images/GUIScreenshots/Sprint6MonsterList.png)
![MainWindow](https://github.com/Jayciee/Assignment/blob/main/Images/GUIScreenshots/Sprint6NewRecord.png)
![MainWindow](https://github.com/Jayciee/Assignment/blob/main/Images/GUIScreenshots/Sprint6NewWeapon.png)


**RetroSpective**

Overall this sprint was a big success and put me back on target for delivering an MVP. All user stories set out in this sprint were completed including all the sprints that were previously laid out from Sprint 5.

*What did we do well, that if we don't discuss might forget?*

- Focusing purely on fulfilling the User requirements for the user stories lead to significantly more visible progress throughout the sprint.

*What did we learn?*

- Carrying out the absolute minimum functionality required is a good measure of progress.

*What should we do differently next time?*

- Potentially better spread out the user stories or divide them more evenly throughout the other sprints. In this sprint alone I completed 9 user stories.
- Better plan out the user stories to include all the necessary functionality planned for the App that fulfils the user requirements.

*What still puzzles us? What potential problems do we foresee?*

- There are still parts of the application that are non-functional that were not included in the User Stories are the epics but the application would seem empty without.

### Sprint 7

The goals of this sprint are to:

- Finish the remaining functions that were not part of the user stories and other requirements listed in the project brief previously missed out in the planning phase. This includes:
  - Readme
  - Class Diagram
  - Connecting missing and/or currently non-functional views
  - Implementing the remaining CRUD functionalities for existing views not listed in the user stories

While I currently have an MVP having completed all my most vital user stories there are several pieces of documentation or non work parts of my application that have not been completed. I believe that while they are not listed it is important that they are at a minimum functional, within the program.

**SprintBoard(Start)**

![ProjectBoardSprint7](https://github.com/Jayciee/Assignment/blob/main/Images/SprintBoard/ProjectSprintBoard7Start.png)

**SprintBoard(End)**

![ProjectBoardSprint7](https://github.com/Jayciee/Assignment/blob/main/Images/SprintBoard/ProjectSprintBoard7End.png)

**RetroSpective**

*What did we do well, that if we don't discuss might forget?*

*What did we learn?*

*What should we do differently next time?*

*What still puzzles us? What potential problems do we foresee?*
