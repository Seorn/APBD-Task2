# APBD-Task2

University equipment rental service project for APBD 2.

## What the program does

Program can:
- add users
- add equipment
- show all equipment
- show only available equipment
- rent equipment
- return equipment
- mark equipment as unavailable
- show active rentals for user
- show overdue rentals
- show simple summary

## Classes used in the project

### Equipment
Equipment is abstract class.  
It is base for:
- Laptop
- Projector
- Camera

Each one has own fields.

### User
User is also abstract class.  
It is base for:
- Student
- Employee

They have different rental limits.

### Rental
Rental keeps info about:
- user
- equipment
- rental date
- due date
- return date
- penalty

## Business rules

- student can rent max 2 items
- employee can rent max 5 items
- unavailable equipment cannot be rented
- rented equipment cannot be set unavailable
- late return can give penalty

## Why I used this design

I tried to split code into parts.

- Models folder for classes
- RentalService for main logic
- ReportService for summary
- Program just runs example

So code is more clear (at least I think).

## Cohesion and coupling

I tried to keep classes simple.

- RentalService does renting
- ReportService does reporting
- models just store data

I tried to not put everything in Program.cs.

## Interface

IRentalService is used to define methods.  
It makes code more organized.

## Inheritance

I used inheritance because Laptop, Projector, Camera are all equipment.  
Also Student and Employee are users.

(I used readme.so to design readme file)