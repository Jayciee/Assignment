# Project Progress

## Table of Contents

[Introduction](#Introduction)

[Sprint 0](#sprint-0)

[Sprint 1](#sprint-1)

[Sprint 2](#sprint-2)

### Introduction

This project is a Monster Hunter Journal based on the videogame series "Monster Hunter". The application is a journal that provides users with the ability to document "hunts" that they have attempted on monsters in the game. The purpose of these hunting records is to allow for users to review tactics that they have previously employed and compare the methods to determine of which are the most effective. Alternatively the application can also be used simply to document their experience and attempts with monster hunts.  

### Sprint 0

Sprint 0 consisted of preparing documentation for the project and general planning for the project. This mostly included preparing the Kanban board using GitHub and rough sketched ideas of what my project was going to be about. Below are visualisations of my ideas.

**Initial Mind Map**

![ProjectBoardSprint0](https://github.com/Jayciee/Assignment/blob/main/Images/Mind%20map.png)

Mind map condensed into **Rough Ideas**, at this point I knew I wanted to do a Monster hunter journal.

![ProjectBoardSprint0](https://github.com/Jayciee/Assignment/blob/main/Images/Rough%20Ideas.png)

Kanban board at the end of Sprint 0

![ProjectBoardSprint0](https://github.com/Jayciee/Assignment/blob/main/Images/ProjectBoardSprint0.png)

To conclude sprint 0 I needed to decide what to do in my official sprint 1. 

### Sprint 1

The project goals for this sprint is to carry out the highest priority user stories for the project. In this case it is:

- The creation of the skeleton of my application
- Designing and initialising of the database. 

I have chosen to carry out these two tasks because a lot of user stories that I have defined are dependent on user stories that involve these two things.
I have made a slight change to the board: introducing an epics column for visual purposes, re-formatting the gherkin syntax to be more clear and adding the dependencies for the definition of ready to each user story again for visual clarity.

**SprintBoard(Start)**

![ProjectBoardSprint0](https://github.com/Jayciee/Assignment/blob/main/Images/SprintBoard/ProjectBoardSprint1Start.png)

**SprintBoard(End)**

![ProjectBoardSprint0](https://github.com/Jayciee/Assignment/blob/main/Images/SprintBoard/ProjectBoardSprint1End.png)

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

![ProjectBoardSprint0](https://github.com/Jayciee/Assignment/blob/main/Images/SprintBoard/ProjectSprintBoard2Start.png)

